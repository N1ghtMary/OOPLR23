using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPLR23AddCourse
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
        static bool iwannarun = true;
        static void Main(string[] args)
        {
            FillTestData();
            
            while (iwannarun)
            {
                ChooseActs();
            }
        }

        static void FillTestData()
        {
            Random randAge = new Random();
            Random randDisc = new Random();
            int studentAmount = 7;
            List<string> disciplineList = new List<string>() { "БД", "РПМ", "ПОПД", "ММ", "ООП", "ОСИС", "ТРЗБД", "ТРПО" };
            List<string> disciplineListConst = new List<string>(disciplineList);
            Random randDisciplineCourse = new Random();
            for (int i = 0; i < disciplineListConst.Count; i++)
            {
                int course = randDisciplineCourse.Next(1, coursesList.Count + 1);
                string disciplineName = disciplineListConst[i];
                Course disciplineCourse = coursesList.FirstOrDefault(c => c.CourseNumber == course);
                Discipline disciplineNameDisc = new Discipline(disciplineName, disciplineCourse);
                disciplinesList.Add(disciplineNameDisc);
            }

            for (int i = 0; i < disciplineListConst.Count; i++)
            {
                string teacherName = Faker.Name.FullName();
                int teacherAge = randAge.Next(25, 120);
                //string[] teacherDisciplines = Console.ReadLine().Split(',');
                Teacher teacher = new Teacher(teacherName, teacherAge);
                /*int amountOfTeacherDisciplines = randDisc.Next(1, 4);
                List<string> chosenDisciplines = new List<string>();
                for (int j = 0; j<amountOfTeacherDisciplines;j++)
                {
                    string randDisciplineName;
                    do
                    {
                        Random randTmp = new Random();
                        randDisciplineName = disciplineListConst[randTmp.Next(0, disciplineListConst.Count - 1)];
                    }
                    while (chosenDisciplines.Contains(randDisciplineName) || 
                    disciplinesList.Any(disc=>disc.DisciplineName==randDisciplineName&&disc.Teacher != teacher));
                    Discipline disciplineTmpTeacher = disciplinesList.FirstOrDefault(d => d.DisciplineName == randDisciplineName.Trim());
                    teacher.Disciplines.Add(disciplineTmpTeacher);
                    disciplineTmpTeacher.Teacher = teacher;
                    //disciplineList.Add(disciplineTmpTeacher);
                    chosenDisciplines.Add(randDisciplineName);
                }*/
                string randDisciplineName = disciplineListConst[i];
                Discipline disciplineTmpTeacher = disciplinesList.FirstOrDefault(d => d.DisciplineName == randDisciplineName.Trim());
                teacher.Disciplines.Add(disciplineTmpTeacher);
                disciplineTmpTeacher.Teacher = teacher;
                teachersList.Add(teacher);

            }
            //randDisc.Next(0, disciplineListConst.Count - 1)

            Random rand = new Random();
            for (int i = 0; i < studentAmount; i++)
            {
                string studentName = Faker.Name.FullName();
                int studentAge = randAge.Next(17, 28);
                int randCourse = rand.Next(1, 5);
                Course studentCourse = coursesList.FirstOrDefault(c => c.CourseNumber == randCourse);
                Student student = new Student(studentName, studentAge, studentCourse);
                foreach (var nameDisc in disciplineListConst)
                {

                    Discipline disciplineTmpStudent = disciplinesList.FirstOrDefault(d => d.DisciplineName == nameDisc.Trim());
                    if (disciplineTmpStudent.DiciplineCourse == studentCourse)
                    {
                        student.Disciplines.Add(disciplineTmpStudent);
                        disciplineTmpStudent.StudentCount += 1;
                    }
                }

                studentsList.Add(student);
            }
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
                    iwannarun = false;
                    break;
            }
        }

        static void AddData()
        {
            Console.WriteLine("1 - Добавить студента \n2 - Добавить преподавателя \n3 - Добавить дисциплину");
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
                    while (courseNumber < 1 || courseNumber > 4)
                    {
                        Console.WriteLine("Неверный номер курса. Введите курс, на котором учится студент (1-4)");
                        int.TryParse(Console.ReadLine(), out courseNumber);
                    }
                    //int courseNumber = int.Parse(Console.ReadLine());
                    Course studentCourse = coursesList.FirstOrDefault(c => c.CourseNumber == courseNumber);
                    Student student = new Student(studentName, studentAge, studentCourse);
                    foreach (var nameDisc in disciplinesList)
                    {
                        // Discipline disciplineTmpStudent = disciplinesList.FirstOrDefault(d => d.DisciplineName == nameDisc.Trim());
                        if (nameDisc.DiciplineCourse == studentCourse)
                        {
                            student.Disciplines.Add(nameDisc);
                            nameDisc.StudentCount += 1;
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
                    int countAvailable = 0;
                    foreach (var discipline in disciplinesList)
                    {
                        if (discipline.Teacher == null)
                        {
                            Console.WriteLine(discipline.DisciplineName);
                            countAvailable++;
                        }
                    }
                    if (countAvailable == 0) { Console.WriteLine("Все дисциплины заняты, добавьте новую дисциплину сначала.");
                        break;
                    }
                    string[] teacherDisciplines = Console.ReadLine().Split(',');
                    Teacher teacher = new Teacher(teacherName, teacherAge);
                    foreach (var name in teacherDisciplines)
                    {
                        Discipline disciplineTmpTeacher = disciplinesList.FirstOrDefault(d => d.DisciplineName == name.Trim());
                        if (disciplineTmpTeacher == null)
                        {
                            // disciplineTmpTeacher = new Discipline { DisciplineName = name.Trim() };
                            //disciplinesList.Add(disciplineTmpTeacher);
                            Console.WriteLine("Нет такой дисциплины. Пожалуйста, добавьте ее сначала");
                            break;
                        }
                        if (disciplineTmpTeacher != null)
                        {
                            teacher.Disciplines.Add(disciplineTmpTeacher);
                            disciplineTmpTeacher.Teacher = teacher;
                        }
                    }

                    teachersList.Add(teacher);
                    break;
                case 3:
                    Console.WriteLine("Введите название дисциплины");
                    string disciplineName = Console.ReadLine();
                    Console.WriteLine("Введите курс, на котором преподается дисциплина (1-4)");
                    int.TryParse(Console.ReadLine(), out int disciplineCourseAdd);
                    while (disciplineCourseAdd < 1 || disciplineCourseAdd > 4)
                    {
                        Console.WriteLine("Неверный номер курса. Введите курс, на котором преподается дисциплина (1-4)");
                        int.TryParse(Console.ReadLine(), out disciplineCourseAdd);
                    }
                    Course disciplineCourse = coursesList.FirstOrDefault(c => c.CourseNumber == disciplineCourseAdd);
                    Discipline disciplineNameDisc = new Discipline(disciplineName, disciplineCourse);
                    foreach (var studentDiscCourse in studentsList)
                    {
                        // Discipline disciplineTmpStudent = disciplinesList.FirstOrDefault(d => d.DisciplineName == nameDisc.Trim());
                        if (studentDiscCourse.CourseNumber == disciplineNameDisc.DiciplineCourse)
                        {
                            studentDiscCourse.Disciplines.Add(disciplineNameDisc);
                            disciplineNameDisc.StudentCount += 1;
                            //studentDiscCourse.Disciplines
                        }
                    }
                    //string disciplineTeacher = Console.ReadLine();
                    /*var teacherDisc = teachersList.FirstOrDefault(t => t.Name == disciplineTeacher);

                    if (teacherDisc != null)
                    {
                        disciplineNameDisc.Teacher = teacherDisc;
                        teacherDisc.Disciplines.Add(disciplineNameDisc);
                    }*/

                    disciplinesList.Add(disciplineNameDisc);
                    break;
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
