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
            string sourceFile = Path.Combine(path, fileName);
            string destFile = Path.Combine(path2, fileName);
            //lines from 18 to 30 stands for creating folders from path and path2
            //first we check if the same folder exists and delete it if it is
            //then we create the folder
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
            //streamwriter allows to create a text file
            StreamWriter sw = File.CreateText(sourceFile);
            sw.Close();//closing the streamwriter session
            //moving a file to new location
            if (File.Exists(destFile))
                File.Delete(destFile);
            File.Move(sourceFile, destFile);

            if (Directory.Exists(path))//for deleting a folder with files
            {
                try
                {
                    Directory.Delete(path, true);//deleting folder
                }

                catch (IOException e)
                {
                    //if any errors occur the computer sends a message about the error
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
