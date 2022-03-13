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


        public int registrarUsuario(string email, string nombre, string apellidos, string tipo, string pass)
        {
            return da.registrarUsuario(email, nombre, apellidos, tipo, pass);
        }

        public int iniciarSesion(string email, string pass)
        {
            return da.iniciarSesion(email, pass);
        }
        public int confirmarUsuario(string email, int n) 
        {
           return da.confirmarUsuario(email, n);
        }

        public int insertarTarea(string codigo, string descripcion, string codAsig, int horas, string tipoTarea)
        {
            return da.insertarTarea(codigo, descripcion, codAsig, horas, tipoTarea);
        }
    }
}
