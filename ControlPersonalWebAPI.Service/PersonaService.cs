using ControlPersonalWebAPI.Entidades;
using ControlPersonalWebAPI.Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPersonalWebAPI.Service
{
    public class PersonaService : IPersonaService
    {
        private readonly PersonaRepository _personaRepository;

        public PersonaService()
        {
            _personaRepository = new PersonaRepository();
        }

        public async Task<ResultadoOperacion<List<Persona>>> ObtenerTodos()
        {
            try
            {
                var personas = await _personaRepository.ObtenerTodos();
                return new ResultadoOperacion<List<Persona>>
                {
                    Exito = true,
                    Datos = personas
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion<List<Persona>>
                {
                    Exito = false,
                    Mensaje = "Error al obtener personas",
                    Error = ex.Message
                };
            }
        }

        public async Task<ResultadoOperacion<Persona>> ObtenerPorId(int id)
        {
            try
            {
                var persona = await _personaRepository.ObtenerPorId(id);
                if (persona != null)
                {
                    return new ResultadoOperacion<Persona>
                    {
                        Exito = true,
                        Datos = persona
                    };
                }
                else
                {
                    return new ResultadoOperacion<Persona>
                    {
                        Exito = false,
                        Mensaje = "Persona no encontrada"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion<Persona>
                {
                    Exito = false,
                    Mensaje = "Error al obtener la persona",
                    Error = ex.Message
                };
            }
        }

        public async Task<ResultadoOperacion<bool>> Insertar(Persona persona)
        {
            try
            {
                await _personaRepository.Insertar(persona);
                return new ResultadoOperacion<bool>
                {
                    Exito = true,
                    Datos = true,
                    Mensaje = "Persona insertada correctamente"
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion<bool>
                {
                    Exito = false,
                    Datos = false,
                    Mensaje = "Error al insertar persona",
                    Error = ex.Message
                };
            }
        }

        public async Task<ResultadoOperacion<bool>> Actualizar(Persona persona)
        {
            try
            {
                await _personaRepository.Actualizar(persona);
                return new ResultadoOperacion<bool>
                {
                    Exito = true,
                    Datos = true,
                    Mensaje = "Persona actualizada correctamente"
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion<bool>
                {
                    Exito = false,
                    Datos = false,
                    Mensaje = "Error al actualizar persona",
                    Error = ex.Message
                };
            }
        }

        public async Task<ResultadoOperacion<bool>> Eliminar(int id)
        {
            try
            {
                await _personaRepository.Eliminar(id);
                return new ResultadoOperacion<bool>
                {
                    Exito = true,
                    Datos = true,
                    Mensaje = "Persona eliminada correctamente"
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion<bool>
                {
                    Exito = false,
                    Datos = false,
                    Mensaje = "Error al eliminar persona",
                    Error = ex.Message
                };
            }
        }
    }
}