using Lab3_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class Confirmar1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BL bl = new BL();
            var email = Request.Params["email"];
            int n = Convert.ToInt32(Request.Params["confirmacion"]);
            if(bl.confirmarUsuario(email, n) ==0){ 
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cuenta confirmada! " + Session["user"] + "'); location.href='Welcome.aspx'", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error en la confirmación!'); location.href='Inicio.aspx'", true);
            }
        }
    }
}