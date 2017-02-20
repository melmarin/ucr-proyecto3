using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Docente
    {
        private String cedula;
        private String nombre;
        private String apellidos;
        private String telefono;
        private String correo;
        private String direccion;
        private LinkedList<Especialidad> especialidades;

        public Docente()
        {
            this.cedula = "";
            this.nombre = "";
            this.apellidos = "";
            this.telefono = "";
            this.correo = "";
            this.direccion = "";
            this.especialidades = new LinkedList<Especialidad>();

        }//constructor
        public Docente(string cedula, string nombre, string apellidos, string telefono, string correo, string direccion, LinkedList<Especialidad> especialidades)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.correo = correo;
            this.direccion = direccion;
            this.especialidades = especialidades;
        }//constructor

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

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public LinkedList<Especialidad> Especialidades
        {
            get
            {
                return especialidades;
            }

            set
            {
                especialidades = value;
            }
        }
    }//class
}//namespace
