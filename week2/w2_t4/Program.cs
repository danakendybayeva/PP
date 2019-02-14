using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2_t4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\test";
            string path2 = @"C:\test2";
            string fileName = "file.txt";
            string destFile = Path.Combine(path2, fileName);
            DirectoryInfo di = new DirectoryInfo(path);
            if(di.Exists)
            {
                di.Delete(true);
            }
            di.Create();
            DirectoryInfo di2 = new DirectoryInfo(path2);
            if (di2.Exists)
            {
                di2.Delete(true);
            }
            di2.Create();

            StreamWriter sw = File.CreateText(@"C:\test\file.txt");
            sw.Close();

            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);

                foreach (string s in files)
                {
                    fileName = Path.GetFileName(s);
                    destFile = Path.Combine(path2, fileName);
                    File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }

            File.Move(destFile, @"C:\test2\file.txt");

            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path, true);
                }

                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
