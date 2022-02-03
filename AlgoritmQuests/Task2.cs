using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmQuests
{
    class Task2
    {
        //Выполняем только задание 1 - реализация типа двусвязного списка. 
        //И контрольный пример, демонстрирующий использование методов.
        //Интерактивный режим (взаимодействие с пользователем) не требуется.
        public void ShowTask()
        {
            int numberTask = 3; //кол-во заданий + 1 для шапки
            string[,] ArrayLessons = new string[numberTask + 1, numberTask + 1];
            //Шапка для отбражения уроков
            ArrayLessons[0, 0] = "Номер задания";
            ArrayLessons[0, 1] = "Содержание";
            //Урок 1
            ArrayLessons[1, 0] = "Здание №1";
            ArrayLessons[1, 1] = "Требуется реализовать класс двусвязного списка и операции вставки, \nудаления и поиска элемента в нём в соответствии с интерфейсом.";
            //Урок 2
            ArrayLessons[2, 0] = "Задание №2";
            ArrayLessons[2, 1] = "Требуется написать функцию бинарного поиска, посчитать его асимптотическую \nсложность и проверить работоспособность функции.";

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

                }
            }
            else
            {
                Console.WriteLine("Задания с таким номером не найден");
            }
        }

        // функция для выполнения задания 1 урока 2 
        static void Task11()
        {

        }

        // функция для выполнения задания 2 урока 2 
        static void Task12()
        {

        }
    }
}
