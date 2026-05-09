using Xunit;

public class PrimeTests
{
    [Theory]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, false)]
    [InlineData(17, true)]
    [InlineData(1, false)]
    [InlineData(0, false)]
    [InlineData(-7, false)]
    [InlineData(1000003, true)]

    // Small composites and primes
    [InlineData(25, false)]
    [InlineData(29, true)]
    [InlineData(97, true)]
    [InlineData(99, false)]

    // Carmichael numbers (composite but can fool some primality tests)
    [InlineData(561, false)]
    [InlineData(41041, false)]
    [InlineData(825265, false)]

    // Larger known primes
    [InlineData(2147483647, true)]            // 2^31-1 (Mersenne prime)
    [InlineData(2305843009213693951, true)]   // 2^61-1 (Mersenne prime)
    [InlineData(32416190071, true)]           // large prime

    // Large composites
    [InlineData(2305843009213693951 - 2, false)]
    [InlineData(4294967296, false)]
    public void TestIsPrime(long n, bool expected)
    {
        Assert.Equal(expected, Program.IsPrime(n));
    }
}
