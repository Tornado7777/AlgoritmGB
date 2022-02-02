using System;

namespace quest1_1
{
    class Program
    {
        public class TestCase
        {
            public string Num { get; set; }
            public bool Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }


        static bool SimpleNumber(string n)
        {
            bool simple = false;
            bool success = int.TryParse(n, out int number);
            if (success)
            {

                int d = 0;

                for (int i = 2; i < number; i++)
                {
                    if (i < number)
                    {
                        if (number % i == 0) d++;
                    }
                }
                if (d == 0) simple = true;

            }
            else throw new ArgumentException("n must be number");
            return simple;
        }

        static void TestSimpleNum(TestCase testCase)
        {
            try
            {
                var actual = SimpleNumber(testCase.Num);

                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST FOR NUMBER " + testCase.Num);
                }
                else
                {
                    Console.WriteLine("INVALID TEST FOR NUMBER " + testCase.Num);
                }
            }
            catch
            {
                if (testCase.ExpectedException != null)
                {
                    //TODO add type exception tests;
                    Console.WriteLine("VALID TEST FOR " + testCase.Num);
                }
                else
                {
                    Console.WriteLine("INVALID TEST FOR " + testCase.Num);
                }

            }


        }


        static void Main(string[] args)
        {
            var testCase1 = new TestCase()
            {
                Num = "6",
                Expected = false,
            };

            var testCase2 = new TestCase()
            {
                Num = "3",
                Expected = true,
            };
            var testCase3 = new TestCase()
            {
                Num = "a",
                Expected = true,
            };

            TestSimpleNum(testCase1);
            TestSimpleNum(testCase2);
            TestSimpleNum(testCase3);


            Console.WriteLine("Input number: ");
            string n = Console.ReadLine();
            if (SimpleNumber(n) == true)
            {
                Console.WriteLine("\n Number " + n + " is simple");
            }
            else
                Console.WriteLine("\n Number " + n + " is not simple");

        }
    }
}