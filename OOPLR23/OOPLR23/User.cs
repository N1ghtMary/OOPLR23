using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLR23
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Discipline> Disciplines { get; set; } = new List<Discipline>();

        

        public void AddDiscipline(Discipline discipline)
        {
            Disciplines.Add(discipline);
        }
    }
}
