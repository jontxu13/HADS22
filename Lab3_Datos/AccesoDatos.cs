using Lab3_Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Datos
{
    public class AccesoDatos
    {
        public int registrarUsuario(string email, string nombre, string apellidos, string tipo, string pass)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "Data Source=tcp:hads14j.database.windows.net,1433;Initial Catalog=hads;Persist Security Info=True;User ID=jon;Password=Hads1422";
                connection.Open();

                Usuario u = new Usuario(email, nombre, apellidos, tipo, pass);
                u.numconfir = u.generarNumero();

                var command = new SqlCommand("INSERT INTO Usuarios VALUES(@email, @nombre, @apellidos, @numconfir, @confirmado, @tipo, @pass, @codpass)", connection);

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

                var command = new SqlCommand("SELECT * FROM Usuarios WHERE email=@email and pass=@pass", connection);

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@pass", pass);
                if (command.ExecuteReader().HasRows)
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public Usuario getUsuarioDB(string email)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "Data Source=tcp:hads14j.database.windows.net,1433;Initial Catalog=hads;Persist Security Info=True;User ID=jon;Password=Hads1422";
                connection.Open();

                var command = new SqlCommand("SELECT * FROM Usuarios WHERE email=@email", connection);

                command.Parameters.AddWithValue("@email", email);
                if (command.ExecuteReader().HasRows)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Usuario u = new Usuario();
                    u.email = reader.GetString(0);
                    u.nombre = reader.GetString(1);
                    u.apellidos = reader.GetString(2);
                    u.numconfir = reader.GetInt32(3);
                    u.confirmado = reader.GetBoolean(4);
                    u.tipo = reader.GetString(5);
                    u.pass = reader.GetString(6);
                    u.codpass = reader.GetInt32(7);
                    connection.Close();
                    return u;
                }
                else
                {
                    connection.Close();
                    return null;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
