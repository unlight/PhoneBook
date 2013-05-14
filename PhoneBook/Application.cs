using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace PhoneBook
{
    class Application
    {

		public const string APPLICATION = "PhoneBook";
    	public const float VERSION = 1.0f;
        public const char FieldSeparator = '\t';
        public delegate void KeyHandler();
        private List<Command> Commands = new List<Command>();

        private Command _Command; // Current command execution.
        public Command Command {
        	get { return _Command; }
        	set { _Command = value; }
        }
        
        public Application()
        {
            Console.Title = "Телефонная книга v" + VERSION;
        }
  
		
		public void Run() 
		{
			Commands.Add(new ExitCommand());
            Commands.Add(new ShowEntriesCommand());
            Commands.Add(new AddEntryCommand());
            Commands.Add(new SearchCommand());
           

            Console.Clear();
            Welcome();
			
			while (true) {
                MainMenu();
				ConsoleKeyInfo ConsoleKeyInfo = Console.ReadKey();
				foreach (var Command in Commands) {
                    if (Command.IsMatchKey(ConsoleKeyInfo.Key)) 
					{
						Command.Execute();
						break;	
					}
				}
                if (ConsoleKeyInfo.Key == ConsoleKey.D0)
                {
                    return;
                }
			}
		}

        public void Welcome()
        {
            Console.WriteLine("Welcome to " + APPLICATION + " " + VERSION);
        }

        public void MainMenu(bool ClearScreen = false)
        {
            if (ClearScreen) {
            	Console.Clear();
            }

            foreach (var Command in Commands)
            {
                Console.WriteLine("[{0}] {1}", Command.ConsoleKey, Command.Title);
            }
            Console.Write("Выберите действие: ");
        }
    }
	
}