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
