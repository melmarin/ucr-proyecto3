using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Estudiante
    {
        private String carne;
        private String cedula;
        private String nombre;
        private String apellidos;
        private EncargadoEstudiante encargado;

        public Estudiante()
        {
            this.Carne = "";
            this.cedula = "";
            this.nombre = "";
            this.apellidos = "";
            this.encargado = new EncargadoEstudiante(); 
        }//constructor

        public Estudiante(String carne, String cedula, String nombre, String apellidos, EncargadoEstudiante encargado)
        {
            this.Carne = carne;
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Encargado = encargado;
        }//consturctor

        public string Carne
        {
            get
            {
                return carne;
            }

            set
            {
                carne = value;
            }
        }

        public string Cedula
        {
            get
            {
                return cedula;
            }

            set
            {
                cedula = value;
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

        public string Apellidos
        {
            get
            {
                return apellidos;
            }

            set
            {
                apellidos = value;
            }
        }

        public EncargadoEstudiante Encargado
        {
            get
            {
                return encargado;
            }

            set
            {
                encargado = value;
            }
        }


    }//class
}//namespace
