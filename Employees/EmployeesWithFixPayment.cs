using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class EmployeesWithFixPayment : Employees
    {
        public EmployeesWithFixPayment(int personnelNumber, int salary) : base(personnelNumber, salary)
        {
        }
        public override void CalculateSalary(decimal rate)
        {
            Salary = rate;
        }
    }
}
