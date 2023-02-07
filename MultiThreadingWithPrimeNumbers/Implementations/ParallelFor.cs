namespace MultiThreadingWithPrimeNumbers.Implementations;

public static class ParallelFor
{
    public static long PrimesInRange(long start, long end)
    {
        long result = 0;
        Parallel.For(start, end, number =>
        {
            if (PrimeNumber.IsPrime(number))
            {
                Interlocked.Increment(ref result);
            }
        });
        return result;
    }
}
