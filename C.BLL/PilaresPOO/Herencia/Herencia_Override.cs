using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C.BLL.PilaresPOO.Herencia
{

    /*
    * 
    * METHOD OVERRIDE
    * Un método de una clase derivada puede tener el mismo nombre que un método de la clase base. 
    * Se puede especificar cómo interactúan los métodos mediante las palabras clave override. 
    * El modificador override extiende el método de clase base.
    * 
    */

    public class BLLHerenciaOverride
    {        
        public void PruebasTrabajadorTemporal()
        {
            var timeC = new TrabajadorTemporal();
            timeC.nombre = "Andrea";
            timeC.apellidos = "Pirlo";
            timeC.NombreCompleto();
        }

        public void PruebasTrabajadorFull()
        {
            var timeP = new TrabajadorFull();
            timeP.nombre = "Diego";
            timeP.apellidos = "Milito";
            timeP.NombreCompleto();
        }

    }

    #region OVERRIDE
    public class TrabajadorTemporal : BaseClassEmploye
    {
        public override void NombreCompleto()
        {
            Console.WriteLine("Metodo de la clase 'derivada' TrabajadorTemporal - {0} {1}", nombre, apellidos);
        }
    }

    public class TrabajadorFull : BaseClassEmploye
    {
        public override void NombreCompleto()
        {
            Console.WriteLine("Metodo de la clase 'derivada' TrabajadorFull - {0} {1}", nombre, apellidos);
        }
    }
    #endregion

    public class BaseClassEmploye
    {
        public string nombre { get; set; }
        public string apellidos { get; set; }

        public virtual void NombreCompleto()
        {
            Console.WriteLine("Metodo de la clase 'base' - {0} {1}", nombre, apellidos);
        }
    }
}
