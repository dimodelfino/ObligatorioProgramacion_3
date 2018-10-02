﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            Importado imp = new Importado();
            Fabricado fab = new Fabricado();
            TxtHandler report = new TxtHandler();
            lblMensajeReporteTxt.Text = "No se pudo generar el reporte correctamente";
            if (report.TxtProductos(imp.TraerTodo(), fab.TraerTodo())) lblMensajeReporteTxt.Text = "El reporte fue generado con exito!";
        }
    }
}