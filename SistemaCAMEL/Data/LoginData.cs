using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class LoginData
    {
        private String cadenaConexion;
        private object sqlConnection;

        public LoginData(string connectionString)
        {
            this.cadenaConexion = connectionString;
        }//ctor

        public String obtenerRol(string usuario, string clave)
        {
            String rol = "";
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdObtenerRol = new SqlCommand();
            cmdObtenerRol.CommandText = "sp_obtener_login_rol";
            cmdObtenerRol.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtenerRol.Connection = conexion;

            //configurar los parametros
            cmdObtenerRol.Parameters.Add(new SqlParameter("@usuario", usuario));
            cmdObtenerRol.Parameters.Add(new SqlParameter("@clave", clave));

            conexion.Open();
            SqlDataReader drRol = cmdObtenerRol.ExecuteReader();
            while (drRol.Read())
            {
                rol = drRol["rol"].ToString();
            }
            conexion.Close();
            return rol;
        }//obtenerRol
    }//class
}//namespace
