using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _01_LazyInstantiation
{
    public class Singleton
    {
        private static Singleton uniqueInstance;

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                if (uniqueInstance == null)
                {
                    uniqueInstance = new Singleton();
                    printHashCode(ref uniqueInstance);
                }
                return uniqueInstance;
            }
        }

        public static void printHashCode(ref Singleton s)
        {
            Console.WriteLine(s.GetHashCode());
        }
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
            var test = Singleton.Instance;
        }
    }
}
