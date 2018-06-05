using System;
using System.Collections.Generic;

namespace PrimeTables
{
    // Uses Sieve of Eratosthenes method https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
    public class PrimeCalculation
    {
        // Int32.MaxValue-th prime (50685770143) fits within the bounds of ulong (18,446,744,073,709,551,615) but not int
        // All primes are positive, so use an unsigned int
        List<ulong> primes;

        public PrimeCalculation(int numPrimes)
        {
            // Initialise our primes
            primes = new List<ulong> ();
            primes.Add(2);

            // Generate a seive and while doing so, add any primes to our array until we have numPrimes
            ulong primeBound = UpperPrimeBound(numPrimes);
            bool[] isPrime = new bool[primeBound];

            // Everything from 2 onwards is possibly a prime
            for (ulong i = 2; i < primeBound; ++i)
            {
                isPrime[i] = true;
            }

            // Calculate primes. Start with 3, because we're going to check bitwise if i is even
            for (ulong i = 3; i < primeBound && primes.Count < numPrimes; ++i)
            {
                if (isPrime[i])
                {
                    if ((i & 1) != 1)
                    {
                        // Fast check, if bit 1 is not set, this value is even and not prime
                        isPrime[i] = false;
                        continue;
                    }

                    // If prime, add to set
                    if (isPrime[i])
                    {
                        primes.Add(i);
                    }

                    // Remove all odd multiples of this number (all even multiples will be even and caught by the check above)
                    for (ulong j=i*3; j < primeBound; j += i * 2)
                    {
                        isPrime[j] = false;
                    }
                }
            }
        }

        // Return the upper bound for the nth prime number
        // According to Rosser (1941) the nth prime must be less than n*log(n*(log(n)))) for n >= 6
        // Less than this, return the 5th prime's value (for compatibility)
        public static ulong UpperPrimeBound(int n)
        {
            if (n >= 6)
            {
                return (ulong)Math.Ceiling(n * Math.Log(n * Math.Log(n)));
            }
            else
            {
                return 11;
            }
        }

        // Return the prime number at index i
        public ulong GetPrime(int i)
        {
            if (i > primes.Count)
            {
                throw new Exception("Out of bounds, have " + primes.Count + " primes, can't get index "+i);
            }
            return primes[i];
        }
    }
}
