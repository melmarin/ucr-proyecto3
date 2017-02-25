using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MatriculaBusiness
    {
        private MatriculaData matriculaData;

        public MatriculaBusiness(String cadenaConexion)
        {
            this.matriculaData = new MatriculaData(cadenaConexion);
        }

        public string insertar(Matricula matricula)
        {
            return matriculaData.insertar(matricula);
        }
        }//class
}//namespace
