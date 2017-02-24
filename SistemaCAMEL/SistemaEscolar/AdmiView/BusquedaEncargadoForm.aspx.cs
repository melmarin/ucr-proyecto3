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
    public partial class BusquedaEncargadoForm : System.Web.UI.Page
    {
        private String conectionString;
        private EncargadoEstudianteBusiness encargadoBusiness;
        private LinkedList<EncargadoEstudiante> encargados;

        protected void Page_Load(object sender, EventArgs e)
        {
            conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
            encargadoBusiness = new EncargadoEstudianteBusiness(conectionString);

            if (Page.IsPostBack == false)
            {
                encargados = new LinkedList<EncargadoEstudiante>();
                encargados = encargadoBusiness.obtenerEncargados();
                gvEncargados.DataSource = encargados;
                gvEncargados.DataBind();
            }//if
        }

        protected void btnNombre_Click(object sender, EventArgs e)
        {
            encargados = encargadoBusiness.obtenerEncargadosNombre(tbNombre.Text);
            gvEncargados.DataSource = encargados;
            gvEncargados.DataBind();
        }

        protected void btnCedula_Click(object sender, EventArgs e)
        {
            encargados = new LinkedList<EncargadoEstudiante>();
            encargados.AddLast(encargadoBusiness.obtenerEncargado(tbCedula.Text));
            gvEncargados.DataSource = encargados;
            gvEncargados.DataBind();
        }

        protected void gvEncargados_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void editarClick(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            string id = Convert.ToString(gvEncargados.DataKeys[index].Value);
            Response.Redirect("/AdmiView/EditarEncargadoForm.aspx?cedula=" + id);

        }


    }//class
}//namespace