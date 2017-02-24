using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data;

namespace Business
{
    public class DocenteBusiness{
        private DocenteData docenteData;

        public DocenteBusiness(String cadenaConexion)
        {
            docenteData = new DocenteData(cadenaConexion);
        }//constructor

        public LinkedList<Docente> obtenerDocentes() {
            return docenteData.obtenerDocentes();
        }

  
    }//class docenteBusiness
}
