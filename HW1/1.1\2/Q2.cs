using System;

namespace Q2
{
    internal class Q2
    {
        static bool IsPrime(int num)
        {
            if (num == 0 || num == 1) return false;

            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

        static void Calculate(int num)
        {
            if (num == 0 || num == 1) return;

            for (int i = 2; i <= num; i++)
            {
                if (num % i == 0 && IsPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("请输入你想查询的数:");

            string input = Console.ReadLine();


            if (int.TryParse(input, out int a) && a > 0)
            {
                Calculate(a);
            }
            else
            {
                Console.WriteLine("请输入一个有效的正整数。");
            }
        }
    }
}
