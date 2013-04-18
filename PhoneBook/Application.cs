using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PhoneBook
{
    class Application
    {

        const char FieldSeparator = '\t';
        readonly string FieldSeparatorString = new String(FieldSeparator, 1);
        private string[] Fields = {"ID", "First Name", "Phone Number" };

        public Application()
        {
            Console.Title = "Телефонная книга v1.0.0";
        }

        public void AddRecord()
        {
            string S;
            var Index = 0;

            Console.Clear();
            Console.WriteLine("Новая запись: ");
            string[] NewValues = new string[Fields.Length + 1];
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
	
            // TODO: Check if file is exists.
            Strings = File.ReadAllLines("db.txt");
            S = Strings[Strings.Length-1];
            Strings = S.Split(FieldSeparator);
            S = Strings[0];

            int Result = (Int32.Parse(S) + 1);
            
            return Result;
        }

        void Exit()
        {

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
            // TODO: Имя программы сделать как константу.
            Console.WriteLine("Welcome to PhoneBook Application.");
        }

        public void MainMenu(bool ClearScreen = false)
        {
            if (ClearScreen)
            {
                // TODO: Очистить экран.				
            }
            Console.WriteLine("[1] Добавить запись");
            Console.WriteLine("[2] Посмотреть записи");
            Console.WriteLine("[0] Выход");
            Console.Write("Выберите действие: ");
        }
    }
	
}
