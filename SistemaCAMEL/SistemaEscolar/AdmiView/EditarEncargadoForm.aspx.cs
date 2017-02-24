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
    public partial class EditarEncargadoForm : System.Web.UI.Page
    {
        private String conectionString;
        private EncargadoEstudianteBusiness encargadoBusiness;
        private EncargadoEstudiante encargadoEstudiante;

        protected void Page_Load(object sender, EventArgs e)
        {
            conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
            encargadoBusiness = new EncargadoEstudianteBusiness(conectionString);

            if (Page.IsPostBack == false)
            {
                String cedula = Request.Params["cedula"];
                encargadoEstudiante = encargadoBusiness.obtenerEncargado(cedula);
                tb_cedula.Text = encargadoEstudiante.Cedula;
                tb_nombre.Text = encargadoEstudiante.Nombre;
                tb_apellidos.Text = encargadoEstudiante.Apellidos;
                tb_correo.Text = encargadoEstudiante.Correo;
                tb_telefono.Text = encargadoEstudiante.Telefono;
                tb_direccion.Text = encargadoEstudiante.Direccion;
            }//if
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            encargadoEstudiante = new EncargadoEstudiante(tb_cedula.Text, tb_nombre.Text,
               tb_apellidos.Text, tb_telefono.Text, tb_correo.Text, tb_direccion.Text);
            lbMensaje.Text = encargadoBusiness.Editar(encargadoEstudiante);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lbMensaje.Text = encargadoBusiness.Eliminar(tb_cedula.Text);
        }
    }//class
}//namespace