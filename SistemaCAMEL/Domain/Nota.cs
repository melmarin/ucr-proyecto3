using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Nota
    {
        private Estudiante estudiante;
        private int calificacion;
        private Curso curso;
        private Grupo grupo;

        public Nota()
        {
            this.estudiante = new Estudiante();
            this.calificacion = 0;
            this.curso = new Curso();
            this.grupo = new Grupo();

        }//constructor

        public Nota(Estudiante estudiante, int calificacion, Curso curso, Grupo grupo)
        {
            this.estudiante = estudiante;
            this.calificacion = calificacion;
            this.curso = curso;
            this.grupo = grupo;
        }//constructor

        public Estudiante Estudiante
        {
            get
            {
                return estudiante;
            }

            set
            {
                estudiante = value;
            }
        }

        public int Calificacion
        {
            get
            {
                return calificacion;
            }

            set
            {
                calificacion = value;
            }
        }

        public Curso Curso
        {
            get
            {
                return curso;
            }

            set
            {
                curso = value;
            }
        }

        public Grupo Grupo
        {
            get
            {
                return grupo;
            }

            set
            {
                grupo = value;
            }
        }
    }//class
}//namespace
