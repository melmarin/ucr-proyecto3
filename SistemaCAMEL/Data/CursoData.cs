using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CursoData
    {
        private String cadenaConexion;

        public CursoData(string connectionString)
        {
            this.cadenaConexion = connectionString;
        }

        public String insertar(Curso curso)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdInsertar = new SqlCommand();
            cmdInsertar.CommandText = "sp_insertar_curso";
            cmdInsertar.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertar.Connection = conexion;

            //configurar los parametros
            cmdInsertar.Parameters.Add(new SqlParameter("@sigla", curso.Sigla));
            cmdInsertar.Parameters.Add(new SqlParameter("@nombre", curso.Nombre));
            cmdInsertar.Parameters.Add(new SqlParameter("@cedula_docente", curso.Docente.Cedula));

            conexion.Open();
            String mensaje = "";
            if (cmdInsertar.ExecuteNonQuery() > 0)
            {
                mensaje = "La inserción del curso fue correcta";
            }
            else
                mensaje = "No se pudo realizar la inserción del curso";
            conexion.Close();
            return mensaje;
        }//insertar

        public LinkedList<Curso> cursos()
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdObtener = new SqlCommand();
            cmdObtener.CommandText = "sp_obtener_cursos";
            cmdObtener.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtener.Connection = conexion;

            conexion.Open();
            SqlDataReader drCursos = cmdObtener.ExecuteReader();
            LinkedList<Curso> cursos = new LinkedList<Curso>();
            Curso curso = new Curso();
            Docente docente = new Docente();
            DocenteData docenteData = new DocenteData(cadenaConexion);

            while (drCursos.Read())
            {
                docente = docenteData.obtenerDocente(drCursos["id_docente"].ToString());
                curso = new Curso(drCursos["sigla"].ToString(),
                    drCursos["nombre"].ToString(), docente);

                cursos.AddLast(curso);
            }//while
            conexion.Close();
            return cursos;
        }

        public Curso curso(string sigla)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdObtener = new SqlCommand();
            cmdObtener.CommandText = "sp_obtener_curso";
            cmdObtener.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtener.Connection = conexion;
            //configurar los parametros
            cmdObtener.Parameters.Add(new SqlParameter("@sigla", sigla));

            conexion.Open();
            SqlDataReader drCursos = cmdObtener.ExecuteReader();
            Curso curso = new Curso();
            Docente docente = new Docente();
            DocenteData docenteData = new DocenteData(cadenaConexion);

            while (drCursos.Read())
            {
                docente = docenteData.obtenerDocente(drCursos["id_docente"].ToString());
                curso = new Curso(drCursos["sigla"].ToString(),
                    drCursos["nombre"].ToString(), docente);

            }//while
            conexion.Close();
            return curso;
        }

    }//class
}//namespace
