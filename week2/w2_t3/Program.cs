using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2_t3
{
    class Program
    {
        static void PrintInfo(FileSystemInfo fsi, int k)
        {
            //function for printing all files and folders
            string s = new string(' ', k);//creating string responsible for blank spaces(пробелы)
            Console.WriteLine(s + fsi.Name);//output name of file/folder and blank spaces in front of it

            if (fsi.GetType() == typeof(DirectoryInfo))
            {
                //if the file is folder the program does next steps
                //puting all files from this folder to array
                FileSystemInfo[] arr = (fsi as DirectoryInfo).GetFileSystemInfos();
                foreach (var x in arr)
                {
                    //outputing all the files with increased number of blank spaces
                    PrintInfo(x, k + 4);
                }
            }
        }

        static void Main(string[] args)
        {
            //assigning the link of folder to represent the info about it
            DirectoryInfo dir = new DirectoryInfo(@"C:\Intel");
            PrintInfo(dir, 0);//calling the function
        }
    }
}
