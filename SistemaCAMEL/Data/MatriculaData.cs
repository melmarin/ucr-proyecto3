using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MatriculaData
    {
        private String cadenaConexion;

        public MatriculaData(string connectionString)
        {
            this.cadenaConexion = connectionString;
        }

        public string insertar(Matricula matricula)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.CommandText = "sp_insertar_matricula";
            cmdLogin.CommandType = System.Data.CommandType.StoredProcedure;
            cmdLogin.Connection = conexion;

            //configurar los parametros
            cmdLogin.Parameters.Add(new SqlParameter("@id_factura", matricula.Factura.Codigo));
            cmdLogin.Parameters.Add(new SqlParameter("@id_grupo", matricula.Grupo.Seccion));
            cmdLogin.Parameters.Add(new SqlParameter("@id_estudiante", matricula.Estudiante.Carne));
            cmdLogin.Parameters.Add(new SqlParameter("@id_usuario", matricula.Login.Usuario));
            cmdLogin.Parameters.Add(new SqlParameter("@fecha", matricula.Factura.Fecha));
            cmdLogin.Parameters.Add(new SqlParameter("@monto_total", matricula.Factura.Monto_total));
            cmdLogin.Parameters.Add(new SqlParameter("@estado", matricula.Factura.Estado));

            conexion.Open();
            string mensaje = "";
            if (cmdLogin.ExecuteNonQuery() > 0)
            {
                mensaje = "La inserción de la matrícula fue correcta";
            }
            else
                mensaje = "No se pudo realizar la matrícula";
            conexion.Close();
            return mensaje;
        }//insertar
    }//class
}//namespace
