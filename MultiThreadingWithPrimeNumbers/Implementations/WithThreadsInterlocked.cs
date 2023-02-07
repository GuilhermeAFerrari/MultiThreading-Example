namespace MultiThreadingWithPrimeNumbers.Implementations;

public static class WithThreadsInterlocked
{
    public static long PrimesInRange(long start, long end)
    {
        long result = 0;
        var range = end - start;
        var numberOfThreads = (long)Environment.ProcessorCount;

        var threads = new Thread[numberOfThreads];

        var chunkSize = range / numberOfThreads;

        for (long i = 0; i < numberOfThreads; i++)
        {
            var chunkStart = start + i * chunkSize;
            var chunkEnd = i == numberOfThreads - 1 ? end : chunkStart + chunkSize;
            threads[i] = new Thread(() =>
            {
                for (var number = chunkStart; number < chunkEnd; ++number)
                {
                    if (PrimeNumber.IsPrime(number))
                    {
                        Interlocked.Increment(ref result);
                    }
                }
            });

            threads[i].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return result;
    }
}