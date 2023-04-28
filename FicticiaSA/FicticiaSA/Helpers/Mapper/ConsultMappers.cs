using AutoMapper;
using FicticiaSA.Models;
using FicticiaSA.Models.Dtos;

namespace FicticiaSA.Helpers.Mapper
{
    public class ConsultMappers:Profile
    {
        public ConsultMappers()
        {
            CreateMap<PersonaPostDto, Persona>();
            CreateMap<PersonaPatchDto, Persona>();
            CreateMap<Persona, PersonaGetDto>();
        }
    }
}
