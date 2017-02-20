using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data;

namespace Business
{
    public class EstudianteBusiness
    {

        private EstudianteData personaData;


        public EstudianteBusiness()
        {
            this.personaData = new EstudianteData();
        }//constructor

        public String insertarPersona(Estudiante estudiantes)
        {
            return personaData.insertarEstudiante(estudiante);
        }
    }//class
}//namespace
