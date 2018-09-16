﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Distribuidora.ServiceReference1;

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

        protected void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (txtContreasena.Text != "" && txtMailEmpleado.Text != "")
                {
                    if (chkBxTecnico.Checked)
                    {
                        lblMensajeEmpleado.Text = "El tecnico no se pudo dar de alta.";
                        Tecnico tec = new Tecnico
                        {
                            Nombre = txtNombreEmpleado.Text,
                            Email = txtMailEmpleado.Text,
                            Contrasena = txtContreasena.Text,
                            DescTarea = txtDescTarea.Text,
                            TiempTarea = int.Parse(txtTiempTarea.Text)
                        };
                        if (tec.Crear())
                        {
                            lblMensajeEmpleado.Text = "El tecnico se dio de alta correctamente.";
                        }
                    }
                    else
                    {
                        lblMensajeEmpleado.Text = "El empleado no se pudo dar de alta.";
                        Empleado emp = new Empleado
                        {
                            Nombre = txtNombreEmpleado.Text,
                            Email = txtMailEmpleado.Text,
                            Contrasena = txtContreasena.Text
                        };
                        if (emp.Crear())
                        {
                            lblMensajeEmpleado.Text = "El empleado se pudo dar de alta correctamente.";
                        }
                    }
                }
            }
        }
    }
}