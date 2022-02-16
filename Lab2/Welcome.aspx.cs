using Lab3_Dominio;
using Lab3_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            labelEmail.Text = Convert.ToString(Session["user"]);
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Hasta pronto!'); location.href='Inicio.aspx'", true);
            Session.Abandon();

        }
    }
}