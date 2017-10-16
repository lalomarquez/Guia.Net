using System;
using C.DAL.Altas;
using C.BO;
using System.IO;
using System.Text;

namespace C.BLL.Rules
{
    public class LogicaCSV
    {
        AltMunicipios dal = new AltMunicipios();
        AltFarmacias dalFar = new AltFarmacias();

        #region Municipios
        private bool InsertarItemCSV(CatEdos bo)        
        {
            try
            {
                dal.InsertarMunicipios(bo);                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
                return false;
            }
        }

        public bool LeerItemCSV(string path)
        {
            bool result = false;
            string[] sLineaArch;

            try
            {
                if (!String.IsNullOrEmpty(path))
                {
                    using (StreamReader sr = new StreamReader(path, Encoding.Default))
                    {
                        while (!sr.EndOfStream)
                        {
                            sLineaArch = sr.ReadLine().Split(',');
                            CatEdos bo = new CatEdos();
                            var items = sLineaArch;
                            bo.ID_Estado = Convert.ToInt16(items[0]);
                            bo.ID_Municipio = Convert.ToInt16(items[1]);
                            bo.NombreEstado = items[2].ToString();
                            bo.NombreMunicipio = items[3].ToString();
                            InsertarItemCSV(bo);
                        }
                    }
                    result = true;
                }
                else
                    Console.WriteLine("El valor de path es {}", path);
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }
            return result;
        }
        #endregion

        #region Farmacias        
        private bool InsertarItemCSV(CatFarmacias bo)
        {
            try
            {                
                dalFar.InsertarFarmacias(bo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
                return false;
            }
        }

        public bool LeerItemFarmaciaCSV(string path)
        {
            bool result = false;
            string[] sLineaArch;

            try
            {
                if (!String.IsNullOrEmpty(path))
                {
                    using (StreamReader sr = new StreamReader(path, Encoding.Default))
                    {
                        while (!sr.EndOfStream)
                        {
                            sLineaArch = sr.ReadLine().Split(',');
                            CatFarmacias bo = new CatFarmacias();                            
                            var items = sLineaArch;
                            bo.Sucursal_cod = Convert.ToInt16(items[0]);
                            bo.Nombre_sucursal_legado = items[1];
                            bo.Segmento_sucursal_ebs = items[2];
                            bo.Farma_id = items[3];
                            bo.Estatus_sucursal = items[4];
                            bo.Ciudad_operativa = items[5];
                            bo.Plaza = items[6];
                            bo.Cadena_cod = Convert.ToInt16(items[7]);
                            bo.Nombre_cadena = items[8];
                            bo.Suc_24hrs = items[9];
                            bo.Calle = items[10];
                            bo.Num_int = items[11];
                            bo.Num_ext = items[12];
                            bo.Colonia = items[13];
                            bo.Ciudad = items[14];
                            bo.Estado = items[15];
                            bo.Deleg_municipio = items[16];
                            bo.Division = items[17];
                            bo.Region = items[18];
                            InsertarItemCSV(bo);
                        }
                    }
                    result = true;
                }
                else
                    Console.WriteLine("El valor de path es {}", path);
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Ha ocurrido una Exception :( " + ex);
            }
            return result;
        }
        #endregion
    }
}
