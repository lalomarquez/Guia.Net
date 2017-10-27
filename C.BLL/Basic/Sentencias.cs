using C.Helpers;
using System;

namespace C.BLL.Basic
{
    public class Sentencias
    {
        public void If_Else(int num)
        {
            Print.WriteEntrada("Sentencia IF-ELSE");
            if (num == 10)
            {
                Print.WriteSalida(string.Format("El numero '{0}' es == a 10", num));
            }
            else if (num == 20)
            {
                Print.WriteSalida(string.Format("El numero '{0}' es == a 20", num));
            }
            else
            {
                Print.WriteSalida(string.Format("El numero capturado es '{0}'", num));
            }
        }

        public void Switch(int num)
        {
            Print.WriteEntrada("Sentencia Switch");            
            switch (num)
            {
                case 10:
                    Print.WriteSalida(string.Format("El numero capturado es: {0}", num));
                    break;
                case 20:
                    Print.WriteSalida(string.Format("El numero capturado es: {0}", num));
                    break;
                default:
                    Print.WriteSalida(string.Format("El numero capturado es: {0}", num));
                    break;
            }
        }

        /// <summary>
        /// Se valida primero la condicion, si es true la sentencia es ejecutada.
        /// </summary>
        /// <param name="num"></param>
        public void While(int num)
        {
            Print.WriteEntrada("Sentencia While");
            Print.WriteComent(string.Format("Multiplo de '2' hasta llegar a '{0}'", num));            
            int i = 0; 
            while (i <= num)
            {                
                Print.WriteSalida(i.ToString());                
                i += 2;
            }            
        }

        /// <summary>
        /// Valida al menos una vez.
        /// </summary>
        public void DoWhile()
        {
            Print.WriteEntrada("Sentencia Do-While");
            string respuesta = string.Empty;

            do
            {
                Console.WriteLine("\nQuieres continuar - SI/NO");
                respuesta = Console.ReadLine().ToUpper();
                if (respuesta == "SI")                
                    Print.WriteSalida("BYE");                
                else if (respuesta == "NO")
                    Print.WriteSalida("TE QUEDAS");                
                else                
                    Console.WriteLine("La respuesta {0} es invalida.", respuesta);
                
            } while (respuesta != "SI");
        }
    }
}
