using Calculator.Api.Commands;
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
        public ActionResult<CalculatorResponse> Add([FromRoute] string input)
        {
            var command = new CalculatorCommands(_logger);
            var response = command.ExecuteAdd(input);

            if (response.Status == "Success")
            {
                return Ok(response);
            }
            else 
            {
                return BadRequest(response);
            }
        }

        [HttpGet("subtract/{input}")]
        public ActionResult<CalculatorResponse> Subtract([FromRoute] string input)
        {
            var command = new CalculatorCommands(_logger);
            var response = command.ExecuteSubtract(input);

            if (response.Status == "Success")
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet("multiply/{input}")]
        public ActionResult<CalculatorResponse> Multiply([FromRoute] string input)
        {
            var command = new CalculatorCommands(_logger);
            var response = command.ExecuteMultiply(input);

            if (response.Status == "Success")
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet("divide/{input}")]
        public ActionResult<CalculatorResponse> Divide([FromRoute] string input)
        {
            var command = new CalculatorCommands(_logger);
            var response = command.ExecuteDivide(input);

            if (response.Status == "Success")
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

    }
}
