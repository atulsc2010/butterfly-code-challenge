using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Api.Domain
{
    public class CalculatorCore
    {
        public double Add(double a, double b) 
        {
            if (Overflow(a,b))
                return double.NaN;
            
            return a + b;            
        }

        public double Subtract(double a, double b)
        {
            if (Overflow(a, b))
                return double.NaN;

            return a - b;
        }

        public double Multiply(double a, double b)
        {
            if (Overflow(a, b))
                return double.NaN;

            return a * b;
        }

        public double Divide(double a, double b)
        {
            if (Overflow(a, b) || b == 0)
                return double.NaN;

            return a / b;
        }

        private bool Overflow(double a, double b) 
        {
            return (a >= double.MaxValue || b >= double.MaxValue) || (a <= double.MinValue || b <= double.MinValue);
        }
    }
}
