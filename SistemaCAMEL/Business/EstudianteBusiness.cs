using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EstudianteBusiness
    {
        private EstudianteData estudianteData;

        public EstudianteBusiness(String cadenaConexion)
        {
            this.estudianteData = new EstudianteData(cadenaConexion);
        }//ctor

        public String InsertarEncargadoEstudiante(Estudiante estudiante)
        {
            return estudianteData.InsertarEncargadoEstudiante(estudiante);
        }//InsertarEncargadoEstudiante

        public String generarCarne()
        {
            return estudianteData.generarCarne();
        }//generarCarne

        }//class
}//namespace
