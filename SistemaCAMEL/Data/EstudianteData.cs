using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.SqlClient;

namespace Data
{
    public class EstudianteData
    {
        private String cadenaConexion;
        private object sqlConnection;

        public EstudianteData(string connectionString)
        {
            this.cadenaConexion = connectionString;
        }//constructor

        private String InsertarEstudiante(Estudiante estudiante)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdInsertarEstudiante = new SqlCommand();
            cmdInsertarEstudiante.CommandText = "sp_insertar_estudiante";
            cmdInsertarEstudiante.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertarEstudiante.Connection = conexion;

            //configurar los parametros
            cmdInsertarEstudiante.Parameters.Add(new SqlParameter("@carne", estudiante.Carne));
            cmdInsertarEstudiante.Parameters.Add(new SqlParameter("@cedula", estudiante.Cedula));
            cmdInsertarEstudiante.Parameters.Add(new SqlParameter("@nombre", estudiante.Nombre));
            cmdInsertarEstudiante.Parameters.Add(new SqlParameter("@apellidos", estudiante.Apellidos));

            conexion.Open();
            String mensaje = "";
            if (cmdInsertarEstudiante.ExecuteNonQuery() > 0)
            {
                mensaje = "La inserción del estudiante fue correcta";
            }
            else
                mensaje = "No se pudo realizar la inserción del estudiante";
            conexion.Close();
            return mensaje;
        }//Insertar

        public String InsertarEncargadoEstudiante(Estudiante estudiante)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdInsertarEncargado = new SqlCommand();
            cmdInsertarEncargado.CommandText = "sp_insertar_encargado_estudiante";
            cmdInsertarEncargado.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertarEncargado.Connection = conexion;

            //configurar los parametros
            cmdInsertarEncargado.Parameters.Add(new SqlParameter("@carne_estudiante", estudiante.Carne));
            cmdInsertarEncargado.Parameters.Add(new SqlParameter("@cedula_encargado", estudiante.Encargado.Cedula));

            conexion.Open();
            String mensaje = "";
            if (cmdInsertarEncargado.ExecuteNonQuery() > 0)
            {
                return InsertarEstudiante(estudiante);
            }
            else
                mensaje = "No se pudo realizar la inserción del encargado asociado al estudiante";
            conexion.Close();
            return mensaje;
        }//Insertar

        public String generarCarne()
        {
            String iniciales = "Est";
            Random random = new Random();
            int num = 100;

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand cmdEstudiante = new SqlCommand("SELECT TOP 1 carne from estudiante order by carne desc", conexion);
            conexion.Open();
            SqlDataReader drEstudiante = cmdEstudiante.ExecuteReader();

            if (drEstudiante.Read())
            {
                num = Int32.Parse(drEstudiante["carne"].ToString().Substring(3));
                num++;
            }//if
            return iniciales + num;
        }
    }//class
}//namespace
