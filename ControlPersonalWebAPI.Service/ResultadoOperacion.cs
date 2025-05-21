﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPersonalWebAPI.Service
{
    public class ResultadoOperacion<T>
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public string Error { get; set; }
        public T Datos { get; set; }
    }
}
