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
            string s = File.ReadAllText(@"C:\Users\Swist\Desktop\c#\input2.txt");
            int n = Convert.ToInt16(s); // amount of numbers
            int[] a = new int[n]; // creating an array of size n
            string[] nums = Console.ReadLine().Split(new char[] { ' ' });
            //spliting the given string of numbers into separate chars, so we can use them
            int cnt = 0; //counter for prime numbers 
            string answer = "";// string for output
            for (int i = 0; i < n; ++i)
            {
                a[i] = int.Parse(nums[i]); // converting from string to int
                if (Prime(a[i])) // checking if the number is prime or not
                {
                    cnt++; // if number is prime the counter increases for 1
                    answer = answer + a[i].ToString() + " "; // getting ready the output
                }
            }
            File.WriteAllText(@"C:\Users\Swist\Desktop\c#\output2.txt", answer);
        }
    }
}