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
using System.Collections.Generic;

namespace PhoneBook
{
	
	public class Entry
	{

	    private static string[] Fields = {"ID", "First Name", "Phone Number" };
		
		private const char FieldSeparator = '\t';
		private readonly string FieldSeparatorString = new String(FieldSeparator, 1);
        private List<string> _Values;

        public static string[] GetFields()
        {
            return Fields;
        }

        public Entry(List<string> Values)
		{
			this._Values = Values;
		}
		
		public int Save() 
		{
			int Result;
			string S;
			
			Result = GetLastID();

            _Values.ForEach(Value => Value.Replace(FieldSeparator, ' '));

            _Values.Insert(0, Result.ToString());
          
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
