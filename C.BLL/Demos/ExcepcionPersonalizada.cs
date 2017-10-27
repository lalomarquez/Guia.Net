using C.Helpers;
using System;
using System.Runtime.Serialization;

namespace C.BLL.Demos
{
    public static class ExcepcionPersonalizada
    {
        public static void Custom()
        {
            Print.WriteEntrada("Generar clase personalizada para excepciones.");
            string test = "_UNO";
            try
            {
                if (!test.Equals("UNO"))
                {
                    //throw new MiExceptionPersonalizada("Se ha presentado la excepcion [tal]");
                    throw new MiExceptionPersonalizada();
                }
                else
                    Print.WriteSalida("Seguir flujo!!");
            }
            catch (MiExceptionPersonalizada ex)
            {
                Print.WriteError(string.Format("Excepcion!! {0}", ex));
                Print.WriteError(string.Format("Excepcion!! {0} Para mas info visita el sitio {1}", ex.Message, ex.HelpLink));
            }            
        }
    }

    [Serializable]
    public class MiExceptionPersonalizada : Exception
    {
        //public MiExceptionPersonalizada() { }
        public MiExceptionPersonalizada() : base("Se ha presentado un error.")
        {
            HelpLink = "http://test.com";
        }

        public MiExceptionPersonalizada(string message) : base(message) { }
        public MiExceptionPersonalizada(string message, Exception inner) : base(message, inner) { }
        protected MiExceptionPersonalizada(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
