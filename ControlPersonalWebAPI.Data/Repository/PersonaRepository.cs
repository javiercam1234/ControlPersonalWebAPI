using ControlPersonalWebAPI.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPersonalWebAPI.Data.Repository
{
    public class PersonaRepository
    {
       
        public async Task<List<Persona>> ObtenerTodos()
        {
            var lista = new List<Persona>();
            try
            {
                using var conn = Conexion.ObtenerConexion();
                await conn.OpenAsync();   
                var query = @"
                    SELECT 
                        p.IdPersona, p.Nombre, p.Edad, p.Telefono,
                        p.FechaNacimiento, p.Sexo, p.Activo, p.IdPuesto,
                        pu.IdPuesto AS Puesto_Id, pu.DescripcionPuesto
                    FROM tblPersona  p
                    INNER JOIN tblPuestos pu ON p.IdPuesto = pu.IdPuesto";

                var cmd = new SqlCommand(query, conn);
                var reader = await cmd.ExecuteReaderAsync();  // Usar ExecuteReaderAsync

                while (await reader.ReadAsync())  // Usar ReadAsync
                {
                    var persona = new Persona
                    {
                        IdPersona = (int)reader["IdPersona"],
                        Nombre = reader["Nombre"].ToString(),
                        Edad = (decimal)reader["Edad"],
                        Telefono = (decimal)reader["Telefono"],
                        FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                        Sexo = reader["Sexo"].ToString().Trim(),
                        Activo = (bool)reader["Activo"],
                        IdPuesto = (int)reader["IdPuesto"],
                        puesto = new Puesto
                        {
                            IdPuesto = (int)reader["Puesto_Id"],
                            DescripcionPuesto = reader["DescripcionPuesto"].ToString()
                        }
                    };

                    lista.Add(persona);
                }
            }
            catch (SqlException sqlEx)
            {
                // Manejo de error específico de SQL
                throw new Exception("Error al obtener las personas desde la base de datos.", sqlEx);
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                throw new Exception("Error al obtener las personas.", ex);
            }
            return lista;
        }

        // Obtener una persona por ID
        public async Task<Persona> ObtenerPorId(int id)
        {
            Persona persona = null;
            try
            {
                using var conn = Conexion.ObtenerConexion();
                await conn.OpenAsync();  // Usar OpenAsync
                var query = @"
                    SELECT 
                        p.IdPersona, p.Nombre, p.Edad, p.Telefono,
                        p.FechaNacimiento, p.Sexo, p.Activo, p.IdPuesto,
                        pu.IdPuesto AS Puesto_Id, pu.DescripcionPuesto
                    FROM tblPersona p
                    INNER JOIN tblPuestos pu ON p.IdPuesto = pu.IdPuesto
                    WHERE p.IdPersona = @id";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = await cmd.ExecuteReaderAsync();  // Usar ExecuteReaderAsync

                if (await reader.ReadAsync())  // Usar ReadAsync
                {
                    persona = new Persona
                    {
                        IdPersona = (int)reader["IdPersona"],
                        Nombre = reader["Nombre"].ToString(),
                        Edad = (decimal)reader["Edad"],
                        Telefono = (decimal)reader["Telefono"],
                        FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                        Sexo = reader["Sexo"].ToString().Trim(),
                        Activo = (bool)reader["Activo"],
                        IdPuesto = (int)reader["IdPuesto"],
                        puesto = new Puesto
                        {
                            IdPuesto = (int)reader["IdPuesto"],
                            DescripcionPuesto = reader["DescripcionPuesto"].ToString()
                        }
                    };
                }
            }
            catch (SqlException sqlEx)
            {
                // Manejo de error específico de SQL
                throw new Exception($"Error al obtener la persona con ID {id}.", sqlEx);
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                throw new Exception($"Error al obtener la persona con ID {id}.", ex);
            }

            return persona;
        }

        // Insertar una persona
        public async Task Insertar(Persona persona)
        {
            try
            {
                using var conn = Conexion.ObtenerConexion();
                await conn.OpenAsync();  // Usar OpenAsync
                var cmd = new SqlCommand(@"
                    INSERT INTO tblPersona (Nombre, Edad, Telefono, FechaNacimiento, Sexo, Activo, IdPuesto)
                    VALUES (@nombre, @edad, @telefono, @fecha, @sexo, @activo, @idPuesto)", conn);

                cmd.Parameters.AddWithValue("@nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@edad", persona.Edad);
                cmd.Parameters.AddWithValue("@telefono", persona.Telefono);
                cmd.Parameters.AddWithValue("@fecha", persona.FechaNacimiento);
                cmd.Parameters.AddWithValue("@sexo", persona.Sexo);
                cmd.Parameters.AddWithValue("@activo", persona.Activo);
                cmd.Parameters.AddWithValue("@idPuesto", persona.IdPuesto);

                await cmd.ExecuteNonQueryAsync();  // Usar ExecuteNonQueryAsync
            }
            catch (SqlException sqlEx)
            {
                // Manejo de error específico de SQL
                throw new Exception("Error al insertar la persona en la base de datos.", sqlEx);
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                throw new Exception("Error al insertar la persona.", ex);
            }
        }

        // Actualizar una persona
        public async Task Actualizar(Persona persona)
        {
            try
            {
                using var conn = Conexion.ObtenerConexion();
                await conn.OpenAsync();  // Usar OpenAsync
                var cmd = new SqlCommand(@"
                    UPDATE tblPersona
                    SET Nombre = @nombre, Edad = @edad, Telefono = @telefono,
                        FechaNacimiento = @fecha, Sexo = @sexo, Activo = @activo, IdPuesto = @idPuesto
                    WHERE IdPersona = @id", conn);

                cmd.Parameters.AddWithValue("@id", persona.IdPersona);
                cmd.Parameters.AddWithValue("@nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@edad", persona.Edad);
                cmd.Parameters.AddWithValue("@telefono", persona.Telefono);
                cmd.Parameters.AddWithValue("@fecha", persona.FechaNacimiento);
                cmd.Parameters.AddWithValue("@sexo", persona.Sexo);
                cmd.Parameters.AddWithValue("@activo", persona.Activo);
                cmd.Parameters.AddWithValue("@idPuesto", persona.IdPuesto);

                await cmd.ExecuteNonQueryAsync();  // Usar ExecuteNonQueryAsync
            }
            catch (SqlException sqlEx)
            {
                // Manejo de error específico de SQL
                throw new Exception("Error al actualizar la persona en la base de datos.", sqlEx);
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                throw new Exception("Error al actualizar la persona.", ex);
            }
        }

        // Eliminar una persona
        public async Task Eliminar(int id)
        {
            try
            {
                using var conn = Conexion.ObtenerConexion();
                await conn.OpenAsync();

                using var cmd = new SqlCommand("DELETE FROM tblPersona WHERE IdPersona = @id", conn);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se encontró una persona con el ID especificado.");
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Error al eliminar la persona en la base de datos.", sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la persona.", ex);
            }
        }
    }
}