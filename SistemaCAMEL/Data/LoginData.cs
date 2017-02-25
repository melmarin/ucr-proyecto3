using Domain;
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

        public string cambiarPass(string user,string pass)
        {
            String monto = "";
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdObtenerRol = new SqlCommand();
            cmdObtenerRol.CommandText = "sp_cambiar_pass";
            cmdObtenerRol.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtenerRol.Connection = conexion;

            //configurar los parametros
            cmdObtenerRol.Parameters.Add(new SqlParameter("@user", user));
            cmdObtenerRol.Parameters.Add(new SqlParameter("@pass", pass));


            conexion.Open();
            SqlDataReader drRol = cmdObtenerRol.ExecuteReader();
            if (!drRol.Read())
            {
                return "Cambio de pass con éxito!";
            }
            
            conexion.Close();
            return "No se cambio el pass, intente de nuevo!";
        }

        public string obtenerMonto(string user)
        {
            String monto = "";
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdObtenerRol = new SqlCommand();
            cmdObtenerRol.CommandText = "sp_obtener_monto_factura";
            cmdObtenerRol.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtenerRol.Connection = conexion;

            //configurar los parametros
            cmdObtenerRol.Parameters.Add(new SqlParameter("@user", user));

            conexion.Open();
            SqlDataReader drRol = cmdObtenerRol.ExecuteReader();
            while (drRol.Read())
            {
                monto = drRol["monto_total"].ToString();
            }
            conexion.Close();
            return monto;
        }

        public string pagar(string carnet)
        {
            String monto = "";
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdObtenerRol = new SqlCommand();
            cmdObtenerRol.CommandText = "sp_pagar_monto_factura";
            cmdObtenerRol.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtenerRol.Connection = conexion;

            //configurar los parametros
            cmdObtenerRol.Parameters.Add(new SqlParameter("@carnet", carnet));

            conexion.Open();
            SqlDataReader drRol = cmdObtenerRol.ExecuteReader();
            while (drRol.Read())
            {
                monto = drRol["estado"].ToString();
            }
            conexion.Close();
            if (monto == "Cancelado")
            {
                return "Cancelado monto de matricula, pago con exito";
            }
            else {
                return "No se pagó la matricula";
            }
            
        }

        public string validarEncargado(string usuario, string clave)
        {
            String carnet = "";
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdValidar = new SqlCommand();
            cmdValidar.CommandText = "sp_validar_encargado_login";
            cmdValidar.CommandType = System.Data.CommandType.StoredProcedure;
            cmdValidar.Connection = conexion;

            //configurar los parametros
            cmdValidar.Parameters.Add(new SqlParameter("@user", usuario));
            cmdValidar.Parameters.Add(new SqlParameter("@pass", clave));

            conexion.Open();
            SqlDataReader drRol = cmdValidar.ExecuteReader();
            

            if (drRol.HasRows)
            {
            conexion.Close();
            SqlConnection conexion2 = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdObtenerEstudiante = new SqlCommand();
            cmdObtenerEstudiante.CommandText = "sp_obtener_id_estudiante_matricula";
            cmdObtenerEstudiante.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtenerEstudiante.Connection = conexion2;

            //configurar los parametros
            cmdObtenerEstudiante.Parameters.Add(new SqlParameter("@user", usuario));

            conexion2.Open();
            SqlDataReader drCarnet = cmdObtenerEstudiante.ExecuteReader();
            
                while (drCarnet.Read())
                {
                    carnet = drCarnet["id_estudiante"].ToString();
                    conexion2.Close();
                    if (carnet == "") {
                        return "estaba sin nada";
                    }
                    return carnet;
                }
            
            }
            else {
                return "error";
            }

            return "salio sin nada.. drCarnet.read Vacío";
        }

        public bool insertarLogin(string usuario, string clave, string rol)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.CommandText = " sp_insertar_login";
            cmdLogin.CommandType = System.Data.CommandType.StoredProcedure;
            cmdLogin.Connection = conexion;

            //configurar los parametros
            cmdLogin.Parameters.Add(new SqlParameter("@usuario", usuario));
            cmdLogin.Parameters.Add(new SqlParameter("@clave", clave));
            cmdLogin.Parameters.Add(new SqlParameter("@rol", rol));

            conexion.Open();
            bool mensaje = false;
            if (cmdLogin.ExecuteNonQuery() > 0)
            {
                mensaje = true;
            }
            else
            conexion.Close();
            return mensaje;
        }//insertarLogin

        public Login obtenerLogin(string usuario)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdObtenerLogin = new SqlCommand();
            cmdObtenerLogin.CommandText = "sp_obtener_login";
            cmdObtenerLogin.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtenerLogin.Connection = conexion;

            //configurar los parametros
            cmdObtenerLogin.Parameters.Add(new SqlParameter("@usuario", usuario));
            conexion.Open();
            Login login = new Login();
            SqlDataReader drRol = cmdObtenerLogin.ExecuteReader();
            while (drRol.Read())
            {
                login = new Login(drRol["usuario"].ToString(), drRol["clave"].ToString(),
                    drRol["rol"].ToString());
            }
            conexion.Close();
            return login;
        }//obtenerRol
    }//class
}//namespace
