using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLR23AddCourse
{
    public class Teacher:User
    {
        public Teacher(string name) { Name = name; }
        public Teacher(string name, int age) { Name = name; Age = age; }
        public void GetInfo()
        {
            Console.WriteLine($"Преподаватель: {Name}, Возраст: {Age}");
            Console.WriteLine("Дисциплины: ");
            foreach (var discipline in Disciplines)
            {
                Console.WriteLine(discipline.DisciplineName);
            }
            Console.WriteLine();
        }
    }
}
