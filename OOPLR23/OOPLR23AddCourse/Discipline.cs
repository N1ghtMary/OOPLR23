using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLR23AddCourse
{
    public class Discipline
    {
        public string DisciplineName { get; set; }
        public Teacher Teacher { get; set; }
        //public List<Student> StudentsList { get; set; } = new List<Student>();
        public int StudentCount { get; set; }
        public Course DiciplineCourse { get; set; }
        public Discipline(string name, Course course) { DisciplineName = name; DiciplineCourse = course; }
        public void GetInfo()
        {
            if (Teacher != null)
            {
                Console.WriteLine($"Дисциплина: {DisciplineName}, Преподаватель: {Teacher.Name}, " +
                  $"Курс: {DiciplineCourse.CourseNumber}, Количество студентов: {StudentCount}");
            }
            else Console.WriteLine($"Дисциплина: {DisciplineName}, Преподаватель не нанят, " +
                  $"Курс: {DiciplineCourse.CourseNumber}, Количество студентов: {StudentCount}");
        }
    }
}
