using C.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C.BLL.Basic
{
    public class Metodos
    {
        public string Mensaje(string msj)
        {
            if (string.IsNullOrEmpty(msj))
                Print.WriteComent("No hay ningun mensaje!!");            
            else            
                Print.WriteSalida(string.Format("El mensaje es: [ {0} ]", msj));
            
            return msj;
        }

        public static string Saludo(string msj)
        {
            if (string.IsNullOrEmpty(msj))
                Print.WriteComent("No hay ningun mensaje!!");
            else
                Print.WriteSalida(string.Format("El mensaje es: [ {0} ]", msj));

            return msj;
        }
    }    
}
