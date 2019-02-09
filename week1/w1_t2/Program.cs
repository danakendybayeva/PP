using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w1_t2
{
    class Student
    {
        string id;
        string name;
        int year;

        public Student(string id, string name) // creating the constructor
        {
            this.name = name;
            this.id = id;
            this.year = DateTime.Now.Year;

        }
        public void GetData() // method for showing id and name
        {
            Console.WriteLine(id + " " + name); // outputs id and name
        }
        public void IncreamentYear() //method for incrementing year
        {
            year++; // adds 1 to year
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("18BD45679", "Asem");// adding new student
            s.GetData();// method for showing id and name
            s.IncreamentYear();//method for incrementing year
        }
    }
}