using System;


namespace AlgoritmQuests
{
    class Program
    {
        static void Lessons()
        {
            int numberLesson = 3; //кол-во опубликованных уроков
            string[,] ArrayLessons = new string[numberLesson+1,numberLesson+1];
            //Шапка для отбражения уроков
            ArrayLessons[0, 0] = "Номер урока";
            ArrayLessons[0, 1] = "Краткое содержание";
            //Урок 1
            ArrayLessons[1, 0] = "Урок №1";
            ArrayLessons[1, 1] = "Блок-схемы, асимптотическая сложность, рекурсия.";
            //Урок 2
            ArrayLessons[2, 0] = "Урок №2";
            ArrayLessons[2, 1] = "Массив, список, поиск.";
            //Урок 3
            ArrayLessons[3, 0] = "Урок №3";
            ArrayLessons[3, 1] = "Класс, структура и дистанция.";
            for (int i=0; i<=numberLesson; i++)
            {
                Console.WriteLine(ArrayLessons[i, 0] + "       " + ArrayLessons[i, 1] +"\n");
            }
            Console.WriteLine("Введите номер интересующего урока и нажмите Enter: ");
            bool successChange = int.TryParse(Console.ReadLine(), out int N);
            if (successChange & (N > 0))
            {
               switch(N)
                {
                    case 1 :
                        {
                            
                            Task1 taskNum1 = new Task1();
                            taskNum1.ShowTask();
                            break;
                        }
                    case 2:
                        {

                            Task2 taskNum2 = new Task2();
                            taskNum2.ShowTask();
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("Урок с таким номером не найден");
            }

        }
        static void Main(string[] args)
        {
            Lessons();
        }
    }
}
