/*
 * Created by SharpDevelop.
 * User: S
 * Date: 20.04.2013
 * Time: 23:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace PhoneBook
{
	/// <summary>
	/// Description of Command.
	/// </summary>
	public abstract class Command
	{
		private string _ConsoleKeyString;
		
		public string ConsoleKeyString {
			get { return _ConsoleKeyString; }
			set { _ConsoleKeyString = value; }
		}
		
		public Command(string ConsoleKeyString) 
		{
			this.ConsoleKeyString = ConsoleKeyString;
		}
		
		public bool IsMatchKey(ConsoleKey K)
		{
			return (K.ToString() == this.ConsoleKeyString);
		}
		
		abstract public void Execute();
	}
}
