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

    	const string APPLICATION = "PhoneBook";
    	const float VERSION = 1.0f;
        const char FieldSeparator = '\t';
        readonly string FieldSeparatorString = new String(FieldSeparator, 1);
        private string[] Fields = {"ID", "First Name", "Phone Number" };

        public Application()
        {
            Console.Title = "Телефонная книга v" + VERSION;
        }
        
        public void AddRecord()
        {
            string S;
            var Index = 0;

            Console.Clear();
            Console.WriteLine("Новая запись: ");
            string[] NewValues = new string[Fields.Length];
            for (Index = 1; Index < Fields.Length; Index++)
            {
                Console.Write("Введите '{0}': ", Fields[Index]);
                S = Console.ReadLine().Replace(FieldSeparator, ' ');
                NewValues[Index] = S;
            }
            NewValues[0] = GetLastID().ToString();
            S = String.Join(FieldSeparatorString, NewValues);

            var StreamWriter = new StreamWriter(new FileStream("db.txt", FileMode.Append));
            StreamWriter.WriteLine(S);
            StreamWriter.Close();
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

        protected int GetLastID()
        {
            string[] Strings; 
            string S;
	
            if (!File.Exists("db.txt")) {
            	return 1;
            }
            Strings = File.ReadAllLines("db.txt");
            S = Strings[Strings.Length-1];
            Strings = S.Split(FieldSeparator);
            S = Strings[0];

            int Result = (Int32.Parse(S) + 1);
            
            return Result;
        }
        
        // UNDONE: Settings
        void Settings() 
        {
        	
        }

        void Exit()
        {
        	Environment.Exit(0);
        }

		// UNDONE: Need RegExp        
        public void Search() {
        	Console.Write("Введите строку для поска: ");
        	string S = Console.ReadLine();
        }

        public void Run()
        {
            Welcome();

            while (true)
            {
                MainMenu();
                ConsoleKeyInfo ConsoleKeyInfo = Console.ReadKey();
                string Key = ConsoleKeyInfo.KeyChar.ToString();
                switch (Key)
                {
                    case "1": AddRecord(); break;
                    case "2": ShowRecords(); break;
                    // case "0": break 2;
                }
                if ("0" == Key) return;
            }
        }

        public void Welcome()
        {
            Console.WriteLine("Welcome to " + APPLICATION + " " + VERSION);
        }

        public void MainMenu(bool ClearScreen = false)
        {
            if (ClearScreen)
            {
            	Console.Clear();
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
