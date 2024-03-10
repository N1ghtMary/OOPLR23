using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OOPLR23
{
    class Program
    {
        static List<Student> studentsList = new List<Student>();
        static List<Teacher> teachersList = new List<Teacher>();
        static List<Discipline> disciplinesList = new List<Discipline>();
        static List<Course> coursesList = new List<Course>()
        {
            new Course{CourseNumber = 1},
            new Course{CourseNumber = 2},
            new Course{CourseNumber = 3},
            new Course{CourseNumber = 4}
        };
        static void Main(string[] args)
        {
            FillTestData();

            while (true)
            {
                ChooseActs();
            }
        }

        static void FillTestData()
        {
            List<string> disciplineList = new List<string>() { "БД", "РПМ", "ПОПД", "ММ", "ООП", "ОСИС" };
            List<string> disciplineListConst = new List<string>(disciplineList);
            List<Teacher> teacherData = new List<Teacher>(){
        new Teacher(/*$"{Faker.Name.First()} {Faker.Name.Last}"*/"Fuck")
        {
            Age = 5,//rand.Next(20,120);
        },
        new Teacher("Марков Климент Валерьянович")
        {
            Age = 82,
        },
        new Teacher("Иванова Дарина Александровна")
        {
            Age = 56,
        },
        new Teacher("Павловский Ярослав Артёмович")
        {
            Age = 82,
        },
        new Teacher("Макарова Василиса Ивановна")
        {
            Age = 56,
        },
        new Teacher("Щеглов Семён Алексеевич")
        {
            Age = 82,
        }
        };
            Random rand = new Random();
            /*foreach (var user in teacherData)
            {
                int numDisciplines = rand.Next(1, disciplineList.Count + 1); // Случайное количество дисциплин

                for (int i = 0; i < numDisciplines; i++)
                {
                    int index = rand.Next(disciplineList.Count); // Случайный индекс дисциплины
                    user.AddDiscipline(disciplineList[index]);
                    disciplineList.RemoveAt(index); // Удаление выбранной дисциплины, чтобы избежать повторений
                }
            }*/
        }

        static void ChooseActs()
        {
            Console.WriteLine("Выберите действие:\n 1 - Ввести новые данные\n 2 - Вывести данные");
            int choiceAct = int.Parse(Console.ReadLine());
            switch (choiceAct)
            {
                case 1:
                    AddData();
                    break;
                case 2:
                    ShowData();
                    break;
                default:
                    Console.WriteLine("Хорошего дня");
                    break;
            }
        }

        static void AddData()
        {
            Console.WriteLine("1 - Добавить студента \n2 - Добавить преподавателя ");
            int.TryParse(Console.ReadLine(), out int choiceActAdd);
            //int choiceActAdd = int.Parse(Console.ReadLine());
            switch (choiceActAdd)
            {
                case 1:
                    Console.WriteLine("Введите ФИО студента");
                    string studentName = Console.ReadLine();
                    Console.WriteLine("Введите возраст студента");
                    int.TryParse(Console.ReadLine(), out int studentAge);
                    Console.WriteLine("Введите курс студента (1-4)");
                    int.TryParse(Console.ReadLine(), out int courseNumber);
                    //int courseNumber = int.Parse(Console.ReadLine());
                    Course studentCourse = coursesList.FirstOrDefault(c => c.CourseNumber == courseNumber);

                    if (studentCourse == null)
                    {
                        Console.WriteLine("Неверный номер курса.");
                        return;
                    }
                    Console.WriteLine("Введите названия дисциплин студента через запятую из списка");
                    string[] studentDisciplines = Console.ReadLine().Split(',');
                    Student student = new Student { Name = studentName, Age = studentAge, CourseNumber = studentCourse };
                    foreach (var name in studentDisciplines)
                    {
                        Discipline disciplineTmpStudent = disciplinesList.FirstOrDefault(d => d.DisciplineName == name.Trim());
                        if (disciplineTmpStudent != null)
                        {
                            student.Disciplines.Add(disciplineTmpStudent);
                            disciplineTmpStudent.StudentCount += 1;
                            //disciplineTmpStudent.StudentsList.Add(student);
                        }
                    }

                    studentsList.Add(student);
                    break;
                case 2:
                    Console.WriteLine("Введите ФИО преподавателя");
                    string teacherName = Console.ReadLine();
                    Console.WriteLine("Введите возраст преподавателя");
                    int.TryParse(Console.ReadLine(), out int teacherAge);
                    //int teacherAge = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите названия дисциплин преподавателя через запятую из списка");
                    //disciplinesList
                    string[] teacherDisciplines = Console.ReadLine().Split(',');
                    Teacher teacher = new Teacher ( teacherName, teacherAge );
                    foreach (var name in teacherDisciplines)
                    {
                        Discipline disciplineTmpTeacher = disciplinesList.FirstOrDefault(d => d.DisciplineName == name.Trim());
                        if (disciplineTmpTeacher == null)
                        {
                            disciplineTmpTeacher = new Discipline { DisciplineName = name.Trim() };
                            disciplinesList.Add(disciplineTmpTeacher);

                        }
                        if (disciplineTmpTeacher != null)
                        {
                            teacher.Disciplines.Add(disciplineTmpTeacher);
                            disciplineTmpTeacher.Teacher = teacher;
                        }
                    }

                    teachersList.Add(teacher);
                    break;
                /*case 3:
                    Console.WriteLine("Введите название дисциплины");
                    string disciplineName = Console.ReadLine();
                    Console.WriteLine("Введите имя преподавателя");
                    Discipline discipline = new Discipline { DisciplineName = disciplineName };
                    string disciplineTeacher = Console.ReadLine();
                    var teacherDisc = teachersList.FirstOrDefault(t => t.Name == disciplineTeacher);

                    if (teacherDisc != null)
                    {
                        discipline.Teacher = teacherDisc;
                        teacherDisc.Disciplines.Add(discipline);
                    }

                    disciplinesList.Add(discipline);
                    break;*/
                default:
                    Console.WriteLine("Пока-пока.");
                    break;
            }
        }

        static void ShowData()
        {
            Console.WriteLine("1 - Вывести информацию о  студентах \n2 - Вывести информацию о преподавателях \n3 - Вывести информацию о дисциплинах");
            int choiceShow = int.Parse(Console.ReadLine());
            switch (choiceShow)
            {
                case 1:
                    foreach (var student in studentsList)
                    {
                        student.GetInfo();
                    }
                    break;
                case 2:
                    foreach (var teacher in teachersList)
                    {
                        teacher.GetInfo();
                    }
                    break;
                case 3:
                    foreach (var discipline in disciplinesList)
                    {
                        discipline.GetInfo();
                    }
                    break;
                default:
                    Console.WriteLine("Хорошего дня");
                    break;
            }
        }
    }
}
