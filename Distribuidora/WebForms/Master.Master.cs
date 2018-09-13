using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Distribuidora.WebForms
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cphMenuInvitado.Visible = true;
            cpgMenuEmpleado.Visible = false;
            if (Session["Funcionario"] != null)
            {
                cphMenuInvitado.Visible = false;
                cpgMenuEmpleado.Visible = true;                
            }
        }
    }
}