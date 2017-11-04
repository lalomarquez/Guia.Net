using C.BLL.Rules;
using C.BLL.Demos;
using C.BLL.Basic;
using C.BO;
using C.Helpers;
using System;
using FileHelpers;
using System.Collections.Generic;
using C.BLL.PilaresPOO;
using C.BLL.PilaresPOO.Herencia;
using C.BLL.PilaresPOO.Poliformismo;
using static C.BLL.Basic.Delegados;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
            {
            //Print.WriteInicioFin("<<<<**************INICIO**************>>>>");            

            CallDelegados();

            //Print.WriteInicioFin("<<<<**************FIN**************>>>>");
            Console.ReadKey();
        }

        public static void CallDelegados()
        {
            var delegado = new SumandoSecuenciaNumeros(SumandoSecuencia);
            var bll = new Delegados();
            bll.CallDelegado(delegado);
        }

        private static string SumandoSecuencia(int maxNum)
        {
            int result = 0;

            for (int i = 1; i <= maxNum; i++)
                result += i;

            return result.ToString();
        }

        public static void Structs()
        {
            var bll = new BLL_Structs();
            bll.CallStructs();
            bll.CallClass();
        }

        public static void Poliformismo()
        {
            var bll = new BLLPoliformismo();            
            Print.WriteComent("Poliformismo X Abstraccion");
            bll.PoliformismoXAbstraccion();
            Console.WriteLine("******************************");
            Print.WriteEntrada("Poliformismo X Interface");
            bll.PoliformismoXInterface();
        }

        public static void POOHerencia_MethodOverride()
        {
            var bll = new BLLHerenciaOverride();
            bll.PruebasTrabajadorFull();
            bll.PruebasTrabajadorTemporal();
        }

        public static void POOHerencia_MethodHidden()
        {
            var bll = new BLLHerenciaHiding();
            bll.PruebasTiempoCompleto();
            bll.PruebasTiempoParcial();
        }

        public static void POOHerencia()
        {
            var herencia = new BLLHerencia();
            herencia.Hombre();
            herencia.Mujer();
        }

        public static void CallMetodos()
        {
            var m = new Metodos();
            m.Mensaje("Como estas?");

            var cd = new ClaseDerivada();
            cd.Implementacion();
        }

        public static void Sentencias()
        {
            var s = new Sentencias();
            s.If_Else(20);
            s.Switch(20);
            s.While(20);
            s.DoWhile();
        }

        public static void EjemplosEnums()
        {
            //Console.WriteLine(OperatingSystems.Linux);
            Print.WriteSalida(OperatingSystems.Linux.ToString());

            var alarmGoesOffOn = DaysOfWeek.Mon | DaysOfWeek.Wed | DaysOfWeek.Fri;
            Print.WriteSalida(DaysOfWeek.Fri.ToString());            
            Console.WriteLine((int)DaysOfWeek.Fri);
            Console.WriteLine("Alarm goes off on: " + alarmGoesOffOn);

            string[] arr = DaysOfWeek.GetNames(typeof(DaysOfWeek));
            foreach (string s in arr)
                Print.WriteSalida(s);                
        }

        public static void MetodoStringFormat()
        {
            var obj = new MetodoStringFormat();
            obj.Saludo("señor locutor");

        }

        public static void PalabraReservadaYield()
        {            
            string numeros = string.Empty;
            var listNumeros = new List<int>();

            try
            {
                PalabrasReservadas.CrearLoopNumeros(1, 100, 30, out numeros);                
                Console.WriteLine("Numeros aleatoreos: {0}", numeros.TrimEnd(','));

                string[] arrayNumeros = numeros.Split(',');

                foreach (var item in arrayNumeros)
                {                    
                    if (!string.IsNullOrEmpty(item))
                    {
                        int numero = Int32.Parse((string)item);
                        listNumeros.Add(numero);
                    }
                }
                
                Print.WriteEntrada("Filtro SIN Yield");
                foreach (var item in PalabrasReservadas.FiltroSinYield(listNumeros))
                {                    
                    Print.WriteSalida(item.ToString());
                }

                Print.WriteEntrada("Filtro CON Yield");                
                foreach (var item in PalabrasReservadas.FiltroConYield(listNumeros))
                {
                    Print.WriteSalida(item.ToString());
                }                
            }
            catch (Exception ex)
            {
                Print.WriteError(ex.ToString());
            }            
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
            tp.NumeroVariableParametros(10);
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

        public static void ClsGenericaMtdGenerico()
        {
            List<string> str_input = new List<string>();
            str_input.Add("uno");
            str_input.Add("dos");

            List<int> int_input = new List<int>();
            int_input.Add(1);
            int_input.Add(2);

            List<float> float_input = new List<float>();
            float_input.Add(1.001f);
            float_input.Add(2.002f);

            List<decimal> decimal_input = new List<decimal>();
            decimal_input.Add(0.001M);
            decimal_input.Add(0.002M);

            var str = MetodosGenericos<string>.GetGeneric(str_input);
            var entero = MetodosGenericos<int>.GetGeneric(int_input);
            var flotante = MetodosGenericos<float>.GetGeneric(float_input);
            var decimales = MetodosGenericos<decimal>.GetGeneric(decimal_input);
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
