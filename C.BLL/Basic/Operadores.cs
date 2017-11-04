using C.Helpers;
using System;

namespace C.BLL.Basic
{
    public static class Operadores
    {
        /// <summary>
        /// condition ? first_expression : second_expression;  
        /// </summary>
        public static void Ternary()
        {
            Print.WriteEntrada("<><><> Ternary Operator ?: <><><>");
            int input = 100;
            string result = string.Empty;
            string ternary = string.Empty;

            if (input > 0)
                result = "positive";
            else
                result = "negative";

            ternary = (input > 0) ? "positive" : "negative";
            Print.WriteSalida(string.Format("Resultado forma IF-ELSE: '{0}' ", result));                       
            Print.WriteSalida(string.Format("Resultado con Ternay: '{0}' ", ternary));            
        }

        /// <summary>
        /// Devuelve el operando de la izquierda si el operando no es nulo; de lo contrario, devuelve el operando de la derecha.
        /// </summary>
        public static void NullCoalescing()
        {
            int? i = null;
            int j = i ?? 2;

            Print.WriteEntrada("<><><> Null Coalescing Operator ?? <><><>");

            Print.WriteComent("ANTES");
            Print.WriteSalida(string.Format("valor de [i] : '{0}' ", i));
            Print.WriteSalida(string.Format("valor de [j] : '{0}' ", j));

            i = 10;            
            j = 50;

            Print.WriteComent("DESPUES");
            Print.WriteSalida(string.Format("valor de [i] : '{0}' ", i));
            Print.WriteSalida(string.Format("valor de [j] : '{0}' ", j));


            Console.WriteLine();
            string name = null;// "nombre";
            string personName;

            Print.WriteInicioFin("forma ordinaria");            
            
            if (name == null)
                personName = "no name";
            else
                personName = name;
            Console.WriteLine(personName);
            
            Print.WriteInicioFin("forma operador ternario");
            personName = name == null ? "no name" : name;
            Console.WriteLine(personName);

            Print.WriteInicioFin("forma Null coalescing");
            personName = name ?? "no name";
            Console.WriteLine(personName);
        }
    }
}
