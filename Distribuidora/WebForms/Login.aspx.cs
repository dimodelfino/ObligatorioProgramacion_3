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
            Empleado e = new Empleado();
            if (LoginFuncionario.UserName.Trim() != null && LoginFuncionario.Password.Trim() != null)
            {
                e.Email = LoginFuncionario.UserName.Trim();
                e = e.Buscar();
            }
                    
        }
    }
}