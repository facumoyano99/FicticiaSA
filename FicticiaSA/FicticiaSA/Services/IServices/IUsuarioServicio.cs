using FicticiaSA.Helpers;

namespace FicticiaSA.Services.IServices
{
    public interface IUsuarioServicio
    {
        Task<ResponseObjectJsonDto> Login(string userName, string password);
        Task<ResponseObjectJsonDto> CreateUser(string nombreUsuario, string password);

    }
}
