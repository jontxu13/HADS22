using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class UsuariosOnline : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            alumnos.Text = Convert.ToString(Application["nAlumnos"]);
            profesores.Text = Convert.ToString(Application["nProfesores"]);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            listAlumnos.Items.Clear();
            listProfesores.Items.Clear();
            alumnos.Text = Convert.ToString(Application["nAlumnos"]);
            profesores.Text = Convert.ToString(Application["nProfesores"]);
            ArrayList cAlumnos = (ArrayList)Application["cAlumnos"];
            ArrayList cProfesores = (ArrayList)Application["cProfesores"];

            foreach (String c in cAlumnos) {

                listAlumnos.Items.Add(c.ToString());
            }

            foreach (String c in cProfesores)
            {

                listProfesores.Items.Add(c.ToString());
            }

        }
    }
}