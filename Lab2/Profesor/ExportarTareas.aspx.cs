using Lab3_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Lab2.Profesor
{
    public partial class ExportarTareas : System.Web.UI.Page
    {
        SqlDataAdapter dapTareas = new SqlDataAdapter();
        SqlDataAdapter dapAsig = new SqlDataAdapter();
        BL bl = new BL();
        DataSet dstTareas = new DataSet();
        DataSet dstAsig = new DataSet();
        DataTable tblTareas = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("../Inicio.aspx");
            }
            if (Page.IsPostBack)
            {
                dapTareas = null;
                tblTareas = null;
                dstAsig = (DataSet)Session["datosAsig"];

                dapTareas = bl.obtenerTablaAdapter("TareaGenerica", "(codAsig = '" + DropDownList1.SelectedValue + "');");

                dapTareas.Fill(dstTareas, "Tareas");
                tblTareas = dstTareas.Tables["Tareas"];
                GridView1.DataSource = tblTareas;
                GridView1.DataBind();

                Session["datosTabla"] = dstTareas;
                Session["adaptadorTabla"] = dapTareas;
            }
            else
            {
                dapAsig = bl.obtenerTablaAdapter("[GrupoClase] INNER JOIN [ProfesorGrupo] ON GrupoClase.codigo = ProfesorGrupo.codigoGrupo", "email ='" + Session["user"] + "';");

                dapAsig.Fill(dstAsig, "Asignaturas");
                DropDownList1.DataSource = dstAsig;
                DropDownList1.DataBind();
                DropDownList1.DataTextField = "codigoasig";
                DropDownList1.DataValueField = "codigoasig";
                DropDownList1.DataBind();
                Session["datosAsign"] = dstAsig;
                Session["adaptadorAsig"] = dapAsig;

                dapTareas = bl.obtenerTablaAdapter("TareaGenerica", "(codAsig = '" + DropDownList1.SelectedValue + "');");

                dapTareas.Fill(dstTareas, "Tareas");
                tblTareas = dstTareas.Tables["Tareas"];
                GridView1.DataSource = tblTareas;
                GridView1.DataBind();

                Session["datosTabla"] = dstTareas;
                Session["adaptadorTabla"] = dapTareas;

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            dstTareas.DataSetName = "tareas";
            tblTareas.TableName = "tarea";
            tblTareas.Columns[0].ColumnMapping = MappingType.Attribute;

            dstTareas.WriteXml(Server.MapPath("../App_Data/" + DropDownList1.SelectedValue + ".xml"));
            XmlDocument xml = new XmlDocument();
            xml.Load(Server.MapPath("../App_Data/" + DropDownList1.SelectedValue + ".xml"));
            error.Text = "Tareas exportadas correctamente en el archivo " + DropDownList1.SelectedValue + ".xml";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Hasta pronto!'); location.href='../Inicio.aspx'", true);
            Session.Abandon();
        }
    }
}