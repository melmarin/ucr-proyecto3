using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{

	[OperationContract]
	string GetData(int value);

	[OperationContract]
	CompositeType GetDataUsingDataContract(CompositeType composite);
    [OperationContract]
    CompositeType GetDataUsingDataContracta(CompositeType composite);

    // TODO: agregue aquí sus operaciones de servicio

    [OperationContract]//las operaciones que realizará el servicio
    string getTextoDePrueba();

    [OperationContract]
    string validar(Matricula parametros);


}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
[DataContract]
public class CompositeType
{
	bool boolValue = true;
	string stringValue = "Hello ";

	[DataMember]
	public bool BoolValue
	{
		get { return boolValue; }
		set { boolValue = value; }
	}

	[DataMember]
	public string StringValue
	{
		get { return stringValue; }
		set { stringValue = value; }
	}
}

[DataContract]//permite hacer la comunicación serializable y así comunicarse por la web
public class Matricula {

    string user = "Nombre_usuario";
    string pass = "Pass_usuario ";

    [DataMember]
    public string User
    {
        get { return user; }
        set { user = value; }
    }
    [DataMember]
    public string Pass
    {
        get { return pass; }
        set { pass = value; }
    }

}//matricula


    