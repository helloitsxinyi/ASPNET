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

            Console.WriteLine("Q1");
            foreach (Student s in iter)
            {
                Console.WriteLine($"{s.Name}, {s.Age}");                
            }

            //Q2
            IEnumerable<int> iter2 =
                from num in Numbers.numbers
                orderby num ascending
                select num;

            Console.WriteLine("Q2");
            foreach (int i in iter2)
            {
                Console.Write($"{i} ");
            }

            //Q3


        }
    }
}
