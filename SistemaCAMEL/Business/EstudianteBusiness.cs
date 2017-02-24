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

        public String InsertarEstudiante(Estudiante estudiante)
        {
            return estudianteData.InsertarEstudiante(estudiante);
        }//InsertarEstudiante

        public String generarCarne()
        {
            return estudianteData.generarCarne();
        }//generarCarne

        public LinkedList<Estudiante> obtenerEstudiantes()
        {
            return estudianteData.obtenerEstudiantes();
        }//obtenerEstudiantes

        public Estudiante obtenerEstudiante(String carne)
        {
            return estudianteData.obtenerEstudiante(carne);
        }//obtenerEstudiante

        public String Editar(Estudiante estudiante)
        {
            return estudianteData.Editar(estudiante);
        }//editar

        }//class
}//namespace
