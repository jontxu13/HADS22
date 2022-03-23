using Lab3_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Lab2.Profesor
{
    public partial class ImportarXML : System.Web.UI.Page
    {
        SqlDataAdapter dapTareas = new SqlDataAdapter();
        DataSet dstTareas = new DataSet();
        DataTable tblTareas = new DataTable();
        SqlCommandBuilder bldTareas;
        BL bl = new BL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Xml1.TransformSource = Server.MapPath("../App_Data/VerTablaTareas.xsl");
            if (Session["user"] == null)
            {
                Response.Redirect("../Inicio.aspx");
            }

           if (Page.IsPostBack) {

                dapTareas = (SqlDataAdapter)Session["adaptadorTabla"];
                dstTareas = (DataSet)Session["datosTabla"];

            } else {

                dapTareas = bl.obtenerTablaAdapter("TareaGenerica", "");
                SqlCommandBuilder bldTareas = new SqlCommandBuilder(dapTareas);
                bldTareas.QuotePrefix = "[";
                bldTareas.QuoteSuffix = "]";
                dapTareas.Fill(dstTareas, "Tareas");
                tblTareas = dstTareas.Tables["Tareas"];
                Session["datosTabla"] = dstTareas;
                Session["adaptadorTabla"] = dapTareas;
        }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Xml1.DocumentSource = Server.MapPath("../App_Data/" + DropDownList1.SelectedValue + ".xml");
                Xml1.TransformSource = Server.MapPath("../App_Data/VerTablaTareas.xsl");
            }catch(Exception ex)
            {
                error.Text = "Archivo no encontrado.";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Server.MapPath("../App_Data/" + DropDownList1.SelectedValue + ".xml"));
            XmlNodeList Tareas = xml.GetElementsByTagName("tarea");

        foreach (XmlNode n in Tareas){

                tblTareas = dstTareas.Tables["Tareas"];
                DataRow rowTareas =  tblTareas.NewRow();
                rowTareas["Codigo"] = n.Attributes.Item(0).Value;
                rowTareas["Descripcion"] = n.ChildNodes[0].ChildNodes[0].Value;
                rowTareas["HEstimadas"] = n.ChildNodes[1].ChildNodes[0].Value;
                rowTareas["TipoTarea"] = n.ChildNodes[2].ChildNodes[0].Value;
                rowTareas["Explotacion"] = n.ChildNodes[3].ChildNodes[0].Value;
                tblTareas.Rows.Add(rowTareas);

                try
                {
                   dapTareas.Update(tblTareas);
                   error.Text = "Tareas insertadas correctamente";
                    
                }
                catch (Exception ex)
                {
                    error.Text = "Error, tareas ya insertadas en BD";
                }
                    
        }
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Hasta pronto!'); location.href='../Inicio.aspx'", true);
            Session.Abandon();
        }

    }
}