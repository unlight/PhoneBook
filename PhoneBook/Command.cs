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
        private ConsoleKey _ConsoleKey;

        public ConsoleKey ConsoleKey
        {
			get { return _ConsoleKey; }
			set { _ConsoleKey = value; }
		}

        public string Title { get; set; }

        public Command(ConsoleKey ConsoleKey)
		{
            this.ConsoleKey = ConsoleKey;
            this.Title = "Unknown";
		}

        public Command(ConsoleKey ConsoleKey, string Title)
        {
            this.ConsoleKey = ConsoleKey;
            this.Title = Title;
        }
		
		public bool IsMatchKey(ConsoleKey K)
		{
			return (K == this.ConsoleKey);
		}
		
		abstract public void Execute();
	}
}
