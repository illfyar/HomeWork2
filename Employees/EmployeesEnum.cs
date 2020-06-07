using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class EmployeesEnum : IEnumerator,IEnumerable
    {
        public Employees[] employees;
        private int _i = -1;

        public object Current => employees[_i];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_i == employees.Length - 1)
            {
                Reset();
                return false;
            }
            _i++;
            return true;
        }

        public void Reset()
        {
            _i = -1;
        }
    }
}
