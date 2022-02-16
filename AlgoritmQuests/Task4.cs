using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmQuests
{
    class Task4 : ILessons
    {
        public string NameTask { get; set; }
        public string Description { get; set; }
        




        public void StartTask()
        {
            NameTask = "\nЗадание №1:\n";
            Description = @"Реализуйте класс двоичного дерева поиска с операциями вставки, 
удаления, поиска. Также напишите метод вывода в консоль дерева, 
чтобы увидеть, насколько корректно работает ваша реализация.";

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
            int sizeTree = 20; //обозначение кол-ва элементов в дереве
            Tree taskLesson4 = new Tree();
            taskLesson4.GreatTree(sizeTree);
            taskLesson4.GetValueTreeNode();  //создаю дерево
            taskLesson4.ShowTree(); //показываю дерево
            


            //демонстрация метода поиска DFS
            int rnd = new Random().Next(0, taskLesson4.ListValueTree.Count);
            Console.WriteLine("\n");
            Console.WriteLine("Поиск значения " + taskLesson4.ListValueTree[rnd] + " по методу DFS:\n");
            Tree.TreeNode taskFind = taskLesson4.FindNodeDFS(taskLesson4.ListValueTree[rnd]);
            if (taskFind != null) Console.WriteLine("\nЗначение найденой записи: " + taskFind.Value + ".\n");
            else
                Console.WriteLine("Значение не найдено.");

            //удалениe записи
            Console.WriteLine("Удаление найденной записи из дерева с потерей всех связей.");
            taskFind.DeleteNode();

            taskLesson4.ShowChangeTree();

            //демонстрация метода поиска BFS
            rnd = new Random().Next(0, taskLesson4.ListValueTree.Count);
            taskFind = taskLesson4.FindNodeBFS(taskLesson4.ListValueTree[rnd]);
            if (taskFind != null) Console.WriteLine("Значение найденой записи: " + taskFind.Value + ".\n");
            else
                Console.WriteLine("Значение не найдено.");
            Console.WriteLine("\n");
            
            Console.WriteLine("Удаление найденной записи из дерева c сохранением ветвей слева.");
            taskFind.DeleteLeftNode();

            taskLesson4.ShowChangeTree();

            //Обновление кол-во элементов и значения в массиве
            taskLesson4.GreatTree(sizeTree);

            taskLesson4.ShowChangeTree();

            //Поиск и удаление рандомной записи по BFS
            rnd = new Random().Next(0, taskLesson4.ListValueTree.Count);
            taskFind = taskLesson4.FindNodeBFS(taskLesson4.ListValueTree[rnd]);
            if (taskFind != null) Console.WriteLine("Значение найденой записи: " + taskFind.Value + ".\n");
            else
                Console.WriteLine("Значение не найдено.");
            Console.WriteLine("\n");
            Console.WriteLine("Удаление найденной записи из дерева c сохранением ветвей справа.");
            taskFind.DeleteRightNode();

            taskLesson4.ShowChangeTree();

            //вставка слева от произвольного элемента
            rnd = new Random().Next(0, taskLesson4.ListValueTree.Count);
            taskFind = taskLesson4.FindNodeBFS(taskLesson4.ListValueTree[rnd]);
            rnd = new Random().Next(1, 999);
            taskFind.InsertNodeLeft(rnd);
            taskLesson4.ListValueTree.Add(rnd);
            Console.WriteLine("Вставляю запись между текущей записью и его левой веткой со значением: " + rnd);
            Console.WriteLine("Нажмите клавишу Enter для продолжения.");
            Console.ReadLine();

            taskLesson4.ShowChangeTree();
        }
        
        


        
    }
}
