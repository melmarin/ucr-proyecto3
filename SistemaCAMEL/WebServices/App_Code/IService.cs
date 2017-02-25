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
    LinkedList<string> consulta(string usuario);

    [OperationContract]
    string consulta2(string user);


    [OperationContract]
    string login(string user, string pass);

    [OperationContract]
    string validar(Matricula parametros);
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


    