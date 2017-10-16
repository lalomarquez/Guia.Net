using C.DAL;
using C.DAL.Consultas;
using Newtonsoft.Json;
using System;
using System.Data;

namespace C.BLL.Rules
{
    public class LogicaSucursales
    {
        ConSucursales dal = new ConSucursales();

        public void ConsultasSucursales()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("test");

            //dal.ObtenerCatRegiones();
            //dal.ObtenerSucursales();
            //dal.ObtenerSucursalesxId(10);
            //dal.ObtenerSucursalesbyId(10);
            //dal.ObtenerPlazas();
            //dal.ObtenerTodasSucursales();

            try
            {             
                ds.Tables.Add(dal.GetRegiones().Copy());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }                       
        }

        public string JsonData()
        {
            string json = string.Empty;
            try
            {
                json = JsonConvert.SerializeObject(dal.GetRegiones());
                Console.WriteLine("Datos Json {0}", json);
                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
                return ex.ToString();
            }                        
        }

        public bool ConsultarSucursalesoPlazas(string query)
        {
            bool result = false;
            try
            {
                dal.ConsultaGenerica(query);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }
            return result;
        }
    }
}
