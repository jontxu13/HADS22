using Lab3_Datos.MediaDedicacion;
using Lab3_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2.Coordinador
{
    public partial class MediaHoras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAsig.Text = DropDownList1.SelectedValue;

            MediaDedicacion media = new MediaDedicacion();
            if (media.calcularMedia(DropDownList1.SelectedValue) == -1)
            {
                lblMedia.Text = "No hay datos";
            }
            else
            {
                lblMedia.Text = Convert.ToString(media.calcularMedia(DropDownList1.SelectedValue));
            }
            
        }
    }
}