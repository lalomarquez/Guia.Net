using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C.Helpers
{
    public class GetConn
    {
        private static string result = string.Empty;

        public static string GetConnStr(string KeyName)
        {
            try
            {
                if (!String.IsNullOrEmpty(ConfigurationManager.ConnectionStrings[KeyName].ConnectionString))
                    result = ConfigurationManager.ConnectionStrings[KeyName].ConnectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
                result = "Ha ocurrido una Exception :(";
            }
            //finally
            //{
            //    Console.WriteLine("Ha finalizado el metodo con resultado: " + result);
            //}
            return result;
        }
    }
}
