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
        static bool IsPalindrome(string s)
        {
            // function for checking whether the word is palindrome or not
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
            string s = File.ReadAllText(@"C:\Users\Swist\Desktop\c#\week2\input1.txt");//taking the input from file
            // checking for palindrome of word and output the answer
            if (IsPalindrome(s)) Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}
