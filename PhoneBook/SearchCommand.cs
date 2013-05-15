/*
 * Created by SharpDevelop.
 * User: S
 * Date: 14.05.2013
 * Time: 22:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace PhoneBook
{
	/// <summary>
	/// Description of SearchCommand.
	/// </summary>
	public class SearchCommand : Command
	{
		public SearchCommand() : base(ConsoleKey.D3, "Поиск")
		{
			
		}
		
		public override void Execute() {
			
			string S;
			
			Console.WriteLine();
			Console.WriteLine("Введите фразу для поиска: ");
			S = Console.ReadLine();
			if (String.IsNullOrEmpty(S)) {
				return;
			}
			var Found = Entry.Find(S);
			if (Found != "") {
				Console.WriteLine("Найдена запись: ");
                Console.WriteLine(Found);
			} else {
				Console.WriteLine("Ничего не найдено.");
			}
		}
	}
}
