using System;
using C.Helpers;

namespace C.BLL.Demos
{
    public class MetodoStringFormat
    {
        public string Saludo(string msj)
        {
            string result = string.Empty;
            try
            {
                Print.WriteEntrada("*****Formato Basico*****");
                Console.WriteLine("Hola {0}!!!", msj);

                Print.WriteEntrada("*****Formateando Enteros*****");
                Console.WriteLine(String.Format("{0:00000}", 1300)); // Imprime: "01300"
                Console.WriteLine(String.Format("{0:00000}", -52)); // Imprime: "-00052"
                Console.WriteLine(String.Format("{0:00000}", 0)); // Imprime: "00000"

                Print.WriteEntrada("*****Formateando Hexadecimales*****");
                int r = 0, g = 133, b = 20;
                Console.WriteLine(String.Format("Hex: R{0:x}, G{1:x4}, B{2:x2}", r, g, b)); // Imprime: "Hex: R0, G0085, B14"
                Console.WriteLine("Hex: {0:x2}{1:x2}{2:x2}", r, g, b); // Imprime: "Hex: 008514"

                Print.WriteEntrada("*****Formateando Numeros Reales*****");
                Console.WriteLine(String.Format("{0:#,##0.00}", 13000d)); // Imprime: "13,000.00"
                Console.WriteLine(String.Format("{0:#,##0.00}", 0.6852871999174f));  // Imprime: "0.69"
                Console.WriteLine(String.Format("{0:#,##0.00}", -0.50m));  // Imprime: "-0.50"

                Print.WriteEntrada("*****Formato Condicional*****");
                Console.WriteLine("{0:[formato si positivo];[formato si negativo];[formato si cero]}");
                Console.WriteLine(String.Format("{0:#,##0.00;MENOS #,##0.00;—}", 13000)); // Imprime: "13,000.00"
                Console.WriteLine(String.Format("{0:#,##0.00;MENOS #,##0.00;—}", 0));  // Imprime: "—"
                Console.WriteLine(String.Format("{0:#,##0.00;MENOS #,##0.00;—}", -0.50m));  // Imprime: "MENOS 0.50"
                Console.WriteLine();
                Console.WriteLine(String.Format("{0:VERDADERO;FALSO;DESCONOCIDO}", 1)); // Imprime: "VERDADERO"
                Console.WriteLine(String.Format("{0:VERDADERO;FALSO;DESCONOCIDO}", 0));  // Imprime: "DESCONOCIDO"
                Console.WriteLine(String.Format("{0:VERDADERO;FALSO;DESCONOCIDO}", -1));  // Imprime: "FALSO"

                Print.WriteEntrada("*****Formato Fechas*****");
                var now = DateTime.Now;
                Console.WriteLine(String.Format("{0:d}", now)); // Imprime: "22/10/2016"
                Console.WriteLine(String.Format("{0:F}", now)); // Imprime: "sábado, 22 de octubre de 2016 09:54:33 a.m."
                Console.WriteLine(String.Format("{0:M}", now)); // Imprime: "22 de octubre"
                Console.WriteLine(String.Format("{0:T}", now)); // Imprime: "09:54:33 a.m."
                Console.WriteLine(String.Format("{0:r}", now)); // Imprime: "Sat, 22 Oct 2016 09:54:33 GMT"
                Console.WriteLine();
                Console.WriteLine(String.Format("{0:dd/MM/yyyy}", now)); // Imprime: "24/10/2016"
                Console.WriteLine(String.Format("{0:dd-MM-yyyy}", now)); // Imprime: "24-10-2016"
                Console.WriteLine(String.Format("{0:dd MMM yyyy}", now)); // Imprime: "24 oct. 2016"
                Console.WriteLine(String.Format("{0:dd 'de' MMMM 'de' yy}", now)); // Imprime: "24 de octubre de 16"

                Print.WriteEntrada("*****Relleno o padding*****");
                Console.WriteLine(String.Format("I|{0,10}|{0,-10}|D", 1300));    // Imprime: "I|      1300|1300      |D"
                Console.WriteLine(String.Format("I|{0,10}|{0,-10}|D", -52));     // Imprime: "I|       -52|-52       |D"
                Console.WriteLine(String.Format("I|{0,10}|{0,-10}|D", 0));       // Imprime: "I|         0|0         |D"
                var data = new[]
					{
						new { Dato1 = 0, Dato2="México", Dato3 = DateTime.Now },
						new { Dato1 = 2, Dato2 = "Canadá", Dato3 = DateTime.Now.AddDays(3) },
						new { Dato1 = 10, Dato2 = "Panamá", Dato3 = DateTime.Now.AddDays(-2) },
						new { Dato1 = 0, Dato2 = "Perú", Dato3 = DateTime.Now.AddMonths(-2) }
					};
                foreach (var item in data)
                {
                    Console.WriteLine("|{0,10:000}|{1,10}|{2,10:dd-MM}|", item.Dato1, item.Dato2, item.Dato3);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }

            return result;
        }
    }
}
