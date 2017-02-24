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
    public partial class IngresarCursoForm : System.Web.UI.Page
    {
        private String conectionString;
        private CursoBusiness cursoBusiness;
        //INSTANCIAR DOCENTE BUSINESS
        protected void Page_Load(object sender, EventArgs e)
        {
            conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
            cursoBusiness = new CursoBusiness(conectionString);

            if (!Page.IsPostBack)
            {
                LinkedList<Docente> docentes = new LinkedList<Docente>();
                //docentes = LA LISTA DE DOCENTES
                 
                //Llenando el dropDownList
                /*
                ddlEncargado.DataSource = listaEncargados;
                ddlEncargado.DataValueField = "cedula";
                ddlEncargado.DataTextField = "cedula";
                ddlEncargado.DataBind();
                ddlEncargado.SelectedIndex = ddlEncargado.Items.Count - 1;*/
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {

        }
    }
}