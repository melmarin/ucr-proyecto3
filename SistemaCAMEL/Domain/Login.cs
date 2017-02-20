using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Login
    {

        private String usuario;
        private String clave;
        private String rol;

        public Login(string usuario, string clave, string rol)
        {
            this.usuario = usuario;
            this.clave = clave;
            this.rol = rol;
        }

        public Login()
        {
            this.usuario = "";
            this.clave = "";
            this.rol = "";
        }

        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public string Clave
        {
            get
            {
                return clave;
            }

            set
            {
                clave = value;
            }
        }

        public string Rol
        {
            get
            {
                return rol;
            }

            set
            {
                rol = value;
            }
        }
    }
}
