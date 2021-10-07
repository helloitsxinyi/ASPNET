using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {        
            //Q1
            IEnumerable<Student> iter =
                from s in Student.students
                where s.Age >= 12 && s.Age <= 20
                select s;

            foreach (Student s in iter)
            {
                Console.WriteLine($"{s.Name}, {s.Age}");
            }

            //Q2


        }
    }
}
