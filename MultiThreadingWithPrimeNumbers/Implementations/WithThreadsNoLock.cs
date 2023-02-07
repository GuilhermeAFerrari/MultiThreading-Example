namespace MultiThreadingWithPrimeNumbers.Implementations;

public static class WithThreadsNoLock
{
    public static long PrimesInRange2_1(long start, long end)
    {
        //var result = new List();
        var range = end - start;
        var numberOfThreads = (long)Environment.ProcessorCount;

        var threads = new Thread[numberOfThreads];
        var results = new long[numberOfThreads];

        var chunkSize = range / numberOfThreads;

        for (long i = 0; i < numberOfThreads; i++)
        {
            var chunkStart = start + i * chunkSize;
            var chunkEnd = i == numberOfThreads - 1 ? end : chunkStart + chunkSize;
            var current = i;

            threads[i] = new Thread(() =>
            {
                results[current] = 0;
                for (var number = chunkStart; number < chunkEnd; ++number)
                {
                    if (PrimeNumber.IsPrime(number))
                    {
                        results[current]++;
                    }
                }
            });

            threads[i].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return results.Sum();
    }
}
