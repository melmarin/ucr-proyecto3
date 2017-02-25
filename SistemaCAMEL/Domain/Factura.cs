using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Factura
    {
        private int codigo;
        private DateTime fecha;
        private float monto_total;
        private String estado;

        public Factura(float monto_total, string estado)
        {
            this.fecha = DateTime.Now;
            this.monto_total = monto_total;
            this.estado = estado;
        }

        public Factura()
        {
            this.codigo = 0;
            this.fecha = DateTime.Now;
            this.monto_total = 0;
            this.estado = "";
        }

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public float Monto_total
        {
            get
            {
                return monto_total;
            }

            set
            {
                monto_total = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }
    }
}
