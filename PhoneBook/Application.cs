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
        private string[] Fields = {"ID", "First Name", "Phone Number" };
        public delegate void KeyHandler();
        public event KeyHandler OnCancelKey;
        private Command _Command; // Current command execution.
        private List<Command> Commands = new List<Command>();
        private ConsoleKey _ConsoleKey; // Last console key.
        
		public ConsoleKey ConsoleKey
		{
			get	{ return _ConsoleKey; }
			set	{
				_ConsoleKey = value;
				if (_ConsoleKey.ToString() == "Escape") {
					if (OnCancelKey != null) {
						OnCancelKey();
					}
					
				}
			}
		}
        
        public Command Command {
        	get { return _Command; }
        	set { _Command = value; }
        }
        
        public Application()
        {
            Console.Title = "Телефонная книга v" + VERSION;
        }
        
        public void AddRecord()
        {
            string S;
            int Index = 0;
            ConsoleKeyInfo ConsoleKeyInfo;
            bool IsCanceled = false;

            Console.Clear();
            Console.WriteLine("Новая запись: ");
            string[] NewValues = new string[Fields.Length];
            for (Index = 1; Index < Fields.Length; Index++)
            {
                Console.Write("Введите '{0}': ", Fields[Index]);
                S = "";
                do {
                	ConsoleKeyInfo = Console.ReadKey();
                	this.ConsoleKey = ConsoleKeyInfo.Key;
                	IsCanceled = (this.ConsoleKey.ToString() == "Escape");
                	if (IsCanceled) {
                		break;
                	}
                	S += this.ConsoleKey.ToString();
                } while (this.ConsoleKey.ToString() != "Enter");
                
                Console.WriteLine();
                if (IsCanceled) {
                	break;
                }
                NewValues[Index] = S;
            }
            
            if (IsCanceled) {
            	return;
            }
            
            var Entry = new Entry(NewValues);
            Entry.Save();
        }
    
        // UNDONE: Settings
        void Settings() 
        {
        	
        }

		// UNDONE: Need RegExp        
        public void Search() {
        	Console.Write("Введите строку для поска: ");
        	string S = Console.ReadLine();
        }
		
		public void Run() 
		{
			Commands.Add(new ExitCommand());
            Commands.Add(new ShowRecordsCommand());

            Console.Clear();
            Welcome();
			
			while (true) {
                MainMenu();
				ConsoleKeyInfo ConsoleKeyInfo = Console.ReadKey();
				ConsoleKey = ConsoleKeyInfo.Key;
				foreach (var Command in Commands) {
					if (Command.IsMatchKey(ConsoleKey)) 
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