/*
 * Created by SharpDevelop.
 * User: S
 * Date: 21.04.2013
 * Time: 1:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace PhoneBook
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class ExitCommand : Command
	{
		public ExitCommand() : base("D0") {
		}
		
		public override void Execute() 
		{
			Environment.Exit(0);
		}
	}
}
