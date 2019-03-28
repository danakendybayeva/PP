using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
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
                for (int i = 2; i < a; i++)
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
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            string[] nums = Console.ReadLine().Split(new char[] { ' ' });
            string ans = "";
            for(int i = 0; i < n; i++)
            {
                a[i] = int.Parse(nums[i]);
                if (Prime(a[i]))
                    ans = ans + a[i].ToString() + " ";
            }
            Console.WriteLine(ans);
        }
    }
}
