using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Curso
    {
        private String sigla;
        private String nombre;
        private Docente docente; 

        public Curso(string sigla, string nombre, Docente docente)
        {
            this.sigla = sigla;
            this.nombre = nombre;
            this.docente = docente;
        }

        public Curso()
        {
            this.sigla = "";
            this.nombre = "";
            this.docente = new Docente();
        }

        public string Sigla
        {
            get
            {
                return sigla;
            }

            set
            {
                sigla = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public Docente Docente
        {
            get
            {
                return docente;
            }

            set
            {
                docente = value;
            }
        }
    }
}
