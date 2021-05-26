using System;
using System.Collections.Generic;

namespace Fibonacci
{
    class Program
    {
        private static int countNormal = 0;
        private static int countMemo = 0;

        private static readonly Dictionary<int, int> _memo = new Dictionary<int, int> { { 0, 0 }, { 1, 1 } };

        static void Main(string[] args)
        {
            for (int i = 0; i < 13; i++)
                Console.Write($" {Fibo(i)} ");

            Console.WriteLine($"No memo: {countNormal}");

            for (int i = 0; i < 13; i++)
                Console.Write($" {FiboWithMemoization(i)} ");

            Console.WriteLine($"With memo: {countMemo}");
        }

        public static int Fibo(int input)
        {
            countNormal++;

            if (input == 0 || input == 1)
                return 1;

            var retorno = Fibo(input - 1) + Fibo(input - 2);
            return retorno;
        }

        public static int FiboWithMemoization(int input)
        {
            countMemo++;

            if (input == 0 || input == 1)
                return 1;

            if (_memo.ContainsKey(input))
                return _memo[input];

            _memo[input] = Fibo(input - 1) + Fibo(input - 2);
            return _memo[input];
        }
    }
}
