using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmQuests
{
    class Task1 : ILessons
    {
        public string NameTask { get; set; }
        public string Description { get; set; }

        //TestCase для задания 1
        public class TestCase
        {
            public string Num { get; set; }
            public bool Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }


        static void Task11()
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

        // функция для выполнения задания 1 урока 1 на простое число
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

        // функция для тестирования задания 1 урока 1 на простое число
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
        
        //функция выполнения задания №2 урока 1
        static void Task12()
        {
            //Вычислите асимптотическую сложность функции из примера ниже.
            string[] task12 = new string[25];
            task12 [0] = @"Вычислите асимптотическую сложность функции из примера ниже.";
            task12 [1] = @"public static int StrangeSum(int[] inputArray)";
            task12 [2] = @"{";
            task12 [3] = @"    int sum = 0; //O(1)";
            task12 [4] = @"    for (int i = 0; i < inputArray.Length; i++) //O(N)";
            task12[5] = @"    {";
            task12[6] = @"        for (int j = 0; j < inputArray.Length; j++) //O(N)";
            task12[7] = @"        {";
            task12[8] = @"            for (int k = 0; k < inputArray.Length; k++) //O(N)";
            task12[9] = @"            {";
            task12[10] = @"                int y = 0; //O(1)";
            task12[11] = @"";
            task12[12] = @"                if (j != 0) //O(1)";
            task12[13] = @"                {";
            task12[14] = @"                    y = k / j; //O(1)";
            task12[15] = @"                }";
            task12[16] = @"";
            task12[17] = @"                sum += inputArray[i] + i + k + j + y;";
            task12[18] = @"            }";
            task12[19] = @"        }";
            task12[20] = @"    }";
            task12[21] = @"";
            task12[22] = @"    return sum; //0(1)";
            task12[23] = @"}";
            task12[24] = @"Ощая сдожность O( f(N)xg(N)x k(N)) = O(N^3) наиболее болшее кол-во операций будет произведенно по правилу 4";
            Console.Clear();
            for (int i=0; i<task12.Length; i++)
            {
                Console.WriteLine(task12[i]);
            }
        }

        //функция выполнения задания №3 урока 1 часть 1 рекурсия
        static void Task1_31()
        {
            //Требуется реализовать расчет числа Фибоначи через рекурси. .
            //Пример чисел Фибоначчи:
            //F(0) = 0,
            //F(1) = 1.
            //Для остальных чисел:
            //F(N) = F(N - 2) + F(N - 1).
            //То есть для F(2) будет F(2) = F(0) + F(1) = 0 + 1 = 1.
            //F(3) будет F(3) = F(1) + F(2) = 1 + 1 = 2.

            Console.WriteLine("Input fibonachi: ");
            bool success = int.TryParse(Console.ReadLine(), out int N);
            if (success & (N >= 0))
            {
                Console.WriteLine("Fibonache " + N + " = " + FibonachiRecursion(N));
            }
            else
            {
                Console.WriteLine("Is not number or N < 0");
            }
        }
        //функция расчета числа Фибоначи рекурсией
        static int FibonachiRecursion(int N)
        {
            int fibonachiN = 0;


            for (int i = 1; i <= N; i++)
            {

                if (i == 1)
                {
                    fibonachiN = 1;

                }
                else
                {
                    fibonachiN = FibonachiRecursion(N - 1) + FibonachiRecursion(N - 2);
                }

            }

            return fibonachiN;
        }

        //функция выполнения задания №3 урока 1 часть 2 цикл
        static void Task1_32() 
        {
            //Требуется реализовать расчет числа Фибоначи через цикл. .
            //Пример чисел Фибоначчи:
            //F(0) = 0,
            //F(1) = 1.
            //Для остальных чисел:
            //F(N) = F(N - 2) + F(N - 1).
            //То есть для F(2) будет F(2) = F(0) + F(1) = 0 + 1 = 1.
            //F(3) будет F(3) = F(1) + F(2) = 1 + 1 = 2.

            Console.WriteLine("Input fibonachi: ");
            bool success = int.TryParse(Console.ReadLine(), out int N);
            if (success & (N >= 0))
            {
                Console.WriteLine("Fibonache " + N + " = " + FibonachiCycle(N));
            }
            else
            {
                Console.WriteLine("Is not number or N < 0");
            }
        }

        //функция расчета числа Фибоначи через цикл
        static int FibonachiCycle(int N)
        {
            int fibonachiN = 0;
            int fibonachiN1 = 0;
            int fibonachiN2 = 0;

            for (int i = 1; i <= N; i++)
            {

                if (i == 1)
                {
                    fibonachiN = 1;

                }
                else
                {
                    fibonachiN = fibonachiN1 + fibonachiN2;
                }
                fibonachiN2 = fibonachiN1;
                fibonachiN1 = fibonachiN;
            }

            return fibonachiN;
        }

        public void StartTask()
        {
            NameTask = "\nЗадание №1:\n";
            Description = "Требуется реализовать на C# функцию согласно блок-схеме. \n Блок-схема описывает алгоритм проверки, простое число или нет.";
            int numberTask = 4; //кол-во заданий + 1 для шапки
            string[,] ArrayLessons = new string[numberTask + 1, numberTask + 1];
            //Шапка для отбражения уроков
            ArrayLessons[0, 0] = "Номер задания";
            ArrayLessons[0, 1] = "Содержание";
            //Урок 1
            ArrayLessons[1, 0] = "Здание №1";
            ArrayLessons[1, 1] = "Требуется реализовать на C# функцию согласно блок-схеме. \n Блок-схема описывает алгоритм проверки, простое число или нет.";
            //Урок 2
            ArrayLessons[2, 0] = "Задание №2";
            ArrayLessons[2, 1] = "Вычислите асимптотическую сложность функции из примера ниже. ";
            //Урок 31
            ArrayLessons[3, 0] = "Задание №31";
            ArrayLessons[3, 1] = "Реализовать функцию вычисления числа Фибоначи \n рекурсивную версию. ";
            //Урок 32
            ArrayLessons[4, 0] = "Задание №32";
            ArrayLessons[4, 1] = "Реализовать функцию вычисления числа Фибоначи \n версию без рекурсии (через цикл).";

            Console.Clear(); //очищаем консоль

            for (int i = 0; i <= numberTask; i++)
            {
                Console.WriteLine(ArrayLessons[i, 0] + "\n");
                Console.WriteLine(ArrayLessons[i, 1] + "\n");
            }
            Console.WriteLine("Введите номер интересующего задания и нажмите Enter: ");
            bool successChange = int.TryParse(Console.ReadLine(), out int N);
            if (successChange & (N > 0))
            {
                switch (N)
                {
                    case 1:
                        {

                            Task11();
                            break;
                        }
                    case 2:
                        {

                            Task12();
                            break;
                        }
                    case 31:
                        {

                            Task1_31();
                            break;
                        }
                    case 32:
                        {

                            Task1_32();
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("Задания с таким номером не найден");
            }
        }
        public void ShowTask()
        {
            Console.WriteLine(NameTask);
            Console.WriteLine(Description);
        }

        public void TaskLogic()
        {
            throw new NotImplementedException();
        }
    }
}
