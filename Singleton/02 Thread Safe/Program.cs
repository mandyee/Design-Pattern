using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _02_Thread_Safe
{
    public class Singleton
    {
        private static Singleton uniqueInstance;
        private static object lockObj = new object();

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new Singleton();
                    }
                    return uniqueInstance;
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(threadFunc);
            Thread t2 = new Thread(threadFunc);
            Thread t3 = new Thread(threadFunc);
            Thread t4 = new Thread(threadFunc);
            t1.Start();
            Thread.Sleep(1000);
            t2.Start();
            Thread.Sleep(1000);
            t3.Start();
            Thread.Sleep(1000);
            t4.Start();
        }

        private static void threadFunc()
        {
            var test = Singleton.Instance;
        }
    }
}
