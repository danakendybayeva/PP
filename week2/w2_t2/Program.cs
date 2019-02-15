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
            List<string> l = new List<string>(); // creating list for output answer
            //FileStream allows to move data to and from the stream as arrays of bytes
            //FileMode allows to operate the file, here we just open existed file
            //FileAccess gives permission on read and write in file, here we give permission to read file
            FileStream fs = new FileStream(@"C:\Users\Swist\Desktop\c#\week2\input2.txt", FileMode.Open, FileAccess.Read);
            //StreamReader allows to take all or some part of data from the file
            StreamReader sr = new StreamReader(fs);

            string line = sr.ReadLine();// creating a string variable and assigning the input from file
            string[] nums = line.Split(new char[] { ' ' });//creating array and putting there splitted input

            foreach (var x in nums)//run through each element in array with numbers and check for prime
            {
                if (Prime(Convert.ToInt32(x)))
                {
                    l.Add(x);//adding the number to list if it's prime
                }
            }
            //closing FileStream and StreamReader sessions
            sr.Close();
            fs.Close();

            //FileStream allows to move data to and from the stream as arrays of bytes
            //FileMode allows to operate the file, here we create new file
            //FileAccess gives permission on read and write in file, here we give permission to write
            FileStream fs2 = new FileStream(@"C:\Users\Swist\Desktop\c#\week2\output2.txt", FileMode.Create, FileAccess.Write);
            //streamwriter allows to write data to a file
            StreamWriter sw = new StreamWriter(fs2);

            foreach (var x in l)//runnig through each element in list
            {
                sw.Write(x + " ");//writing the output in the file
                Console.Write(x + " ");//writing the output in the console
            }
            //closing FileStream and StreamWriter sessions
            sw.Close();
            fs2.Close();
        }
    }
}