using System;


namespace Prophet.Terminal.Interface
{
    public static class ExtendedConsole
    {
        public static void WriteLine(
            string text = "",
            ConsoleColor foregroundColor = ConsoleColor.Gray,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Write(text + "\n", foregroundColor, backgroundColor);
        }
        
        public static void Write(
            string text, 
            ConsoleColor foregroundColor = ConsoleColor.Gray, 
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}