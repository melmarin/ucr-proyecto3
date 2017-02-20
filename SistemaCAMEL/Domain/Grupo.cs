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

        public Grupo(string seccion, string grado, int ano)
        {
            this.seccion = seccion;
            this.grado = grado;
            this.ano = ano;
        }

        public Grupo()
        {
            this.seccion = "";
            this.grado = "";
            this.ano = 0;
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
    }
}
