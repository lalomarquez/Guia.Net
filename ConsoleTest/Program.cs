using C.BLL.Rules;
using C.BLL.Demos;
using C.BO;
using C.Helpers;
using System;
using FileHelpers;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
            {
            Print.WriteInicioFin("<<<<**************INICIO**************>>>>");

            LeerCSVconFileHelpers();

            Print.WriteInicioFin("<<<<**************FIN**************>>>>");
            Console.ReadKey();
        }

        public static void Excel()
        {
            var r = new Random();
            var suc = new LogicaSucursales();            
            var boExcel = new ArchivoExcel();
            boExcel.extencion = ".xlsx";
            boExcel.nombreArchivo = "prueba_" + r.Next(1, 999).ToString();
            boExcel.encabezadoArchivo = "Almacenes";
            boExcel.path = @"C:\Users\TNDeveloper\Desktop\excel\";
            boExcel.inicioColumna = 2;
            boExcel.inicioFila = 6;            
            //Console.WriteLine(boExcel.ToString());

            suc.GenerarReporteExcel("SELECT top 50 * FROM ADM_PREGUNTAS", boExcel);
        }

        public static void TiposParametros()
        {
            var tp = new TiposParametros();
            int i = 10, j = 10, h=0;
            string salidaA= string.Empty, salidaB= string.Empty;
            Print.WriteEntrada("DECLARE VAR i: " + i.ToString());
            Print.WriteEntrada("DECLARE VAR j: " + j.ToString());

            Console.WriteLine("********PARAMETRO X VALOR********");            
            tp.ParametroxValor(i);            
            Print.WriteSalida("valor DESPUES de entrar al metodo ParametroxValor i: " + i.ToString());

            Console.WriteLine("********PARAMETRO X REFERENCIA********");
            tp.ParametroxReferencia(ref j);
            Print.WriteSalida("valor DESPUES de entrar al metodo ParametroxReferencia j: " + j.ToString());

            Console.WriteLine("********PARAMETRO X OUT********");
            tp.ParametroxOut(out h, out salidaA, out salidaB);
            Print.WriteSalida("retorno int: "+ h.ToString());
            Print.WriteSalida("retorno paramA: " + salidaA);
            Print.WriteSalida("retorno paramB: " + salidaB);

            Console.WriteLine("********parametro opcional********");
            tp.ParametroOpcional(10);
            tp.ParametroOpcional(10, 10);

            Console.WriteLine("********parametro opcional usuando atributo opcional********");
            tp.ParametroOpcionalUsandoAtributoOpcional(10);
            tp.ParametroOpcionalUsandoAtributoOpcional(10, 6);

            Console.WriteLine("********parametro utilizando metodos sobrecargado********");
            tp.ParametroUtilizandoMetodoSobrecargado(10);
            tp.ParametroUtilizandoMetodoSobrecargado(10, 15);

            Console.WriteLine("********numero variable de parametros********");
            //tp.NumeroVariableParametros(10);
            tp.NumeroVariableParametros(10, 1);
            tp.NumeroVariableParametros(10, 1, 19);
        }

        public static void MetodosGenericos()
        {
            var bll = new MetodosGenericos();
            var boEdos = new CatEdos();
            boEdos.ID_Estado = 1;
            boEdos.ID_Municipio = 1;
            boEdos.NombreEstado = "Nuevo León";
            boEdos.NombreMunicipio = "Guadalupe";

            var boFarm = new CatFarmacias();
            boFarm.Region = "R12";
            boFarm.Nombre_cadena = "Benvides";
            boFarm.Farma_id = "Bes001";
            boFarm.Estado = "Guadalajara";
            boFarm.Estatus_sucursal = "Activo";

            Console.WriteLine(bll.Serializar(boEdos));
            Console.WriteLine(bll.Serializar(boFarm));
            
            Console.WriteLine("{0}*************CON METODO GENERICO*************{0}", Environment.NewLine);

            Console.WriteLine(bll.SerializarGenerico<CatEdos>(boEdos));
            Console.WriteLine(bll.SerializarGenerico<CatFarmacias>(boFarm));
        }

        /// <summary>
        /// Leer .CSV y insertar en BD
        /// </summary>
        public void LeerCSVInsertarBD()
        {
            LogicaCSV csv = new LogicaCSV();
            string load = @"C:\Users\TNDeveloper\Documents\TELSTOCK\Pruebas POO\Guia.NET\Archivos\farmacias.csv";
            //csv.LeerItemCSV(load);                
            //csv.LeerItemFarmaciaCSV(load);
        }

        /// <summary>
        /// Leer arhico csv con libreria FileHelpers
        /// </summary>
        public static void LeerCSVconFileHelpers()
        {
            /*var detector = new FileHelpers.Detection.SmartFormatDetector();
            var formats = detector.DetectFileFormat(@"C:\Users\TNDeveloper\Desktop\excel\datos.csv");
            foreach (var format in formats)
            {
                Console.WriteLine("Format Detected, confidence:" + format.Confidence + "%");
                var delimited = format.ClassBuilderAsDelimited;

                Console.WriteLine("    Delimiter:" + delimited.Delimiter);
                Console.WriteLine("    Fields:");

                foreach (var field in delimited.Fields)
                {
                    Console.WriteLine("        " + field.FieldName + ": " + field.FieldType);
                }               
            }*/

            try
            {
                var engine = new FileHelperEngine<CatEdosFileHelper>();
                var records = engine.ReadFile(@"C:\Users\TNDeveloper\Desktop\excel\datos.csv");
                //records = null;
                if (records != null)
                {
                    foreach (var record in records)
                    {
                        Console.WriteLine(string.Format("idEstado: {0}", (!string.IsNullOrEmpty(record.ID_Estado)) ? record.ID_Estado : "[NO HAY DATOS EN CSV]"));
                        Console.WriteLine(string.Format("idMunicipio: {0}", record.ID_Municipio));
                        Console.WriteLine(string.Format("Estado: {0}", record.NombreEstado));
                        Console.WriteLine(string.Format("Municipio: {0}", record.NombreMunicipio));
                        Print.WriteSalida("==========================================================");
                    }
                }
                else
                    Console.WriteLine("El objeto es null!!");
            }
            catch (Exception ex)
            {
                Print.WriteError(ex.ToString());
            }            
        }
    }
}
