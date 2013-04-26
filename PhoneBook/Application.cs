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
        private List<Command> Commands;
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
//            OnCancelKey += delegate {
//            	Console.WriteLine("Нажата клавиша Escape.");
//            };
        }
        
        public void AddRecord()
        {
            string S;
            var Index = 0;
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

        // TODO: Постраничная 
        void ShowRecords()
        {
            string S;

            Console.WriteLine();

            var StreamReader = new StreamReader(new FileStream("db.txt", FileMode.Open));
            //var Records = File.ReadLines("db.txt");

            while (!StreamReader.EndOfStream)
            {
                S = StreamReader.ReadLine();
                Console.WriteLine(S);
            }
            StreamReader.Close();

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
			var Commands = new List<Command>();
			Commands.Add(new ExitCommand());
			
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
			}
		}

        public void _Run()
        {
        	
        	
            Welcome();

            while (true)
            {
                MainMenu();
                ConsoleKeyInfo ConsoleKeyInfo = Console.ReadKey();
                // Console.WriteLine("+" + ConsoleKeyInfo.Key.ToString() + "xx");
                switch (ConsoleKeyInfo.Key.ToString())
                {
                    case "D1": AddRecord(); break;
                    case "D2": ShowRecords(); break;
                    // case "0": break;
                }
                if ("D0" == ConsoleKeyInfo.Key.ToString()) return;
            }
        }

        public void Welcome()
        {
            Console.WriteLine("Welcome to " + APPLICATION + " " + VERSION);
        }

        public void MainMenu(bool ClearScreen = false)
        {
        	// TODO: Brush this block.
            if (ClearScreen) {
            	Console.Clear();
            } else {
            	Console.WriteLine();
            }
            
            Console.WriteLine("[1] Добавить запись");
            Console.WriteLine("[2] Посмотреть записи");
            Console.WriteLine("[3] Поиск");
            Console.WriteLine("[8] Настройки");
            Console.WriteLine("[0] Выход");
            Console.Write("Выберите действие: ");
        }
    }
	
}
