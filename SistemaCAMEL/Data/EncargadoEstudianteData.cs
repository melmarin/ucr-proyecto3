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
            cmdInsertarEncargado.Parameters.Add(new SqlParameter("@ceduala", encargadoEstudiante.Cedula));
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
