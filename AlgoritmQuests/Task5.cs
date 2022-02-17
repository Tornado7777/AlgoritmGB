using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmQuests
{
    class Task5 : ILessons
    {
        public string NameTask { get; set; }
        public string Description { get; set; }

        public void StartTask()
        {
            NameTask = "Задание №1";
            Description = "Реализуйте методы поиска в дереве \"поиск в ширину\" и \"поиск в глубину\" " +
                "\n(класс дерева должен быть реализован в ДЗ урока 4) с выводом каждого шага в консоль.";
            ShowTask();
            TaskLogic();
        }

        public void ShowTask()
        {
            Console.WriteLine(NameTask);
            Console.WriteLine(Description);
            Console.WriteLine("Нажмите клавишу Enter для продолжения.");
            Console.ReadLine();
        }

        public void TaskLogic()
        {
            Console.Clear();
            Task4 task4 = new Task4();
            task4.StartTask();
        }
    }
}
