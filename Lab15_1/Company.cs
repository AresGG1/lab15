using System;
using System.Management.Instrumentation;

namespace Lab15_1
{
    public class Company : IComparable<Company>
    {
        public string Name { get; set; }
        public int Budget { get; set; }
        public int Employees { get; set; }

        public Company(string data)
        {
            string[] dataArray = data.Split(',');
            this.Name = dataArray[0];
            this.Budget = Convert.ToInt32(dataArray[1]);
            this.Employees = Convert.ToInt32(dataArray[2]);
        }

        public Company(string name, int budget, int employees)
        {
            Name = name;
            Budget = budget;
            Employees = employees;
        }

        public int CompareTo(Company other)
        {
            if (other == null)
                return 1;
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