using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.SqlClient;


namespace Data
{
    public class DocenteData{
        private String connectionString;

        public DocenteData(string connectionString)
        {
            this.connectionString = connectionString; //recibimos el string de conexion;     
        }//contructor

        public LinkedList<Docente> obtenerDocentes() {
            SqlConnection conexion  = new SqlConnection(connectionString);

            SqlCommand cmdDocentes = new SqlCommand("sp_obtener_docentes", conexion);
            conexion.Open();

            SqlDataReader readerDocentes = cmdDocentes.ExecuteReader();

            LinkedList<Docente> docentes = new LinkedList<Docente>();

            while (readerDocentes.Read()){
                docentes.AddLast(new Docente(readerDocentes["cedula"].ToString(),readerDocentes["nombre"].ToString(),
                    readerDocentes["apellidos"].ToString(), readerDocentes["telefono"].ToString(), 
                    readerDocentes["correo"].ToString(), readerDocentes["direccion"].ToString(), 
                    readerDocentes["especialidad"].ToString()));

            }//while
            conexion.Close();
            return docentes;
        }//getDocentes

        public void eliminarDocente(string cedula)
        {
            SqlConnection conexion = new SqlConnection(this.connectionString);
            SqlCommand cmdObtener = new SqlCommand();
            cmdObtener.CommandText = "sp_eliminar_docente";
            cmdObtener.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtener.Connection = conexion;


            //configurar los parametros
            cmdObtener.Parameters.Add(new SqlParameter("@cedula", cedula));

            conexion.Open();
            SqlDataReader drDocente = cmdObtener.ExecuteReader();

            conexion.Close();
        }

        public void modificarDocente(Docente docente)
        {
            SqlConnection conexion = new SqlConnection(this.connectionString);
            SqlCommand cmdObtener = new SqlCommand();
            cmdObtener.CommandText = "sp_actualizar_docente";
            cmdObtener.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtener.Connection = conexion;

            string cedula = docente.Cedula;
            string nombre = docente.Nombre;
            string apellidos = docente.Apellidos;
            string telefono = docente.Telefono;
            string correo = docente.Correo;
            string direccion = docente.Direccion;
            string especialidad = docente.Especialidad;

            //configurar los parametros
            cmdObtener.Parameters.Add(new SqlParameter("@cedula", cedula));
            cmdObtener.Parameters.Add(new SqlParameter("@nombre", nombre));
            cmdObtener.Parameters.Add(new SqlParameter("@apellidos", apellidos));
            cmdObtener.Parameters.Add(new SqlParameter("@telefono", telefono));
            cmdObtener.Parameters.Add(new SqlParameter("@correo", correo));
            cmdObtener.Parameters.Add(new SqlParameter("@direccion", direccion));
            cmdObtener.Parameters.Add(new SqlParameter("@especialidad", especialidad));

            conexion.Open();
            SqlDataReader drDocente = cmdObtener.ExecuteReader();

            conexion.Close();
        }

        public void ingresarDocente(Docente docente)
        {
            SqlConnection conexion = new SqlConnection(this.connectionString);
            SqlCommand cmdObtener = new SqlCommand();
            cmdObtener.CommandText = "sp_insertar_docente";
            cmdObtener.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtener.Connection = conexion;

            string cedula = docente.Cedula;
            string nombre = docente.Nombre;
            string apellidos = docente.Apellidos;
            string telefono = docente.Telefono;
            string correo = docente.Correo;
            string direccion = docente.Direccion;
            string especialidad = docente.Especialidad;

            //configurar los parametros
            cmdObtener.Parameters.Add(new SqlParameter("@cedula", cedula));
            cmdObtener.Parameters.Add(new SqlParameter("@nombre", nombre));
            cmdObtener.Parameters.Add(new SqlParameter("@apellidos", apellidos));
            cmdObtener.Parameters.Add(new SqlParameter("@telefono", telefono));
            cmdObtener.Parameters.Add(new SqlParameter("@correo", correo));
            cmdObtener.Parameters.Add(new SqlParameter("@direccion", direccion));
            cmdObtener.Parameters.Add(new SqlParameter("@especialidad", especialidad));

            conexion.Open();
            SqlDataReader drDocente = cmdObtener.ExecuteReader();
            
            conexion.Close();
           
        }

        public Docente obtenerDocente(String cedula)
        {
            SqlConnection conexion = new SqlConnection(this.connectionString);
            SqlCommand cmdObtener = new SqlCommand();
            cmdObtener.CommandText = "sp_obtener_docente";
            cmdObtener.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtener.Connection = conexion;

            //configurar los parametros
            cmdObtener.Parameters.Add(new SqlParameter("@cedula", cedula));

            conexion.Open();
            SqlDataReader drDocente = cmdObtener.ExecuteReader();
            Docente docente = new Docente();

            while (drDocente.Read())
            {

                docente = new Docente(drDocente["cedula"].ToString(), drDocente["nombre"].ToString(),
                    drDocente["apellidos"].ToString(), drDocente["telefono"].ToString(), drDocente["correo"].ToString(),
                    drDocente["direccion"].ToString(), drDocente["especialidad"].ToString());
            }//while
            conexion.Close();
            return docente;
        }
    }//clase
}//namespace
