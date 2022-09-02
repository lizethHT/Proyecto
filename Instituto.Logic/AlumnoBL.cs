using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instituto.Data;
using Instituto.Dominio;

namespace Instituto.Logic
{
    public static class AlumnoBL
    {
        public static List<Alumnos> Listar()
        {
            var alumnoData = new AlumnoData();
            return alumnoData.Listar();
        }

        public static Alumnos BuscarPorId(int id)
        {
            var alumnoData = new AlumnoData();
            return alumnoData.BuscarPorId(id);
        }
        public static bool Insertar(Alumnos alumnos)
        {
            var alumnoData = new AlumnoData();
            return alumnoData.Insertar(alumnos);
        }

        public static bool Actualizar(Alumnos alumnos)
        {
            var alunmoData = new AlumnoData();
            return alunmoData.Actualizar(alumnos);
        }

        public static bool Eliminar(int id)
        {
            var productoData = new AlumnoData();
            return productoData.Eliminar(id);
        }
    }
}
