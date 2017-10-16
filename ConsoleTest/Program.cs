using C.BLL.Rules;
using C.BLL.Demos;
using C.BO;
using C.Helpers;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Print.WriteInicioFin("<<<<**************INICIO**************>>>>");

            //MetodosGenericos();
            //TiposParametros();

            Print.WriteInicioFin("<<<<**************FIN**************>>>>");
            Console.ReadKey();

            //LogicaSucursales objSuc = new LogicaSucursales();
            //objSuc.ConsultasSucursales();
            //objSuc.JsonData();                                 
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
       
    }
}
