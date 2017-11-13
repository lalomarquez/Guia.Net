using System;
using System.Runtime.InteropServices;
using C.Helpers;

namespace C.BLL.Demos
{
    public class TiposParametros
    {
        /// <summary>
        /// Parametro x valor
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int ParametroxValor(int i)
        {
            Console.WriteLine("BEGIN");
            Console.WriteLine("--Se envia una copia de su valor.");
            Console.WriteLine("--Cualquier cambio que sufra el parámetro dentro del método no afectará al valor original.");
            Console.WriteLine("--Al pasar un objeto no crea una copia del objeto.");
            Console.WriteLine("--Los tipos simples son x valor (boolean, int, float,…)");

            Console.WriteLine();
            Console.WriteLine("     valor del parametro de entrada: {0}", i.ToString());
            Console.WriteLine("     operacion: i + {0}", 1);
            i = i + 1;
            Console.WriteLine("     valor de salida: {0}", i);
            Console.WriteLine("END;");
            return i;
        }

        /// <summary>
        /// Parametro x referencia
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int ParametroxReferencia(ref int i)
        {
            Console.WriteLine("BEGIN");
            Console.WriteLine("--Cualquier cambio en alguna propiedad del objeto dentro del método se reflejará también fuera de dicho método.");
            Console.WriteLine("--Los obj pasar por ref");
            Console.WriteLine("--Por REGLA, si admite NULL es por referencia y si no admite NULL es por valor. ");

            Console.WriteLine();
            Console.WriteLine("     valor del parametro de entrada: {0}", i.ToString());
            Console.WriteLine("     operacion: i + {0}", 1);
            i = i + 1;
            Console.WriteLine("     valor de salida: {0}", i);
            Console.WriteLine("END;");
            return i;
        }

        /// <summary>
        /// Utilizando parametro OUT.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="paramA"></param>
        /// <param name="paramB"></param>
        public void ParametroxOut(out int i, out string paramA, out string paramB)
        {
            Console.WriteLine("--Se puede regresar mas de un valor.");
            try
            {
                i = 44;
                paramA = "I've been returned";
                paramB = null;                      
            }
            catch (Exception ex)
            {
                i = 0;
                paramA = string.Empty;
                paramB = string.Empty;
                Print.WriteError("Ha ocurrido una Exception :( " + ex);
            }
        }

        /// <summary>
        /// Ejemplo de un metodo con parametro out y return
        /// </summary>
        /// <param name="idsEncuestas"></param>
        /// <param name="listUsuarios"></param>
        /// <returns></returns>
        //public static ETypeStatusOperacion ObtenerUsuariosxRuta(int[] idsEncuestas, out List<int> listUsuarios)
        //{
        //    statusOperacion = ETypeStatusOperacion.InitTask;
        //    listUsuarios = new List<int>();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(MainData.StringConnectionAdoNet))
        //        {
        //            conn.Open();
        //            using (SqlCommand cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandText = string.Format(@"SELECT  DISTINCT(R.idUsuario)
        //                                                    FROM  [ADM_ENCUESTAS_ENVIADAS] EE
        //                                                       INNER JOIN [ADM_DETALLE_RUTAS] DR WITH (nolock) ON DR.idReferencia = EE.idReferencia
        //                                                          INNER JOIN [ADM_RUTAS] R WITH (nolock) ON R.idRuta = DR.idRuta	                                                            
        //                                                    WHERE EE.idEncuesta IN({0})
        //                                                          AND EE.status = 1
        //                                                       AND DR.status = 1
        //                                                       AND R.status = 1
        //                                                    ORDER BY R.idUsuario ASC;", string.Join(",", idsEncuestas));
        //                cmd.CommandType = CommandType.Text;
        //                SqlDataReader reader = cmd.ExecuteReader();
        //                using (reader)
        //                {
        //                    if (reader.HasRows)
        //                    {
        //                        while (reader.Read())
        //                            listUsuarios.Add((int)reader["idUsuario"]);

        //                        statusOperacion = ETypeStatusOperacion.Ok;
        //                    }
        //                    else
        //                        statusOperacion = ETypeStatusOperacion.NoContent;

        //                    reader.Close();
        //                }
        //                cmd.Dispose();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception: {0}", ex);
        //    }
        //    return statusOperacion;
        //}

        //forma de como se llama
        //var listUsersXEncuesta = new List<int>();
        //var hiloOne = new Thread(() => { statusOperacion = UsuarioData.ObtenerUsuariosxRuta(info.idsEncuesta.ToArray(), out listUsersXEncuesta); });

        /// <summary>
        /// Utilizando parametro opcional.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int ParametroOpcional(int i, int j = 0)
        {
            Console.WriteLine("Suma: {0}", i + j);
            return i + j;
        }

        /// <summary>
        /// Utilizando parametro opcional usando atributo opcional.
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        public int ParametroOpcionalUsandoAtributoOpcional(int i, [Optional] int j)
        {
            Console.WriteLine("Resta: {0}", i - j);
            return i + j;
        }

        #region SOBRECARGA DE METODOS        
        /// <summary>
        /// Metodo sobrecargado, un parametro
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <returns></returns>
        public int ParametroUtilizandoMetodoSobrecargado(int firstNumber)
        {
            Console.WriteLine("Suma: {0}", firstNumber);
            return firstNumber;
        }

        /// <summary>
        /// Metodo sobrecargado, dos parametro
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        public int ParametroUtilizandoMetodoSobrecargado(int firstNumber, int secondNumber)
        {
            Console.WriteLine("Suma: {0}", firstNumber + secondNumber);
            return firstNumber + secondNumber;
        }
        #endregion

        /// <summary>
        /// Utilizando arreglo de parametro.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int NumeroVariableParametros(int i, params int[] numbers)
        {
            int result = 0;
            try
            {
                foreach (var item in numbers)
                {
                    result += item;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }

            Console.WriteLine("Suma: {0}", i + result);
            return i + result;
        }
    }
}
