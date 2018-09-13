using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Distribuidora
{
    public partial class AltaEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Funcionario"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
            divTecnico.Visible = false;
            if (chkBxTecnico.Checked)
            {
                divTecnico.Visible = true;
            }            
        }
      
        protected void chkBxTecnico_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxTecnico.Checked)
            {
                divTecnico.Visible = true;
            }else
            {
                divTecnico.Visible = false;
            }            
        }
    }
}