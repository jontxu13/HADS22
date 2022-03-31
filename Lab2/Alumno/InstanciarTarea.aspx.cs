using Lab3_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2.Alumno
{
    public partial class InstanciarTarea1 : System.Web.UI.Page
    {
        BL bl = new BL();
        DataSet dstTareas = new DataSet();
        DataTable tblTareas = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("../Inicio.aspx");
            }

            txtUsuario.Text = Request.Params["Usuario"];
            txtTarea.Text = Request.Params["Tarea"];
            txtHestimadas.Text = Request.Params["Horas"];

                SqlDataAdapter dapTareas = bl.obtenerTablaAdapter("EstudianteTarea", "email = '" + Session["user"] + "'");
                SqlCommandBuilder bldTareas = new SqlCommandBuilder(dapTareas);

                dapTareas.Fill(dstTareas, "Tareas");
                tblTareas = dstTareas.Tables["Tareas"];
                GridView1.DataSource = tblTareas;
                GridView1.DataBind();

                Session["datosTabla"] = dstTareas;
                Session["adaptadorTabla"] = dapTareas;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            BL bl = new BL();

            int resul = bl.instanciarTarea(txtUsuario.Text, txtTarea.Text, Convert.ToInt32(txtHestimadas.Text), Convert.ToInt32(txtHreales.Text));

            if (resul == -1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error al añadir la tarea.');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Tarea añadida correctamente.');", true);

                DataRow rowTareas = tblTareas.NewRow();
                rowTareas["email"] = txtUsuario.Text;
                rowTareas["codTarea"] = txtTarea.Text;
                rowTareas["hEstimadas"] = txtHestimadas.Text;
                rowTareas["hReales"] = txtHreales.Text;
                tblTareas.Rows.Add(rowTareas);
                GridView1.DataSource = tblTareas;
                GridView1.DataBind();
                txtHestimadas.Text = "";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Hasta pronto!'); location.href='../Inicio.aspx'", true);
            FormsAuthentication.SignOut();
            Session.Abandon();
        }
    }
}