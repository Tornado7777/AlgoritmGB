using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary
{
    public class Task6 : ILessons
    {
        public string NameTask { get; set; }
        public string Description { get; set; }

        public void StartTask()
        {
            NameTask = "Задание №1";
            Description = "Реализовать загрузку списка уроков из файла.";
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
            task4.TaskLogic();
        }
    }
}
