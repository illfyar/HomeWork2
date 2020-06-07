using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class EmployeesWithHourlyPayment : Employees
    {
        public EmployeesWithHourlyPayment(int personnelNumber) : base(personnelNumber)
        {
        }
        public override void CalculateSalary(decimal rate)
        {
            Salary = (decimal) 20.8 * 8 * rate;
        }
    }
}
