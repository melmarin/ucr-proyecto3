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
        cmdInsertar.Parameters.Add(new SqlParameter("@seccion", seccion));
        cmdInsertar.Parameters.Add(new SqlParameter("@id_curso", idCurso));

        conexion.Open();
        cmdInsertar.ExecuteNonQuery();
        }//insertarCursoGrupo
        
    }//class
}//namspace
