namespace MultiThreadingWithPrimeNumbers;

public static class PrimeNumber
{
    public static bool IsPrime(long number)
    {
        if (number == 2) return true;
        if (number % 2 == 0) return false;
        for (long divisor = 3; divisor < (number / 2); divisor += 2)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }
        return true;
    }
}
