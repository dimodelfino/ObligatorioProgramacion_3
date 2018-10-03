using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Distribuidora.ServiceReferenceDistribuidoraWCF;

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
            }
            else
            {
                divFabricado.Visible = false;
                divImportado.Visible = true;
            }
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (!Fachada.ExisteProducto(txtNombreProducto.Text.Trim()))
                {
                    if (this.rbtnListTipoProd.SelectedValue == "Fabricado")
                    {
                        Empleado emp = (Empleado)Session["Funcionario"];
                        if (txtNombreProducto.Text.Trim() != "" && txtDescProd.Text.Trim() != ""
                            && txtCostoProd.Text.Trim() != "" && txtPrecioSugerido.Text.Trim() != ""
                            && txtTiempoFab.Text.Trim() != "" && emp.IdEmpleado > 0)
                        {
                            DistribuidoraWCFClient cli = new DistribuidoraWCFClient();                            
                            if (cli.agregarProductoFabricado(txtNombreProducto.Text, txtDescProd.Text, double.Parse(txtCostoProd.Text), double.Parse(txtPrecioSugerido.Text), Convert.ToInt32(txtTiempoFab.Text), emp.IdEmpleado))
                            {
                                lblMensajeProducto.Text = "El producto fabricado fue dado de alta correctamente.";
                            }
                            else
                            {
                                lblMensajeProducto.Text = "No se pudo dar de alta el producto fabricado";
                            }
                        }
                    }
                    else if (this.rbtnListTipoProd.SelectedValue == "Importado")
                    {
                        if (txtNombreProducto.Text.Trim() != "" && txtDescProd.Text.Trim() != ""
                            && txtCostoProd.Text.Trim() != "" && txtPrecioSugerido.Text.Trim() != ""
                            && txtOrigen.Text.Trim() != "" && txtCantImp.Text.Trim() != "")
                        {
                            if (Fachada.CrearProductoImportado(txtNombreProducto.Text, txtDescProd.Text, double.Parse(txtCostoProd.Text), double.Parse(txtPrecioSugerido.Text), txtOrigen.Text, Convert.ToInt32(txtCantImp.Text)))
                            {
                                lblMensajeProducto.Text = "El producto importado fue dado de alta correctamente.";
                            }
                            else
                            {
                                lblMensajeProducto.Text = "No se pudo dar de alta el producto importado.";
                            }
                        }
                    }
                    else
                    {
                        lblMensajeProducto.Text = "Debe seleccionar un tipo de producto.";
                    }

                }else
                {
                    lblMensajeProducto.Text = "Ya existe producto con ese nombre.";
                }
            }
            rbtnListTipoProd.ClearSelection();
        }
    }
}