﻿using FicticiaSA.Helpers;
using FicticiaSA.Models.Dtos;
using FicticiaSA.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FicticiaSA.Controllers
{
    [Route("api/persona")]
    [ApiController]
    [Authorize]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaServicio personaServicio;

        public PersonaController(IPersonaServicio personaServicio)
        {
            this.personaServicio = personaServicio;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseObjectJsonDto>> CreatePersona(PersonaPostDto personaDto)
        {
            ResponseObjectJsonDto response = await personaServicio.CreatePersona(personaDto);

            if (response.Code != (int)CodeHTTP.OK)
            {
                return StatusCode(response.Code, response);
            }

            return Ok(response);
        }
        [HttpPatch]
        public async Task<ActionResult<ResponseObjectJsonDto>> UpdatePersona(PersonaPatchDto personaDto)
        {
            ResponseObjectJsonDto response = await personaServicio.UpdatePersona(personaDto);

            if (response.Code != (int)CodeHTTP.OK)
            {
                return StatusCode(response.Code, response);
            }

            return Ok(response);
        }
        [HttpPatch("BajaLogica/{idPersona:int}")]
        public async Task<ActionResult<ResponseObjectJsonDto>> BajaLogicaPersona(int idPersona)
        {
            ResponseObjectJsonDto response = await personaServicio.BajaLogicaPersona(idPersona);

            if (response.Code != (int)CodeHTTP.OK)
            {
                return StatusCode(response.Code, response);
            }

            return Ok(response);
        }
        [HttpDelete]
        public async Task<ActionResult<ResponseObjectJsonDto>> DeletePersona(int idPersona)
        {
            ResponseObjectJsonDto response = await personaServicio.DeletePersona(idPersona);

            if (response.Code != (int)CodeHTTP.OK)
            {
                return StatusCode(response.Code, response);
            }

            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<ResponseObjectJsonDto>> GetPersonas()
        {
            ResponseObjectJsonDto response = await personaServicio.GetPersonas();

            if (response.Code != (int)CodeHTTP.OK)
            {
                return StatusCode(response.Code, response);
            }

            return Ok(response);
        }
    }
}
