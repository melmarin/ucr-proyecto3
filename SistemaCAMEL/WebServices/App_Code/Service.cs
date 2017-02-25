using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Business;
using Domain;
using System.Web.Configuration;
using System.Diagnostics;
using Domain;
using Business;


public class Service : IService
{
    public LinkedList<string> consulta(string usuario)
      {
        LinkedList<string> login = new LinkedList<string>();
        login.AddLast(usuario+"User");
        login.AddLast(usuario +"pass4");
        return login ;
    }

    public string consulta2(string user)
    {
        
        return "esto es un texto del servidor-******-usuario "+user ;
    }

    public string login(string user, string pass)
    {
        string conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
        Login login = new Login();
        login.Usuario = user;
        login.Clave = pass;
        LoginBusiness loginBusiness = new LoginBusiness(conectionString);
        string resultado = loginBusiness.validarEncargado(user, pass);

        return resultado;
    }

    public string validar(Matricula parametros)
    {
        if (parametros == null)
        {
            //throw new ArgumentNullException("parametros");
            return "fallo el envío de deatos... aparentemente un null pointer";
        }
        else {

            return " El usuario es: " + parametros.User + " y la contrasena: " + parametros.Pass;
        }
    }

}
