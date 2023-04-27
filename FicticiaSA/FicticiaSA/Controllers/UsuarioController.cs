using FicticiaSA.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FicticiaSA.Helpers;
using FicticiaSA.Models.Dtos.UserDtos;

namespace FicticiaSA.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicio iUsuarioServ;

        public UsuarioController(IUsuarioServicio iUsuarioServ)
        {
            this.iUsuarioServ = iUsuarioServ;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ResponseObjectJsonDto>> Login(UserLoginDto userLoginDto)
        {
            string userName = userLoginDto.User;
            string password = userLoginDto.Password;

            ResponseObjectJsonDto response = await iUsuarioServ.Login(userName, password);

            if (response.Code == 200)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ResponseObjectJsonDto>> CreateUser(string nombreUsuario, string password)
        {
            ResponseObjectJsonDto response = await iUsuarioServ.CreateUser(nombreUsuario, password);


            if (response.Code != (int)CodeHTTP.OK)
            {
                return StatusCode(response.Code, response);
            }


            return Ok(response);
        }
    }
}
