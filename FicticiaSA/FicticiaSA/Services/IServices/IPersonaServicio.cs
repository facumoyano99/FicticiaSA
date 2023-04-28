using FicticiaSA.Models.Dtos;
using FicticiaSA.Helpers;

namespace FicticiaSA.Services.IServices
{
    public interface IPersonaServicio
    {
        Task<ResponseObjectJsonDto> CreatePersona(PersonaPostDto personaPostDto);
        Task<ResponseObjectJsonDto> UpdatePersona(PersonaPatchDto personaPatchDto);
        Task<ResponseObjectJsonDto> DeletePersona(int idPersona);
        Task<ResponseObjectJsonDto> BajaLogicaPersona(int idPersona);
        Task<ResponseObjectJsonDto> AltaLogicaPersona(int idPersona);
        Task<ResponseObjectJsonDto> GetPersonas(bool EsActivo);
        Task<ResponseObjectJsonDto> GetPersona(int idPersona);



    }
}
