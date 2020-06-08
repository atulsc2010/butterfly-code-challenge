using Calculator.Api.Domain;
using Calculator.Api.Handlers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Calculator.Api.Commands
{
    public class CalculatorCommands
    {
        private readonly ILogger _logger;

        public CalculatorCommands(ILogger logger)
        {
            _logger = logger;
        }
        public CalculatorResponse ExecuteAdd(string input)
        {
            var add = new AddCommandHandler(input, _logger);
            return add.Handle();
        }

        public CalculatorResponse ExecuteSubtract(string input)
        {
            var subtract = new SubtractCommandHandler(input, _logger);
            return subtract.Handle();
        }

        public CalculatorResponse ExecuteMultiply(string input)
        {
            var multiply = new MultiplyCommandHandler(input, _logger);
            return multiply.Handle();
        }

        public CalculatorResponse ExecuteDivide(string input)
        {
            var subtract = new DivideCommandHandler(input, _logger);
            return subtract.Handle();
        }
    }
}