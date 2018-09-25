using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Distribuidora.ServiceReference1;

namespace Distribuidora
{
    public partial class AltaEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Funcionario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            if (IsValid && txtContreasena.Text != "" && txtMailEmpleado.Text != "")
            {
                Empleado emp = new Empleado()
                {
                    Nombre = txtNombreEmpleado.Text,
                    Email = txtMailEmpleado.Text,
                    Contrasena = txtContreasena.Text,
                    Activo = true,
                    Tipo = "E"
                };
                if (chkBxTecnico.Checked) emp.Tipo = "T";
                if (emp.Buscar().Email == null)
                {
                    if (emp.Crear())
                    {
                        lblMensajeEmpleado.Text = "El empleado se pudo dar de alta correctamente.";
                    }
                    else
                    {
                        lblMensajeEmpleado.Text = "El empleado no se pudo dar de alta.";
                    }
                }
                else
                {
                    lblMensajeEmpleado.Text = "Ya existe un empleado con ese email.";
                }
            }
        }
    }
}
