using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmQuests
{
    class Task4 : ILessons
    {

        public class TreeNode
        {
            public int Value { get; set; }
            public TreeNode Parrent { get; set; }
            public TreeNode LeftChild { get; set; }
            public TreeNode RightChild { get; set; }


            List<int> listValue = new List<int>(0); //создаю массив значение, для выбора значение поиска
            /// <summary>
            /// Вставляет запись между текущей записью и его левой веткой
            /// </summary>
            public void InsertNodeLeft(int value)
            {
                var newNodeLeft = new TreeNode();
                if(this.LeftChild != null)this.LeftChild.Parrent = newNodeLeft;
                newNodeLeft.LeftChild = this.LeftChild;
                this.LeftChild = newNodeLeft;
                newNodeLeft.Parrent = this;
                newNodeLeft.Value = value;

            }
            /// <summary>
            /// Вставляет запись между текущей записью и его правой веткой
            /// </summary>
            public void AddNodeRight(int value)
            {
                var newNodeRight = new TreeNode();
                if (this.RightChild != null) this.RightChild.Parrent = newNodeRight;
                newNodeRight.RightChild = this.RightChild;
                this.RightChild = newNodeRight;
                newNodeRight.Parrent = this;
                newNodeRight.Value = value;
            }

            /// <summary>
            /// Удаление текущей записи с удалением всех привязок к нему
            /// </summary>
            public void DeleteNode()
            {
                var parrentNode = this.Parrent;
                var rightNode = this.RightChild;
                var leftNode = this.LeftChild;
                if (parrentNode.LeftChild == this && parrentNode != null)
                {
                    parrentNode.LeftChild = null;
                }
                else
                {
                    parrentNode.RightChild = null;
                }
                if (rightNode != null) rightNode.Parrent = null;
                if (leftNode != null) leftNode.Parrent = null;
                this.Value = 0;
                this.RightChild = null;
                this.LeftChild = null;
            }

            /// <summary>
            /// Удаление текущей записи сохранением ветвей слева
            /// </summary>
            public void DeleteLeftNode()
            {
                var parrentNode = this.Parrent;
                var rightNode = this.RightChild;
                var leftNode = this.LeftChild;
                if (parrentNode != null)
                {
                    if (parrentNode.LeftChild == this)
                    {
                        parrentNode.LeftChild = leftNode;
                    }
                    else
                    {
                        parrentNode.RightChild = leftNode;
                    }
                }
                if (rightNode != null) rightNode.Parrent = null;
                if (leftNode != null) leftNode.Parrent = parrentNode;
                this.Value = 0;
                this.RightChild = null;
                this.LeftChild = null;
            }

            /// <summary>
            /// Удаление текущей записи с сохранением ветвей справа
            /// </summary>
            public void DeleteRightNode()
            {
                var parrentNode = this.Parrent;
                var rightNode = this.RightChild;
                var leftNode = this.LeftChild;
                if (parrentNode != null)
                {
                    if (parrentNode.LeftChild == this)
                    {
                        parrentNode.LeftChild = rightNode;
                    }
                    else
                    {
                        parrentNode.RightChild = rightNode;
                    }
                }
                if (rightNode != null) rightNode.Parrent = parrentNode;
                if (leftNode != null) leftNode.Parrent = null;
                this.Value = 0;
                this.RightChild = null;
                this.LeftChild = null;
            }


            /// <summary>
            /// Поиск записи по значению метод DFS.
            /// Возвращает null если значение не найдено;
            /// Отображает значения: родителя(справа или слева), свое значение 
            /// и значение ближайщих ветвей при наличии(при отсутствии пишет null)/
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public TreeNode FindNodeDFS(int value, int level = 1, TreeNode findNode = null) 
            {
                Console.Write(this.Value + "=>");
                if (this.Value == value)
                {
                    findNode = this;
                    WriteFinde(this, level);
                }
                else
                {
                    if (this.LeftChild != null) findNode = this.LeftChild.FindNodeDFS(value, level + 1, findNode);
                    if (this.RightChild != null) findNode = this.RightChild.FindNodeDFS(value, level + 1, findNode);
                }
                return findNode;
            }

            /// <summary>
            /// Поиск записи по значению метод BFS.
            /// Возвращает null если значение не найдено;
            /// Отображает значения: родителя(справа или слева), свое значение 
            /// и значение ближайщих ветвей при наличии(при отсутствии пишет null)
            /// </summary>
            /// <param name="value">значение для поиска</param>
            /// <returns></returns>
            public TreeNode FindNodeBFS(int value, List<TreeNode> listLevel = null, int level = 1, TreeNode findNode = null)
            {
                List<TreeNode> listNextLevel = new List<TreeNode>(0);
                if (level == 1 && listLevel == null) //работаю с первым элементом в дереве
                {
                    TreeNode currentNode = this.GetFirstNode();
                    Console.WriteLine("\n");
                    if (currentNode.Value == value)
                    {
                        findNode = currentNode;
                        WriteFinde(currentNode, level);
                    }
                    else
                    {
                        Console.WriteLine("Осуществялем поиск значения " + value + " методом BFS.\n");
                        Console.Write(currentNode.Value + "=>");
                        listNextLevel.Add(currentNode.LeftChild);
                        listNextLevel.Add(currentNode.RightChild);
                        findNode = FindNodeBFS(value, listNextLevel, level + 1, findNode);
                    }
                }
                else
                {
                    //перебераю массив
                    Console.WriteLine("\n");
                    bool find = false;
                    for (int i = 0; i < listLevel.Count; i++)
                    {
                        if (listLevel[i] != null)
                        {
                            if (listLevel[i].Value == value)
                            {
                                findNode = listLevel[i];
                                WriteFinde(listLevel[i], level);
                                find = true;
                                i = listLevel.Count;
                                break;
                            }
                            else 
                            {
                                Console.Write(listLevel[i].Value + "=>");
                                listNextLevel.Add(listLevel[i].LeftChild);
                                listNextLevel.Add(listLevel[i].RightChild);
                            }
                            
                        }
                    }
                    if (find == false && listLevel.Count>0) findNode = FindNodeBFS(value, listNextLevel, level + 1, findNode);
                }
                return findNode;
            }
            private void WriteFinde(TreeNode node, int level)
            {
                TreeNode parrentNode = node.Parrent;
                if (parrentNode != null)
                {
                    if (parrentNode.LeftChild == node) Console.WriteLine("\n|| \t | \t | " + parrentNode.Value); else Console.WriteLine("\n|| " + parrentNode.Value);
                }
                else
                {
                    Console.WriteLine("\t || null ||");
                }
                Console.WriteLine("\t || " + node.Value + "|| Level = " + level);
                if (node.LeftChild != null) Console.Write("|| " + node.LeftChild.Value + " |"); else Console.Write("|| null | ");
                if (node.RightChild != null) Console.Write(" \t |  " + node.RightChild.Value + " ||\n"); else Console.Write("\t| null || \n");
            }

            /// <summary>
            /// метод отображения дерева
            /// </summary>
            public void ShowTree()
            {
                TreeNode firstNode = this.GetFirstNode(); //нахожу первый элемент
                Console.Clear();
                firstNode.ShowTreeConsole(1, 0, firstNode);
                Console.WriteLine("\n");
            }

            private void ShowTreeConsole(int level, int numInLevel, TreeNode node)
            {
                int cursorYPosition = level * 2;
                int cursorXPosithon = (int)(Console.WindowWidth * ((double)(1 + numInLevel * 2) / (Math.Pow(2, level)))) - 1;
                Console.SetCursorPosition(cursorXPosithon, cursorYPosition);
                Console.Write(node.Value);
                Console.SetCursorPosition(0, cursorYPosition + 1);
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write("*");
                }
                TreeNode nodeLeft = new TreeNode();
                nodeLeft = node.LeftChild;
                int numInLevelLeft = GetNumInLevel(numInLevel, true);
                if (nodeLeft != null) ShowTreeConsole(level + 1, numInLevelLeft, nodeLeft);
                TreeNode nodeRight = new TreeNode();
                nodeRight = node.RightChild;
                int numInLevelRight = GetNumInLevel(numInLevel, false);
                if (nodeRight != null) ShowTreeConsole(level + 1, numInLevelRight, nodeRight);

            }
            /// <summary>
            /// Метод возвращает порядковый номер элемента на уровне
            /// </summary>
            /// <param name="parrentNum">Порядковый номер родителя</param>
            /// <param name="left">Слева элемент, значит true, иначе  false</param>
            /// <returns></returns>
            private int GetNumInLevel(int parrentNum, bool left)
            {
                int number = 0;
                if (left) number = parrentNum * 2; else number = parrentNum * 2 + 1;
                return number;
            }



            /// <summary>
            /// метод создания сбалансированного дерева с заданным кол-вом элементов
            /// и произвольными значениями типа int
            /// </summary>
            /// <param name="n">кол-во элементов</param>
            
            public List<int> GreatTree(int n)
            {
                listValue.Clear();
                if (n == 0)
                    Console.WriteLine("Ничего не созданно");
                else
                {
                    var nl = n / 2;
                    var nr = n - nl - 1;
                    this.Value = new Random().Next(1, 999);
                    listValue.Add(this.Value);
                    this.LeftChild = GreatTreeParrent(nl, this);
                    this.RightChild = GreatTreeParrent(nr, this);

                }
                return listValue;
            }
            //создает элементы с родителем
            private TreeNode GreatTreeParrent(int n, TreeNode parrent)
            {
                TreeNode newNode = new TreeNode();
                if (n == 0)
                    return null;
                else
                {
                    var nl = n / 2;
                    var nr = n - nl - 1;
                    newNode.Value = new Random().Next(1, 999);
                    newNode.Parrent = parrent;
                    listValue.Add(newNode.Value);
                    newNode.LeftChild = GreatTreeParrent(nl, newNode);
                    newNode.RightChild = GreatTreeParrent(nr, newNode);

                }
                return newNode;
            }

            /// <summary>
            /// Метод получения ссылки на первый элемент в дереве
            /// </summary>
            /// <returns></returns>
            private TreeNode GetFirstNode()
            {
                var currentNode = this;
                //ищу самый первый элемент дерева
                if (currentNode.Parrent == null)
                {

                }
                else
                {
                    while (currentNode.Parrent != null)
                        currentNode = currentNode.Parrent;
                }
                return currentNode;

            }
        }





        public void StartTask()
        {
            Tasks task4 = new Tasks(1);
            task4 = task4.AddTask("\nЗадание №1:\n", @"Реализуйте класс двоичного дерева поиска с операциями вставки, 
удаления, поиска. Также напишите метод вывода в консоль дерева, 
чтобы увидеть, насколько корректно работает ваша реализация.");
            int numTask = task4.ShowTask();
            switch (numTask)
            {
                case 1:
                    {

                        TaskLogic();
                        break;
                    }

            }
        }


        public void TaskLogic()
        {
            int sizeTree = 20; //обозначение кол-ва элементов в дереве
            TreeNode taskLesson4 = new TreeNode(); 
            List<int> listValue = taskLesson4.GreatTree(sizeTree); //создаю дерево

            taskLesson4.ShowTree(); //показываю дерево
            ShowListValue(listValue);
            

            //демонстрация метода поиска DFS
            int rnd = new Random().Next(0, listValue.Count);
            Console.WriteLine("\n");
            Console.WriteLine("Поиск значения " + listValue[rnd] + " по методу DFS:\n");
            TreeNode taskFind = taskLesson4.FindNodeDFS(listValue[rnd]);
            if (taskFind != null) Console.WriteLine("\nЗначение найденой записи: " + taskFind.Value + ".\n"); else
                Console.WriteLine("Значение не найдено.");
            //удалениe записи
            Console.WriteLine("Удаление найденной записи из дерева с потерей всех связей.");
            taskFind.DeleteNode();
            listValue.Clear();
            listValue = ValueTreeNode(taskLesson4);
            Console.WriteLine("Нажмите клавишу Enter для продолжения.");
            Console.ReadLine();
            taskLesson4.ShowTree();
            ShowListValue(listValue);

            //демонстрация метода поиска BFS
            rnd = new Random().Next(0, listValue.Count);
            taskFind = taskLesson4.FindNodeBFS(listValue[rnd]);
            if (taskFind != null) Console.WriteLine("Значение найденой записи: " + taskFind.Value + ".\n"); else
                Console.WriteLine("Значение не найдено.");
            Console.WriteLine("\n");
            //
            Console.WriteLine("Удаление найденной записи из дерева c сохранением ветвей слева.");
            taskFind.DeleteLeftNode();
            listValue.Clear();
            listValue = ValueTreeNode(taskLesson4);
            Console.WriteLine("Нажмите клавишу Enter для продолжения.");
            Console.ReadLine();
            taskLesson4.ShowTree();
            ShowListValue(listValue);

            //Обновление кол-во элементов и значения в массиве
            listValue.Clear();
            listValue = taskLesson4.GreatTree(sizeTree);
            Console.WriteLine("Нажмите клавишу Enter для продолжения.");
            Console.ReadLine();
            taskLesson4.ShowTree();
            ShowListValue(listValue);

            //Поиск и удаление рандомной записи по BFS
            rnd = new Random().Next(0, listValue.Count);
            taskFind = taskLesson4.FindNodeBFS(listValue[rnd]);
            if (taskFind != null) Console.WriteLine("Значение найденой записи: " + taskFind.Value + ".\n");
            else
                Console.WriteLine("Значение не найдено.");
            Console.WriteLine("\n");
            Console.WriteLine("Удаление найденной записи из дерева c сохранением ветвей справа.");
            taskFind.DeleteRightNode();
            listValue.Clear();
            listValue = ValueTreeNode(taskLesson4);
            Console.WriteLine("Нажмите клавишу Enter для продолжения.");
            Console.ReadLine();
            taskLesson4.ShowTree();
            ShowListValue(listValue);

            //вставка слева от произвольного элемента
            rnd = new Random().Next(0, listValue.Count);
            taskFind = taskLesson4.FindNodeBFS(listValue[rnd]);
            rnd = new Random().Next(1, 999);
            taskFind.InsertNodeLeft(rnd);
            listValue.Add(rnd);
            Console.WriteLine("Вставляю запись между текущей записью и его левой веткой со значением: " + rnd);
            Console.WriteLine("Нажмите клавишу Enter для продолжения.");
            Console.ReadLine();
            taskLesson4.ShowTree();
            ShowListValue(listValue);
            Console.WriteLine("\n");
            Console.WriteLine("Нажмите клавишу Enter для продолжения.");
            Console.ReadLine();
        }

        /// <summary>
        /// Обходит дерево начиная с 0 элемента и записывает значения в список
        /// </summary>
        /// <param name="firstNode">Ссылка на первый элемент дерева</param>
        /// <returns></returns>
        private List<int> ValueTreeNode(TreeNode firstNode)
        {
            List<int> listValue = new List<int>(0);
            List<TreeNode> listLevel = new List<TreeNode>(0);
            List<TreeNode> listNextLevel = new List<TreeNode>(0);
            listValue.Add(firstNode.Value);
            if (firstNode.LeftChild != null)
            {
                listLevel.Add(firstNode.LeftChild);
                listValue.Add(firstNode.LeftChild.Value);
            }
            if (firstNode.RightChild != null)
            {
                listLevel.Add(firstNode.RightChild);
                listValue.Add(firstNode.RightChild.Value);
            }
            while (listLevel.Count > 0)
            {
                listNextLevel.Clear();
                for (int i = 0; i < listLevel.Count; i++)
                {
                    if (listLevel[i].LeftChild != null) listNextLevel.Add(listLevel[i].LeftChild);
                    if (listLevel[i].RightChild != null) listNextLevel.Add(listLevel[i].RightChild);
                }
                for (int i = 0; i < listNextLevel.Count; i++) listValue.Add(listNextLevel[i].Value);
                listLevel.Clear();
                listLevel.AddRange(listNextLevel);
            }
            return listValue;
        }

        private void ShowListValue(List<int> listValue)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Отображаю список значений: \n");
            for (int i = 0; i < listValue.Count; i++)
            {
                Console.Write(listValue[i] + "\t");
                if (i%10 == 0) Console.WriteLine("\n");
                
            }
        }
    }
}
