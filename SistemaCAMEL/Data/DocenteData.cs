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
        private object sqlConnection;

        public DocenteData(string connectionString)
        {
            this.connectionString = connectionString; //recibimos el string de conexion;     
        }//contructor

        public LinkedList<Docente> obtenerDocentes() {
            SqlConnection conexion  = new SqlConnection(connectionString);

            SqlCommand cmdDocentes = new SqlCommand("EXEC sp_obtener_docentes", conexion);
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
            //TODO  hacer método
        }

        public void modificarDocente(Docente docente, string cedula)
        {
            //TODO  hacer método
        }

        public void ingresarDocente(Docente docente)
        {
            //TODO  hacer método para ingresar docentes.
        }
    }//clase
}//namespace
