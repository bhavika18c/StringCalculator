using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StringCalculator
{
    public class CalculatorException : Exception
    {
        public string ClientMessage { get; set; }

        public CalculatorException(string message, string ClientMessage, Exception innerException)
          : base(message, innerException)
        {

        }

        public CalculatorException(string message) : base(message)
        {
        }
    }
}
