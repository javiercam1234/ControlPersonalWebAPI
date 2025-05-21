using ControlPersonalWebAPI.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPersonalWebAPI.Service
{
    public interface IPuestoService
    {
        Task<ResultadoOperacion<List<Puesto>>> ObtenerTodos();
        Task<ResultadoOperacion<Puesto>> ObtenerPorId(int id);
        Task<ResultadoOperacion<bool>> Insertar(Puesto puesto);
        Task<ResultadoOperacion<bool>> Actualizar(Puesto puesto);
        Task<ResultadoOperacion<bool>> Eliminar(int id);
    }
}