using Lab3_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class Registro1 : System.Web.UI.Page
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

        protected void btnRegistrar_Click1(object sender, EventArgs e)
        {
            BL bl = new BL();

            int resul = bl.registrarUsuario(txtEmail.Text, txtNombre.Text, txtApellidos.Text, rdbtnRol.SelectedValue, txtPassword.Text);

            if (resul == -1)
            {
                error.Text = "Email ya registrado";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registrado correctamente, revise su correo para la confirmación.'); location.href='Inicio.aspx'", true);
            }
        }
    }
}