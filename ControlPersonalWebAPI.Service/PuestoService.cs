using ControlPersonalWebAPI.Data.Repository;
using ControlPersonalWebAPI.Entidades;
using ControlPersonalWebAPI.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPersonalWebAPI.Service
{
    public class PuestoService : IPuestoService
    {
        private readonly PuestoRepository _puestoRepository;

        public PuestoService(PuestoRepository puestoRepository)
        {
            _puestoRepository = puestoRepository;
        }

        public async Task<ResultadoOperacion<List<Puesto>>> ObtenerTodos()
        {
            try
            {
                var puestos = await _puestoRepository.ObtenerTodos();
                return new ResultadoOperacion<List<Puesto>>
                {
                    Exito = true,
                    Datos = puestos
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion<List<Puesto>>
                {
                    Exito = false,
                    Mensaje = "Error al obtener puestos",
                    Error = ex.Message
                };
            }
        }

        public async Task<ResultadoOperacion<Puesto>> ObtenerPorId(int id)
        {
            try
            {
                var puesto = await _puestoRepository.ObtenerPorId(id);
                if (puesto != null)
                {
                    return new ResultadoOperacion<Puesto>
                    {
                        Exito = true,
                        Datos = puesto
                    };
                }
                else
                {
                    return new ResultadoOperacion<Puesto>
                    {
                        Exito = false,
                        Mensaje = "Puesto no encontrado"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion<Puesto>
                {
                    Exito = false,
                    Mensaje = $"Error al obtener el puesto con Id: {id}",
                    Error = ex.Message
                };
            }
        }

        public async Task<ResultadoOperacion<bool>> Insertar(Puesto puesto)
        {
            try
            {
                await _puestoRepository.Insertar(puesto);
                return new ResultadoOperacion<bool>
                {
                    Exito = true,
                    Datos = true,
                    Mensaje = "Puesto insertado correctamente"
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion<bool>
                {
                    Exito = false,
                    Datos = false,
                    Mensaje = "Error al insertar el puesto",
                    Error = ex.Message
                };
            }
        }

        public async Task<ResultadoOperacion<bool>> Actualizar(Puesto puesto)
        {
            try
            {
                await _puestoRepository.Actualizar(puesto);
                return new ResultadoOperacion<bool>
                {
                    Exito = true,
                    Datos = true,
                    Mensaje = "Puesto actualizado correctamente"
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion<bool>
                {
                    Exito = false,
                    Datos = false,
                    Mensaje = "Error al actualizar el puesto",
                    Error = ex.Message
                };
            }
        }

        public async Task<ResultadoOperacion<bool>> Eliminar(int id)
        {
            try
            {
                await _puestoRepository.Eliminar(id);
                return new ResultadoOperacion<bool>
                {
                    Exito = true,
                    Datos = true,
                    Mensaje = "Puesto eliminado correctamente"
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion<bool>
                {
                    Exito = false,
                    Datos = false,
                    Mensaje = $"Error al eliminar el puesto con Id: {id}",
                    Error = ex.Message
                };
            }
        }
    }
}