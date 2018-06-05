using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeTables;
using System;
using System.Collections.Generic;

namespace PrimeTablesTests
{
    [TestClass]
    public class TestPrimes
    {
        private static int TEST_PRIME_COUNT = 200000;

        [TestMethod]
        public void TestPrimeGeneration()
        {
            // BENCHMARK THIS
            PrimeCalculation primeCalculation = new PrimeCalculation(TEST_PRIME_COUNT);
            // END BENCHMARK

            // List our primes so we can check them for false negatives
            HashSet<ulong> foundPrimes = new HashSet<ulong>();

            // Check for false positives
            for (int i = 0; i < TEST_PRIME_COUNT; ++i)
            {
                ulong possiblePrime = primeCalculation.GetPrime(i);
                foundPrimes.Add(possiblePrime);
                Assert.IsTrue(IsPrime(possiblePrime), "Non-prime value found: " + possiblePrime);
            }

            // Check for false negatives
            ulong upperPrimeBound = PrimeCalculation.UpperPrimeBound(TEST_PRIME_COUNT);
            int totalPrimesFound = 0;
            for (ulong i = 0; i < upperPrimeBound && totalPrimesFound < TEST_PRIME_COUNT; ++i)
            {
                if (IsPrime(i))
                {
                    ++totalPrimesFound;
                    Assert.IsTrue(foundPrimes.Contains(i), "Calculated primes are missing number: " + i);
                }
            }
        }

        private static bool IsPrime (ulong number)
        {
            if (number < 2) { return false; }   // No primes less than 2
            if (number % 2 == 0) { return number == 2; } // No even primes EXCEPT 2

            // Check to see if the value is a multiple of the root of the number
            ulong root = (ulong)Math.Sqrt(number);
            for (ulong i=3; i <= root; i += 2)
            {
                if (number % i == 0) { return false; }
            }

            return true;
        }
    }
}
