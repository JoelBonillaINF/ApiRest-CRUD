using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class EmpleadoDatos
    {
        public static List<EmpleadoEntidad> Listar()
        {
            var lista = new List<EmpleadoEntidad>();
            string cadenaConexion = "Data Source=JOEL-PC;Initial Catalog=BD_Empresa;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_Empleado_ListarTodos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drlector = cmd.ExecuteReader();


            while (drlector.Read())
            {
                EmpleadoEntidad oEmpleadoEntidad = new EmpleadoEntidad();
                oEmpleadoEntidad.EmpleadoCodigo = Convert.ToInt32(drlector["EmpleadoCodigo"]);
                oEmpleadoEntidad.EmpleadoNombre = drlector["EmpleadoNombre"].ToString().Trim();
                oEmpleadoEntidad.EmpleadoApellido = drlector["EmpleadoApellido"].ToString().Trim();
                oEmpleadoEntidad.EmpleadoDireccion = drlector["EmpleadoDireccion"].ToString().Trim();
                oEmpleadoEntidad.EmpleadoTelefono = drlector["EmpleadoTelefono"].ToString().Trim();
                oEmpleadoEntidad.EmpleadoEmail = drlector["EmpleadoEmail"].ToString().Trim();
                oEmpleadoEntidad.EmpleadoFechaNacimiento = Convert.ToDateTime(drlector["EmpleadoFechaNacimiento"]).ToString("dd/MM/yyyy");
                oEmpleadoEntidad.EmpleadoSueldo = Convert.ToDouble(drlector["EmpleadoSueldo"]);
                oEmpleadoEntidad.EmpleadoEstado = Convert.ToBoolean(drlector["EmpleadoEstado"]);
                lista.Add(oEmpleadoEntidad);
            }
            return lista;
        }

        public static List<EmpleadoEntidad> Filtrar(EmpleadoEntidad entidad)
        {
            var lista = new List<EmpleadoEntidad>();
            string cadenaConexion = "Data Source=JOEL-PC;Initial Catalog=BD_Empresa;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_Empleado_Filtrar", cn);
            cmd.Parameters.Add(new SqlParameter("@EmpleadoNombre", SqlDbType.VarChar, 100)).Value = entidad.EmpleadoNombre;
            cmd.Parameters.Add(new SqlParameter("@EmpleadoApellido", SqlDbType.VarChar, 100)).Value = entidad.EmpleadoApellido;

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drlector = cmd.ExecuteReader();


            while (drlector.Read())
            {
                EmpleadoEntidad oEmpleadoEntidad = new EmpleadoEntidad();
                oEmpleadoEntidad.EmpleadoCodigo = Convert.ToInt32(drlector["EmpleadoCodigo"]);
                oEmpleadoEntidad.EmpleadoNombre = drlector["EmpleadoNombre"].ToString().Trim();
                oEmpleadoEntidad.EmpleadoApellido = drlector["EmpleadoApellido"].ToString().Trim();
                oEmpleadoEntidad.EmpleadoDireccion = drlector["EmpleadoDireccion"].ToString().Trim();
                oEmpleadoEntidad.EmpleadoTelefono = drlector["EmpleadoTelefono"].ToString().Trim();
                oEmpleadoEntidad.EmpleadoEmail = drlector["EmpleadoEmail"].ToString().Trim();
                oEmpleadoEntidad.EmpleadoFechaNacimiento = Convert.ToDateTime(drlector["EmpleadoFechaNacimiento"]).ToString("dd/MM/yyyy");
                oEmpleadoEntidad.EmpleadoSueldo = Convert.ToDouble(drlector["EmpleadoSueldo"]);
                oEmpleadoEntidad.EmpleadoEstado = Convert.ToBoolean(drlector["EmpleadoEstado"]);
                lista.Add(oEmpleadoEntidad);
            }
            return lista;
        }

        public static string Registrar(EmpleadoEntidad entidad)
        {
            var lista = new List<EmpleadoEntidad>();
            string cadenaConexion = "Data Source=JOEL-PC;Initial Catalog=BD_Empresa;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_Empleado_Registrar", cn);
            cmd.Parameters.Add(new SqlParameter("@EmpleadoNombre", SqlDbType.VarChar, 100)).Value = entidad.EmpleadoNombre;
            cmd.Parameters.Add(new SqlParameter("@EmpleadoApellido", SqlDbType.VarChar, 100)).Value = entidad.EmpleadoApellido;
            cmd.Parameters.Add(new SqlParameter("@EmpleadoDireccion", SqlDbType.VarChar, 200)).Value = entidad.EmpleadoDireccion;
            cmd.Parameters.Add(new SqlParameter("@EmpleadoTelefono", SqlDbType.VarChar, 200)).Value = entidad.EmpleadoTelefono;
            cmd.Parameters.Add(new SqlParameter("@EmpleadoEmail", SqlDbType.VarChar, 200)).Value = entidad.EmpleadoEmail;
            cmd.Parameters.Add(new SqlParameter("@EmpleadoFechaNacimiento", SqlDbType.DateTime)).Value = DateTime.Parse(entidad.EmpleadoFechaNacimiento);
            cmd.Parameters.Add(new SqlParameter("@EmpleadoSueldo", SqlDbType.Real)).Value = entidad.EmpleadoSueldo;
            cmd.Parameters.Add(new SqlParameter("@EmpleadoEstado", SqlDbType.VarChar, 100)).Value = entidad.EmpleadoEstado;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Registro Exitoso";

        }

        public static string Modificar(EmpleadoEntidad entidad)
        {
            var lista = new List<EmpleadoEntidad>();
            string cadenaConexion = "Data Source=JOEL-PC;Initial Catalog=BD_Empresa;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_Empleado_Modificar", cn);
            cmd.Parameters.Add(new SqlParameter("@EmpleadoCodigo", SqlDbType.Int)).Value = entidad.EmpleadoCodigo;
            cmd.Parameters.Add(new SqlParameter("@EmpleadoNombre", SqlDbType.VarChar, 100)).Value = entidad.EmpleadoNombre;
            cmd.Parameters.Add(new SqlParameter("@EmpleadoApellido", SqlDbType.VarChar, 100)).Value = entidad.EmpleadoApellido;
            cmd.Parameters.Add(new SqlParameter("@EmpleadoDireccion", SqlDbType.VarChar, 200)).Value = entidad.EmpleadoDireccion;
            cmd.Parameters.Add(new SqlParameter("@EmpleadoTelefono", SqlDbType.VarChar, 200)).Value = entidad.EmpleadoTelefono;
            cmd.Parameters.Add(new SqlParameter("@EmpleadoEmail", SqlDbType.VarChar, 200)).Value = entidad.EmpleadoEmail;
            cmd.Parameters.Add(new SqlParameter("@EmpleadoFechaNacimiento", SqlDbType.DateTime)).Value = DateTime.Parse(entidad.EmpleadoFechaNacimiento);
            cmd.Parameters.Add(new SqlParameter("@EmpleadoSueldo", SqlDbType.Real)).Value = entidad.EmpleadoSueldo;
            cmd.Parameters.Add(new SqlParameter("@EmpleadoEstado", SqlDbType.VarChar, 100)).Value = entidad.EmpleadoEstado;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Modificación Exitosa";

        }

        public static string Eliminar(EmpleadoEntidad entidad)
        {
            var lista = new List<EmpleadoEntidad>();
            string cadenaConexion = "Data Source=JOEL-PC;Initial Catalog=BD_Empresa;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_Empleado_Eliminar", cn);
            cmd.Parameters.Add(new SqlParameter("@EmpleadoCodigo", SqlDbType.Int)).Value = entidad.EmpleadoCodigo;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Registro Eliminado";

        }
    }
}