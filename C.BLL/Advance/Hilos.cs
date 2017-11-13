using C.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace C.BLL.Advance
{
    public class Hilos
    {
        public async Task bllAsync()
        {
            var time = new Stopwatch();
            bool flag = false;
            bool flag2 = false;
            //var thA = new Thread(() => { flag = HiloA(); });
            //var thB = new Thread(() => { flag2 = HiloB(); });

            var tarea1 = HiloA();
            var tarea2 = HiloB();

            

            time.Start();
            await Task.WhenAll(tarea1, tarea2);
            //thA.Start();
            //thB.Start();
            //thA.Join();
            //thB.Join();            
            time.Stop();

            Console.WriteLine();
            using (StreamWriter writer = new StreamWriter(@"C:\Users\TNDeveloper\Desktop\TEST\log.txt", true))
            {
                writer.WriteLine("===============TIME===============");
                writer.WriteLine("tiempo {0}", time.Elapsed);
                writer.WriteLine("tiempo {0}", time.ElapsedMilliseconds / 100);
                writer.WriteLine("==================================");
            }
            Console.WriteLine("tiempo {0}", time.Elapsed);
            //Console.WriteLine("status hilo A: {0}", flag.ToString());
            //Console.WriteLine("status hilo B: {0}", flag2.ToString());
        }

        private async Task<bool> HiloA()
        {
            bool result = false;

            return await Task.Run(() =>
            {
                try
                {
                    for (int i = 0; i < 2000; i++)
                        Console.Write("abc ");

                    result = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ha ocurrido una Exception :( " + ex);
                }
                return result;
            });
        }

        private async Task<bool> HiloB()
        {
            bool result = false;

            return await Task.Run(() =>
            {
                try
                {
                    for (int i = 0; i < 1000; i++)
                        Console.Write("{0} ", i);

                    result = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ha ocurrido una Exception :( " + ex);
                }
                return result;
            });
        }
    }
}
