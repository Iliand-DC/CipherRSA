using System;
namespace CipherRSA
{
	public class FindCoprime
	{
        public long e;
        public static bool IsCoprime(long a, long b)
        {
            if (a == 1)
            {
                return true;
            }
            else
            {
                if (a > b)
                {
                    return IsCoprime(a - b, b);
                }
                else
                {
                    return false;
                }
            }
        }
        public FindCoprime(long number)
		{
            Random random = new Random();
            e = random.NextInt64(1, 100);
            while (IsCoprime(e, number) != true)
            {
                e = random.NextInt64(1, 100);
            }
		}
        public long GetE() { return e; }
	}
}

