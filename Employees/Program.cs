using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeesEnum employeesEnum = new EmployeesEnum();
            employeesEnum.employees = new Employees[10];
            Random random = new Random();
            for (int i = 0; i < employeesEnum.employees.Length/2; i++)
            {
                employeesEnum.employees[i] = new EmployeesWithHourlyPayment(i, random.Next(15, 70));
            }
            for (int i = employeesEnum.employees.Length / 2; i < employeesEnum.employees.Length; i++)
            {
                employeesEnum.employees[i] = new EmployeesWithFixPayment(i, random.Next(3000, 12000));
            }
            Array.Sort(employeesEnum.employees);
            foreach (Employees item in employeesEnum)
            {
                Console.WriteLine(item.Salary);                
            }
            Console.ReadKey();
        }
    }
}
