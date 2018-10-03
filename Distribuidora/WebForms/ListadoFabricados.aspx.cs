using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Distribuidora.ServiceReferenceDistribuidoraWCF;

namespace Distribuidora.WebForms
{
    public partial class ListadoFabricados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Funcionario"] == null)
            {
                Response.Redirect("Login.aspx");
            }


            DistribuidoraWCFClient cli = new DistribuidoraWCFClient();           
            cli.Open();
            grdVwListaFabricados.DataSource = cli.mostrarTodosFabricados();
            grdVwListaFabricados.DataBind();
            cli.Close();
        }
    }
}