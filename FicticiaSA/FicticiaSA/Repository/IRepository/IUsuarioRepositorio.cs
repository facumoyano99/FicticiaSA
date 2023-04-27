using FicticiaSA.Models;

namespace FicticiaSA.Repository.IRepository
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> GetUsuario(string userName);
        Task CreateUsuario(Usuario user);

    }
}
