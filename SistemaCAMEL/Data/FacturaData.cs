using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FacturaData
    {
        private String cadenaConexion;

        public FacturaData(string connectionString)
        {
            cadenaConexion = connectionString;
        }//ctor

        public String insertar(Factura factura)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdInsertar = new SqlCommand();
            cmdInsertar.CommandText = "sp_insertar_factura";
            cmdInsertar.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertar.Connection = conexion;

            //configurar los parametros
            cmdInsertar.Parameters.Add(new SqlParameter("@fecha", factura.Fecha));
            cmdInsertar.Parameters.Add(new SqlParameter("@monto_total", factura.Monto_total));
            cmdInsertar.Parameters.Add(new SqlParameter("@estado", factura.Estado));

            conexion.Open();
            String mensaje = "";
            if (cmdInsertar.ExecuteNonQuery() > 0)
            {
                mensaje = "La inserción de la factura fue correcta";
            }//if
            else
                mensaje = "No se pudo realizar la inserción de la factura";
            conexion.Close();

            return mensaje;
        }//insertar

        public float calcularMonto(string grupo)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdObtenerEstudiante = new SqlCommand();
            cmdObtenerEstudiante.CommandText = "sp_calcular_monto";
            cmdObtenerEstudiante.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtenerEstudiante.Connection = conexion;

            //configurar los parametros
            cmdObtenerEstudiante.Parameters.Add(new SqlParameter("@seccion", grupo));

            conexion.Open();
            SqlDataReader drEncargados = cmdObtenerEstudiante.ExecuteReader();
            float total =0;

            while (drEncargados.Read())
            {
                total = float.Parse(drEncargados["total"].ToString());

            }//while
            conexion.Close();
            return total *100;
        }//calcularMonto

    }//class
}//namespace
