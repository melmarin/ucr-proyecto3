using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Grupo
    {
        private String seccion;
        private String grado;
        private int ano;
        private LinkedList<Estudiante> listaEstudiantes;
        private LinkedList<Curso> listaCursos;

        public Grupo(string seccion, string grado, int ano, LinkedList<Estudiante> listaEstudiantes, LinkedList<Curso> listaCursos)
        {
            this.seccion = seccion;
            this.grado = grado;
            this.ano = ano;
            this.listaEstudiantes = listaEstudiantes;
            this.listaCursos = listaCursos;
        }
        public Grupo()
        {
            this.seccion = "";
            this.grado = "";
            this.ano = 0;
            this.listaEstudiantes = new LinkedList<Estudiante>();
            this.listaCursos = new LinkedList<Curso>();
        }

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

        public LinkedList<Estudiante> ListaEstudiantes
        {
            get
            {
                return listaEstudiantes;
            }

            set
            {
                listaEstudiantes = value;
            }
        }

        public LinkedList<Curso> ListaCursos
        {
            get
            {
                return listaCursos;
            }

            set
            {
                listaCursos = value;
            }
        }
    }
}
