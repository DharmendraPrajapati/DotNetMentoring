using System;

namespace SringConverter
{
    public class StringConvert
    {
        public static int ConvertStringToInteger(string stringText)
        {
            try
            {
                if (string.Equals(stringText, string.Empty))
                {
                    throw new Exception("String is Empty.");
                }
                if (string.Equals(stringText, null))
                {
                    throw new ArgumentNullException();
                }
                return StringValidationAndConvert(stringText);
            }
            
            catch (Exception ex)
            {
                Console.WriteLine("Exception has occured with message "+ex.Message);
                throw;
            }
        }

        private static int  StringValidationAndConvert(string text)
        {
            var charArray = text.ToCharArray();
            var num = 0;
            foreach (var c in charArray)
            {
                if (char.IsNumber(c))
                {
                    num *= 10;
                    num += c - '0';
                }
                else
                {
                    throw new FormatException();
                }
            }
            return num;
        }
    }
}
