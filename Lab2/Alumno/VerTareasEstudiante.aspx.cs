using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class VerTareasEstudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Tarea = GridView1.SelectedRow.Cells[1].Text;
            var Horas = GridView1.SelectedRow.Cells[3].Text;
            var Usuario = Session["user"];

            Response.Redirect("Alumno/InstanciarTarea.aspx?Usuario=" + Usuario + "&Tarea=" + Tarea + "&Horas=" + Horas);
        }
    }
}