namespace MultiThreadingWithPrimeNumbers.Implementations;

public static class SequencialImplementation
{
    public static long PrimesInRange(long start, long end)
    {
        long result = 0;
        for (var number = start; number < end; number++)
        {
            if (PrimeNumber.IsPrime(number))
            {
                result++;
            }
        }
        return result;
    }
}
