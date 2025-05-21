using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace ControlPersonalWebAPI.Data
{
    public static class Conexion
    {
        private static string _cadenaConexion;

        public static void Configurar(IConfiguration configuration)
        {
            _cadenaConexion = configuration.GetConnectionString("DefaultConnection");
        }

        public static SqlConnection ObtenerConexion()
        {
            if (string.IsNullOrEmpty(_cadenaConexion))
            {
                throw new InvalidOperationException("La cadena de conexión no ha sido configurada.");
            }

            return new SqlConnection(_cadenaConexion);
        }
    }
}
