using Lab3_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2.Profesor
{
    public partial class InsertarTarea1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("../Inicio.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Hasta pronto!'); location.href='../Inicio.aspx'", true);
            FormsAuthentication.SignOut();
            Session.Abandon();
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            BL bl = new BL();

            int resul = bl.insertarTarea(txtCodigo.Text, txtDes.Text, dplAsignatura.SelectedValue, Convert.ToInt32(txtHestimadas.Text), dplTipoTarea.SelectedValue);

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