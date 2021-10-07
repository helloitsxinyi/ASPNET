using System;
using System.Collections.Generic;

namespace LINQWorkshop
{
    public class Student
    {      
        public Student()
        {
        }

        public static List<Student> students = new List<Student>()
            {
                new Student() { Name = "John", Age = 13 } ,
                new Student() { Name = "Joey",  Age = 21 } ,
                new Student() { Name = "Bill",  Age = 18 } ,
                new Student() { Name = "Alex" , Age = 20} ,
                new Student() { Name = "Ron" , Age = 15 }
            };

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
