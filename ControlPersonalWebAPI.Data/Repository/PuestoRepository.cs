using ControlPersonalWebAPI.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPersonalWebAPI.Data.Repository
{
    public class PuestoRepository
    {
        // Obtener todos los puestos
        public async Task<List<Puesto>> ObtenerTodos()
        {
            var lista = new List<Puesto>();
            using var conn = Conexion.ObtenerConexion();
            await conn.OpenAsync();  // Usar OpenAsync
            var query = "SELECT * FROM tblPuestos";

            var cmd = new SqlCommand(query, conn);
            var reader = await cmd.ExecuteReaderAsync();  // Usar ExecuteReaderAsync

            while (await reader.ReadAsync())  // Usar ReadAsync
            {
                lista.Add(new Puesto
                {
                    IdPuesto = (int)reader["IdPuesto"],
                    DescripcionPuesto = reader["DescripcionPuesto"].ToString()
                });
            }

            return lista;
        }

        public async Task<Puesto> ObtenerPorId(int id)
        {
            Puesto puesto = null;  // Inicializar la variable puesto como null

            using var conn = Conexion.ObtenerConexion();
            await conn.OpenAsync();  // Usar OpenAsync

            var query = "SELECT * FROM tblPuestos WHERE IdPuesto = @id";
            var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            var reader = await cmd.ExecuteReaderAsync();  // Usar ExecuteReaderAsync

            if (await reader.ReadAsync())  // Usar ReadAsync y solo leer el primer registro
            {
                puesto = new Puesto
                {
                    IdPuesto = (int)reader["IdPuesto"],
                    DescripcionPuesto = reader["DescripcionPuesto"].ToString()
                };
            }

            return puesto;  // Devolver el puesto encontrado o null si no existe
        }
        // Insertar un puesto
        public async Task Insertar(Puesto puesto)
        {
            using var conn = Conexion.ObtenerConexion();
            await conn.OpenAsync();  // Usar OpenAsync
            var query = "INSERT INTO tblPuestos (DescripcionPuesto) VALUES (@desc)";

            var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@desc", puesto.DescripcionPuesto);

            await cmd.ExecuteNonQueryAsync();  // Usar ExecuteNonQueryAsync
        }

        // Actualizar un puesto
        public async Task Actualizar(Puesto puesto)
        {
            using var conn = Conexion.ObtenerConexion();
            await conn.OpenAsync();  // Usar OpenAsync
            var query = "UPDATE tblPuestos SET DescripcionPuesto = @desc WHERE IdPuesto = @id";

            var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@desc", puesto.DescripcionPuesto);
            cmd.Parameters.AddWithValue("@id", puesto.IdPuesto);

            await cmd.ExecuteNonQueryAsync();  // Usar ExecuteNonQueryAsync
        }

        // Eliminar un puesto
        public async Task Eliminar(int id)
        {
            using var conn = Conexion.ObtenerConexion();
            await conn.OpenAsync();  // Usar OpenAsync
            var query = "DELETE FROM tblPuestos WHERE IdPuesto = @id";

            var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            await cmd.ExecuteNonQueryAsync();  // Usar ExecuteNonQueryAsync
        }
    }
}