using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Api.Domain
{
    public class CalculatorResponse
    {
        public double Result { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
