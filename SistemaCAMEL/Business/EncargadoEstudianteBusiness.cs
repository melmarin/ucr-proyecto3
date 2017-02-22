using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EncargadoEstudianteBusiness
    {
        private EncargadoEstudianteData encargadoEstudianteData;

        public EncargadoEstudianteBusiness(String cadenaConexion)
        {
            encargadoEstudianteData = new EncargadoEstudianteData(cadenaConexion);
        }//constructor

        public String Insertar(EncargadoEstudiante encargadoEstudiante)
        {
            return encargadoEstudianteData.Insertar(encargadoEstudiante);
        }//Insertar

        public String Editar(EncargadoEstudiante encargadoEstudiante)
        {
            return encargadoEstudianteData.Editar(encargadoEstudiante);
        }//Editar

        public EncargadoEstudiante obtenerEncargado(String cedula)
        {
            return encargadoEstudianteData.obtenerEncargado(cedula);
        }//obtenerEncargado

        public LinkedList<EncargadoEstudiante> obtenerEncargados()
        {
            return encargadoEstudianteData.obtenerEncargados();
        }//obtenerEncargados

        public String Eliminar(String cedula)
        {
            return encargadoEstudianteData.Eliminar(cedula);
        }//Eliminar

        }//class
}//namespace
