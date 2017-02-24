using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CursoBusiness
    {
        private CursoData cursoData;

        public CursoBusiness(String cadenaConexion)
        {
            cursoData = new CursoData(cadenaConexion);
        }//ctor

        public String insertar(Curso curso)
        {
            return cursoData.insertar(curso);
        }//insertar

        /*public LinkedList<Curso> cursos()
        {
            return cursoData.cursos();
        }//cursos*/
        }//class
}//namespace
