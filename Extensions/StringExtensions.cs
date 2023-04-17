
namespace ReactCLI.Extensions
{
    internal static class StringExtensions
    {
        public static void Log(this string message, bool writeLine = true)
        {
            Log(message, Console.ForegroundColor, writeLine);
        }

        public static void LogBlue(this string message, bool writeLine = true)
        {
            Log(message, ConsoleColor.Blue, writeLine);
        }

        public static void LogRed(this string message, bool writeLine = true)
        {
            Log(message, ConsoleColor.Red, writeLine);
        }

        public static void LogYellow(this string message, bool writeLine = true)
        {
            Log(message, ConsoleColor.Yellow, writeLine);
        }

        public static void LogGreen(this string message, bool writeLine = true)
        {
            Log(message, ConsoleColor.Green, writeLine);
        }

        private static void Log(string message, ConsoleColor color, bool writeLine)
        {
            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            if (writeLine)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.Write(message);
            }

            Console.ForegroundColor = prevColor;
        }
    }
}