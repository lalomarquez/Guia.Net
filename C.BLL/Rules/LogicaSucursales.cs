using C.DAL;
using C.DAL.Consultas;
using Newtonsoft.Json;
using System;
using System.Data;
using C.BO;
using C.Helpers;
using System.Collections.Generic;
using System.Collections;

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

        public string GenerarReporteExcel(string query, ArchivoExcel excel)
        {
            string datos = string.Empty;
            var helperExcel = new HelperExcel();            
            var dt = new DataTable();            

            try
            {
                dt = dal.ConsultaDataTable(query);                
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        helperExcel.GenerarExcel(dt, excel);
                    }
                }    
                else
                    Console.WriteLine("[dt] is null");
            }
            catch (Exception ex)
            {                
                Console.WriteLine("Ha ocurrido una Exception :( ");
                Print.WriteError(ex.ToString());
            }
            return datos;
        }
    }
}
