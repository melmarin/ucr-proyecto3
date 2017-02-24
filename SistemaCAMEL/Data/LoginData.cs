﻿using Domain;
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
