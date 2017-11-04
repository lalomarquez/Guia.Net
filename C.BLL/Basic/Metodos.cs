using C.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C.BLL.Basic
{
    /*
    /// public: Todos tienen acceso.
    /// private: Solo la clase que lo define tiene acceso él.
    /// protected: Solo las clases derivadas tienen acceso.
    /// internal: Solo clases contenidas en el mismo ensamblado tienen acceso.
    /// protected internal: Solo clases contenidas en el mismo ensamblado tienen acceso y desde dentro de una clase derivada.
    /// Si se omite, el valor por default es private.
    /// al añadir el modificador static para especificar que un método debe ser llamado desde una instancia de la clase o desde la clase misma.   
    */

    #region Modificador de acceso PRIVATE & PUBLIC    
    public class Metodos
    {        
        private int myVar;
        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public string Mensaje(string msj)
        {
            if (string.IsNullOrEmpty(msj))
                Print.WriteComent("No hay ningun mensaje!!");            
            else            
                Print.WriteSalida(string.Format("El mensaje es: [ {0} ]", msj));
            
            return msj;
        }

        public static string Saludo(string msj)
        {
            if (string.IsNullOrEmpty(msj))
                Print.WriteComent("No hay ningun mensaje!!");
            else
                Print.WriteSalida(string.Format("El mensaje es: [ {0} ]", msj));

            return msj;
        }
    }
    #endregion

    #region Modificador de acceso PROTECTED
    public class ClaseBase
    {
        protected int id;

        protected void Saludo(string msj)
        {
            Console.WriteLine("mensaje: {0}", msj);
        }
    }

    public class ClaseDerivada : ClaseBase
    {
        public void Implementacion()
        {
            Saludo("hola");
        }        
    }

    public class OtraClase
    {
        /// <summary>
        /// No es posible call el metodo de la clase base
        /// </summary>
        public void Prueba()
        {
            var cb = new ClaseBase();
            //cb.Saludo("saludo");
        }
    }
    #endregion

    #region MyRegion

    #endregion

    #region MyRegion

    #endregion
}
