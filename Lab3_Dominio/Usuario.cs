using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Dominio
{
    public class Usuario
    {
        public String email { get; set; }
        public String nombre { get; set; }
        public String apellidos { get; set; }
        public int numconfir { get; set; }
        public Boolean confirmado {get; set;}
        public String tipo { get; set; }
        public String pass { get; set; }
        public int codpass { get; set; }

        public Usuario(string email, string nombre, string apellidos, string tipo, string pass)
        {
            this.email = email;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.confirmado = false;
            this.tipo = tipo;
            this.pass = pass;
            
        }

        public Usuario()
        {
        }

        public int generarNumero()
        {
            Random rnd = new Random();
            var n= 0;
            for (int j = 0; j < 7; j++)
            {
                n = rnd.Next();
            }

            return n;
        }
    }
}
