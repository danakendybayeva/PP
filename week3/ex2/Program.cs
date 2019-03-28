using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\");
            var dirs = dir.GetDirectories();

            foreach (var subd in dirs)
            {
                try
                {
                    var files = subd.GetFiles("*.txt");
                    int n = files.Length;
                    Console.WriteLine(subd.Name + " " + n);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}