using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Distribuidora;

namespace Distribuidora.WebForms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Funcionario"] = null;
        }

        protected void LoginFuncionario_Authenticate(object sender, AuthenticateEventArgs e)
        {
            e.Authenticated = true;
            Empleado emp = new Empleado();
            if (LoginFuncionario.UserName.Trim() != null && LoginFuncionario.Password.Trim() != null)
            {
                emp.Email = LoginFuncionario.UserName.Trim();
                emp = emp.Buscar();

                if (emp != null && emp.Contrasena == LoginFuncionario.Password.Trim() && emp.Email == LoginFuncionario.UserName.Trim())
                {

                    Session["Funcionario"] = emp;
                    Response.Redirect("~/WelcomePage.aspx");
                }
                else
                {
                    e.Authenticated = false;
                    lblLoginEmp.Text = "No existe usuario con esas credenciales.";
                }
            }
            else
            {
                e.Authenticated = false;
                lblLoginEmp.Text = "Asegurese de ingresar un valor en nombre de usuario y contraseña.";
            }

        }
    }
}