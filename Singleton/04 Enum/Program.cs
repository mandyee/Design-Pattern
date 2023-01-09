using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _04_Enum
{
    public enum Singleton
    {
        UNIQUE_INSTANCE
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(threadFunc);
            Thread t2 = new Thread(threadFunc);
            t1.Start();
            t2.Start();
        }

        private static void threadFunc()
        {
            Singleton uniqueInstance = Singleton.UNIQUE_INSTANCE;
            Console.WriteLine(uniqueInstance);
            Thread.Sleep(1000);
        }
    }
}
