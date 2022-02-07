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
            int numberTask = 2; //кол-во заданий + 1 для шапки
            string[,] ArrayLessons = new string[numberTask + 1, numberTask + 1];
            //Шапка для отбражения уроков
            ArrayLessons[0, 0] = "Номер задания";
            ArrayLessons[0, 1] = "Содержание";
            //Урок 1
            ArrayLessons[1, 0] = "Здание №1";
            ArrayLessons[1, 1] = "Требуется реализовать класс двусвязного списка и операции вставки, \nудаления и поиска элемента в нём в соответствии с интерфейсом.";
           
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

                            Task21();
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
        static void Task21()
        {
            int countNewNode = 10; // указываю кол-во элементов в массиве
            var masNode = new NodeTwoLinks [countNewNode]; //создаю массив Node
            Random rnd = new Random();                   //Создание объекта для генерации чисел

            for (int i = 0; i <countNewNode;i++)
            {
                masNode[i] = new NodeTwoLinks(rnd.Next(0,1000));//создаю i-тый элемент массива с рандомным значением Value 
                if (i > 0)
                {
                   
                    masNode[i].PrevNode = masNode[i-1]; 
                    masNode[i - 1].NextNode = masNode[i];
                }

            }

            int count = masNode[1].GetCount(); //доступ к первому аргументу
            Console.WriteLine("Велиина массива - " + count);
            
        }

        
    }
}
