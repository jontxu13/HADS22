using Lab3_LogicaNegocio;
using System;
using System.Collections;
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
    public partial class VerTareasEstudiante1 : System.Web.UI.Page
    {
        SqlDataAdapter dapTareas = new SqlDataAdapter();
        SqlDataAdapter dapAsig = new SqlDataAdapter();
        BL bl = new BL();
        DataSet dstTareas = new DataSet();
        DataSet dstAsig = new DataSet();
        DataTable tblTareas = new DataTable();
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

                dapTareas = bl.obtenerTablaAdapter("TareaGenerica", "(codAsig = '" + DropDownList1.SelectedValue + "' AND explotacion = 'True');");

                dapTareas.Fill(dstTareas, "Tareas");
                tblTareas = dstTareas.Tables["Tareas"];
                GridView1.DataSource = tblTareas;
                GridView1.DataBind();

                Session["datosTabla"] = dstTareas;
                Session["adaptadorTabla"] = dapTareas;
            }
            else
            {
                dapAsig = bl.obtenerTablaAdapter("GrupoClase INNER JOIN EstudianteGrupo ON GrupoClase.codigo = EstudianteGrupo.Grupo", "EstudianteGrupo.Email ='" + Session["user"] + "';");

                dapAsig.Fill(dstAsig, "Asignaturas");
                DropDownList1.DataSource = dstAsig;
                DropDownList1.DataBind();
                DropDownList1.DataTextField = "codigoasig";
                DropDownList1.DataValueField = "codigoasig";
                DropDownList1.DataBind();
                Session["datosAsign"] = dstAsig;
                Session["adaptadorAsig"] = dapAsig;

                dapTareas = bl.obtenerTablaAdapter("TareaGenerica", "(codAsig = '" + DropDownList1.SelectedValue + "' AND explotacion = 'True');");

                dapTareas.Fill(dstTareas, "Tareas");
                tblTareas = dstTareas.Tables["Tareas"];
                GridView1.DataSource = tblTareas;
                GridView1.DataBind();

                Session["datosTabla"] = dstTareas;
                Session["adaptadorTabla"] = dapTareas;

            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Hasta pronto!'); location.href='../Inicio.aspx'", true);
            FormsAuthentication.SignOut();
            Application["nAlumnos"] = (int)Application["nAlumnos"] - 1;
            ArrayList cAlumnos = (ArrayList)Application["cAlumnos"];
            cAlumnos.Remove((string)Session["user"]);
            Application["cAlumnos"] = cAlumnos;
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