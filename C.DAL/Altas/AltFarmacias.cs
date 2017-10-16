using C.Helpers;
using C.BO;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data.Common;
using System.Data;

namespace C.DAL.Altas
{
    public class AltFarmacias
    {
        SqlDatabase sqlDB = new SqlDatabase(GetConn.GetConnStr("ProspectaNet"));

        public bool InsertarFarmacias(CatFarmacias bo)
        {
            bool result = false;
            try
            {
                string sql = "INSERT INTO [dbo].[_CAT_FARMACIAS]\n"
                               + "           ([Sucursal_cod]\n"
                               + "           ,[Nombre_sucursal_legado]\n"
                               + "           ,[Segmento_sucursal_ebs]\n"
                               + "           ,[Farma_id]\n"
                               + "           ,[Estatus_sucursal]\n"
                               + "           ,[Ciudad_operativa]\n"
                               + "           ,[Plaza]\n"
                               + "           ,[Cadena_cod]\n"
                               + "           ,[Nombre_cadena]\n"
                               + "           ,[Suc_24hrs]\n"
                               + "           ,[Calle]\n"
                               + "           ,[Num_int]\n"
                               + "           ,[Num_ext]\n"
                               + "           ,[Colonia]\n"
                               + "           ,[Ciudad]\n"
                               + "           ,[Estado]\n"
                               + "           ,[Deleg_municipio]\n"
                               + "           ,[Division]\n"
                               + "           ,[Region])\n"
                               + "     VALUES\n"
                               + "           (@Sucursal_cod\n"
                               + "           ,@Nombre_sucursal_legado\n"
                               + "           ,@Segmento_sucursal_ebs\n"
                               + "           ,@Farma_id\n"
                               + "           ,@Estatus_sucursal\n"
                               + "           ,@Ciudad_operativa\n"
                               + "           ,@Plaza\n"
                               + "           ,@Cadena_cod\n"
                               + "           ,@Nombre_cadena\n"
                               + "           ,@Suc_24hrs\n"
                               + "           ,@Calle\n"
                               + "           ,@Num_int\n"
                               + "           ,@Num_ext\n"
                               + "           ,@Colonia\n"
                               + "           ,@Ciudad\n"
                               + "           ,@Estado\n"
                               + "           ,@Deleg_municipio\n"
                               + "           ,@Division\n"
                               + "           ,@Region)";

                using (DbCommand sqlCmd = sqlDB.GetSqlStringCommand(sql))
                {
                    sqlDB.AddInParameter(sqlCmd, "Sucursal_cod", DbType.Int16, bo.Sucursal_cod);
                    sqlDB.AddInParameter(sqlCmd, "Nombre_sucursal_legado", DbType.String, bo.Nombre_sucursal_legado);
                    sqlDB.AddInParameter(sqlCmd, "Segmento_sucursal_ebs", DbType.String, bo.Segmento_sucursal_ebs);
                    sqlDB.AddInParameter(sqlCmd, "Farma_id", DbType.String, bo.Farma_id);
                    sqlDB.AddInParameter(sqlCmd, "Estatus_sucursal", DbType.String, bo.Estatus_sucursal);
                    sqlDB.AddInParameter(sqlCmd, "Ciudad_operativa", DbType.String, bo.Ciudad_operativa);
                    sqlDB.AddInParameter(sqlCmd, "Plaza", DbType.String, bo.Plaza);
                    sqlDB.AddInParameter(sqlCmd, "Cadena_cod", DbType.Int16, bo.Cadena_cod);
                    sqlDB.AddInParameter(sqlCmd, "Nombre_cadena", DbType.String, bo.Nombre_cadena);
                    sqlDB.AddInParameter(sqlCmd, "Suc_24hrs", DbType.String, bo.Suc_24hrs);
                    sqlDB.AddInParameter(sqlCmd, "Calle", DbType.String, bo.Calle);
                    sqlDB.AddInParameter(sqlCmd, "Num_int", DbType.String, bo.Num_int);
                    sqlDB.AddInParameter(sqlCmd, "Num_ext", DbType.String, bo.Num_ext);
                    sqlDB.AddInParameter(sqlCmd, "Colonia", DbType.String, bo.Colonia);
                    sqlDB.AddInParameter(sqlCmd, "Ciudad", DbType.String, bo.Ciudad);
                    sqlDB.AddInParameter(sqlCmd, "Estado", DbType.String, bo.Estado);
                    sqlDB.AddInParameter(sqlCmd, "Deleg_municipio", DbType.String, bo.Deleg_municipio);
                    sqlDB.AddInParameter(sqlCmd, "Division", DbType.String, bo.Division);
                    sqlDB.AddInParameter(sqlCmd, "Region", DbType.String, bo.Region);

                    int insert = sqlDB.ExecuteNonQuery(sqlCmd);
                    if (insert == 1)
                    {
                        result = true;                        
                    }
                    else
                        Console.WriteLine("ERROR: Could not update just one row.");
                }
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }
            finally
            {
                Console.WriteLine("Ha finalizado el metodo con resultado: " + result.ToString());
            }

            return result;
        }
    }
}
