﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Distribuidora.ServiceReferenceDistribuidoraWCF;

namespace Distribuidora.WebForms
{
    public partial class TxtProd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Funcionario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            
            lblMensajeReporteTxt.Text = "No se pudo generar el reporte correctamente";
            DistribuidoraWCFClient cli = new DistribuidoraWCFClient();            
            if (cli.GenerarReporteTxtProductos()) lblMensajeReporteTxt.Text = "El reporte fue generado con exito!";
        }
    }
}