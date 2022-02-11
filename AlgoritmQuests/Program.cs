using System;


namespace AlgoritmQuests
{
    class Program
    {
        static void Lessons()
        {
            Tasks lessons = new Tasks(1);
            //изменение шапки для отбражения уроков
            lessons = lessons.ChangeTask(0, "Номер урока", "Краткое содержание");
            //Урок 1
            lessons = lessons.AddTask("Урок №1", "Блок-схемы, асимптотическая сложность, рекурсия.");
            //Урок 2
            lessons = lessons.AddTask("Урок №2", "Массив, список, поиск.");
            //Урок 3
            lessons = lessons.AddTask("Урок №3", "Класс, структура и дистанция.");
            //Урок 4
            lessons = lessons.AddTask("Урок №4", "Деревья, хэш-таблицы.");
            int numLesson = lessons.ShowTask(); //вывожу на экран уроки и получаю номер выбранного урока

            switch (numLesson)
            {
                case 1:
                    {

                        Task1 lesson1 = new Task1();
                        lesson1.ShowTask();
                        break;
                    }
                case 2:
                    {

                        Task2 lesson2 = new Task2();
                        lesson2.ShowTask();
                        break;
                    }
                case 3:
                    {

                        Task3 lesson3 = new Task3();
                        lesson3.StartTask();
                        break;
                    }
                case 4:
                    {

                        Task4 lesson4 = new Task4();
                        lesson4.StartTask();
                        break;
                    }
            }

        }
        static void Main(string[] args)
        {
            Lessons();
        }
    }
}
