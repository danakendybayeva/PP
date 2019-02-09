using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w1_t3
{
    class Program
    {
        static void DoubleNum(int[] a)
        {
            int n = a.Length;   
            int[] a2 = new int[n * 2]; // array for output nums
            string[] nums = Console.ReadLine().Split(new char[] { ' ' });
            //spliting the given string of numbers into separate chars, so we can use them
            for (int i = 0; i < n; ++i) // running through array of input num
            {
                a[i] = Convert.ToInt32(nums[i]); //convert from string to int
                a2[i * 2] = a[i]; // for showing the number first time
                a2[i * 2 + 1] = a[i]; // for showing the number second time
                Console.Write(a2[i * 2] + " " + a2[i * 2 + 1] + " "); // output
            }
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());  // convert the number of inputs to int
            int[] a = new int[n]; // array for input nums 
            DoubleNum(a);
        }
    }
}