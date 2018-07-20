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

        // GET api/calculator/sum/5/5
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertNumber(firstNumber) + ConvertNumber(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Input Invalid.");
        }

        // GET api/calculator/subtraction/5/5
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertNumber(firstNumber) - ConvertNumber(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Input Invalid.");
        }

        // GET api/calculator/average/5/5
        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult Average(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ( ConvertNumber(firstNumber) + ConvertNumber(secondNumber) ) /2;

                return Ok(sum.ToString());
            }

            return BadRequest("Input Invalid.");
        }

        // GET api/calculator/multiplication/5/5
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = (ConvertNumber(firstNumber) * ConvertNumber(secondNumber)) ;

                return Ok(sum.ToString());
            }

            return BadRequest("Input Invalid.");
        }

        // GET api/calculator/division/5/5
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {

            try
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var sum = (ConvertNumber(firstNumber) / ConvertNumber(secondNumber));

                    return Ok(sum.ToString());
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest("Input Invalid.");
        }

        // GET api/calculator/squareroot/5
        [HttpGet("squareroot/{number}")]
        public IActionResult SquareRoot(string number)
        {

            if (IsNumeric(number) )
            {
                var sum = Math.Sqrt((double)ConvertNumber(number));

                return Ok(sum.ToString());
            }

            return BadRequest("Input Invalid.");
        }

        // Converte uma string recebida no metodo GET em Decimal
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
