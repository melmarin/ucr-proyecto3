using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEscolar
{
    public partial class IngresarEncargadoEstudianteForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            String conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
            EncargadoEstudianteBusiness encargadoBusiness = new EncargadoEstudianteBusiness(conectionString);
            lbMensaje.Text = encargadoBusiness.Insertar(new Domain.EncargadoEstudiante(tb_cedula.Text, tb_nombre.Text, 
                tb_apellidos.Text, tb_telefono.Text, tb_correo.Text, tb_direccion.Text));
        }
    }
}