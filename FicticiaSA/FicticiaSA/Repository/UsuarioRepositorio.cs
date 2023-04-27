using FicticiaSA.Entity;
using FicticiaSA.Models;
using FicticiaSA.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FicticiaSA.Repository
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext dbContext;

        public UsuarioRepositorio(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Usuario> GetUsuario(string userName)
        {
            return await dbContext.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario.ToUpper() == userName.ToUpper());
        }

        public async Task CreateUsuario(Usuario user)
        {
            await dbContext.Usuarios.AddAsync(user);
        }
    }
}
