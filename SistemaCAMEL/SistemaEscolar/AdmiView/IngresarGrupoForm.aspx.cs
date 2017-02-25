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

            if (lbCursos.SelectedItem != null)
            {
                lbCursosSeleccionados.Items.Add(new ListItem(lbCursos.SelectedItem.Text, Convert.ToString(lbCursos.SelectedItem.Value)));
                lbCursos.Items.Remove(lbCursos.SelectedItem);
            }
        }

        protected void remover_onClick(object sender, EventArgs e)
        {
            if (lbCursosSeleccionados.SelectedItem != null)
            {
                lbCursos.Items.Add(new ListItem(lbCursosSeleccionados.SelectedItem.Text, Convert.ToString(lbCursosSeleccionados.SelectedItem.Value)));
                lbCursosSeleccionados.Items.Remove(lbCursosSeleccionados.SelectedItem);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            LinkedList<Curso> cursosSeleccionados = new LinkedList<Curso>();
            Curso curso = new Curso();

            for (int i = 0; i < lbCursosSeleccionados.Items.Count; i++)
            {
                curso = cursoBusiness.curso(lbCursosSeleccionados.Items[i].Value);
                cursosSeleccionados.AddLast(curso);
            }//for

            Grupo grupo = new Grupo();
            grupo = new Grupo(tbSeccion.Text, tbGrado.Text, Int32.Parse(tbAno.Text), cursosSeleccionados);
            lbMensaje.Text = grupoBusiness.insertar(grupo);

        }
    }
}