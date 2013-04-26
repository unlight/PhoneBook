/*
 * Created by SharpDevelop.
 * User: S
 * Date: 20.04.2013
 * Time: 23:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace PhoneBook
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class AddRecordCommand : Command
	{
		public AddRecordCommand() : base(ConsoleKey.D1, "Добавить запись")
		{
		}
		
		public override void Execute() {
		}
	}
}
