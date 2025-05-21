using ControlPersonalWebAPI.Service;
using ControlPersonalWebAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPersonalWebAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestoController : ControllerBase
    {
        private readonly IPuestoService _puestoService;

        public PuestoController(IPuestoService puestoService)
        {
            _puestoService = puestoService;
        }

        [HttpGet("GetPuestos")]
        public async Task<ActionResult<IEnumerable<Puesto>>> GetPuestos()
        {
            try
            {
                var puestos = await _puestoService.ObtenerTodos();
                return Ok(puestos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al obtener los puestos", error = ex.Message });
            }
        }

        [HttpGet("GetPuesto/{id}")]
        public async Task<ActionResult<Puesto>> GetPuesto(int id)
        {
            try
            {
                var puesto = await _puestoService.ObtenerPorId(id);
                if (puesto == null)
                {
                    return NotFound();
                }
                return Ok(puesto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al obtener el puesto", error = ex.Message });
            }
        }

        [HttpPost("CreatePuesto")]
        public async Task<ActionResult> CreatePuesto([FromBody] Puesto puesto)
        {
            try
            {
                await _puestoService.Insertar(puesto);
                return CreatedAtAction(nameof(GetPuesto), new { id = puesto.IdPuesto }, puesto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al crear el puesto", error = ex.Message });
            }
        }

        [HttpPut("UpdatePuesto/{id}")]
        public async Task<ActionResult> UpdatePuesto(int id, [FromBody] Puesto puesto)
        {
            try
            {
                if (id != puesto.IdPuesto)
                {
                    return BadRequest();
                }

                await _puestoService.Actualizar(puesto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al actualizar el puesto", error = ex.Message });
            }
        }

        [HttpDelete("DeletePuesto/{id}")]
        public async Task<ActionResult> DeletePuesto(int id)
        {
            try
            {
                await _puestoService.Eliminar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al eliminar el puesto", error = ex.Message });
            }
        }
    }
}
