using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Distribuidora.WebForms
{
    public partial class ListProdPorTipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divGrdVwFabricados.Visible = false;
            divGrdVwImportados.Visible = false;
            
            grdVwFabricados.DataSource = Fachada.TraerTodoProdFabricado();
            grdVwFabricados.DataBind();
            
            GrdVwImportados.DataSource = Fachada.TraerTodoProdImportado();
            GrdVwImportados.DataBind();

        }

        protected void rbtnLstTipoProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rbtnLstTipoProd.SelectedValue == "Fabricado") 
            {
                divGrdVwFabricados.Visible = true;
                divGrdVwImportados.Visible = false;                
            }else if (this.rbtnLstTipoProd.SelectedValue == "Importado")
            {
                divGrdVwFabricados.Visible = false;
                divGrdVwImportados.Visible = true;
                divGrdVwImportados.Style.Clear();
                divGrdVwImportados.Style.Value = "float:left";
            }else
            {
                divGrdVwFabricados.Visible = true;
                divGrdVwImportados.Visible = true;
                divGrdVwImportados.Style.Clear();
                divGrdVwImportados.Style.Value = "float:right";
            }
            
        }
    }
}