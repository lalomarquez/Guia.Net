using System;
using C.Helpers;
using System.Collections.Generic;

namespace C.BLL.PilaresPOO.Herencia
{
    /*
     * 
     * HERENCIA EN SU FORMA BASICA(SIMPLE)     
     * 
     */
    public class BLLHerencia
    {
        public void Mujer()
        {
            var costurera = new Costurera();
            List<string> list = new List<string>();

            var bo = new Persona();
            bo.nombre = "Maria";
            bo.apellMaterno = "Perez";
            bo.apellPaterno = "Sanchez";

            list = costurera.Prendas(bo);
            
            Console.WriteLine(" ha realizado las siguientes prendas: ");

            foreach (var item in list)
            {
                Print.WriteSalida(item);
                Console.WriteLine();
            }
        }

        public void Hombre()
        {
            int hrs = 666;
            var granjero = new Granjero();
            var bo = new Persona();            
            bo.nombre = "Pedro";
            bo.apellMaterno = "Perez";
            bo.apellPaterno = "Sanchez";

            granjero.HorasTrabajadas(bo, 5, out hrs);           
            Console.Write(" ha trabajado ");
            Print.WriteSalida(string.Format("{0}hrs.", hrs.ToString()));
        }
    }   

    #region Class Granjero heredando propiedades de BO.Persona        
    public class Granjero : Persona
    {
        public void HorasTrabajadas(Persona bo, int dias, out int horas)
        {                        
                Console.Write("El señor ");                
                nombre = bo.nombre;
                apellMaterno = bo.apellMaterno;
                apellPaterno = bo.apellPaterno;

                Print.WriteSalida(string.Format("{0}", bo.NombreCompleto()));
                horas = dias * 8;           
        }        
    }
    #endregion

    #region Class Costurera heredando propiedades de BO.Persona        
    public class Costurera : Persona
    {
        public List<string> Prendas(Persona bo)
        {
            Console.WriteLine();

            List<string> list = new List<string>();
            nombre = bo.nombre;
            apellMaterno = bo.apellMaterno;
            apellPaterno = bo.apellPaterno;
            
            Console.Write("La señora ");
            Print.WriteSalida(string.Format("{0}", bo.NombreCompleto()));
            list.Add("pantalones");
            list.Add("camisas");
            list.Add("playeras");

            return list;
        }
    }
    #endregion

    #region Class base BO.Persona    
    public class Persona
    {
        public string tipoPersona { get; set; }
        public string nombre { get; set; }
        public string apellPaterno { get; set; }
        public string apellMaterno { get; set; }

        public string NombreCompleto()
        {
            return string.Format("{0} {1} {2}",nombre,apellPaterno,apellMaterno);
        }
    }
    #endregion  
}
