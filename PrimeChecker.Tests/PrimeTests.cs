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
    [InlineData(1000003, true)]
    public void TestIsPrime(long n, bool expected)
    {
        Assert.Equal(expected, Program.IsPrime(n));
    }
}
