using AutoMapper;
using FicticiaSA.Entity;
using FicticiaSA.Models;
using FicticiaSA.Repository.IRepository;
using FicticiaSA.Services.IServices;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using FicticiaSA.Helpers;
using FicticiaSA.Helpers.Config;
using FicticiaSA.Models.Dtos.UserDtos;

namespace FicticiaSA.Services
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IConfig config;
        private readonly IDbOperation dbOperation;
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public UsuarioServicio(IConfig config, IDbOperation dbOperation, IUsuarioRepositorio usuarioRepositorio)
        {
            this.config = config;
            this.dbOperation = dbOperation;
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<ResponseObjectJsonDto> Login(string userName, string password)
        {
            Usuario dbUser = await usuarioRepositorio.GetUsuario(userName);

            if (dbUser == null)
            {
                return new ResponseObjectJsonDto { Code = 404, Message = "Usuario y/o contraseña incorrectos" };
            }
            HelperPassword passwordHash = new HelperPassword();
            bool response = passwordHash.ValidatePassword(password, dbUser.Password, dbUser.Salt);

            if (!response)
            {
                return new ResponseObjectJsonDto { Code = 404, Message = "Usuario y/o contraseña incorrectos" };
            }
            Jwt jwt = new(config);

            UserTokenDto token = jwt.Construction(dbUser.NombreUsuario, dbUser.IdUsuario);

            return new ResponseObjectJsonDto { Code = 200, Response = new { token } };

        }

        public async Task<ResponseObjectJsonDto> CreateUser(string nombreUsuario, string password)
        {
            HelperPassword passwordHashCreate = new();
            passwordHashCreate.CreatePasswordHash(password, out byte[] passwordHash, out byte[] salt);
            Usuario user = new()
            {
                NombreUsuario = nombreUsuario,
                Password = passwordHash,
                Salt = salt
            };
            await usuarioRepositorio.CreateUsuario(user);

            if (!await dbOperation.Save())
            {

                return new ResponseObjectJsonDto { Code = 500, Message = "Error al intentar crear el usuario" };
            }

            return new ResponseObjectJsonDto { Code = 200, Message = "Usuario creado con exito" };
        }
    }
}
