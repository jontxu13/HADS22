using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Lab3_Datos;
using Lab3_Dominio;

namespace Lab3_LogicaNegocio
{
    public class BL
    {
        AccesoDatos da = new AccesoDatos();
        public int sendEmail(String email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("your_email_address@gmail.com");
                mail.To.Add("to_address");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int registrarUsuario(string email, string nombre, string apellidos, string tipo, string pass)
        {
            return da.registrarUsuario(email, nombre, apellidos, tipo, pass);
        }

        public int iniciarSesion(string email, string pass)
        {
            return da.iniciarSesion(email, pass);
        }
        public Usuario getUsuarioDB(string email)
        {
            return da.getUsuarioDB(email);
        }
    }
}
