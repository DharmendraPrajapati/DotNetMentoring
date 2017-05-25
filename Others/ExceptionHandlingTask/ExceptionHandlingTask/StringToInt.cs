using System;

namespace ExceptionHandlingTask
{
    public class StringToInt
    {
        public int StringToIntConverter(string inputString)
        {
            var sum = 0;
            if (string.IsNullOrEmpty(inputString))
            {
                return sum;
            }
            var digits = inputString.ToCharArray();
            var zeroAscii = '0';
            foreach (var digit in digits)
            {
                try
                {
                    if (!char.IsNumber(digit))
                    {
                        throw new Exception("Invalid Input");
                    }
                }
                catch (Exception exception)
                {

                    Console.WriteLine(exception.ToString());
                }
                int tempAscii = digit;
                try
                {
                    sum = sum * 10 + (tempAscii - zeroAscii);
                }
                catch (Exception exception)
                {
                    sum = 0;
                    Console.WriteLine(exception.ToString());
                }
            }
            return sum;
        }
    }
}