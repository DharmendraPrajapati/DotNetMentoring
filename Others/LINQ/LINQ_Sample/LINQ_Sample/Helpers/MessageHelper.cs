using System;
using Task.Properties;

namespace Task.Helpers
{
    namespace ResizerApp.Helpers
    {
        internal static class MessageHelper
        {
            private static readonly object ConsoleWriterLock = new object();

            public static void ErrorMessage(Exception e, string text)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Resources.MessageHelper_NewLine + text + Resources.MessageHelper_ErrorMessage,
                                  e.Message);
                if(!string.IsNullOrEmpty(e.StackTrace))
                {
                    Console.WriteLine(Resources.MessageHelper_ErrorMessageStackTrace, e.StackTrace);
                }
                Console.ResetColor();
            }

            public static void InfoMessage(string text,
                                           ConsoleColor bgColor = ConsoleColor.Black,
                                           ConsoleColor fgColor = ConsoleColor.Cyan)
            {
                lock(ConsoleWriterLock)
                {
                    Console.BackgroundColor = bgColor;
                    Console.ForegroundColor = fgColor;
                    Console.WriteLine(text);
                    Console.ResetColor();
                }
            }

            public static void SuccessMessage(string additionalText = "",
                                              ConsoleColor bgColor = ConsoleColor.Green,
                                              ConsoleColor fgColor = ConsoleColor.Black)
            {
                lock(ConsoleWriterLock)
                {
                    Console.BackgroundColor = bgColor;
                    Console.ForegroundColor = fgColor;
                    Console.WriteLine(Resources.MessageHelper_SuccessMessageSuccess, additionalText);
                    Console.ResetColor();
                }
            }
        }
    }
}