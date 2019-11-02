using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculate
    {
        public static void Main(string[] args)
        {
            string input = "";
            while (true)
            {
                Console.WriteLine("Enter string: ");
                input = Console.ReadLine();

                if (input.ToLower().CompareTo("exit") == 0)
                {
                    break;
                }
                try
                {
                    Console.WriteLine(CalculateString(input));
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


        public static int CalculateString(string input)
        {
            List<string> delimiters = new List<string> { ",", "\\n", "\n" }; 

            if (input.StartsWith("//"))
            {
                try
                {
                    List<string> sections = input.Split(new string[] { "\n", "\\n" }, 2, StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (sections[0].Length > 3 && (!sections[0].Contains('[') || !sections[0].Contains(']'))) 

                    {
                        throw new FormatException("No delimiter found");
                    }
                    List<string> customDelim = sections[0].Remove(0, 2).Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    customDelim.ForEach(f => delimiters.Add(f));
                    input = sections[1];
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
            List<string> parts = input.Split(delimiters.ToArray<string>(), StringSplitOptions.RemoveEmptyEntries).ToList();
            int result = 0;
            List<int> rejectedNumbers = new List<int>();
            foreach (string part in parts)
            {
                try
                {
                    int value = Int32.Parse(part);
                    if (value < 0)
                    {
                        rejectedNumbers.Add(value);
                    }
                    else if (value > 1000) 
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
            if (rejectedNumbers.Count != 0)
            {
                string rejectedStringMsg = "Negative Number(s) are not accepted. You entered: ";
                rejectedNumbers.ForEach(f => rejectedStringMsg += f.ToString() + " ");
                throw new CalculatorException(rejectedStringMsg); 
            }
            return result;
        }
    }
}
