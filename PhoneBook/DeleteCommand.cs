/*
 * Created by SharpDevelop.
 * User: S
 * Date: 15.05.2013
 * Time: 22:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace PhoneBook
{
    /// <summary>
    /// Description of DeleteCommand.
    /// </summary>
    public class DeleteCommand : Command
    {
        public DeleteCommand() : base(ConsoleKey.D5, "Удалить запись")
        {
        }
        
        public override void Execute() {
            
            string S;
            
            Console.WriteLine();
            Console.WriteLine("Введите номер записи:");
            S = Console.ReadLine();
            
            int EntryID = Convert.ToInt32(S);
            
            var Result = Entry.Delete(EntryID);
            if (Result) {
                Console.WriteLine("Запись удалена.");
            } else {
                Console.WriteLine("Запись не найдена.");
            }
            
        }
    }
}
