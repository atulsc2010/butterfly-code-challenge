﻿using Calculator.Api.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Api.Handlers
{
    public class SubtractCommandHandler
    {
        private readonly string _input;
        private readonly ILogger _logger;
        public SubtractCommandHandler(string input, ILogger logger)
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
                        Message = "Input 2 or more numbers for subtraction",
                    };
                }

                foreach (var value in values)
                {
                    numbers.Add(double.Parse(value.Trim()));
                }

                if (numbers != null)
                {
                    var calc = new CalculatorCore();
                    result = calc.Subtract(numbers.ToArray());
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
