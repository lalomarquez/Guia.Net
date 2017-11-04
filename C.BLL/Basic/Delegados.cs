using C.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static C.BLL.Basic.Delegados;

namespace C.BLL.Basic
{
    public class Delegados
    {
        /*
         * Delegate: es un tipo que encapsula un metodo (es un obj. que guarda una funcion). Define una firma de un metodo.
         * de un metodo tradicional es posible que reciba como parametro un metodo(funcion).
         */

        /// <summary>
        /// Esto funciona como un apuntador a un metodo.
        /// </summary>
        /// <param name="anoNacimiento"></param>
        /// <returns></returns>
        public delegate int CalcularEdad(int anoNacimiento);
        public delegate string SumandoSecuenciaNumeros(int maxNum);
        public delegate bool EsMayorA(List<Empleado> list, int edad);
        public delegate bool IsMayor(Empleado bo);

        /// <summary>
        /// Call delegate [CalcularEdad]
        /// </summary>
        public void CallDelegado(SumandoSecuenciaNumeros sum, int numero = 100)
        {
            Console.WriteLine("Hacer algo ANTES");
            Console.WriteLine("***************Aqui entra el delegado***************");
            Console.WriteLine("Resultado {0}", sum(numero));
            Console.WriteLine("****************************************************");
            Console.WriteLine("Hacer algo DESPUES");

            Print.WriteInicioFin("Usando forma tradicional");
            ListaEmpleados();

            Print.WriteInicioFin("Usando delegados");
            var empleado = new Empleado();
            var list = new List<Empleado>();
            list.Add(new Empleado { edad = 35, nombre = "Victor" });
            list.Add(new Empleado { edad = 55, nombre = "Raul" });
            list.Add(new Empleado { edad = 89, nombre = "Jesus" });
            list.Add(new Empleado { edad = 48, nombre = "Maria" });
            list.Add(new Empleado { edad = 15, nombre = "Violeta" });

            //var del = new EsMayorA(empleado.EmpleadoXX);
            //del(list, 35);

            empleado.EmpleadoXX(list, x => x.edad > 50);
        }

        public void PruebasDelegados()
        {
            /*Aqui se instancia el obj. delegate y recibe como parametro un metodo.*/
            var miDelegado = new CalcularEdad(MetodoCalcularEdad);
            int edad = miDelegado(1985);

            /*resultado del metodo*/
            Console.WriteLine("Calculando la edad: {0}", edad);                       
        }

        /// <summary>
        /// Metodo que sera llamado por el delegado.
        /// </summary>
        /// <param name="anoNacimiento"></param>
        /// <returns></returns>
        public int MetodoCalcularEdad(int anoNacimiento)
        {            
            return 2017 - anoNacimiento;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ListaEmpleados()
        {
            var list = new List<Empleado>();
            var empleado = new Empleado();

            /*
            var e1 = new Empleado { edad = 35, nombre = "Victor" };
            var e2 = new Empleado { edad = 55, nombre = "Raul" };
            var e3 = new Empleado { edad = 89, nombre = "Jesus" };
            list.Add(e1);
            list.Add(e2);
            list.Add(e3);
            */

            list.Add(new Empleado { edad = 35, nombre = "Victor" });
            list.Add(new Empleado { edad = 55, nombre = "Raul" });
            list.Add(new Empleado { edad = 89, nombre = "Jesus" });
            list.Add(new Empleado { edad = 48, nombre = "Maria" });
            list.Add(new Empleado { edad = 15, nombre = "Violeta" });

            Console.WriteLine("Empleados mayores a 35: ");
            empleado.EmpleadoX(list);
        }
    }

    public class Empleado
    {
        public int edad { get; set; }
        public string nombre { get; set; }

        public void EmpleadoX(List<Empleado> list)
        {
            foreach (var item in list)
            {
                if (item.edad > 35)
                    Console.WriteLine(item.nombre);
            }
        }

        public bool EmpleadoXX(List<Empleado> list, IsMayor esMayor)
        {
            foreach (var item in list)
            {                
                if (esMayor(item))
                    Console.WriteLine(item.nombre);
            }

            return true;
        }
    }
}
