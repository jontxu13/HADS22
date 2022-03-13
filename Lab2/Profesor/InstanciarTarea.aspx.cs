using Lab3_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class InstanciarTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            BL bl = new BL();

            int resul = bl.insertarTarea(txtCodigo.Text, txtDes.Text, )

            if (resul == -1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error al añadir la tarea.');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Tarea añadida correctamente.');", true);
            }
        }
    }
}