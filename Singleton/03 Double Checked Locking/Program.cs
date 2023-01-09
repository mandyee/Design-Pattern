using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _03_Double_Checked_Locking
{
    public class Singleton
    {
        private volatile static Singleton uniqueInstance;
        private static object lockObj = new object();

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                if (uniqueInstance == null)
                {
                    lock (lockObj)
                    {
                        if (uniqueInstance == null)
                        {
                            uniqueInstance = new Singleton();
                        }
                    }
                }
                return uniqueInstance;
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
