using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Distribuidora.WebForms
{
    public partial class AltaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Funcionario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            divFabricado.Visible = false;
            divImportado.Visible = false;            
        }

        protected void rbtnListTipoProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rbtnListTipoProd.SelectedValue == "Fabricado")
            {
                divFabricado.Visible = true;
                divImportado.Visible = false;
            }else
            {
                divFabricado.Visible = false;
                divImportado.Visible = true;
            }
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (IsValid) {
                if (this.rbtnListTipoProd.SelectedValue == "Fabricado")
                {
                    Empleado emp = (Empleado)Session["Funcionario"];
                    if (txtNombreProducto.Text.Trim() != "" && txtDescProd.Text.Trim() != "" 
                        && txtCostoProd.Text.Trim() != "" && txtPrecioSugerido.Text.Trim() != ""
                        && txtTiempoFab.Text.Trim() != "" && emp.IdEmpleado > 0) {                        
                        Fabricado fab = new Fabricado() {
                            Nombre = txtNombreProducto.Text,
                            Desc = txtDescProd.Text,
                            Costo = double.Parse(txtCostoProd.Text),
                            PrecioSugerido = double.Parse(txtPrecioSugerido.Text),
                            Descontinuado = false,
                            TiempoFab = Convert.ToInt32(txtTiempoFab.Text),
                            //TODO: CONFIRMAR QUE QUEDE INGRESADO EL IdEmpleado EN LA VARIABLE UsuarioAlta
                            UsuarioAlta = emp.IdEmpleado
                        };

                        if (fab.Crear())
                        {
                            lblMensajeProducto.Text = "El producto fabricado fue dado de alta correctamente.";
                        } else
                        {
                            lblMensajeProducto.Text = "No se pudo dar de alta el producto fabricado";
                        }
                    }
                }
                else if(this.rbtnListTipoProd.SelectedValue == "Importado")
                {
                    if (txtNombreProducto.Text.Trim() != "" && txtDescProd.Text.Trim() != ""
                        && txtCostoProd.Text.Trim() != "" && txtPrecioSugerido.Text.Trim() != ""
                        && txtOrigen.Text.Trim() != "" && txtCantImp.Text.Trim() !="")
                    {
                        Importado imp = new Importado()
                        {
                            Nombre = txtNombreProducto.Text,
                            Desc = txtDescProd.Text,
                            Costo = double.Parse(txtCostoProd.Text),
                            PrecioSugerido = double.Parse(txtPrecioSugerido.Text),
                            Descontinuado = false,
                            Origen = txtOrigen.Text,
                            CantImportacion = Convert.ToInt32(txtCantImp.Text)
                        };
                        if (imp.Crear())
                        {
                            lblMensajeProducto.Text = "El producto importado fue dado de alta correctamente.";
                        }
                        else
                        {
                            lblMensajeProducto.Text = "No se pudo dar de alta el producto importado.";
                        }
                    }
                }else
                {
                    lblMensajeProducto.Text = "Debe seleccionar un tipo de producto.";
                }
            }
        }
    }
}