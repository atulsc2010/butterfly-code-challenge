using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Calculator.Api.Domain
{
    public class CalculatorResponse
    {
        [JsonIgnore]
        public double _Result { get; set; }
        public string Result => _Result.ToString();
        public string Status { get; set; } = null;
        public string Message { get; set; } = null;
    }
}
