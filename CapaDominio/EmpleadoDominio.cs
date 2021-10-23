using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaDominio
{
    public class EmpleadoDominio
    {

        public List<EmpleadoEntidad> Listar()
        {
            return EmpleadoDatos.Listar();
        }

        public List<EmpleadoEntidad> Filtrar(EmpleadoEntidad entidad)
        {
            return EmpleadoDatos.Filtrar(entidad);
        }

        public string Registrar(EmpleadoEntidad entidad)
        {
            return EmpleadoDatos.Registrar(entidad);

        }

        public string Modificar(EmpleadoEntidad entidad)
        {
            return EmpleadoDatos.Modificar(entidad);

        }

        public string Eliminar(EmpleadoEntidad entidad)
        {
            return EmpleadoDatos.Eliminar(entidad);

        }
    }
}
