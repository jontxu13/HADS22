using Lab3_LogicaNegocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class Inicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                  new ScriptResourceDefinition
                  {
                      Path = "~/scripts/jquery-1.8.3.min.js",
                      DebugPath = "~/scripts/jquery-1.8.3.js",
                      CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js",
                      CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.js"
                  });

            if (!Page.IsPostBack)
            {
                if (Application["nAlumnos"] == null)
                {
                    ArrayList cAlumnos = new ArrayList();
                    Application["nAlumnos"] = 0;
                    Application["cAlumnos"] = cAlumnos;
                }
                if (Application["nProfesores"] == null)
                {
                    ArrayList cProfesores = new ArrayList();
                    Application["nProfesores"] = 0;
                    Application["cProfesores"] = cProfesores;
                }
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            BL bl = new BL();

            int resul = bl.iniciarSesion(txtEmail.Text, txtPassword.Text);

            if (resul == -1)
            {
                error.Text = "Algo salió mal";
            }
            else if (resul == -2)
            {
                error.Text = "Usuario o contraseña incorrecto.";
            }
            else if (resul == 0)
            {
                Session["user"] = txtEmail.Text;
                Application["nAlumnos"] = (int)Application["nAlumnos"] + 1;
                ArrayList cAlumnos = (ArrayList)Application["cAlumnos"];
                cAlumnos.Add(txtEmail.Text);
                Application["cAlumnos"] = cAlumnos;
                FormsAuthentication.SetAuthCookie("Alumno", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bienvenido! " + Session["user"] + "'); location.href='Alumno/Alumno.aspx'", true);
            }
            else if (resul == 1)
            {
                if (txtEmail.Text == "vadillo@ehu.es")
                {
                    Session["user"] = txtEmail.Text;
                    Application["nProfesores"] = (int)Application["nProfesores"] + 1;
                    ArrayList cProfesores = (ArrayList)Application["cProfesores"];
                    cProfesores.Add(txtEmail.Text);
                    Application["cProfesores"] = cProfesores;
                    FormsAuthentication.SetAuthCookie("Coordinador", true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bienvenido! " + Session["user"] + "'); location.href='Profesor/Profesor.aspx'", true);
                }
                else
                {
                    Session["user"] = txtEmail.Text;
                    Application["nProfesores"] = (int)Application["nProfesores"] + 1;
                    ArrayList cProfesores = (ArrayList)Application["cProfesores"];
                    cProfesores.Add(txtEmail.Text);
                    Application["cProfesores"] = cProfesores;
                    FormsAuthentication.SetAuthCookie("Profesor", true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bienvenido! " + Session["user"] + "'); location.href='Profesor/Profesor.aspx'", true);
                }
            }
        }
    }
}