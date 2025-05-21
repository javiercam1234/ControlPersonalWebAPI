using ControlPersonalWebAPI.Entidades;
using ControlPersonalWebAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPersonalWebAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpGet("GetPersonas")]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            try
            {
                var resultado = await _personaService.ObtenerTodos();
                if (resultado.Exito)
                    return Ok(resultado.Datos);
                else
                    return BadRequest(new { message = resultado.Mensaje });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al obtener las personas", error = ex.Message });
            }
        }

        [HttpGet("GetPersona/{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            try
            {
                var resultado = await _personaService.ObtenerPorId(id);
                if (resultado.Exito)
                    return Ok(resultado.Datos);
                else
                    return NotFound(new { message = resultado.Mensaje });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al obtener la persona", error = ex.Message });
            }
        }

        [HttpPost("CreatePersona")]
        public async Task<ActionResult> CreatePersona([FromBody] Persona persona)
        {
            try
            {
                var resultado = await _personaService.Insertar(persona);
                if (resultado.Exito)
                    return CreatedAtAction(nameof(GetPersona), new { id = persona.IdPersona }, persona);
                else
                    return BadRequest(new { message = resultado.Mensaje });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al crear la persona", error = ex.Message });
            }
        }

        [HttpPut("UpdatePersona/{id}")]
        public async Task<ActionResult> UpdatePersona(int id, [FromBody] Persona persona)
        {
            try
            {
                if (id != persona.IdPersona)
                    return BadRequest(new { message = "El ID proporcionado no coincide con el ID de la persona" });

                var resultado = await _personaService.Actualizar(persona);
                if (resultado.Exito)
                    return NoContent();
                else
                    return BadRequest(new { message = resultado.Mensaje });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al actualizar la persona", error = ex.Message });
            }
        }

        [HttpDelete("DeletePersona/{id}")]
        public async Task<ActionResult> DeletePersona(int id)
        {
            try
            {
                var resultado = await _personaService.Eliminar(id);
                if (resultado.Exito)
                    return NoContent();
                else
                    return BadRequest(new { message = resultado.Mensaje });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al eliminar la persona", error = ex.Message });
            }
        }
    }
}
