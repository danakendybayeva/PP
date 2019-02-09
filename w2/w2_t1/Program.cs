using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2_t1 
{
    class Program
    {
        public static bool IsPalindrome(string s)
        {
            if (s.Length <= 1)
                return true;
            else
            {
                if (s[0] != s[s.Length - 1])
                    return false;
                else
                    return IsPalindrome(s.Substring(1, s.Length - 2));
            }
        }

        static void Main(string[] args)
        {
            string s = File.ReadAllText(@"C:\Users\Swist\Desktop\c#\input1.txt");
            bool pl = IsPalindrome(s);
            if (pl == true) Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}
