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
                    readerDocentes["correo"].ToString(), readerDocentes["direccion"].ToString()));

            }//while
            conexion.Close();
            return docentes;
        }//getDocentes

        public Docente obtenerDocente(Docente docente)
        {
            SqlConnection conexion = new SqlConnection(connectionString);

            SqlCommand cmdDocente = new SqlCommand();
            cmdDocente.CommandText = "sp_obtener_especialidades_docente";
            cmdDocente.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDocente.Connection = conexion;

            //configurar los parametros
            cmdDocente.Parameters.Add(new SqlParameter("@cedula", docente.Cedula));
            conexion.Open();

            SqlDataReader readerEspecialidades = cmdDocente.ExecuteReader();

            LinkedList<Especialidad> especialidades = new LinkedList<Especialidad>();

            while (readerEspecialidades.Read())
            {
                especialidades.AddLast(new Especialidad(readerEspecialidades["nombre"].ToString()));

            }//while
            Docente nuevoDocente = docente;
            docente.Especialidades = especialidades;
            return nuevoDocente;
        }//getDocentes

    }//clase
}//namespace
