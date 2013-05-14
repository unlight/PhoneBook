/*
 * Created by SharpDevelop.
 * User: S
 * Date: 14.05.2013
 * Time: 22:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

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
			throw new NotImplementedException();
		}
	}
}
