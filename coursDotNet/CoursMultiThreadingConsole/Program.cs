using System;
using System.Threading;

namespace CoursMultiThreadingConsole
{
    class Program
    {
        //Mutex
        static Mutex m1 = new Mutex();
        //Lock
        static object _lock = new object();

        //Semaphore
        static SemaphoreSlim semaphore = new SemaphoreSlim(4);
        static void Main(string[] args)
        {
            //Thread t1 = new Thread(()=> Afficher("A"));
            //t1.Start();
            //Thread t2 = new Thread(() => Afficher("B"));
            //t2.Start();
            TestSemaphore();
        }

        static void Afficher(string chaine)
        {
            //m1.WaitOne();
            //for(int i=1; i <= 1000; i++)
            //{
            //    Console.Write(chaine);
            //}
            //m1.ReleaseMutex();

            //Version avec un lock
            lock(_lock)
            {
                for (int i = 1; i <= 1000; i++)
                {
                    Console.Write(chaine);
                }
            }
        }

        static void TestSemaphore()
        {

            for(int i=1; i <= 10; i++)
            {
                Thread t = new Thread(AffichageSemaphore);
                t.Start(i);
            }
        }

        static void AffichageSemaphore(object numeroThread)
        {
            semaphore.Wait();
            Console.WriteLine($"Thread N° {(int)numeroThread} démarre");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread N° {(int)numeroThread} s'arrete");
            semaphore.Release();
        }
    }
}
