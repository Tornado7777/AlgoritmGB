using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmQuests
{
    class Task1
    {
        public void ShowTask()
        {
           
            int numberTask = 4; //кол-во заданий
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
            ArrayLessons[3, 1] = "Реализовать функцию вычисления числа Фибоначи \n рекурсивную версию и версию без рекурсии (через цикл);";
            //Урок 32
            ArrayLessons[4, 0] = "Задание №32";
            ArrayLessons[4, 1] = "Реализовать функцию вычисления числа Фибоначи \n версию без рекурсии (через цикл);";

            Console.Clear(); //очищаем консоль

            for (int i = 0; i <= numberTask; i++)
            {
                Console.WriteLine(ArrayLessons[i, 0] + "\n");
                Console.WriteLine(ArrayLessons[i, 1] + "\n");
            }
            Console.WriteLine("Введите номер интересующего урока: ");
            bool successChange = int.TryParse(Console.ReadLine(), out int N);
            if (successChange & (N > 0))
            {
                switch (N)
                {
                    case 1:
                        {

                            Task1 taskNum1 = new Task1();
                            taskNum1.ShowTask();
                            break;
                        }
                    case 2:
                        {

                            Task2 taskNum2 = new Task2();
                            taskNum2.ShowTask();
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("Урок с таким номером не найден");
            }

        }
    }
}
