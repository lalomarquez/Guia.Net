using System;

namespace C.BLL.PilaresPOO.Poliformismo
{
    public class BLLPoliformismo
    {
        /*
         * Existen 4 formas de poliformosmo
         * POLIFORMISMO X HERENCIA: ver ejemplo de la clase Herencia_Override.cs
         * SOBRECARGA DE METODOS: ver ejemplo de la clase TiposParametros region [SOBRECARGA DE METODOS]
         * POLIFORMISMO X ABSTRACCION, caracterisiticas:
         * - siempre debe de ser [public], no debe de ser [sealed]
         * - podemos declarar métodos, funciones, eventos, delegados, propiedades y variables.
         * - para utilizar una clase abstracta, no tenemos más remedio que heredar de ella.
         * - tanto la class como el method deben de contener la palabra reservada [abstract]
         * - puede incluir funcionalidad ; a esto se le llama agregar funcionalidad. Una interfaz no puede.
         * - puede contener funciones y métodos que serán utilizados por las clases que implementen la clase abstracta.
         * - una clase sólo puede implementar una única clase abstracta, ya que no existe soporte para herencia múltiple.
         * - una clase que herede de una clase abstracta no tiene porqué implementar ningún método abstracto de la misma.
         * - una clase abstracta puede contener estados (data members) e implementaciones (funciones y métodos).
         * - en rendimiento, una clase abstracta es más rápida que una interfaz, ya que la clase que implementa la interfaz, debe preparar todas las definiciones de la misma.
         * POLIFORMISMO X INTERFACE: 
         * - la interfaz siempre es [public] y los miembros igual por defecto (todo los miembros de una interfaz son públicos y abstractos).
         * - se puede declarar métodos, funciones, eventos, delegados o propiedades.
         * - solo se definen los comportamientos (header del metodo)
         * - se puede heredar n [interface] a una clase.
         * - todo lo que se declare en la [interface] se instancia en la clase (se expone un contrato que debe cumplirse).
         * - no posee estado (data members) o implementación alguna (funciones y métodos).
         */

        public void PoliformismoXAbstraccion()
        {
            
            var c = new Circulo();
            c.Radius = 5;
            Console.WriteLine(c.Descripcion("RADIO"));            
            Console.WriteLine("Area = {0}", c.CalcularArea());
            Console.WriteLine("Perimetro = {0}", c.CalcularPerimetro());

            var cu = new Cuadrado();
            cu.Lado = 2;
            cu.Perimetro = 3;
            Console.WriteLine(cu.Descripcion("CUADRADO"));
            Console.WriteLine("Area = {0}", cu.CalcularArea());
            Console.WriteLine("Perimetro = {0}", cu.CalcularPerimetro());

            var r = new Rectangulo();
            r.Altura = 10;
            r.Base = 15;
            Console.WriteLine(cu.Descripcion("RECTANGULO"));
            Console.WriteLine("Area = {0}", r.CalcularArea());
            Console.WriteLine("Perimetro = {0}", r.CalcularPerimetro());
        }

        public void PoliformismoXInterface()
        {
            var chi = new Chihuahua();
            Console.WriteLine(chi.Ladrar());
            Console.WriteLine(chi.Dormir());
            Console.WriteLine(chi.CalcularEdad(50));

            var pa = new PastorAleman();
            Console.WriteLine(pa.Ladrar());
            Console.WriteLine(pa.Dormir());
            Console.WriteLine(pa.CalcularEdad(666));
        }
    }

    #region POLIFORMISMO X ABSTRACCION
    /// <summary>
    /// Clase Base para operaciones de las Fig. Geometricas.
    /// </summary>
    public abstract class FigGeometrica
    {
        public double Area { get; set; }
        public double Perimetro { get; set; }
        public double Radius { get; set; }
        public double Lado { get; set; }
        public double Base { get; set; }
        public double Altura { get; set; }
       
        /// <summary>
        /// Metodos que se van a implementar en [n] clases deribadas.
        /// </summary>
        public abstract double CalcularArea();
        public abstract double CalcularPerimetro();

        /// <summary>
        /// Metodo que aporta funcionalidad.
        /// </summary>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        public string Descripcion(string descripcion) => descripcion;
        //public string Descripcion(string descripcion)
        //{
        //    return descripcion;
        //}    
    }

    public class Circulo : FigGeometrica
    {
        public override double CalcularArea()
        {
            return Area = (float)Math.PI * Radius * Radius;
        }

        public override double CalcularPerimetro()
        {
            return Perimetro = (float)Math.PI * (Radius * 2);
        }

        //WARNING, para utilizar este metodo se debe de add la palabra reservada [new], ver ejemplo Herencia_Hiding.cs
        //public string Descripcion(string msj)
        //{
        //    Console.WriteLine("cxzkljczxjk");
        //    return msj;
        //}
    }

    public class Cuadrado : FigGeometrica
    {        
        public override double CalcularArea()
        {
            return Area = Lado * Lado;
        }

        public override double CalcularPerimetro()
        {
            return Perimetro = 4 * Lado;
        }
    }

    public class Rectangulo : FigGeometrica
    {       
        public override double CalcularArea()
        {
            return Area = Base * Altura;     
        }

        public override double CalcularPerimetro()
        {
            return Perimetro = (2 * Base) + (2 * Altura);
        }
    }
    #endregion

    #region POLIFORMISMO X INTERFACE
    public interface IPerro
    {
        string Ladrar();
        string Dormir();
        int CalcularEdad(int edad);
    }
    public class Chihuahua : IPerro
    {
        public int CalcularEdad(int edad)
        {
            return edad;
        }

        public string Dormir()
        {
            return "Chihuahua ladrando";
        }

        public string Ladrar()
        {
            return "Chihuahua durmiendo";
        }
    }
    public class PastorAleman : IPerro
    {
        public int CalcularEdad(int edad)
        {
            return edad;
        }

        public string Dormir()
        {
            return "Pastor Aleman ladrando";
        }

        public string Ladrar()
        {
            return "Pastor Aleman durmiendo";
        }
    }
    #endregion
}
