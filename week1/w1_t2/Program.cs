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
        int year = 1;

        public Student(string id, string name) // creating parameters
        {
            this.name = name;
            this.id = id;

            //creating constructors
        }
        public void GetData() // method for showing id and name
        {
            Console.WriteLine(id + " " + name + " " + year); // outputs id and name
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
            s.GetData();
        }
    }
}