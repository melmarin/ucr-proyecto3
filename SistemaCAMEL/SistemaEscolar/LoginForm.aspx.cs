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
    public partial class LoginForm : System.Web.UI.Page
    {
        private String conectionString;
        private LoginBusiness loginBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
            loginBusiness = new LoginBusiness(conectionString);
        }

        
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string rol = loginBusiness.obtenerRol(tbUsuario.Text, passClave.Value);
            if (rol.Equals(""))
            {
                lbMensaje.Text = "Error usuario y/o contraseña incorrecta";
            }
            else if (rol.Equals("ADMI"))
            {
                Response.Redirect("~/AdmiView/InicioAdmiForm.aspx");
            }
            else if (rol.Equals("DOCENTE"))
            {
                Response.Redirect("~/DocenteView/InicioDocenteForm.aspx");
            }
        }
    }//class
}//namespace