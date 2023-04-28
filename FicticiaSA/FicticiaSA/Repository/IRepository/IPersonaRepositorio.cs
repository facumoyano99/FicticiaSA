using FicticiaSA.Models;

namespace FicticiaSA.Repository.IRepository
{
    public interface IPersonaRepositorio
    {
        Task CreatePersona(Persona persona);
        Task<Persona> GetPersona(int idPersona);

        Task<bool> PersonaIdentificacionExists(string dni);
        void UpdatePersona(Persona persona);
        Task<bool> PersonaUpdateExists(int IdPersona, string documento);
        void DeletePersona(Persona persona);
        Task<IList<Persona>> GetPersonas(bool EsActivo);


    }
}
