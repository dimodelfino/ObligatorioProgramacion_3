using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Distribuidora.WebForms
{
    public partial class AsignarTecnico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Funcionario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            Fabricado fab = new Fabricado();
            grdVwProductosFab.DataSource = fab.TraerTodo();
            grdVwProductosFab.DataBind();
        }
    }
}