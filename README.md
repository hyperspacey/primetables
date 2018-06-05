# primetables
Generate multiplication table of primes

Author: Colin Whiteside

How to run:
- 	Open PrimeTablesBuilt folder on a Windows PC
- 	Run PrimeTables.exe
-	Enter your value for number of primes
-	Press Generate
- 	Output will be send to output.txt. Note that this is best read with Notepad++; Notepad starts wordwrapping

Pleased with:
- 	Has simple unit test
- 	Algorithm is fairly straightforward and well commented
-	Can display fairly large prime multiplication values
-	Asynchronous execution so no application hangs

What to do with more time:
- 	There are better implementations of prime-finding; one such example is an answer 
	given at https://stackoverflow.com/questions/1569127/c-implementation-of-the-sieve-of-atkin
	and uses pregenerated prime tables, lookups and wheel factorisation to make the algorithm more efficient. As I don't
	understand the implementation details sufficiently to explain what it does,	I have chosen not to attempt to
	implement it; code I don't understand myself is unlikely to be maintainable by someone else
-	Make PrimeCalculation implement an interface so we can have a consistent way to access different prime calculation methods
- 	Localise front-end rather than using hardcoded text
-	For large-ish amounts of primes (>300) we're going to run out of memory writing the output to the application, so we do it
	to a file. By 20000 primes, the output file will be approx. 1GB and too large to open even in Notepad++.
-	Producing a subset of prime multiplication tables seems like an obvious progression, that would mitigate the above
-	Needs better exception handling
