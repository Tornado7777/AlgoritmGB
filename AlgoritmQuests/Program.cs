using System;
using System.Collections.Generic;
using TaskLibrary;

namespace AlgoritmQuests
{
    class Program
    {
        static string Lessons()
        {
            List<ILessons> lessons = new List<ILessons>();
            lessons.Add(new Task1 { NameTask = "Урок №1", Description = "Блок-схемы, асимптотическая сложность, рекурсия." });
            lessons.Add(new Task2 { NameTask = "Урок №2", Description = "Массив, список, поиск." });
            lessons.Add(new Task3 { NameTask = "Урок №3", Description = "Класс, структура и дистанция." });
            lessons.Add(new Task4 { NameTask = "Урок №4", Description = "Деревья, хэш-таблицы." });
            lessons.Add(new Task5 { NameTask = "Урок №5", Description = "Стек, очередь, словарь и коллекции в C#" });
            for (int i = 0; i < lessons.Count; i++) Console.WriteLine(lessons[i].NameTask + "\n" + lessons[i].Description + "\n"); 
            Console.WriteLine("Введите номер интересующего задания и нажмите Enter: ");
            string input = Console.ReadLine();
            int N = 0;
            bool successChange = int.TryParse(input,out N);
            if (successChange & (N > 0) & (N<=lessons.Count)) lessons[N-1].StartTask();
            return input;
        }
        static void Main(string[] args)
        {
            string input = ""; 
            do
            {
                Console.WriteLine("Для завершения введите exit \n");
                input = Lessons();
                if (input != "exit")
                {
                    Console.WriteLine("Для продолжение нажмите Enter \n");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            while (input != "exit") ;

        }
    }
}
