using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary
{
    public class Lessons
    {
        public string startLessons()
        {
            List<ILessons> lessons = new List<ILessons>();
            lessons.Add(new Task1 { NameTask = "Урок №1", Description = "Блок-схемы, асимптотическая сложность, рекурсия." });
            lessons.Add(new Task2 { NameTask = "Урок №2", Description = "Массив, список, поиск." });
            lessons.Add(new Task3 { NameTask = "Урок №3", Description = "Класс, структура и дистанция." });
            lessons.Add(new Task4 { NameTask = "Урок №4", Description = "Деревья, хэш-таблицы." });
            lessons.Add(new Task5 { NameTask = "Урок №5", Description = "Стек, очередь, словарь и коллекции в C#." });
            lessons.Add(new Task6 { NameTask = "Урок №6", Description = "Графы." });
            for (int i = 0; i < lessons.Count; i++) Console.WriteLine(lessons[i].NameTask + "\n" + lessons[i].Description + "\n");
            Console.WriteLine("Введите номер интересующего задания и нажмите Enter: ");
            string input = Console.ReadLine();
            int N = 0;
            bool successChange = int.TryParse(input, out N);
            if (successChange & (N > 0) & (N <= lessons.Count)) lessons[N - 1].StartTask();
            return input;
        }
    }
}
