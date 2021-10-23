using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDominio;
using CapaEntidad;
namespace Servicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : ControllerBase
    {
     
    
    [HttpGet("Listar")]
        public List<EmpleadoEntidad> Listar()
    {
        EmpleadoDominio oEmpleadoDominio = new EmpleadoDominio();
        return oEmpleadoDominio.Listar();
    }
        [HttpPost("Filtrar")]
    public List<EmpleadoEntidad> Filtrar([FromBody] EmpleadoEntidad entidad)
    {
        EmpleadoDominio oEmpleadoDominio = new EmpleadoDominio();
        return oEmpleadoDominio.Filtrar(entidad);
    }
    [HttpPost("Grabar")]
    public string Registrar([FromBody] EmpleadoEntidad entidad)
    {
        EmpleadoDominio oEmpleadoDominio = new EmpleadoDominio();
        return oEmpleadoDominio.Registrar(entidad);
    }
    [HttpPut("Actualizar")]
    public string Modificar([FromBody] EmpleadoEntidad entidad)
    {
        EmpleadoDominio oEmpleadoDominio = new EmpleadoDominio();
        return oEmpleadoDominio.Modificar(entidad);
    }
    [HttpDelete("Eliminar")]
    public string Eliminar([FromBody] EmpleadoEntidad entidad)
    {
        EmpleadoDominio oEmpleadoDominio = new EmpleadoDominio();
        return oEmpleadoDominio.Eliminar(entidad);
    }
}
}
