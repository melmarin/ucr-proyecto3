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
    public partial class EditarEncargadoForm : System.Web.UI.Page
    {
        private String conectionString;
        private EncargadoEstudianteBusiness encargadoBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public EditarEncargadoForm()
        {
            conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
            encargadoBusiness = new EncargadoEstudianteBusiness(conectionString);
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            
            lbMensaje.Text = encargadoBusiness.Editar(new Domain.EncargadoEstudiante(tb_cedula.Text, tb_nombre.Text,
                tb_apellidos.Text, tb_telefono.Text, tb_correo.Text, tb_direccion.Text));
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            String cedula = tb_cedula.Text;
            EncargadoEstudiante encargadoEstudiante = encargadoBusiness.obtenerEncargado(cedula);
            tb_nombre.Text = encargadoEstudiante.Nombre;
            tb_apellidos.Text = encargadoEstudiante.Apellidos;
            tb_correo.Text = encargadoEstudiante.Correo;
            tb_telefono.Text = encargadoEstudiante.Telefono;
            tb_direccion.Text = encargadoEstudiante.Direccion;
        }//btnBuscar_Click

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            String cedula = tb_cedula.Text;
            lbMensaje.Text = encargadoBusiness.Eliminar(cedula);
        }
    }//class
}//namespace