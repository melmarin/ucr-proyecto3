using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EncargadoEstudianteData
    {
        private String cadenaConexion;
        private object sqlConnection;

        public EncargadoEstudianteData(string connectionString)
        {
            this.cadenaConexion = connectionString;
        }

        public String Insertar(EncargadoEstudiante encargadoEstudiante)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdInsertarEncargado = new SqlCommand();
            cmdInsertarEncargado.CommandText = "sp_insertar_encargado";
            cmdInsertarEncargado.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertarEncargado.Connection = conexion;

            //configurar los parametros
            cmdInsertarEncargado.Parameters.Add(new SqlParameter("@cedula", encargadoEstudiante.Cedula));
            cmdInsertarEncargado.Parameters.Add(new SqlParameter("@nombre", encargadoEstudiante.Nombre));
            cmdInsertarEncargado.Parameters.Add(new SqlParameter("@apellidos", encargadoEstudiante.Apellidos));
            cmdInsertarEncargado.Parameters.Add(new SqlParameter("@telefono", encargadoEstudiante.Telefono));
            cmdInsertarEncargado.Parameters.Add(new SqlParameter("@correo", encargadoEstudiante.Correo));
            cmdInsertarEncargado.Parameters.Add(new SqlParameter("@direccion", encargadoEstudiante.Direccion));

            conexion.Open();
            String mensaje = ""; 
            if(cmdInsertarEncargado.ExecuteNonQuery() > 0)
            {
                mensaje= "La inserción del encargado fue correcta";
            }
            else
               mensaje = "No se pudo realizar la inserción del encargado";
            conexion.Close();
            return mensaje;
        }//Insertar


        public String Editar(EncargadoEstudiante encargadoEstudiante)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdEditarEncargado = new SqlCommand();
            cmdEditarEncargado.CommandText = "sp_editar_encargado";
            cmdEditarEncargado.CommandType = System.Data.CommandType.StoredProcedure;
            cmdEditarEncargado.Connection = conexion;

            //configurar los parametros
            cmdEditarEncargado.Parameters.Add(new SqlParameter("@cedula", encargadoEstudiante.Cedula));
            cmdEditarEncargado.Parameters.Add(new SqlParameter("@nombre", encargadoEstudiante.Nombre));
            cmdEditarEncargado.Parameters.Add(new SqlParameter("@apellidos", encargadoEstudiante.Apellidos));
            cmdEditarEncargado.Parameters.Add(new SqlParameter("@telefono", encargadoEstudiante.Telefono));
            cmdEditarEncargado.Parameters.Add(new SqlParameter("@correo", encargadoEstudiante.Correo));
            cmdEditarEncargado.Parameters.Add(new SqlParameter("@direccion", encargadoEstudiante.Direccion));

            conexion.Open();
            String mensaje = "";
            if (cmdEditarEncargado.ExecuteNonQuery() > 0)
            {
                mensaje = "La edición del encargado fue correcta";
            }
            else
                mensaje = "No se pudo realizar la edición del encargado";
            conexion.Close();
            return mensaje;
        }//Editar

        public String Eliminar(String cedula)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdEliminarEncargado = new SqlCommand();
            cmdEliminarEncargado.CommandText = "sp_eliminar_encargado";
            cmdEliminarEncargado.CommandType = System.Data.CommandType.StoredProcedure;
            cmdEliminarEncargado.Connection = conexion;

            //configurar los parametros
            cmdEliminarEncargado.Parameters.Add(new SqlParameter("@cedula", cedula));

            conexion.Open();
            String mensaje = "";
            if (cmdEliminarEncargado.ExecuteNonQuery() > 0)
            {
                mensaje = "La eliminación del encargado fue correcta";
            }
            else
                mensaje = "No se pudo realizar la eliminación del encargado";
            conexion.Close();
            return mensaje;
        }//Eliminar

        public EncargadoEstudiante obtenerEncargado(String cedula)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdObtenerEncargado = new SqlCommand();
            cmdObtenerEncargado.CommandText = "sp_obtener_encargado";
            cmdObtenerEncargado.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtenerEncargado.Connection = conexion;

            //configurar los parametros
            cmdObtenerEncargado.Parameters.Add(new SqlParameter("@cedula", cedula));

            conexion.Open();
            SqlDataReader drEncargado = cmdObtenerEncargado.ExecuteReader();
            EncargadoEstudiante encargadoEstudiante = new EncargadoEstudiante();
            while (drEncargado.Read())
            {
                encargadoEstudiante = new EncargadoEstudiante(drEncargado["cedula"].ToString(),
                    drEncargado["nombre"].ToString(), drEncargado["apellidos"].ToString(), drEncargado["telefono"].ToString(),
                    drEncargado["correo"].ToString(), drEncargado["direccion"].ToString());
            }
            conexion.Close();
            return encargadoEstudiante;
        }//obtenerEncargado

        public LinkedList<EncargadoEstudiante> obtenerEncargados()
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdObtenerEncargados = new SqlCommand();
            cmdObtenerEncargados.CommandText = "sp_obtener_encargados";
            cmdObtenerEncargados.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtenerEncargados.Connection = conexion;

            conexion.Open();
            SqlDataReader drEncargados = cmdObtenerEncargados.ExecuteReader();
            LinkedList<EncargadoEstudiante> encargados = new LinkedList<EncargadoEstudiante>();
            EncargadoEstudiante encargadoEstudiante = new EncargadoEstudiante();
            while (drEncargados.Read())
            {
                encargadoEstudiante = new EncargadoEstudiante(drEncargados["cedula"].ToString(),
                    drEncargados["nombre"].ToString(), drEncargados["apellidos"].ToString(), drEncargados["telefono"].ToString(),
                    drEncargados["correo"].ToString(), drEncargados["direccion"].ToString());

                encargados.AddLast(encargadoEstudiante);
            }//while
            conexion.Close();
            return encargados;
        }//obtenerEncargados


        public object SqlConnection
        {
            get
            {
                return sqlConnection;
            }

            set
            {
                sqlConnection = value;
            }
        }
    }//class
}//namespace
