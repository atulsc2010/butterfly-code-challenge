using Calculator.Api.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Calculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> Get() 
        {
            return Ok("Use Add/Subtract/Multiply/Divide Apis.");
        }

        [HttpGet("add/{input}")]
        public ActionResult<double> Add([FromRoute] string input)
        {
            var values = input.Split(',', '+');
            var numbers = new List<double>();
            double sum = double.NaN;

            if (values.Length <= 1)
                return BadRequest("2 or more numbers must be sent for addition");
            try
            {
                foreach (var value in values)
                {
                    numbers.Add(double.Parse(value.Trim()));
                }

                if (numbers != null)
                {
                    var calc = new CalculatorCore();
                    sum = calc.Add(numbers.ToArray());
                }

                return Ok(sum);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid input received : {ex.StackTrace}");
                return BadRequest($"Invalid input : {ex.Message}");
            }

        }

    }
}
