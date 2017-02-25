using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class LoginBusiness
    {
        private LoginData loginData;

        public LoginBusiness(String cadenaConexion)
        {
            this.loginData = new LoginData(cadenaConexion);
        }//ctor

        public String obtenerRol(string usuario, string clave)
        {
            return loginData.obtenerRol(usuario, clave);
        }//obtenerRol

        public string validarEncargado(string usuario, string clave)
        {
            return loginData.validarEncargado(usuario, clave);
        }

        public String generarUsuario()
        {
            return loginData.generarUsuario();
        }

        public String generarClave()
        {
            return loginData.generarClave();
        }

        public bool insertarLogin(string usuario, string clave, string rol)
        {
            return loginData.insertarLogin(usuario, clave, rol);
        }
        }//class
}//namespace
