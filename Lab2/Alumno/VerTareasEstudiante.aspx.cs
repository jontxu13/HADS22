using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2.Alumno
{
    public partial class VerTareasEstudiante : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection("Data Source=tcp:hads14j.database.windows.net,1433;Initial Catalog=hads;Persist Security Info=True;User ID=jon;Password=Hads1422");
        SqlDataAdapter dapTareas = new SqlDataAdapter();
        SqlDataAdapter dapAsig = new SqlDataAdapter();
        DataSet dstTareas = new DataSet();
        DataSet dstAsig = new DataSet();
        DataTable tblTareas = new DataTable();
        DataRow rowTareas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"]== null)
            {
                Response.Redirect("../Inicio.aspx");
            }
            if (Page.IsPostBack)
            {
                dapTareas = null;
                tblTareas = null;
                dstAsig = (DataSet)Session["datosAsig"];

                dapTareas = new SqlDataAdapter("select codigo, descripcion, codAsig, hEstimadas, tipoTarea from TareaGenerica where codAsig = '" + DropDownList1.SelectedValue + "';", connection);
                SqlCommandBuilder bldTareas = new SqlCommandBuilder(dapTareas);

                dapTareas.Fill(dstTareas, "Tareas");
                tblTareas = dstTareas.Tables["Tareas"];
                GridView1.DataSource = tblTareas;
                GridView1.DataBind();

                Session["datosTabla"] = dstTareas;
                Session["adaptadorTabla"] = dapTareas;
            }
            else
            {
                dapAsig = new SqlDataAdapter("SELECT GrupoClase.codigoasig FROM GrupoClase INNER JOIN EstudianteGrupo ON GrupoClase.codigo = EstudianteGrupo.Grupo WHERE EstudianteGrupo.Email ='" + Session["user"] + "';", connection);
                SqlCommandBuilder bldAsig = new SqlCommandBuilder(dapAsig);

                dapAsig.Fill(dstAsig, "Asignaturas");
                DropDownList1.DataSource = dstAsig;
                DropDownList1.DataBind();
                DropDownList1.DataTextField = "codigoasig";
                DropDownList1.DataValueField = "codigoasig";
                DropDownList1.DataBind();
                Session["datosAsign"] = dstAsig;
                Session["adaptadorAsig"] = dapAsig;

                dapTareas = new SqlDataAdapter("select codigo, descripcion, codAsig, hEstimadas, tipoTarea from TareaGenerica where codAsig = '"+ DropDownList1.SelectedValue + "';", connection);
                SqlCommandBuilder bldTareas = new SqlCommandBuilder(dapTareas);

                dapTareas.Fill(dstTareas, "Tareas");
                tblTareas = dstTareas.Tables["Tareas"];
                GridView1.DataSource = tblTareas;
                GridView1.DataBind();

                Session["datosTabla"] = dstTareas;
                Session["adaptadorTabla"] = dapTareas;

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Response.Redirect("Alumno/InstanciarTarea.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Hasta pronto!'); location.href='Inicio.aspx'", true);
            Session.Abandon();
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            var Tarea = GridView1.SelectedRow.Cells[1].Text;
            var Horas = GridView1.SelectedRow.Cells[4].Text;

            Response.Redirect("InstanciarTarea.aspx?Usuario=" + Session["user"] + "&Tarea=" + Tarea + "&Horas=" + Horas);
        }
    }
}