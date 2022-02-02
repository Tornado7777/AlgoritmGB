using System;

namespace AlgoritmQuests
{
    class Program
    {
        //Вычислите асимптотическую сложность функции из примера ниже.
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; //O(1)
            for (int i = 0; i < inputArray.Length; i++) //O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) //O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) //O(N)
                    {
                        int y = 0; //O(1)

                        if (j != 0) //O(1)
                        {
                            y = k / j; //O(1)
                        }

                        sum += inputArray[i] + i + k + j + y;
                    }
                }
            }

            return sum; //0(1)
        }
        //Ощая сдожность O( f(N)xg(N)x k(N)) = O(N^3) наиболее болшее кол-во операций будет произведенно по правилу 4
        static void Main(string[] args)
        {
          //  Console.WriteLine("Hello World!");
        }
    }
}
