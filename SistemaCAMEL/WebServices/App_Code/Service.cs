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
