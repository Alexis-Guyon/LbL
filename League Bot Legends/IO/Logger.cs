using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace League_Bot_Legends.IO
{

    public enum MessageState
    {
        INFO = 0,
        INFO2 = 1,
        IMPORTANT_INFO = 2,
        WARNING = 3,
        ERROR = 4,
        ERROR_FATAL = 5,
        SUCCES = 6,
    }
    
    public class Logger
    {
        private const ConsoleColor COLOR_1 = ConsoleColor.DarkYellow;
        private const ConsoleColor COLOR_2 = ConsoleColor.DarkMagenta;

        private static Dictionary<MessageState, ConsoleColor> colors = new Dictionary<MessageState, ConsoleColor>()
        {
            {MessageState.INFO, ConsoleColor.Cyan},
            {MessageState.INFO2, ConsoleColor.Magenta},
            {MessageState.IMPORTANT_INFO, ConsoleColor.White},
            {MessageState.WARNING, ConsoleColor.Yellow},
            {MessageState.ERROR, ConsoleColor.Red},
            {MessageState.ERROR_FATAL, ConsoleColor.DarkRed},
            {MessageState.SUCCES, ConsoleColor.Green}
        };

        public static void Write(object value, MessageState state = MessageState.INFO)
        {
            WriteColored(value, colors[state]);
        }

        public static void WriteColored(object value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
        }
        
        public static void WriteColor1(object value)
        {
            WriteColored(value, COLOR_1);
        }
        public static void WriteColor2(object value)
        {
            WriteColored(value, COLOR_2);
        }
        public static void NewLine()
        {
            Console.WriteLine(Environment.NewLine);
        }
        
        public static void OnStartup()
        {

            WriteColor2(".-.                                    .---.       .-.   .-.                              .-.      ");
            WriteColor1(": :                                    : .; :     .' `.  : :                              : :      ");
            WriteColor2(": :    .--.  .--.   .--. .-..-. .--.   :   .' .--.`. .'  : :    .--.  .--.  .--. ,-.,-. .-' : .--. ");
            WriteColor1(": :__ ' '_.'' .; ; ' .; :: :; :' '_.'  : .; :' .; :: :   : :__ ' '_.'' .; :' '_.': ,. :' .; :`._-.'");
            WriteColor2(":___.'`.__.'`.__,_;`._. ;`.__.'`.__.'  :___.'`.__.':_;   :___.'`.__.'`._. ;`.__.':_;:_;`.__.'`.__.'");
            WriteColor1("                    .-. :                                             .-. :                        ");
            WriteColor2("                    `._.'                                             `._.'                        ");
            Console.WriteLine();
            Console.Title = Assembly.GetEntryAssembly().GetName().Name;
        }
        
    }
}