﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2.Profesor
{
    public partial class VerTareasProfesor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("../Inicio.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Response.Redirect("Profesor/GestionarTarea.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstanciarTarea.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Hasta pronto!'); location.href='Inicio.aspx'", true);
            Session.Abandon();
        }
    }
}