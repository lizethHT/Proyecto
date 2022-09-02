using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto.Dominio
{
    public class Alumnos
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Distrito { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int DNI { get; set; }
        public int Celular { get; set; }
    }
}
