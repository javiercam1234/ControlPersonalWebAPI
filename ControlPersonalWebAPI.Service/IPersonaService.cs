using ControlPersonalWebAPI.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPersonalWebAPI.Service
{
    public interface IPersonaService
    {
        Task<ResultadoOperacion<List<Persona>>> ObtenerTodos();
        Task<ResultadoOperacion<Persona>> ObtenerPorId(int id);
        Task<ResultadoOperacion<bool>> Insertar(Persona persona);
        Task<ResultadoOperacion<bool>> Actualizar(Persona persona);
        Task<ResultadoOperacion<bool>> Eliminar(int id);
    }
}