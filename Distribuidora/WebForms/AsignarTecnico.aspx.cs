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
        static int idProd = -1;
        static int idFab = -1;
        static int idEmp = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Funcionario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            Fabricado fab = new Fabricado();
            grdVwProductosFab.DataSource = fab.TraerTodo();
            grdVwProductosFab.DataBind();

            Empleado emp = new Empleado();
            grdVwTecnicos.DataSource = emp.TraerTodoTecnicos();
            grdVwTecnicos.DataBind();
        }

        protected void grdVwProductosFab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = grdVwProductosFab.SelectedRow.RowIndex;
            idProd = Convert.ToInt32(grdVwProductosFab.DataKeys[selectedIndex].Values[0]);
            idFab = Convert.ToInt32(grdVwProductosFab.DataKeys[selectedIndex].Values[1]);
            lblProductoSeleccionado.Text = "El producto de nombre " + grdVwProductosFab.Rows[selectedIndex].Cells[3].Text + " ha sido seleccionado.";
        }

        protected void grdVwTecnicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = grdVwTecnicos.SelectedRow.RowIndex;
            idEmp = Convert.ToInt32(grdVwTecnicos.DataKeys[grdVwProductosFab.SelectedRow.RowIndex].Values[0]);
            lblTecnicoSeleccionado.Text = "El tecnico con el nombre " + grdVwTecnicos.Rows[selectedIndex].Cells[2].Text + ", email " + grdVwTecnicos.Rows[selectedIndex].Cells[3].Text + " ha sido seleccionado.";
        }

        protected void btnAsignarTecnico_Click(object sender, EventArgs e)
        {
            if (IsValid && txtDescTarea.Text != "" && txtTiempoRealizacion.Text != "")
            {
                if (idProd != -1 && idFab != -1 && idEmp != -1)
                {
                    Tecnico tec = new Tecnico()
                    {
                        IdProducto = idProd,
                        IdEmpleado = idEmp,
                        IdFabricado = idFab
                    };

                    if (tec.Buscar() == null)
                    {
                        tec.DescTarea = txtDescTarea.Text;
                        tec.TiempTarea = Convert.ToInt32(txtTiempoRealizacion.Text);                       

                        if (tec.Crear())
                        {
                            lblMensajeAsigTecnico.Text = "El tecnico fue asignado correctamente.";
                        }
                        else
                        {
                            lblMensajeAsigTecnico.Text = "No se pudo asignar el tecnico.";
                        }
                    }
                    else
                    {
                        lblMensajeAsigTecnico.Text = "El tecnico seleccionado ya fue asignado a ese producto";
                    }
                }
                else
                {
                    lblMensajeAsigTecnico.Text = "Debe seleccionar un producto fabricado y un tecnico antes de asignarlos.";
                }
            }
            else
            {
                lblMensajeAsigTecnico.Text = "Debe Ingresar una descripcion de tarea y un tiempo de realizacion.";
            }
        }
    }
}