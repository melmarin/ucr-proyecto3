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
    public partial class IngresarMatriculaForm : System.Web.UI.Page
    {
        private String conectionString;
        private Estudiante estudiante;
        private EstudianteBusiness estudianteBusiness;
        private Grupo grupo;
        private GrupoBusiness grupoBusiness;
        private Factura factura;
        private FacturaBusiness facturaBusines;
        private Domain.Login login;
        private LoginBusiness loginBusiness;
        MatriculaBusiness matriculaBusiness;


        protected void Page_Load(object sender, EventArgs e)
        {
            conectionString = WebConfigurationManager.ConnectionStrings["2017_sistema_camel"].ConnectionString;
            estudiante = new Estudiante();
            estudianteBusiness = new EstudianteBusiness(conectionString);
            grupo = new Grupo();
            grupoBusiness = new GrupoBusiness(conectionString);
            factura = new Factura();
            facturaBusines = new FacturaBusiness(conectionString);
            login = new Domain.Login();
            loginBusiness = new LoginBusiness(conectionString);
            matriculaBusiness = new MatriculaBusiness(conectionString);

            if (!Page.IsPostBack)
            {
                LinkedList<Estudiante> estudiantes = new LinkedList<Estudiante>();
                estudiantes = estudianteBusiness.obtenerEstudiantes();
                //docentes = LA LISTA DE DOCENTES

                //Llenando el dropDownList

                ddlEstudiantes.DataSource = estudiantes;
                ddlEstudiantes.DataValueField = "carne";
                ddlEstudiantes.DataTextField = "carne";
                ddlEstudiantes.DataBind();
                //ddlDocentes.SelectedIndex = ddlDocentes.Items.Count - 1;

                LinkedList<Grupo> grupos = new LinkedList<Grupo>();
                grupos = grupoBusiness.obtenerGrupos();

                ddlGrupo.DataSource = grupos;
                ddlGrupo.DataValueField = "seccion";
                ddlGrupo.DataTextField = "seccion";
                ddlGrupo.DataBind();
            }//if

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            //estudiante 
            estudiante = estudianteBusiness.obtenerEstudiante(ddlEstudiantes.SelectedItem.Value);

            //grupo
            grupo = grupoBusiness.obtenerGrupo(ddlGrupo.SelectedItem.Value);

            factura = new Factura(facturaBusines.calcularMonto(grupo.Seccion), "Pendiente");

            string usuario = loginBusiness.generarUsuario();
            string clave = loginBusiness.generarClave();
            loginBusiness.insertarLogin(usuario,clave, "ENCA");
            login = new Domain.Login(usuario);

            Matricula matricula = new Matricula(factura, grupo, estudiante, login);
            lbMensaje.Text = matriculaBusiness.insertar(matricula);

            lbCredenciales.Text = "Usuario: " + usuario + " clave: " + clave; 

        }
    }
}