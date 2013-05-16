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
using System.Linq;
using System.Xml.Linq;

namespace PhoneBook
{
	
	public class Entry
	{

	    private static string[] Fields = {"First Name", "Phone Number" };
		
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
		
		/// <summary>
		/// Finds first match.
		/// </summary>
		/// <param name="Value"></param>
		/// <returns></returns>
		public static string Find(string Value) {
			var Content = File.ReadAllLines("db.txt");
			string Result = "";
			foreach (var Line in Content) {
				var Pos = Line.IndexOf(Value, StringComparison.InvariantCultureIgnoreCase);
				if (Pos >= 0) {
					Result = Line;
					break;
				}
			}
			return Result;
		}
		
		public static string Load(int EntryID) {
			foreach (var Line in File.ReadAllLines("db.txt")) {
				if (Convert.ToInt32(Line.Split(FieldSeparator)[0]) == EntryID) {
					return Line;
				}
			}
			return "";
		}
		
		public static bool Delete(int EntryID) {
			var Lines = new List<string>(File.ReadAllLines("db.txt"));
			bool Removed = false;
			for (int i = 0, Count = Lines.Count; i < Count; i++) {
				var N = Convert.ToInt32(Lines[i].Split(FieldSeparator)[0]);
				if (N == EntryID) {
					Lines.RemoveAt(i);
					Removed = true;
					break;
				}
			}
			if (Removed) {
				File.WriteAllLines("db.txt", Lines);
				return true;
			}
			return false;
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
