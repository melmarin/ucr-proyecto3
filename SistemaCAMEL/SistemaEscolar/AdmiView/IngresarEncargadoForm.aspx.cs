using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEscolar.AdmiView
{
    public partial class IngresarEncargadoForm : System.Web.UI.Page
    {
        private String conectionString;
        private EncargadoEstudianteBusiness encargadoBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
            encargadoBusiness = new EncargadoEstudianteBusiness(conectionString);
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            lbMensaje.Text = encargadoBusiness.Insertar(new Domain.EncargadoEstudiante(tb_cedula.Text, tb_nombre.Text,
               tb_apellidos.Text, tb_telefono.Text, tb_correo.Text, tb_direccion.Text));
        }//btnInsertar_Click
    }//class
}//namespace