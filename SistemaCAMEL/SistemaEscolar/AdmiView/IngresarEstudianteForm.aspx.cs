using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEscolar.AdmiView
{
    public partial class IngresarEstudianteForm : System.Web.UI.Page
    {
        private String conectionString;
        private EstudianteBusiness estudianteBusiness;
        private EncargadoEstudianteBusiness encargadoBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
            estudianteBusiness = new EstudianteBusiness(conectionString);
            encargadoBusiness = new EncargadoEstudianteBusiness(conectionString);

            if (!Page.IsPostBack)
            {
                LinkedList<EncargadoEstudiante> listaEncargados = new LinkedList<EncargadoEstudiante>();
                listaEncargados = encargadoBusiness.obtenerEncargados();
                //Llenando el dropDownList
                ddlEncargado.DataSource = listaEncargados;
                ddlEncargado.DataValueField = "cedula";
                ddlEncargado.DataTextField = "cedula";
                ddlEncargado.DataBind();
                ddlEncargado.SelectedIndex = ddlEncargado.Items.Count - 1;
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            //primero obtiene el encargado
            EncargadoEstudiante encargadoEstudiante;
            encargadoEstudiante = encargadoBusiness.obtenerEncargado(ddlEncargado.SelectedItem.Value);
            //crea el estudiante
            Estudiante estudiante;
            String carne = Convert.ToString(estudianteBusiness.generarCarne());

            estudiante = new Estudiante(carne, tb_cedula.Text,
                tb_nombre.Text, tb_apellidos.Text, encargadoEstudiante, "Activo");
            //inserta en la base
            lbMensaje.Text = estudianteBusiness.InsertarEstudiante(estudiante);
        }

        protected void ddlEncargado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }//class
}//namespace