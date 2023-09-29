using System;
namespace CipherRSA
{
	public class FindPrime
    {
        private long primeNumber;
        public static bool IsPrimeNumber(long n)
        {
            var result = true;

            if (n > 1)
            {
                for (var i = 2u; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
        public FindPrime(long number)
		{
            while(IsPrimeNumber(number) != true)
            {
                number += 1;
            }
            primeNumber = number;
		}
        public long GetPrime() { return primeNumber; }
	}
}

