using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace w8_t2
{
    public class MyThread
    {
        int id;
        Thread t;

        public MyThread(int id)
        {
            this.id = id;
            t = new Thread(new ThreadStart(StartThread));
            t.Start();
        }

        void StartThread()
        {
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine("Thread {0} is running", id);

            }
            Console.WriteLine("Thread {0} is finished", id);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 4; i++)
            {
                MyThread tr = new MyThread(i);
            }
        }
    }
}
