using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2_t2
{
    class Program
    {
        static bool Prime(int a)
        /*
        this function checks is the number prime or not; 
        true is prime and false is not prime
        */
        {
            bool x = true;
            if (a != 1)
            {
                for (int i = 2; i < a; ++i)
                {
                    if (a % i == 0)
                    {
                        x = false;
                    }
                }
            }
            else x = false;
            return x;
        }
        static void Main(string[] args)
        {
            List<string> l = new List<string>();

            FileStream fs = new FileStream(@"C:\Users\Swist\Desktop\c#\week2\input2.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line = sr.ReadLine();
            string[] nums = line.Split(new char[] { ' ' });

            foreach (var x in nums)
            {
                if (Prime(Convert.ToInt32(x)))
                {
                    l.Add(x);
                }
            }

            sr.Close();
            fs.Close();

            FileStream fs2 = new FileStream(@"C:\Users\Swist\Desktop\c#\week2\output2.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);

            foreach (var x in l)
            {
                sw.Write(x + " ");
                Console.Write(x + " ");
            }

            sw.Close();
            fs2.Close();
        }
    }
}