using System;
using System.Numerics;
namespace CipherRSA
{
	public class Alphabet
	{
		
		private static string russianAlphabet = "АБВГДЕËЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ ,.!?";
		public Alphabet()
		{
		}
		public uint GetNumberOfSymbol(char s)
		{
			return Convert.ToUInt32(russianAlphabet.IndexOf(s));
		}
		public char GetSymbolByNumber(BigInteger n)
		{
			int index = (short)n;
			return russianAlphabet[index];
		}
		public int Size = russianAlphabet.Length;
	}
}

