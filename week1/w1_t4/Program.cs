using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w1_t4
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = Convert.ToInt32(Console.ReadLine());//input of number of lines
            string[,] arr = new string[n, n];//creating 2d array
            for (int i = 0; i < n; i++)//running through y coordinate
            {
                for (int j = 0; j <= i; j++)//running through x coordinate
                {
                    arr[i, j] = "[*]";//assigning [*] to element
                    Console.Write(arr[i, j]);//output [*]
                }
                    
                    Console.WriteLine();//jump to a new line\


            }
        }
    }
}
