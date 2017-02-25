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
    public partial class IngresarGrupoForm : System.Web.UI.Page
    {
        private String conectionString;
        private CursoBusiness cursoBusiness;
        private GrupoBusiness grupoBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
            cursoBusiness = new CursoBusiness(conectionString);
            grupoBusiness = new GrupoBusiness(conectionString);
            LinkedList<Curso> cursos = new LinkedList<Curso>();
            cursos = cursoBusiness.cursos(); 

            if (!Page.IsPostBack)
            {
                //Llenando el list
                lbCursos.DataSource = cursos;
                lbCursos.DataValueField = "sigla";
                lbCursos.DataTextField = "nombre";
                lbCursos.DataBind();
            }
        }

        protected void agregar_onClick(object sender, EventArgs e)
        {

        }

        protected void remover_onClick(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}