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
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

    public string getTextoDePrueba()//interfaz generada
    {
        DocenteBusiness docente;
        String conectionString;
        conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
        docente = new DocenteBusiness(conectionString);
        LinkedList<Docente> docentes;
       // using (docentes = docente.obtenerDocentes())
            return "esto es una respuesta";
    }
}
