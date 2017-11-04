using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C.BLL.PilaresPOO.Herencia
{
    /*
    * 
    * METHOD HIDING 
    * Un método de una clase derivada puede tener el mismo nombre que un método de la clase base. 
    * Se puede especificar cómo interactúan los métodos mediante las palabras clave new.
    * El modificador new oculta el método de clase base.
    * 
    */

    public class BLLHerenciaHiding
    {
        public void PruebasTiempoCompleto()
        {
            var timeC = new TrabajadorTiempoCompleto();
            timeC.nombre = "Andrea";
            timeC.apellidos = "Pirlo";
            timeC.NombreCompleto();
        }

        public void PruebasTiempoParcial()
        {
            var timeP = new TrabajadorTiempoParcial();
            timeP.nombre = "Diego";
            timeP.apellidos = "Milito";
            timeP.NombreCompleto();
        }
    }

    #region HIDING    
    public class TrabajadorTiempoCompleto : BaseClassEmpleado
    {
        /// <summary>
        /// Ocultando el metodo de la clase base (BaseClassEmpleado), es necesario add [new]
        /// </summary>
        public new void NombreCompleto()
        {
            Console.WriteLine("Metodo de la clase 'derivada' - {0} {1}", nombre, apellidos);
        }

        /// <summary>
        /// Si el metodo se llama igual que el de la clase base y se se deja de esa manera se muestra una ADVERTENCIA.
        /// </summary>
        //public void NombreCompleto()
        //{
        //    Console.WriteLine("TTC {0} {1}", nombre, apellidos);
        //}
    }

    public class TrabajadorTiempoParcial : BaseClassEmpleado
    {
        /// <summary>
        /// Es posible volver a llamar a el metodo base de la siguiente manera.
        /// </summary>
        public new void NombreCompleto()
        {
            base.NombreCompleto();
        }
    }       
    #endregion

    public class BaseClassEmpleado
    {
        public string nombre { get; set; }
        public string apellidos { get; set; }

        public void NombreCompleto()
        {
            Console.WriteLine("Metodo de la clase 'base' - {0} {1}", nombre, apellidos);
        }
    }
}
