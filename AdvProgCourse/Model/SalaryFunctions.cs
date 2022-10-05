using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class SalaryFunctions
    {
        public static double WorkerSalary(Person person)
        {
            if (person is Worker worker)
            {
                throw new NotImplementedException();
            }
            else
                throw new ArgumentException("Invalid person type");
        }
    }
}
