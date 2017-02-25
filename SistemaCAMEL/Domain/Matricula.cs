using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Matricula
    {
        private Factura factura;
        private Grupo grupo;
        private Estudiante estudiante;
        private Login login;

        public Matricula(Factura factura, Grupo grupo, Estudiante estudiante, Login login)
        {
            this.factura = factura;
            this.grupo = grupo;
            this.estudiante = estudiante;
            this.login = login;
        }

        public Matricula()
        {

        }

        public Factura Factura
        {
            get
            {
                return factura;
            }

            set
            {
                factura = value;
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

        public Login Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }
    }//Matricula
}//namespace
