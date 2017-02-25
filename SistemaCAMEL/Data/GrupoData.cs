using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class GrupoData
    {
        private String cadenaConexion;

        public GrupoData(string connectionString)
        {
            this.cadenaConexion = connectionString;
        }//ctor

        public String insertar(Grupo grupo)
        {           
                SqlConnection conexion = new SqlConnection(this.cadenaConexion);
                SqlCommand cmdInsertar = new SqlCommand();
                cmdInsertar.CommandText = "sp_insertar_grupo";
                cmdInsertar.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsertar.Connection = conexion;

                //configurar los parametros
                cmdInsertar.Parameters.Add(new SqlParameter("@seccion", grupo.Seccion));
                cmdInsertar.Parameters.Add(new SqlParameter("@grado", grupo.Grado));
                cmdInsertar.Parameters.Add(new SqlParameter("@ano", grupo.Ano));

                conexion.Open();
                String mensaje = "";
                if (cmdInsertar.ExecuteNonQuery() > 0)
                {
                    mensaje = "La inserción del curso fue correcta";
                foreach (Curso curso in grupo.Cursos)
                {
                    this.insertarCursoGrupo(grupo.Seccion, curso.Sigla);
                }//foreach

                }//if
                else
                    mensaje = "No se pudo realizar la inserción del curso";
                conexion.Close();
            
            return mensaje;
        }//insertar

    private void insertarCursoGrupo(string seccion, string idCurso)
    {
        SqlConnection conexion = new SqlConnection(this.cadenaConexion);
        SqlCommand cmdInsertar = new SqlCommand();
        cmdInsertar.CommandText = "sp_insertar_curso_grupo";
        cmdInsertar.CommandType = System.Data.CommandType.StoredProcedure;
        cmdInsertar.Connection = conexion;

        //configurar los parametros
        cmdInsertar.Parameters.Add(new SqlParameter("@id_curso", idCurso));
        cmdInsertar.Parameters.Add(new SqlParameter("@seccion", seccion));

        conexion.Open();
        cmdInsertar.ExecuteNonQuery();
        conexion.Close();
        }//insertarCursoGrupo

        public LinkedList<Grupo> obtenerGrupos()
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdObtenerGrupos = new SqlCommand();
            cmdObtenerGrupos.CommandText = "sp_obtener_grupos";
            cmdObtenerGrupos.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtenerGrupos.Connection = conexion;

            conexion.Open();
            SqlDataReader drGrupos = cmdObtenerGrupos.ExecuteReader();
            LinkedList<Grupo> grupos = new LinkedList<Grupo>();
            Grupo grupo = new Grupo();

            while (drGrupos.Read())
            {

                grupo = new Grupo(drGrupos["seccion"].ToString(), drGrupos["grado"].ToString(),
                    Int32.Parse(drGrupos["ano"].ToString()));

                grupos.AddLast(grupo);
            }//while
            conexion.Close();
            return grupos;
        }//obtenerGrupos

        public Grupo obtenerGrupo(string seccion)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);
            SqlCommand cmdObtenerGrupos = new SqlCommand();
            cmdObtenerGrupos.CommandText = "sp_obtener_grupo";
            cmdObtenerGrupos.CommandType = System.Data.CommandType.StoredProcedure;
            cmdObtenerGrupos.Connection = conexion;

            //configurar los parametros
            cmdObtenerGrupos.Parameters.Add(new SqlParameter("@seccion", seccion));

            conexion.Open();
            SqlDataReader drGrupos = cmdObtenerGrupos.ExecuteReader();
            Grupo grupo = new Grupo();

            while (drGrupos.Read())
            {

                grupo = new Grupo(drGrupos["seccion"].ToString(), drGrupos["grado"].ToString(),
                    Int32.Parse(drGrupos["ano"].ToString()));

            }//while
            conexion.Close();
            return grupo;
        }//obtenerGrupo

    }//class

}//namspace
