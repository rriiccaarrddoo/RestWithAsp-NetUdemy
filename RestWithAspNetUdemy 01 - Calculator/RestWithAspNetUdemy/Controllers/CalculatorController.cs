using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNetUdemy.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {

        // GET api/values/5
        [HttpGet("{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertNumber(firstNumber) + ConvertNumber(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Input Invalid.");
        }

        private decimal ConvertNumber(string number)
        {
            decimal convertNumber;

            if (decimal.TryParse(number, out convertNumber))
            {
                return convertNumber;
            }

            return 0;
        }

        private bool IsNumeric(string number)
        {
            decimal convertNumber;

            bool isNumber = decimal.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out convertNumber);

            return isNumber;
        }
    }
}
