using C.Helpers;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Text;

namespace C.DAL.Consultas
{
    public class ConSucursales
    {
        Database db = new SqlDatabase(GetConn.GetConnStr("ProspectaNet"));
        SqlDatabase sqlDB = new SqlDatabase(GetConn.GetConnStr("ProspectaNet"));        
        private string count = string.Empty;

        /// <summary>
        /// get conn with Database
        /// </summary>
        public void ObtenerCatRegiones()
        {
            try
            {
                using (IDataReader reader =db.ExecuteReader(CommandType.Text, "SELECT TOP 10 * FROM CAT_REGIONES"))
                {
                    DisplayRowValues(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }            
        }

        /// <summary>
        /// Query con CommandType.Text 
        /// </summary>
        public void ObtenerSucursales()
        {
            try
            {               
                using (IDataReader reader = sqlDB.ExecuteReader(CommandType.Text, "SELECT TOP 10 * FROM ADM_SUCURSALES"))
                {
                    DisplayRowValues(reader);
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }
            finally
            {
                Console.WriteLine("Ha finalizado ");
            }            
        }

        /// <summary>
        /// Query con CommandType.Text y utilizando parametros con prefijo @
        /// </summary>
        public void ObtenerPlazas()
        {
            try
            {
                string query = "SELECT TOP 10 * FROM CAT_PLAZAS WHERE ID_Plaza = @idPlaza";
                using (DbCommand sqlCmd = sqlDB.GetSqlStringCommand(query))
                {
                    sqlDB.AddInParameter(sqlCmd, "idPlaza", DbType.Int16, 7);                    
                    using (IDataReader sqlReader = sqlDB.ExecuteReader(sqlCmd))
                    {
                        DisplayRowValues(sqlReader);
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }
            //finally
            //{
            //    Console.WriteLine("Ha finalizado ");
            //}
        }

        /// <summary>
        /// call SP with input parameter
        /// </summary>
        /// <param name="IdSucursal"></param>
        public void ObtenerSucursalesxId(int IdSucursal)
        {            
            try
            {
                using (IDataReader reader = sqlDB.ExecuteReader(ConstantesDB.sp_GetByIdSucursal, 10))
                {
                    DisplayRowValues(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }
        }

        /// <summary>
        /// call SP with input parameter cmd
        /// </summary>
        /// <param name="IdSucursal"></param>
        public void ObtenerSucursalesbyId(int IdSucursal)
        {
            try
            {   
                using (DbCommand cmd = db.GetStoredProcCommand(ConstantesDB.sp_GetByIdSucursal))
                {
                    db.AddInParameter(cmd, "@ID_Sucursal", DbType.Int32, IdSucursal);
                    using (IDataReader sqlReader = db.ExecuteReader(cmd))
                    {
                        DisplayRowValues(sqlReader);
                    }
                }                 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }
        }

        /// <summary>
        /// call SP with out parameters cmd
        /// </summary>
        /// <returns></returns>
        public string ObtenerTodasSucursales()
        {
            try
            {                
                using (DbCommand sqlCmd = sqlDB.GetStoredProcCommand(ConstantesDB.sp_GetAllSucursales))
                {
                    sqlDB.AddOutParameter(sqlCmd, "totalregistros", DbType.Int16, 7);
                    sqlDB.ExecuteNonQuery(sqlCmd);
                    count = string.Format("{0}",sqlDB.GetParameterValue(sqlCmd, "totalregistros"));                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }
            finally
            {
                Console.WriteLine("# de rows obtenidos: {0}", count);
            }
            return count;
        }

        public DataTable GetRegiones()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM CAT_REGIONES";
                using (DbCommand cmd = sqlDB.GetSqlStringCommand(query))
                {
                    dt = sqlDB.ExecuteDataSet(cmd).Tables[0];
                }               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }
            finally
            {
                Console.WriteLine("Get rows: {0}", dt.Rows.Count.ToString());
            }
            return dt;
        }

        private static void DisplayRowValues(IDataReader reader)
        {            
            try
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine("{0} = {1}", reader.GetName(i), reader[i].ToString());
                    }                    
                    Console.WriteLine();
                    //if (reader != null)                    
                    //    reader.Close();                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }            
        }

        private string ObtenerDatosConsulta(IDataReader reader)
        {            
            var sb = new StringBuilder();

            try
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine("{0} = {1}", reader.GetName(i), reader[i].ToString());
                        sb.Append(reader[i].ToString());
                    }                    
                    if (reader != null)
                        reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }
            return sb.ToString();
        }

        #region Consulta Generica.
        public string ConsultaGenerica(string query)
        {            
            string datos = string.Empty;

            try
            {
                using (IDataReader reader = sqlDB.ExecuteReader(CommandType.Text, query))
                {
                    datos = ObtenerDatosConsulta(reader);                    
                }
            }
            catch (Exception ex)
            {
                throw;
                //Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }            
            return datos;
        }

        public DataTable ConsultaDataTable(string query)
        {                                    
            DataTable dt = new DataTable();
            try
            {                
                using (DbCommand cmd = sqlDB.GetSqlStringCommand(query))
                {
                    dt = sqlDB.ExecuteDataSet(cmd).Tables[0];
                }                
            }
            catch (Exception ex)
            {
                dt = null;                
                throw;                
            }

            return dt;
        }
        #endregion
    }
}
