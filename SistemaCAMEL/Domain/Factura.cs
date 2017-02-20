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
        private DateTime fecha_vencimiento;
        private float monto_total;
        private int recargo;
        private String estado;

        public Factura(int codigo, DateTime fecha, DateTime fecha_vencimiento, float monto_total, int recargo, string estado)
        {
            this.codigo = codigo;
            this.fecha = fecha;
            this.fecha_vencimiento = fecha_vencimiento;
            this.monto_total = monto_total;
            this.recargo = recargo;
            this.estado = estado;
        }

        public Factura()
        {
            this.codigo = 0;
            this.fecha = DateTime.Now;
            this.fecha_vencimiento = DateTime.Now;
            this.monto_total = 0;
            this.recargo = 0;
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

        public DateTime Fecha_vencimiento
        {
            get
            {
                return fecha_vencimiento;
            }

            set
            {
                fecha_vencimiento = value;
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

        public int Recargo
        {
            get
            {
                return recargo;
            }

            set
            {
                recargo = value;
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
