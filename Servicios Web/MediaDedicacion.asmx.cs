using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Lab2
{
    /// <summary>
    /// Descripción breve de MediaDedicacion
    /// </summary>
    [WebService(Namespace = "MediaDedidacion")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class MediaDedicacion : System.Web.Services.WebService
    {

        public MediaDedicacion() {
            }

        [WebMethod]
        public int calcularMedia(String asig)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "Data Source=tcp:hads14j.database.windows.net,1433;Initial Catalog=hads;Persist Security Info=True;User ID=jon;Password=Hads1422";
                connection.Open();
                var command = new SqlCommand("SELECT AVG(hEstimadas) FROM TareaGenerica WHERE codAsig='"+ asig +"'", connection);
                int resul = (int)command.ExecuteScalar();

                connection.Close();
                return resul;
            }
            catch (Exception e)
            {

                return -1;

            }

        }
    }
}
