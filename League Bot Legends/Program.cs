using System;
using League_Bot_Legends.IO;

namespace League_Bot_Legends
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.OnStartup();
            HandleCommand();
            Console.Read();
        }

        static void HandleCommand()
        {
            Logger.Write("Enter a command, type 'help' for help.", MessageState.INFO);
            string line = Console.ReadLine();

            if (line == "help")
            {
                Logger.Write("No commands.", MessageState.WARNING);
                HandleCommand();
                return;
            }
            HandleCommand();
        }
    }
}