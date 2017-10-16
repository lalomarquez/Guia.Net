using C.Helpers;
using C.BO;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;

namespace C.DAL.Altas
{
    public class AltMunicipios
    {
        SqlDatabase sqlDB = new SqlDatabase(GetConn.GetConnStr("ProspectaNet"));

        public bool InsertarMunicipios(CatEdos bo)
        {
            bool result = false;
            try
            {
                string sql = "INSERT INTO [dbo].[_CAT_EDOS]\n"
                               + "           ([ID_Estado]\n"
                               + "           ,[ID_Municipio]\n"
                               + "           ,[NombreEstado]\n"
                               + "           ,[NombreMunicipio])\n"
                               + "     VALUES\n"
                               + "           (@ID_Estado\n"
                               + "           ,@ID_Municipio\n"
                               + "           ,@NombreEstado\n"
                               + "           ,@NombreMunicipio)\n";

                using (DbCommand sqlCmd = sqlDB.GetSqlStringCommand(sql))
                {
                    sqlDB.AddInParameter(sqlCmd, "ID_Estado", DbType.Int16, bo.ID_Estado);
                    sqlDB.AddInParameter(sqlCmd, "ID_Municipio", DbType.Int16, bo.ID_Municipio);
                    sqlDB.AddInParameter(sqlCmd, "NombreEstado", DbType.String, bo.NombreEstado);
                    sqlDB.AddInParameter(sqlCmd, "NombreMunicipio", DbType.String, bo.NombreMunicipio);
                    int insert = sqlDB.ExecuteNonQuery(sqlCmd);
                    if (insert == 1)
                    {
                        result = true;
                        //Console.WriteLine("OK");
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
