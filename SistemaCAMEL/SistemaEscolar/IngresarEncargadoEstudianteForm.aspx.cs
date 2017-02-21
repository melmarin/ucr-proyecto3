using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEscolar
{
    public partial class IngresarEncargadoEstudianteForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EncargadoEstudianteBusiness encargadoBusiness = new EncargadoEstudianteBusiness();
            lblMensaje.Text = encargadoBusiness.insertar(new Encargado(tb_cedula,tb_nombre,tb_apellidos,tb_telefono,tb_correo,tb_direccion));
        }
    }
}