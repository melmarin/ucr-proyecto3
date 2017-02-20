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

        public Curso(string sigla, string nombre)
        {
            this.sigla = sigla;
            this.nombre = nombre;
        }

        public Curso()
        {
            this.sigla = "";
            this.nombre = "";
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
    }
}
