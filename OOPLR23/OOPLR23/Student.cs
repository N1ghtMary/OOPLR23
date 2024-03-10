using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLR23
{
    public class Student:User
    {
        public Course CourseNumber { get; set; }

        public void GetInfo()
        {
            Console.WriteLine($"Студент: {Name}, Возраст: {Age}, Курс: {CourseNumber.CourseNumber}");
            Console.WriteLine("Дисциплины: ");
            foreach (var discipline in Disciplines)
            {
                Console.WriteLine(discipline.DisciplineName);
            }
            Console.WriteLine();
        }
    }
}
