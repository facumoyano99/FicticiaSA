using FicticiaSA.Models.Dtos;
using FicticiaSA.Repository.IRepository;
using FicticiaSA.Services.IServices;
using FicticiaSA.Helpers;
using AutoMapper;
using FicticiaSA.Models;
using FicticiaSA.Entity;

namespace FicticiaSA.Services
{
    public class PersonaServicio : IPersonaServicio
    {
        private readonly IDbOperation dbOperation;
        private readonly IMapper mapper;
        private readonly IPersonaRepositorio personaRepositorio;

        public PersonaServicio(IDbOperation dbOperation, IMapper mapper, IPersonaRepositorio personaRepositorio)
        {
            this.dbOperation = dbOperation;
            this.mapper = mapper;
            this.personaRepositorio = personaRepositorio;
        }

        public async Task<ResponseObjectJsonDto> CreatePersona(PersonaPostDto personaPostDto)
        {
            try
            {
                if (await personaRepositorio.PersonaIdentificacionExists(personaPostDto.Identificacion))
                {
                    return new ResponseObjectJsonDto { Code = (int)CodeHTTP.INTERNALSERVER, Message = "Ya existe un cliente registrado con ese documento" };
                }
                Persona persona = mapper.Map<Persona>(personaPostDto);
                persona.FechaAlta = DateTime.Now;
                persona.EsActivo = true;
                await personaRepositorio.CreatePersona(persona);
                if (!await dbOperation.Save())
                {
                    return new ResponseObjectJsonDto { Code = (int)CodeHTTP.INTERNALSERVER, Message = "Error al intentar registrar el cliente" };
                }
                return new ResponseObjectJsonDto() { Code = (int)CodeHTTP.OK, Message = "Cliente registrado con éxito" };
            }
            catch (Exception e)
            {
                return new ResponseObjectJsonDto() { Code = (int)CodeHTTP.INTERNALSERVER, Response = e };
            }

        }

        public async Task<ResponseObjectJsonDto> UpdatePersona(PersonaPatchDto personaPatchDto)
        {
            try
            {
                Persona personaBD = await personaRepositorio.GetPersona(personaPatchDto.IdPersona);
                if (personaBD == null)
                {
                    return new ResponseObjectJsonDto { Code = (int)CodeHTTP.INTERNALSERVER, Message = "No existe el cliente" };
                }
                if (await personaRepositorio.PersonaUpdateExists(personaPatchDto.IdPersona, personaPatchDto.Identificacion))
                {
                    return new ResponseObjectJsonDto { Code = (int)CodeHTTP.INTERNALSERVER, Message = "Ya existe un cliente registrado con ese documento" };
                }
                Persona persona = mapper.Map<Persona>(personaPatchDto);
                persona.EsActivo = personaBD.EsActivo;
                persona.FechaAlta = personaBD.FechaAlta;
                personaRepositorio.UpdatePersona(persona);
                if (!await dbOperation.Save())
                {
                    return new ResponseObjectJsonDto { Code = (int)CodeHTTP.INTERNALSERVER, Message = "Error al intentar actualizar el cliente" };
                }
                return new ResponseObjectJsonDto() { Code = (int)CodeHTTP.OK, Message = "Cliente actualizado con éxito" };
            }
            catch (Exception e)
            {
                return new ResponseObjectJsonDto() { Code = (int)CodeHTTP.INTERNALSERVER, Response = e };
            }

        }

        public async Task<ResponseObjectJsonDto> BajaLogicaPersona(int idPersona)
        {
            try
            {
                Persona personaBD = await personaRepositorio.GetPersona(idPersona);
                if (personaBD == null)
                {
                    return new ResponseObjectJsonDto { Code = (int)CodeHTTP.INTERNALSERVER, Message = "No existe el cliente" };
                }
                personaBD.EsActivo = false;
                personaBD.FechaBaja = DateTime.Now;
                personaRepositorio.UpdatePersona(personaBD);
                if (!await dbOperation.Save())
                {
                    return new ResponseObjectJsonDto { Code = (int)CodeHTTP.INTERNALSERVER, Message = "Error al intentar dar de baja el cliente" };
                }
                return new ResponseObjectJsonDto() { Code = (int)CodeHTTP.OK, Message = "Cliente dado de baja con éxito" };
            }
            catch (Exception e)
            {
                return new ResponseObjectJsonDto() { Code = (int)CodeHTTP.INTERNALSERVER, Response = e };
            }

        }

        public async Task<ResponseObjectJsonDto> AltaLogicaPersona(int idPersona)
        {
            try
            {
                Persona personaBD = await personaRepositorio.GetPersona(idPersona);
                if (personaBD == null)
                {
                    return new ResponseObjectJsonDto { Code = (int)CodeHTTP.INTERNALSERVER, Message = "No existe el cliente" };
                }
                personaBD.EsActivo = true;
                personaBD.FechaBaja = null;
                personaBD.FechaAlta = DateTime.Now;
                personaRepositorio.UpdatePersona(personaBD);
                if (!await dbOperation.Save())
                {
                    return new ResponseObjectJsonDto { Code = (int)CodeHTTP.INTERNALSERVER, Message = "Error al intentar dar de alta el cliente" };
                }
                return new ResponseObjectJsonDto() { Code = (int)CodeHTTP.OK, Message = "Cliente dado de alta con éxito" };
            }
            catch (Exception e)
            {
                return new ResponseObjectJsonDto() { Code = (int)CodeHTTP.INTERNALSERVER, Response = e };
            }

        }

        public async Task<ResponseObjectJsonDto> DeletePersona(int idPersona)
        {
            try
            {
                Persona personaBD = await personaRepositorio.GetPersona(idPersona);
                if (personaBD == null)
                {
                    return new ResponseObjectJsonDto { Code = (int)CodeHTTP.INTERNALSERVER, Message = "No existe el cliente" };
                }
                personaRepositorio.DeletePersona(personaBD);
                if (!await dbOperation.Save())
                {
                    return new ResponseObjectJsonDto { Code = (int)CodeHTTP.INTERNALSERVER, Message = "Error al intentar eliminar el cliente" };
                }
                return new ResponseObjectJsonDto() { Code = (int)CodeHTTP.OK, Message = "Cliente eliminado éxito" };
            }
            catch (Exception e)
            {
                return new ResponseObjectJsonDto() { Code = (int)CodeHTTP.INTERNALSERVER, Response = e };
            }

        }
        public async Task<ResponseObjectJsonDto> GetPersonas(bool EsActivo)
        {
            IList<Persona> personas = await personaRepositorio.GetPersonas(EsActivo);
            if (personas == null || personas.Count == 0)
            {
                if (EsActivo)
                {
                    return new ResponseObjectJsonDto { Code = (int)CodeHTTP.INTERNALSERVER, Message = "No existen clientes dados de alta" };
                }
                else
                {
                    return new ResponseObjectJsonDto { Code = (int)CodeHTTP.INTERNALSERVER, Message = "No existen clientes dados de baja" };
                }
            }
            IList<PersonaGetDto> personasDto = mapper.Map<IList<Persona>, IList<PersonaGetDto>>(personas);
            return new ResponseObjectJsonDto() { Code = (int)CodeHTTP.OK, Response = personasDto };

        }

        public async Task<ResponseObjectJsonDto> GetPersona(int idPersona)
        {
            Persona persona = await personaRepositorio.GetPersona(idPersona);
            if (persona == null)
            {
                return new ResponseObjectJsonDto { Code = (int)CodeHTTP.INTERNALSERVER, Message = "No existen clientes dados de baja" };

            }
            PersonaGetDto personasDto = mapper.Map<Persona, PersonaGetDto>(persona);
            return new ResponseObjectJsonDto() { Code = (int)CodeHTTP.OK, Response = personasDto };

        }
    }
}
