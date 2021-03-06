using Lab3_Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Datos
{
    public class AccesoDatos
    {
        public int sendEmail(String email, int n)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("hads14j@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Email de confirmación de registro";
                mail.Body = "Haz click el siguiente link para confirmar el registro: http://hads22-14.azurewebsites.net/Confirmar.aspx?email=" + email + "&confirmacion=" + n + "";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hads14j@gmail.com", "hads1422Jon");
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
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "Data Source=tcp:hads14j.database.windows.net,1433;Initial Catalog=hads;Persist Security Info=True;User ID=jon;Password=Hads1422";
                connection.Open();

                Usuario u = new Usuario(email, nombre, apellidos, tipo, pass);
                u.numconfir = u.generarNumero();
                u.pass = encriptar(pass);

                var command = new SqlCommand("INSERT INTO Usuario VALUES(@email, @nombre, @apellidos, @numconfir, @confirmado, @tipo, @pass, @codpass)", connection);

                command.Parameters.AddWithValue("@email", u.email);
                command.Parameters.AddWithValue("@nombre", u.nombre);
                command.Parameters.AddWithValue("@apellidos", u.apellidos);
                command.Parameters.AddWithValue("@numconfir", u.numconfir);
                command.Parameters.AddWithValue("@confirmado", Convert.ToInt32(u.confirmado));
                command.Parameters.AddWithValue("@tipo", u.tipo);
                command.Parameters.AddWithValue("@pass", u.pass);
                command.Parameters.AddWithValue("@codpass", u.codpass);

                command.ExecuteNonQuery();

                connection.Close();

                sendEmail(email, u.numconfir);
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public int iniciarSesion(string email, string pass)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "Data Source=tcp:hads14j.database.windows.net,1433;Initial Catalog=hads;Persist Security Info=True;User ID=jon;Password=Hads1422";
                connection.Open();
                var passE = encriptar(pass);
                var command = new SqlCommand("SELECT * FROM Usuario WHERE email=@email and pass=@pass", connection);

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@pass", passE);
                command.ExecuteNonQuery();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    if (Convert.ToString(reader[5]) == "Alumno")
                    {
                        connection.Close();
                        return 0;
                    }
                    else
                    {
                        connection.Close();
                        return 1;
                    }
                }
                else
                {
                    connection.Close();
                    return -2;
                } 

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public int confirmarUsuario(string email, int n)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "Data Source=tcp:hads14j.database.windows.net,1433;Initial Catalog=hads;Persist Security Info=True;User ID=jon;Password=Hads1422";
                connection.Open();
                var command = new SqlCommand("update Usuario set confirmado=@confirmado where email=@email and numconfir=@numconfir", connection);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@numconfir", n);
                command.Parameters.AddWithValue("@confirmado", true);
                command.ExecuteNonQuery();
                connection.Close();
                return 0;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public int insertarTarea(string codigo, string descripcion, string codAsig, int horas, string tipoTarea)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "Data Source=tcp:hads14j.database.windows.net,1433;Initial Catalog=hads;Persist Security Info=True;User ID=jon;Password=Hads1422";
                connection.Open();

                var command = new SqlCommand("INSERT INTO TareaGenerica VALUES(@codigo, @descripcion, @codAsig, @hEstimadas, @explotacion, @tipoTarea)", connection);

                command.Parameters.AddWithValue("@codigo", codigo);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@codAsig", codAsig);
                command.Parameters.AddWithValue("@hEstimadas", horas);
                command.Parameters.AddWithValue("@explotacion", false);
                command.Parameters.AddWithValue("@tipoTarea", tipoTarea);

                command.ExecuteNonQuery();

                connection.Close();

                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        public int instanciarTarea(string email, string tarea, int hEstimadas, int hReales)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "Data Source=tcp:hads14j.database.windows.net,1433;Initial Catalog=hads;Persist Security Info=True;User ID=jon;Password=Hads1422";
                connection.Open();

                var command = new SqlCommand("INSERT INTO EstudianteTarea VALUES(@email, @codTarea, @hEstimadas, @hReales)", connection);

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@codTarea", tarea);
                command.Parameters.AddWithValue("@hEstimadas", hEstimadas);
                command.Parameters.AddWithValue("@hReales", hReales);

                command.ExecuteNonQuery();

                connection.Close();

                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public SqlDataAdapter obtenerTablaAdapter(string tabla, string where)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=tcp:hads14j.database.windows.net,1433;Initial Catalog=hads;Persist Security Info=True;User ID=jon;Password=Hads1422");
                SqlDataAdapter dapTareas = new SqlDataAdapter();
                if (where != "")
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("select * from " + tabla + " where " + where + ";", connection);
                    return adapter;
                }
                else
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("select * from " + tabla + ";", connection);
                    return adapter;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static string encriptar(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //Pasar a hash los bytes del texto 
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //Obtener el hash 
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //Cambiar a 2 digitos hexadecimales 
                //por cada byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
