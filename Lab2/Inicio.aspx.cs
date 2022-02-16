using Lab3_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                  new ScriptResourceDefinition
                  {
                      Path = "~/scripts/jquery-1.8.3.min.js",
                      DebugPath = "~/scripts/jquery-1.8.3.js",
                      CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js",
                      CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.js"
                  });
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            BL bl = new BL();

            int resul = bl.iniciarSesion(txtEmail.Text, txtPassword.Text);

            if (resul == -1)
            {
                error.Text = "Algo salió mal";
            }
            else if(resul == 1)
            {
                error.Text = "Usuario o contraseña incorrecto.";
            }
            else
            {
                Session["user"] = txtEmail.Text;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bienvenido! " + Session["user"] + "'); location.href='Welcome.aspx'", true);
            }
        }
    }
}