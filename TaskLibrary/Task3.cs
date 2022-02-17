using System;
using System.Diagnostics;


namespace TaskLibrary
{
    public class Task3 : ILessons
    {
        public string NameTask { get; set; }
        public string Description { get; set; }

        public class PointClassDouble
        {
            public double X;
            public double Y;
        }

        public struct PointStructDouble
        {
            public double X;
            public double Y;
        }
        /// <summary>
        /// Расчитывает расстояние между двумя точками типа класс
        /// </summary>
        /// <param name="A">Точка1</param>
        /// <param name="B">Точка2</param>
        /// <returns></returns>
        private double DistanceBothPointClass(PointClassDouble A, PointClassDouble B)
        {
            double y = A.Y - B.Y;
            double x = A.X - B.X;
            float d = (float)((x * x) + (y * y));
            return MathF.Sqrt(d);
        }
        /// <summary>
        /// Расчитывает расстояние между двумя точками типа структура
        /// </summary>
        /// <param name="A">Точка1</param>
        /// <param name="B">Точка2</param>
        private double DistanceBothPointStruct(PointStructDouble A, PointStructDouble B)
        {
            double y = A.Y - B.Y;
            double x = A.X - B.X;
            float d = (float)((x * x) + (y * y));
            return MathF.Sqrt(d);
        }
        /// <summary>
        /// Генерирут массив точек типа класс
        /// </summary>
        /// <param name="number">кол-во</param>
        /// <returns></returns>
        private PointClassDouble[] GeneratePointClass(int number)
        {
            PointClassDouble[] massivPointClass = new PointClassDouble[number];
            Random rnd = new Random();
            for (int i = 0; i < number; i++)
            {
                massivPointClass[i] = new PointClassDouble { X = rnd.NextDouble(), Y = rnd.NextDouble() };
            }
            return massivPointClass;
        }
        /// <summary>
        /// Генерирут массив точек типа структуры
        /// </summary>
        /// <param name="number">кол-во</param>
        /// <returns></returns>
        private PointStructDouble[] GeneratePointStruct(int number)
        {
            PointStructDouble[] massivPointClass = new PointStructDouble[number];
            Random rnd = new Random();
            for (int i = 0; i < number; i++)
            {
                massivPointClass[i].X = rnd.NextDouble();
                massivPointClass[i].Y = rnd.NextDouble();
            }
            return massivPointClass;
        }

        public void StartTask()
        {
            NameTask = "\nЗадание №1:\n";
            Description = @"Создаем 2 типа: 
            * структура PointStructDouble с полями типа double(Double)
            * класс PointClassDouble с полями типа double(Double)
             Создаем метод, возвращающий расстояние между парой точек каждого типа.Реализуем метод, создающий 
             массив точек каждого типа и заполняющий его случайными значениями.Проводим замеры длительности 
             выполнения методов на массивах разного размера.
            Вывод может иметь вид(соответственно x, y - время выполнения, Ratio - отношение времени):
            Количество точек | PointStructDouble | PointClassDouble | Ratio
            100000 | x1 | y1 | y1 / x1
            200000 | x2 | y2 | y2 / x2";

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
            int number = 10000;
            Console.WriteLine("Количество точек | PointStructDouble | PointClassDouble | Ratio ticksStruct/ticksClass");
            for (int i = 1; i < 5; i++) TaskChek(number * i);
        }

        private void TaskChek(int number)
        {
            PointClassDouble[] massivPointClass = GeneratePointClass(number);
            PointStructDouble[] massivPointStruct = GeneratePointStruct(number);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < (massivPointClass.Length - 1); i++) DistanceBothPointClass(massivPointClass[i], massivPointClass[i + 1]);
            sw.Stop();
            long ticksClass = sw.ElapsedTicks;
            sw.Reset();
            sw.Start();
            for (int i = 0; i < (massivPointClass.Length - 1); i++) DistanceBothPointClass(massivPointClass[i], massivPointClass[i + 1]);
            sw.Stop();
            long ticksStruct = sw.ElapsedTicks;
            Console.WriteLine("\t" + number + "\t\t" + ticksStruct + "\t\t" + ticksClass + "\t\t\t" + ((double)ticksStruct / ticksClass));
        }
    }
}
