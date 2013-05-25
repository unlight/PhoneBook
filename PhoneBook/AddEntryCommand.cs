/*
 * Created by SharpDevelop.
 * User: S
 * Date: 20.04.2013
 * Time: 23:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook
{
    /// <summary>
    /// Description of Class1.
    /// </summary>
    public class AddEntryCommand : Command
    {
        public AddEntryCommand() : base(ConsoleKey.D2, "Добавить запись")
        {
        }
        
        public override void Execute() {

            string S;
            ConsoleKeyInfo IncomingKeyInfo;
            bool IsCanceled = false;
            
            Console.Clear();
            Console.WriteLine("Новая запись: ");
            var NewValues = new List<string>();
            var Fields = Entry.GetFields();
            foreach (var Field in Fields)
            {
                Console.Write("Введите '{0}': ", Field);
                var Sb = new StringBuilder();
                do {
                    IncomingKeyInfo = Console.ReadKey();
                    IsCanceled = (IncomingKeyInfo.Key == ConsoleKey.Escape);
                    if (IsCanceled) {
                        break;
                    }
                    Sb.Append(IncomingKeyInfo.KeyChar);
                } while (IncomingKeyInfo.Key != ConsoleKey.Enter);
                
                Console.WriteLine();
                if (IsCanceled) {
                    break;
                }
                NewValues.Add(Sb.ToString());
            }
            
            if (IsCanceled) {
                return;
            }
            
            var E = new Entry(NewValues);
            E.Save();

        }
    }
}
