using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2.Alumno
{
    public partial class Alumno1 : System.Web.UI.Page
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
            Application["nAlumnos"] = (int)Application["nAlumnos"] - 1;
            ArrayList cAlumnos = (ArrayList)Application["cAlumnos"];
            cAlumnos.Remove((string)Session["user"]);
            Application["cAlumnos"] = cAlumnos;
            Session.Abandon();
        }
    }
}