using System;

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
        if (n % 2 == 0)
            return n == 2;
        if (n % 3 == 0)
            return n == 3;

        long i = 5;
        long w = 2;
        while (i * i <= n)
        {
            if (n % i == 0) return false;
            i += w;
            w = 6 - w; // alternate 2,4 (checks 6k-1,6k+1)
        }
        return true;
    }
}
