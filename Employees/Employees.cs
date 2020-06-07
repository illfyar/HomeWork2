using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
     abstract class Employees : IComparable
    {
        public int PersonnelNumber { get; set; }
        public decimal Salary { get; set; }

        protected Employees(int personnelNumber)
        {
            PersonnelNumber = personnelNumber;                        
        }
        public abstract void CalculateSalary(decimal rate);

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Employees Employe = (Employees)obj;
            if (this.Salary > Employe.Salary)
            {
                return 1;
            }
            if (this.Salary == Employe.Salary)
            {
                return 0;
            }
            return -1;
        }
    }
}
