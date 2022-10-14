using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Lab15
{
    public class Company : IComparable<Company>
    {
        public string Name { get; set; }
        public int Budget { get; set; }
        public int Employees { get; set; }

        public Company(string name, int budget, int employees)
        {
            Name = name;
            Budget = budget;
            Employees = employees;
        }

        public int CompareTo(Company other)
        {
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return $"{Name}, {Budget}, {Employees}";
        }

        public override bool Equals(object obj)
        {
            var cmp = (Company)obj;
            if (this.Name == cmp.Name && this.Budget == cmp.Budget && this.Employees == cmp.Employees)
                return true;
            return false;
        }
    }
}