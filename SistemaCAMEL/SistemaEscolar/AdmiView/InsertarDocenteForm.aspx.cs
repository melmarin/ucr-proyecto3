using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Business;
using System.Web.Configuration;

namespace SistemaEscolar.AdmiView
{
    public partial class InsertarDocenteForm : System.Web.UI.Page
    {
        private String conectionString;
        private DocenteBusiness docenteBusiness;
        private LinkedList<Domain.Docente> listaDocentes;

        public InsertarDocenteForm()
        {
            conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
            docenteBusiness = new DocenteBusiness(conectionString);
            listaDocentes = new LinkedList<Domain.Docente>();
            listaDocentes = docenteBusiness.obtenerDocentes();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Llenado del dropDown
                ddl_cedulas.DataSource = listaDocentes;
                ddl_cedulas.DataValueField = "cedula";
                ddl_cedulas.DataTextField = "cedula";
                ddl_cedulas.DataBind();
                ddl_cedulas.SelectedIndex = ddl_cedulas.Items.Count - 1;
            }
        }

        protected void btn_Consultar_Click(object sender, EventArgs e)
        {

            Domain.Docente docente = new Domain.Docente();
            string valorCedula = ddl_cedulas.Text;
            while (listaDocentes.Count != 0)
            {
                docente = listaDocentes.First();
                if (docente.Cedula == valorCedula)
                {
                    break;
                }
                else
                {
                    listaDocentes.RemoveFirst();
                }
            }//while

            tb_cedula.Text = docente.Cedula;
            tb_nombre.Text = docente.Nombre;
            tb_apellidos.Text = docente.Apellidos;
            tb_telefono.Text = docente.Telefono;
            tb_correo.Text = docente.Correo;
            tb_direccion.Text = docente.Direccion;
            tb_especialidad.Text = docente.Especialidad;
        }

        protected void btn_insertar_Click(object sender, EventArgs e)
        {
            Domain.Docente docente = new Domain.Docente(tb_cedula.Text, tb_nombre.Text, tb_apellidos.Text, 
                tb_telefono.Text, tb_correo.Text, tb_direccion.Text, tb_especialidad.Text);

            docenteBusiness.ingresarDocente(docente);
        }

        protected void btn_editar_Click(object sender, EventArgs e)
        {
            string cedula = tb_cedula.Text;
            Domain.Docente docente = new Domain.Docente(tb_cedula.Text, tb_nombre.Text, tb_apellidos.Text,
                tb_telefono.Text, tb_correo.Text, tb_direccion.Text, tb_especialidad.Text);
            docenteBusiness.modificarDocente(docente, cedula);
        }

        protected void btn_borrar_Click(object sender, EventArgs e)
        {
            string cedula = tb_cedula.Text;
            docenteBusiness.eliminarDocente(cedula);
        }
    }
}