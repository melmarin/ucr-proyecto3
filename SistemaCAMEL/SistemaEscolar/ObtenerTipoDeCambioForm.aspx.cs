using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SistemaEscolar
{
    public partial class ObtenerTipoDeCambioForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cr.fi.bccr.indicadoreseconomicos.wsIndicadoresEconomicos cliente = new cr.fi.bccr.indicadoreseconomicos.wsIndicadoresEconomicos();
            DataSet tipoCambio= cliente.ObtenerIndicadoresEconomicos("317", DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"), "NombreEmpresa", "N");//retorna un DATASET
             //317 numero indica valor de compra, fecha inicio, fecha final, nombre de quien solicita, indicador de subniveles

            tb_resultado.Text = (tipoCambio.Tables[0].Rows[0].ItemArray[2].ToString());
            tb_fecha.Text = ( tipoCambio.Tables[0].Rows[0].ItemArray[1].ToString());
            tb_codigo.Text = ( tipoCambio.Tables[0].Rows[0].ItemArray[0].ToString());
        }
    }
}