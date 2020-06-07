using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class EmployeesWithFixPayment : Employees
    {
        public EmployeesWithFixPayment(int personnelNumber) : base(personnelNumber)
        {
        }

        public override void CalculateSalary(decimal rate)
        {
            Salary = rate;
        }
    }
}
