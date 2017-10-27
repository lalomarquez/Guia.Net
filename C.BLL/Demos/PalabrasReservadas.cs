using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C.BLL.Demos
{
    public static class PalabrasReservadas
    {

        #region YIELD
        public static void CrearLoopNumeros(int valorMin, int valorMax, int tamañoArreglo, out string resultado)        
        {
            var r = new Random();
            var sb = new StringBuilder();
            var list = new List<int>();

            for (int i = 0; i < tamañoArreglo; i++)
            {
                list.Add(r.Next(valorMin, valorMax));
                sb.Append(list[i] + ",");                
            }                       
                                    
            resultado = sb.ToString();            
        }

        /// <summary>
        /// Filtro de numeros con Yield. Para que dentro de un método se pueda usar la palabra yield, este debe tener como tipo de retorno 'IEnumerable'.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<int> FiltroConYield(List<int> list)
        {            
                foreach (int i in list)
                {
                    if (i > 30)
                    {                        
                        yield return i;
                    }
                }            
        }

        /// <summary>
        /// Filtrar numeros > 30 y guardarlos en una List<int>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<int> FiltroSinYield(List<int> list)
        {
            List<int> listTemp = new List<int>();
            try
            {
                foreach (int i in list)
                {
                    if (i > 30)
                    {
                        listTemp.Add(i);
                        //Console.WriteLine("numeros > '30' [{0}]", i);
                    }
                }
                //Console.WriteLine("Total item's > a 30: {0}", listTemp.Count.ToString());
                return listTemp;
            }
            catch (Exception ex)
            {
                throw;
            }                        
        }
        #endregion
    }
}
