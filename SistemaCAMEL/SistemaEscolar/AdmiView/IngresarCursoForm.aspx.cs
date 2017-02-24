using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;

namespace SistemaEscolar.AdmiView
{
    public partial class IngresarCursoForm : System.Web.UI.Page
    {
        private String conectionString;
        private CursoBusiness cursoBusiness;
        private DocenteBusiness docenteBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
            cursoBusiness = new CursoBusiness(conectionString);
            docenteBusiness = new DocenteBusiness(conectionString);

            if (!Page.IsPostBack)
            {
                LinkedList<Domain.Docente> docentes = new LinkedList<Domain.Docente>();
                docentes = docenteBusiness.obtenerDocentes();
                //docentes = LA LISTA DE DOCENTES
                 
                //Llenando el dropDownList
                
                ddlDocentes.DataSource = docentes;
                ddlDocentes.DataValueField = "cedula";
                ddlDocentes.DataTextField = "cedula";
                ddlDocentes.DataBind();
                ddlDocentes.SelectedIndex = ddlDocentes.Items.Count - 1;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            //primero obtiene el docente
            Domain.Docente docente = new Domain.Docente();
            docente = docenteBusiness.obtenerDocente(ddlDocentes.SelectedItem.Value);

            Curso curso = new Curso(tbSigla.Text, tbNombre.Text, docente);
            //inserta en la base
            lbMensaje.Text = cursoBusiness.insertar(curso);
        }
    }
}