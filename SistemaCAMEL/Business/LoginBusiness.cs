using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
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

        public string cambiarPass(string user,string pass)
        {
            return loginData.cambiarPass(user,pass);
        }

        public string obtenerMonto(string user)
        {
            cr.fi.bccr.indicadoreseconomicos.wsIndicadoresEconomicos cliente = new cr.fi.bccr.indicadoreseconomicos.wsIndicadoresEconomicos();
            DataSet tipoCambio = cliente.ObtenerIndicadoresEconomicos("317", DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"), "NombreEmpresa", "N");//retorna un DATASET
                                                                                                                                                                             //317 numero indica valor de compra, fecha inicio, fecha final, nombre de quien solicita, indicador de subniveles
            int monto=int.Parse( loginData.obtenerMonto(user));
            float valorTipoCambio =float.Parse (tipoCambio.Tables[0].Rows[0].ItemArray[2].ToString());
            int cambio = (int)valorTipoCambio;
            string resultado = (monto * cambio).ToString();
           
            return resultado;
        }

        public string pagar(string carnet)
        {
            return loginData.pagar(carnet);
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
