using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class FacturaBusiness
    {
        FacturaData facturaData;

        public FacturaBusiness(String cadenaConexion)
        {
            this.facturaData = new FacturaData(cadenaConexion);
        }//ctor

        public String insertar(Factura factura)
        {
            return facturaData.insertar(factura);
        }//insertar

        public float calcularMonto(string grupo)
        {
            return facturaData.calcularMonto(grupo);
        }

        }//class
}//namespace
