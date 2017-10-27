using System;
using C.Helpers;

namespace C.BLL.Basic
{
    public static class Conversiones
    {
        static float f = 666.45f;
        static int i = 12345;

        /// <summary>
        /// Conversion Implicita.
        /// El compilador garantiza que las conversiones se lleven a cabo de manera satisfactoria.
        /// No hay pérdida de información.
        /// </summary>
        public static void Implicita()
        {                   
            int Implicit = (int)f;
            float flo = i;
            long l = i;
            Print.WriteEntrada("Conversion Implicita");
            Console.WriteLine(Implicit);
            Console.WriteLine(flo);
            Console.WriteLine(l);            
        }

        /// <summary>
        /// Conversion Explicita.
        /// El compilador no garantiza que la conversión siempre sea satisfactoria.
        /// Puede ocurrir pérdida de información durante la conversión.
        /// </summary>
        public static void Explicita()
        {
            int Explicit = Convert.ToInt16(f);// cuando el valor a convertir es muy grande falla
            short z = (short)i;

            Print.WriteEntrada("Conversion Explicita");
            Console.WriteLine(Explicit);
            Console.WriteLine(z);            
        }

        public static void Diferencia_ParseTryParse()
        {            
            string num1 = "666";
            string num2 = "666FN";
            int salida = 0;
            Print.WriteInicioFin("Valores de entrada.");
            Print.WriteComent("num1: "+ num1);
            Print.WriteComent("num2: " + num2);

            Print.WriteEntrada("==========Parse==========");
            int i = int.Parse(num1);
            Console.WriteLine(i);

            Print.WriteEntrada("==========TryParse==========");
            bool IsConversionSuccessful = int.TryParse(num2, out salida);

            if (IsConversionSuccessful == true)
                Console.WriteLine(salida);
            else
            {
                Console.WriteLine("Valor capturado : ");
                Print.WriteError(num2.ToString());
                Console.WriteLine("Please bitch, captura un # valido.");
            }
        }
    }
}
