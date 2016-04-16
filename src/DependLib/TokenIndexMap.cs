using System;
using System.Collections.Generic;

namespace DependLib
{
	public class TokenIndexMap
	{

		private Dictionary<int, string> Token { get; set; } = new Dictionary<int,string>();
		private Dictionary<string, int> Index { get; set; } = new Dictionary<string,int>();

		public TokenIndexMap ()
		{
		}

		public void Insert(int index, string token)
		{
			Token [index] = token;
			Index [token] = index;
		}

		public void Insert(string token)
		{
			Insert (Token.Count, token);
		}

		public int GetIndex(string token)
		{
			if (Index.ContainsKey (token)) 
			{
				return Index[token];
			}
			Insert (token);
			return Index [token];
		}

		public int this[string value]
		{
			get{ return Index [value]; }
		}

		public string this[int value]
		{
			get{ return Token [value]; }
		}
	}
}

