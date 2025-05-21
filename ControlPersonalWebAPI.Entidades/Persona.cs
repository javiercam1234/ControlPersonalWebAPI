using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPersonalWebAPI.Entidades
{

    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public decimal Edad { get; set; }
        public decimal Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public bool Activo { get; set; }
        public int IdPuesto { get; set; }
        public Puesto puesto { get; set; }
    }
}
