using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("整数を入力してください:");
        string? input = Console.ReadLine();
        if (input == null)
        {
            Console.WriteLine("入力がありません。");
            return;
        }

        if (!long.TryParse(input.Trim(), out long n))
        {
            Console.WriteLine("有効な整数を入力してください。");
            return;
        }

        if (n < 2)
        {
            Console.WriteLine($"{n} は素数ではありません。");
            return;
        }

        if (IsPrime(n))
            Console.WriteLine($"{n} は素数です。");
        else
            Console.WriteLine($"{n} は素数ではありません。");
    }

    public static bool IsPrime(long n)
    {
        if (n < 2) return false;
        if (n % 2 == 0) return n == 2;

        ulong d = (ulong)n;

        // Small primes trial division
        ulong[] smallPrimes = new ulong[] { 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };
        foreach (var p in smallPrimes)
        {
            if (d == p) return true;
            if (d % p == 0) return false;
        }

        // Write d-1 as 2^s * r
        ulong dMinus1 = d - 1;
        int s = 0;
        ulong r = dMinus1;
        while ((r & 1) == 0)
        {
            r >>= 1;
            s++;
        }

        // Deterministic bases for 64-bit integers
        ulong[] witnesses = new ulong[] { 2UL, 325UL, 9375UL, 28178UL, 450775UL, 9780504UL, 1795265022UL };

        foreach (var a in witnesses)
        {
            if (a % d == 0) return true;

            // x = a^r mod d
            ulong x = (ulong)BigInteger.ModPow(new BigInteger(a), new BigInteger(r), new BigInteger(d));
            if (x == 1 || x == dMinus1) continue;

            bool composite = true;
            for (int i = 1; i < s; i++)
            {
                x = (ulong)((BigInteger)x * x % d);
                if (x == dMinus1)
                {
                    composite = false;
                    break;
                }
            }

            if (composite) return false;
        }

        return true;
    }
}
