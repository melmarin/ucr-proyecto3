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
    public partial class BuscarEstudianteForm : System.Web.UI.Page
    {
        private String conectionString;
        private EstudianteBusiness estudianteBusiness;
        private LinkedList<Estudiante> estudiantes;

        protected void Page_Load(object sender, EventArgs e)
        {
            conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
            estudianteBusiness = new EstudianteBusiness(conectionString);

            if (Page.IsPostBack == false)
            {
                estudiantes = new LinkedList<Estudiante>();
                estudiantes = estudianteBusiness.obtenerEstudiantes();
                gvEstudiantes.DataSource = estudiantes;
                gvEstudiantes.DataBind();
            }//if
        }

        protected void btnNombre_Click(object sender, EventArgs e)
        {

        }

        protected void btnCedula_Click(object sender, EventArgs e)
        {
            estudiantes = new LinkedList<Estudiante>();
            estudiantes.AddLast(estudianteBusiness.obtenerEstudiante(tbCarne.Text));
            gvEstudiantes.DataSource = estudiantes;
            gvEstudiantes.DataBind();
        }

        protected void editarClick(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            string id = Convert.ToString(gvEstudiantes.DataKeys[index].Value);
            Response.Redirect("/AdmiView/EditarEstudianteForm.aspx?carne=" + id);
        }

        protected void gvEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}