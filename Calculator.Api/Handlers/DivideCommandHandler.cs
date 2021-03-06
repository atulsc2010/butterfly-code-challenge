﻿using Calculator.Api.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Api.Handlers
{
    public class DivideCommandHandler
    {
        private readonly string _input;
        private readonly ILogger _logger;

        public DivideCommandHandler(string input, ILogger logger)
        {
            _input = input;
            _logger = logger;
        }

        public CalculatorResponse Handle()
        {
            var values = _input.Split(',');
            var numbers = new List<double>();
            var result = double.NaN;
            CalculatorResponse response;

            try
            {
                if (values.Length <= 1)
                {
                    return response = new CalculatorResponse
                    {
                        Status = "Error",
                        Message = "Input 2 or more numbers for division",
                    };
                }

                foreach (var value in values)
                {
                    numbers.Add(double.Parse(value.Trim()));
                }

                if (numbers != null)
                {
                    var calc = new CalculatorCore();

                    if ( numbers.Any( n => n == 0))
                        return response = new CalculatorResponse
                        {
                            Status = "Error",
                            Message = "Division by Zero not allowed.",
                        };

                    result = calc.Divide(numbers.ToArray());
                }

                return response = new CalculatorResponse
                {
                    _Result = result,
                    Status = "Success"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid input : {ex.StackTrace}");
                return new CalculatorResponse
                {
                    Status = "Error",
                    Message = ($"Invalid input : {ex.Message}")
                };
            }
        }
    }
}
