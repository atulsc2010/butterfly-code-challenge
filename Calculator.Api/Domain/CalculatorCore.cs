using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Api.Domain
{
    public class CalculatorCore
    {
        public double Add(double a, double b)
        {
            if (Overflow(a+b))
                return double.NaN; 
                        
            return a + b;            
        }

        public double Add(params double[] values)
        {
            double result = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                result = Add(result, values[i]);                
                if (result == double.NaN)
                    break;
            }

            return result;
        }

        public double Subtract(double a, double b)
        {
            if (Overflow(a-b))
                return double.NaN;

            return a - b;
        }

        public double Subtract(params double[] values)
        {
            double result = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                result = Subtract(result, values[i]);
                if (result == double.NaN)
                    break;
            }

            return result;
        }

        public double Multiply(double a, double b)
        {
            if (Overflow(a*b))
                return double.NaN;

            return a * b;
        }
        
        public double Multiply(params double[] values)
        {
            double result = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                result = Multiply(result, values[i]);
                if (result == double.NaN)
                    break;
            }

            return result;
        }

        public double Divide(double a, double b)
        {
            if (Overflow(a / b) || b == 0)
                return double.NaN;

            return a / b;
        }

        public double Divide(params double[] values)
        {
            double result = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                result = Divide(result, values[i]);
                if (result == double.NaN)
                    break;
            }

            return result;
        }

        private bool Overflow(double a)
        {
            return double.IsInfinity(a) || a >= double.MaxValue || a <= double.MinValue ;
        }
    }
}
