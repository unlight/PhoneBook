/*
 * Created by SharpDevelop.
 * User: S
 * Date: 21.04.2013
 * Time: 0:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace PhoneBook
{
	
	public class Entry
	{
		
		private const char FieldSeparator = '\t';
		private readonly string FieldSeparatorString = new String(FieldSeparator, 1);
		private string[] _Values;
		
		public Entry(string[] Values)
		{
			this._Values = Values;
		}
		
		public int Save() 
		{
			int Result;
			string S;
			
			Result = GetLastID();
            this._Values[0] = Result.ToString();
            
            // TODO: Replace TAB in values to SPACE.
            //.Replace(FieldSeparator, ' ')
            
            S = String.Join(FieldSeparatorString, this._Values);
            var StreamWriter = new StreamWriter(new FileStream("db.txt", FileMode.Append));
            StreamWriter.WriteLine(S);
            StreamWriter.Close();
			
            return Result;
		}
		
        protected int GetLastID()
        {
            string[] Strings; 
            string S;
	
            if (!File.Exists("db.txt")) {
            	return 1;
            }
            Strings = File.ReadAllLines("db.txt");
            S = Strings[Strings.Length-1];
            Strings = S.Split(FieldSeparator);
            S = Strings[0];

            int Result = (Int32.Parse(S) + 1);
            
            return Result;
        }
	}
	
}
