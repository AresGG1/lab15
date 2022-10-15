using System;

namespace Lab15_1
{
    public class UniversityUnit:IComparable<UniversityUnit>
    {
        public string UnitName { get; set; }
        public string UniversityName { get; set; }
        public int Employees { get; set; }

        public UniversityUnit(string data)
        {
            string[] dataArray = data.Split(',');
            this.UnitName = dataArray[0];
            this.UniversityName = dataArray[1];
            this.Employees = Convert.ToInt32(dataArray[2]);
        }
        
        
        public UniversityUnit(string unitName, string universityName, int employees)
        {
            UnitName = unitName;
            UniversityName = universityName;
            Employees = employees;
        }
        
        public int CompareTo(UniversityUnit other)
        {
            if (other == null)
                return 1;
            return UnitName.CompareTo(other.UnitName);
        }
        
        
        
        public override string ToString()
        {
            return $"{UnitName}, {UniversityName}, {Employees}";
        }

        public override bool Equals(object obj)
        {
            var cmp = (UniversityUnit)obj;
            if (this.UnitName == cmp.UnitName && this.UniversityName == cmp.UniversityName && this.Employees == cmp.Employees)
                return true;
            return false;
        }
        
        
    }
}