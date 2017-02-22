using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEscolar
{
    public partial class BusquedaEncargadoForm : System.Web.UI.Page
    {
        private String conectionString;
        private EncargadoEstudianteBusiness encargadoBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack == false)
            {
                LinkedList<EncargadoEstudiante> encargados = new LinkedList<EncargadoEstudiante>();
                encargados = encargadoBusiness.obtenerEncargados();
                gvEncargados.DataSource = encargados;
                gvEncargados.DataBind();
            }//if
        }
        public BusquedaEncargadoForm()
        {
            conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
            encargadoBusiness = new EncargadoEstudianteBusiness(conectionString);
        }//constructor

      
    }//class
}//namespace