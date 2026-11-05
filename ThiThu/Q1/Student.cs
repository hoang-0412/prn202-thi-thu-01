using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    internal class Student : IItem
    {
        public int Id {  get; set; }
        public string? Name { get; set; }
        public DateOnly Dob { get; set; }
        public Student() { }
        public Student(int id, string name, DateOnly dob)
        {
            this.Id = id;
            this.Name = name;
            this.Dob = dob;
        }
        public void DisplayList()
        {
            Console.WriteLine($"Student {Id} - {Name} - {Dob}");
        }
    }
}
