using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Grupo
    {
        private string seccion;
        private string grado;
        private int ano;
        private LinkedList<Curso> cursos;

        public Grupo()
        {

        }//ctor

        public Grupo(string seccion, string grado, int ano, LinkedList<Curso> cursos)
        {
            this.seccion = seccion;
            this.grado = grado;
            this.ano = ano;
            this.cursos = cursos;
        }//ctor

        public string Seccion
        {
            get
            {
                return seccion;
            }

            set
            {
                seccion = value;
            }
        }

        public string Grado
        {
            get
            {
                return grado;
            }

            set
            {
                grado = value;
            }
        }

        public int Ano
        {
            get
            {
                return ano;
            }

            set
            {
                ano = value;
            }
        }

        public LinkedList<Curso> Cursos
        {
            get
            {
                return cursos;
            }

            set
            {
                cursos = value;
            }
        }
    }//class
}//namespace
