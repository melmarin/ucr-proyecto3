using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Especialidad
    {
        private String nombre;

        public Especialidad()
        {
            this.nombre = "";
        }//constructor

        public Especialidad(string nombre)
        {
            this.nombre = nombre;
        }//constructor

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
    }//class
}//namespace
