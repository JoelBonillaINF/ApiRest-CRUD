using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EmpleadoEntidad
    {
        public int EmpleadoCodigo { get; set; }
        public string EmpleadoNombre { get; set; }
        public string EmpleadoApellido { get; set; }
        public string EmpleadoDireccion { get; set; }
        public string EmpleadoTelefono { get; set; }
        public string EmpleadoEmail { get; set; }
        public string EmpleadoFechaNacimiento { get; set; }
        public double EmpleadoSueldo { get; set; }
        public bool EmpleadoEstado { get; set; }
    }
}
