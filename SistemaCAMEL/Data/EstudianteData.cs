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

        public EstudianteData(string connectionString)
        {
            this.cadenaConexion = connectionString;
        }//constructor

        public String InsertarEstudiante(Estudiante estudiante)
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
            cmdInsertarEstudiante.Parameters.Add(new SqlParameter("@activo", "Activo"));

            conexion.Open();
            String mensaje = "";
            if (cmdInsertarEstudiante.ExecuteNonQuery() > 0)
            {
                mensaje = InsertarEncargadoEstudiante(estudiante);
            }
            else
                mensaje = "No se pudo realizar la inserción del estudiante";
            conexion.Close();
            return mensaje;
        }//Insertar

        private String InsertarEncargadoEstudiante(Estudiante estudiante)
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
                mensaje = "La inserción del estudiante fue correcta";
            }
            else
                mensaje = "No se pudo realizar la inserción del encargado asociado al estudiante";
            conexion.Close();
            return mensaje;
        }//Insertar

        public String generarCarne()
        {
            String iniciales = "EST";
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

        public String Editar(Estudiante estudiante, string cedulaEncargado)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdInsertarEstudiante = new SqlCommand();
            cmdInsertarEstudiante.CommandText = "sp_editar_estudiante";
            cmdInsertarEstudiante.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertarEstudiante.Connection = conexion;

            //configurar los parametros
            cmdInsertarEstudiante.Parameters.Add(new SqlParameter("@carne", estudiante.Carne));
            cmdInsertarEstudiante.Parameters.Add(new SqlParameter("@cedula", estudiante.Cedula));
            cmdInsertarEstudiante.Parameters.Add(new SqlParameter("@nombre", estudiante.Nombre));
            cmdInsertarEstudiante.Parameters.Add(new SqlParameter("@apellidos", estudiante.Apellidos));
            cmdInsertarEstudiante.Parameters.Add(new SqlParameter("@cedula_encargado", cedulaEncargado));

            conexion.Open();
            String mensaje = "";
            if (cmdInsertarEstudiante.ExecuteNonQuery() > 0)
            {
                mensaje = "La edición del estudiante fue correcta";
            }
            else
                mensaje = "No se pudo realizar la edición del estudiante";
            conexion.Close();
            return mensaje;
        }//Editar

        public LinkedList<Estudiante> obtenerEstudiantes()
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdObtenerEstudiantes = new SqlCommand();
            cmdObtenerEstudiantes.CommandText = "sp_obtener_estudiantes";
            cmdObtenerEstudiantes.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtenerEstudiantes.Connection = conexion;

            conexion.Open();
            SqlDataReader drEncargados = cmdObtenerEstudiantes.ExecuteReader();
            LinkedList<Estudiante> estudiantes = new LinkedList<Estudiante>();
            EncargadoEstudiante encargadoEstudiante = new EncargadoEstudiante();
            Estudiante estudiante = new Estudiante();

            while (drEncargados.Read())
            {
                //se recupera el encargado asoociado al estudiante
                encargadoEstudiante = obtenerEncargadoEstudiante(drEncargados["carne"].ToString());

                estudiante = new Estudiante(drEncargados["carne"].ToString(), drEncargados["cedula"].ToString(),
                    drEncargados["nombre"].ToString(), drEncargados["apellidos"].ToString(),
                     encargadoEstudiante, drEncargados["activo"].ToString());

                estudiantes.AddLast(estudiante);
            }//while
            conexion.Close();
            return estudiantes;
        }//obtenerEncargados

        public Estudiante obtenerEstudiante(String carne)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdObtenerEstudiante = new SqlCommand();
            cmdObtenerEstudiante.CommandText = "sp_obtener_estudiante";
            cmdObtenerEstudiante.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtenerEstudiante.Connection = conexion;

            //configurar los parametros
            cmdObtenerEstudiante.Parameters.Add(new SqlParameter("@carne", carne));

            conexion.Open();
            SqlDataReader drEncargados = cmdObtenerEstudiante.ExecuteReader();
            Estudiante estudiante = new Estudiante();
            EncargadoEstudiante encargadoEstudiante = new EncargadoEstudiante();

            while (drEncargados.Read())
            {
                //se recupera el encargado asoociado al estudiante
                encargadoEstudiante = obtenerEncargadoEstudiante(drEncargados["carne"].ToString());

                estudiante = new Estudiante(drEncargados["carne"].ToString(), drEncargados["cedula"].ToString(),
                    drEncargados["nombre"].ToString(), drEncargados["apellidos"].ToString(),
                     encargadoEstudiante, drEncargados["activo"].ToString());
            }//while
            conexion.Close();
            return estudiante;
        }//obtenerEncargados

        public EncargadoEstudiante obtenerEncargadoEstudiante(String carneEstudiante)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdObtenerEncargados = new SqlCommand();
            cmdObtenerEncargados.CommandText = "sp_obtener_encargado_carne";
            cmdObtenerEncargados.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtenerEncargados.Connection = conexion;
            //configurar los parametros
            cmdObtenerEncargados.Parameters.Add(new SqlParameter("@carne", carneEstudiante));

            conexion.Open();
            SqlDataReader drEncargados = cmdObtenerEncargados.ExecuteReader();
            EncargadoEstudiante encargadoEstudiante = new EncargadoEstudiante();
            while (drEncargados.Read())
            {
                encargadoEstudiante = new EncargadoEstudiante(drEncargados["cedula"].ToString(),
                    drEncargados["nombre"].ToString(), drEncargados["apellidos"].ToString(), drEncargados["telefono"].ToString(),
                    drEncargados["correo"].ToString(), drEncargados["direccion"].ToString());

            }//while
            conexion.Close();
            return encargadoEstudiante;
        }//obtenerEncargados

    }//class
}//namespace
