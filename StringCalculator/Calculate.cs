using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculate
    {
        const int defaultNumber = 0;
        const int maxNo = 1000;
        private List<string> delimiters = new List<string> { ",", "\\n", "\n" };
        
        public static void Main(string[] args)
        {
            string inputValue = "";
            while (true)
            {
                Console.WriteLine("Enter string: ");
                inputValue = Console.ReadLine();

                if (inputValue.ToLower().CompareTo("exit") == 0)
                {
                    break;
                }
                try
                {
                    Calculate c = new Calculate();
                    Console.WriteLine(c.CalculateString(inputValue));
                }
                catch (CalculatorException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public int CalculateString(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return defaultNumber;



            if (input.StartsWith("//"))
            {
                input = AddSeperators(input);
            }

            return FinalResult(input);

        }

        private string AddSeperators(string number)
        {
            try
            {
                List<string> seperators = number.Split(new string[] { "\n", "\\n" }, 2, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (seperators[0].Length > 3 && (!seperators[0].Contains('[') || !seperators[0].Contains(']')))

                {
                    throw new FormatException("No delimiters/seperators found");
                }

                List<string> del = seperators[0].Remove(0, 2).Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                              

                foreach (var d in del) {
                    delimiters.Add(d);
                }
                
                number = seperators[1];

                return number;
            }
            catch (FormatException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new FormatException("Custom delimiter format is not correct.");
            }
        }


        public int FinalResult(string number)
        {
            List<string> newNum = number.Split(delimiters.ToArray<string>(), StringSplitOptions.RemoveEmptyEntries).ToList();
            int result = 0;
            List<int> rejectedNegtaviveNum = new List<int>();
            foreach (string n in newNum)
            {
                try
                {
                    int value = Int32.Parse(n);
                    if (value < defaultNumber)
                    {
                        rejectedNegtaviveNum.Add(value);
                    }
                    else if (value > maxNo)
                    {
                        result += 0;
                    }
                    else
                    {
                        result += value;
                    }
                }
                catch
                {
                    result += 0;
                }
            }
            if (rejectedNegtaviveNum.Count != 0)
            {
                string rejectedStringMsg = "Negative Number(s) are not allowed. You entered: ";

                foreach (var rejNum in rejectedNegtaviveNum) {
                    rejectedStringMsg += rejNum.ToString() + " ";
                }
                
                throw new CalculatorException(rejectedStringMsg);
            }

            return result;
        }
    }
}
