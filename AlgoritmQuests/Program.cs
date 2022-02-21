using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
//using TaskLibrary;

namespace AlgoritmQuests
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string longName = @"dll\TaskLibrary.dll"; 
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), longName);
            Assembly assem = Assembly.LoadFrom(path);
            string input = "";
            Type Lessons = assem.GetType("TaskLibrary.Lessons");
            object obj = Activator.CreateInstance(Lessons);
            MethodInfo stratTask1 = Lessons.GetMethod("startLessons");
            object result = new object();
            do
            {
                Console.WriteLine("Для завершения введите exit \n");
                result = stratTask1.Invoke(obj, new object[0]);
                input = result.ToString();
                Console.WriteLine("Урок №7");
                Console.WriteLine("Динамическое программирование.");
                Console.WriteLine("Для продолжение нажмите Enter или 7 и Enter \n");
                if (input != "7" && input != "exit") input = Console.ReadLine();
                if (input == "7")
                {
                    Task7 task7 = new Task7();
                    task7.StartTask();
                }
                if (input != "exit")
                {
                    Console.Clear();
                }
                
            }
            while (input != "exit") ;

        }
    }
}
