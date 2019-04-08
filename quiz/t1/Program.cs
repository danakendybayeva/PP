using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace t1
{
    public class Course
    {
        public string title;
        public Teacher teacher;
        XmlSerializer xs = new XmlSerializer(typeof(Course));
        public Course()
        {

        }
        public Course(string title, Teacher teacher)
        {
            this.title = title;
            this.teacher = teacher;
        }
        public void Serialize()
        {
            FileStream fs = new FileStream("course.xml", FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, this);
            fs.Close();
        }
        public Course Deserialize()
        {
            FileStream fs = new FileStream("course.xml", FileMode.Open, FileAccess.Read);
            Course c1 = xs.Deserialize(fs) as Course;
            fs.Close();
            return c1;
        }
        public override string ToString()
        {
            return title + " " + teacher;
        }
    }
    public class Teacher
    {
        public string name;
        public string surname;
        public int salary;
        XmlSerializer xs = new XmlSerializer(typeof(Teacher));

        public Teacher()
        {

        }
        public Teacher( string name, string surname, int salary)
        {
            this.name = name;
            this.surname = surname;
            this.salary = salary;
        }
        
        public override string ToString()
        {
            return name + " " + surname + " " + salary;
        }

        public void Serialize()
        {
            FileStream fs = new FileStream("teacher.xml", FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, this);
            fs.Close();
        }
        public Teacher Deserialize()
        {
            FileStream fs = new FileStream("teacher.xml", FileMode.Open, FileAccess.Read);
            Teacher t1 = xs.Deserialize(fs) as Teacher;
            fs.Close();
            return t1;
        }
        
    }
    
    class Program
    {
        static void Main(string[] args)
        {

            Course c = new Course();
            c.title = "PP";
            //c.teacher = "A";
            Teacher t = new Teacher();
            t.name = "A";
            t.surname = "B";
            t.salary = 1000;

            c.teacher = t;
            c.Serialize();
            t.Serialize();

            Course c2 = c.Deserialize();
            Console.WriteLine(c2.ToString());

            Teacher t2 = t.Deserialize();
            Console.WriteLine(t2.ToString());
        }
    }
}
