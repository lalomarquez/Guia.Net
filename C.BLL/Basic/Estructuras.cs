using System;

namespace C.BLL.Basic
{
    /// <summary>
    /// Pueden contener constructores, constantes, campos, métodos, propiedades, indizadores, operadores y tipos anidados, 
    /// se utilizan principalmente para encapsular grupos de campos relacionados.
    /// - Los structs son de tipo valor.
    /// - no es posible asignar [null]
    /// - utilizar cuando la lógicamente representa un único valor, como los tipos primitivos (int, double, etc.)
    /// - Es inmutable
    /// - cuando no se empaqueta y desempaqueta con frecuencia.
    /// </summary>
    public struct Persona
    {
        public int edad { get; set; }
        public string nombre { get; set; }

        public void FullName()
        {
            Console.WriteLine("{1} tiene {0} años.", edad, nombre);
        }
    }

    public class Gente
    {
        public string name { get; set; }
        public string lastName { get; set; }

        public void NombreFull()
        {
            Console.WriteLine("Tu nombre es: {0} y tus apellidos {1}.", name, lastName);
        }
    }

    public class BLL_Structs
    {
        public void CallStructs()
        {
            var p = new Persona();
            //p = null;
            p.edad = 15;
            p.nombre = "Luis";
            p.FullName();
        }

        public void CallClass()
        {
            var g = new Gente();
            //g = null;
            g.name = "valente";
            g.lastName = "marquez";
            g.NombreFull();
        }
    }
}