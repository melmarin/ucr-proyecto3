using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Business;
using System.Web.Configuration;

namespace SistemaEscolar
{
    public partial class InsertarDocenteForm : System.Web.UI.Page
    {
        private String conectionString;
        private DocenteBusiness docenteBusiness;
        private LinkedList<Docente> listaDocentes;
        private LinkedList<Docente> listaDocentes2;
        public InsertarDocenteForm()
        {
            conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
            docenteBusiness = new DocenteBusiness(conectionString);
            listaDocentes = new LinkedList<Docente>();
            listaDocentes = docenteBusiness.obtenerDocentes();
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Llenado del dropDown
                ddlDocentes.DataSource = listaDocentes;
                ddlDocentes.DataValueField = "cedula";
                ddlDocentes.DataTextField = "cedula";
                ddlDocentes.DataBind();
                ddlDocentes.SelectedIndex = ddlDocentes.Items.Count - 1;
            }
        }//page_load

        protected void btn_consultar_Click(object sender, EventArgs e)
        {

            Docente docente = new Docente();
            string valorCedula = ddlDocentes.Text;
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
              docente = docenteBusiness.obtenerDocente(docente);
              LinkedList<Especialidad> especialidades = docente.Especialidades;
             Especialidad especialidad= new Especialidad();
               string salidaEspec="";
             while (especialidades.Count != 0)
             {
                 especialidad = especialidades.First();
                 salidaEspec += especialidad.Nombre;
                 especialidades.RemoveFirst();
                 if (especialidades.Count != 0)
                 {
                     salidaEspec += ", ";
                 }
                 else { break; }


             }//while 


            lbl_cedula.Text = docente.Cedula;
            lbl_nombre.Text = docente.Nombre;
            lbl_apellidos.Text = docente.Apellidos;
            lbl_telefono.Text = docente.Telefono;
            lbl_correo.Text = docente.Correo;
            lbl_direccion.Text = docente.Direccion;
            tb_especialidades.Text = salidaEspec;    
        }//consultar
    }
}