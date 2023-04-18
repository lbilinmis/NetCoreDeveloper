using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.OpenClosed.Good
{
    public interface ISalaryCalculate
    {
        decimal Calculate(decimal amount);
    }

    public class LowSalaryCalculate : ISalaryCalculate
    {
        public decimal Calculate(decimal amount)
        {
            return amount * 2;
        }
    }

    public class MiddleSalaryCalculate : ISalaryCalculate
    {
        public decimal Calculate(decimal amount)
        {
            return amount * 4;

        }
    }


    public class HighSalaryCalculate : ISalaryCalculate
    {
        public decimal Calculate(decimal amount)
        {
            return amount * 6;

        }
    }

    public class HighOnSalaryCalculate : ISalaryCalculate
    {
        public decimal Calculate(decimal amount)
        {
            return amount * 10;

        }
    }

    public class SalaryCalculate
    {
        public decimal Calculate(decimal salary, ISalaryCalculate salaryCalculate)
        {
            return salaryCalculate.Calculate(salary);
        }
    }

}
