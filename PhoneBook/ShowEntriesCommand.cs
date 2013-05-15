using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PhoneBook
{
    class ShowEntriesCommand : Command
    {
        public ShowEntriesCommand() : base(ConsoleKey.D1, "Посмотреть записи") {
        }

        // TODO: Постраничная навигация.
        public override void Execute() {

            string S;

            Console.WriteLine();

            var StreamReader = new StreamReader(new FileStream("db.txt", FileMode.Open));

            while (!StreamReader.EndOfStream)
            {
                S = StreamReader.ReadLine();
                Console.WriteLine(S);
            }
            StreamReader.Close();
        }
    }
}
