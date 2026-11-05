using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    internal class MemberList : ICustomList
    {
        public int MaximumNumberOfMember { get; set; }
        private readonly List<IItem> members = new List<IItem>();
        public event Notify? OnFullOfMember;
        public MemberList() { }
        public MemberList(int MaximumNumberOfMember)
        {
            this.MaximumNumberOfMember = MaximumNumberOfMember;
        }
        public void Add(IItem item)
        {
            members.Add(item);
            Console.WriteLine("Added successfully.");

            if(MaximumNumberOfMember > 0 && members.Count >= MaximumNumberOfMember)
            {
                OnFullOfMember?.Invoke();
            }
        }
        public void DisplayList()
        {
            Console.WriteLine("List of member:");
            foreach (var member in members)
            {
                member.DisplayList();
            }
        }
    }
}
