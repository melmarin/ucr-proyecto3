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

        
        public void ingresarDocente(Docente docente)
        {
            docenteData.ingresarDocente(docente);
        }
        
        public void modificarDocente(Docente docente)
        {
            docenteData.modificarDocente(docente);
        }

        public void eliminarDocente(string cedula)
        {
            docenteData.eliminarDocente(cedula);
        }
       

        public Docente obtenerDocente(String cedula)
        {
            return docenteData.obtenerDocente(cedula);
        }
        }//class docenteBusiness
}
