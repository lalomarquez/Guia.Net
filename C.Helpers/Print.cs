using System;

namespace C.Helpers
{
    public static class Print
    {
        public static void WriteInicioFin(string value)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));            
            Console.ResetColor();
        }

        public static void WriteSalida(string value, params string[] param)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            //Console.Write(value.PadRight(Console.WindowWidth - 1));            
            Console.Write(value);
            Console.ResetColor();
        }        

        public static void WriteEntrada(string value)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));            
            Console.ResetColor();
        }

        public static void WriteError(string value, params string[] param)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));            
            Console.ResetColor();
        }

        public static void WriteComent(string value, params string[] param)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();
        }
    }
}
