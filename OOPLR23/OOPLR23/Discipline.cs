using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLR23
{
    public class Discipline
    {
        public string DisciplineName { get; set; }
        public Teacher Teacher { get; set; }
        //public List<Student> StudentsList { get; set; } = new List<Student>();
        public int StudentCount { get; set; }

        public void GetInfo()
        {
            Console.WriteLine($"Дисциплина: {DisciplineName}, Преподаватель: {Teacher.Name}, Количество студентов: {StudentCount}");
        }
    }
}
