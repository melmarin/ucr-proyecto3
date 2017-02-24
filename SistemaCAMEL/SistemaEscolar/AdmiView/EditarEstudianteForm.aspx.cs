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
    public partial class EditarEstudianteForm : System.Web.UI.Page
    {
        private String conectionString;
        private EstudianteBusiness estudianteBusiness;
        private EncargadoEstudianteBusiness encargadoBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
            estudianteBusiness = new EstudianteBusiness(conectionString);
            encargadoBusiness = new EncargadoEstudianteBusiness(conectionString);


            if (Page.IsPostBack == false)
            {
                String carne = Request.Params["carne"];
                Estudiante estudiante = estudianteBusiness.obtenerEstudiante(carne);
                tbCarne.Text = estudiante.Carne;
                tb_cedula.Text = estudiante.Cedula;
                tb_apellidos.Text = estudiante.Apellidos;
                tb_nombre.Text = estudiante.Nombre;

                LinkedList<EncargadoEstudiante> listaEncargados = new LinkedList<EncargadoEstudiante>();
                listaEncargados = encargadoBusiness.obtenerEncargados();
                //Llenando el dropDownList
                ddlEncargado.DataSource = listaEncargados;
                ddlEncargado.DataValueField = "cedula";
                ddlEncargado.DataTextField = "cedula";
                ddlEncargado.DataBind();
                ddlEncargado.SelectedIndex = ddlEncargado.Items.Count - 1;
            }//if
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            //primero obtiene el encargado
            EncargadoEstudiante encargadoEstudiante;
            encargadoEstudiante = encargadoBusiness.obtenerEncargado(ddlEncargado.SelectedItem.Value);
            //crea el estudiante
            Estudiante estudiante;

            estudiante = new Estudiante(tbCarne.Text, tb_cedula.Text,
                tb_nombre.Text, tb_apellidos.Text, encargadoEstudiante, "Activo");
            //inserta en la base
            lbMensaje.Text = estudianteBusiness.InsertarEstudiante(estudiante);
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            //primero obtiene el encargado
            EncargadoEstudiante encargadoEstudiante;
            encargadoEstudiante = encargadoBusiness.obtenerEncargado(ddlEncargado.SelectedItem.Value);
            //crea el estudiante
            Estudiante estudiante;

            estudiante = new Estudiante(tbCarne.Text, tb_cedula.Text,
                tb_nombre.Text, tb_apellidos.Text, encargadoEstudiante, "Inactivo");
            //inserta en la base
            lbMensaje.Text = estudianteBusiness.InsertarEstudiante(estudiante);
        }

        protected void ddlEncargado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }//class
}//namespace