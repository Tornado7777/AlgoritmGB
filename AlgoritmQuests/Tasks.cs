using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmQuests
{
    class Tasks
    {
        public int NumberTasks { get; set; }
        public string[,] ArrayLessons { get; set; }

        /// <summary>
        /// Метод показа содержания заданий
        /// </summary>

        public Tasks(int numberTasks)
        {
            NumberTasks = numberTasks;
            ArrayLessons = new string[numberTasks, 2];
            ArrayLessons[0, 0] = "Номер задания\n";
            ArrayLessons[0, 1] = "Содержание";

        }
        public int ShowTask()
        {
            Tasks task = this;
            int N = 0; //ввыеденый номер задачи
            Console.Clear();
            for (int i = 0; i < (task.ArrayLessons.Length / 2); i++)
            {
                Console.WriteLine("\n" + ArrayLessons[i, 0]);
                Console.WriteLine(ArrayLessons[i, 1]);
            }
            Console.WriteLine("\nВведите номер интересующего задания и нажмите Enter: ");
            bool successChange = int.TryParse(Console.ReadLine(), out N);
            if (successChange & (N > 0) & (N <= ((task.ArrayLessons.Length / 2) - 1)))
            {
                return N;
            }
            else
            {
                Console.WriteLine("Задания с таким номером не найден");
            }
            return N;
        }
        /// <summary>
        /// Добавляет задачу в конец списка
        /// </summary>
        /// <param name="numTask">Например: "Здание №1"</param>
        /// <param name="Description">Описание задания</param>
        /// <returns></returns>
        public Tasks AddTask(string nameTask, string description)
        {
            var currentTask = this;
            var newTasks = new Tasks(currentTask.NumberTasks + 1);
            for (int i = 1; i < currentTask.NumberTasks; i++)
            {
                newTasks.ArrayLessons[i, 0] = currentTask.ArrayLessons[i, 0];
                newTasks.ArrayLessons[i, 1] = currentTask.ArrayLessons[i, 1];
            }
            newTasks.ArrayLessons[currentTask.NumberTasks, 0] = nameTask;
            newTasks.ArrayLessons[currentTask.NumberTasks, 1] = description;

            return newTasks;
        }

        public Tasks ChangeTask(int numTask, string nameTask, string description)
        {
            var currentTask = this;
            currentTask.ArrayLessons[numTask, 0] = nameTask;
            currentTask.ArrayLessons[numTask, 0] = description;
            return currentTask;
        }
    }
}
