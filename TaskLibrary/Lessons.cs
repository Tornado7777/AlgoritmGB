using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary
{
    public class Lessons
    {
        public void startLessons(int N = 0)
        {

            List<ILessons> lessons = new List<ILessons>();
            lessons.Add(new Task1 { NameTask = "Урок №1", Description = "Блок-схемы, асимптотическая сложность, рекурсия." });
            lessons.Add(new Task2 { NameTask = "Урок №2", Description = "Массив, список, поиск." });
            lessons.Add(new Task3 { NameTask = "Урок №3", Description = "Класс, структура и дистанция." });
            lessons.Add(new Task4 { NameTask = "Урок №4", Description = "Деревья, хэш-таблицы." });
            lessons.Add(new Task5 { NameTask = "Урок №5", Description = "Стек, очередь, словарь и коллекции в C#." });
            lessons.Add(new Task6 { NameTask = "Урок №6", Description = "Графы." });

            if (N == 0) //отображать список уроков, если не задан вызываемый урок
            {
                for (int i = 0; i < lessons.Count; i++) Console.WriteLine(lessons[i].NameTask + "\n" + lessons[i].Description + "\n");
            }
            else
            {
                if ((N > 0) & (N <= lessons.Count)) lessons[N - 1].StartTask();
            }
        }
    }
}
