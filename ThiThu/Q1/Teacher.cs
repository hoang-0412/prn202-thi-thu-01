using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    internal class Teacher : IItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Skill { get; set; }
        public Teacher() { }
        public Teacher(int id, string name, string? skill)
        {
            this.Id = id;
            this.Name = name;
            this.Skill = skill;
        }
        public void DisplayList()
        {
            Console.WriteLine($"Teacher {Id} - {Name} - {Skill}");
        }
    }
}
