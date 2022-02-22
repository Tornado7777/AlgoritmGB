using System;
using System.Collections.Generic;

namespace TaskLibrary
{
    class Tree
    {
        public TreeNode FirstNodeTree { get; set; } //ссылка на первое значение в дереве
        public List<int> ListValueTree { get; set; } //массив значение, для выбора значение поиска
        public class TreeNode
        {
            public int Value { get; set; }
            public TreeNode Parrent { get; set; }
            public TreeNode LeftChild { get; set; }
            public TreeNode RightChild { get; set; }
            //все методы вставки, удаления отнес к методам работы с элементом дерева
            /// <summary>
            /// Вставляет запись между текущей записью и его левой веткой
            /// </summary>
            public void InsertNodeLeft(int value)
            {
                var newNodeLeft = new TreeNode();
                if (this.LeftChild != null) this.LeftChild.Parrent = newNodeLeft;
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
                if (parrentNode != null & parrentNode.LeftChild == this)
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

        }


        public void GetValueTreeNode()
        {
            TreeNode firstNode = this.FirstNodeTree;
            this.ListValueTree = new List<int>(0);
            List<int> listValue = new List<int>(0);
            List<Tree.TreeNode> listLevel = new List<Tree.TreeNode>(0);
            List<Tree.TreeNode> listNextLevel = new List<Tree.TreeNode>(0);
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
            if (this.ListValueTree.Count > 0) this.ListValueTree.Clear();
            this.ListValueTree.AddRange(listValue);
        }


        /// <summary>
        /// Поиск записи по значению метод DFS.
        /// Возвращает null если значение не найдено;
        /// Отображает значения: родителя(справа или слева), свое значение 
        /// и значение ближайщих ветвей при наличии(при отсутствии пишет null)/
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TreeNode FindNodeDFS(int value, int level = 1, TreeNode findNode = null, TreeNode currentNode = null)
        {
            if (currentNode == null) currentNode = this.FirstNodeTree;

            if (currentNode.Value == value)
            {
                findNode = currentNode;
                WriteFinde(currentNode, level);
            }
            else
            {
                Console.Write(currentNode.Value + "=>");
                if (currentNode.LeftChild != null) findNode = FindNodeDFS(value, level + 1, findNode, currentNode.LeftChild);
                if (currentNode.RightChild != null) findNode = FindNodeDFS(value, level + 1, findNode, currentNode.RightChild);
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
        public TreeNode FindNodeBFS(int value)
        {
            int level = 1;
            TreeNode findNode = null;
            List<TreeNode> listLevel = new List<TreeNode>(0);
            List<TreeNode> listNextLevel = new List<TreeNode>(0);
            if (level == 1) //работаю с первым элементом в дереве
            {
                TreeNode currentNode = this.FirstNodeTree;
                Console.WriteLine("\n");
                Console.WriteLine("Осуществялем поиск значения " + value + " методом BFS.\n");
                if (currentNode.Value == value)
                {
                    findNode = currentNode;
                    WriteFinde(currentNode, level);
                }
                else
                {
                    Console.Write(currentNode.Value + "=>");
                    listLevel.Add(currentNode.LeftChild);
                    listLevel.Add(currentNode.RightChild);
                    level++;
                }
            }
            //перебераю массив
            while (listLevel.Count > 0)
            {
                listNextLevel.Clear();
                for (int i = 0; i < listLevel.Count; i++)
                {
                    if (listLevel[i].Value == value)
                    {
                        findNode = listLevel[i];
                        WriteFinde(listLevel[i], level);
                        listLevel.Clear();
                        listNextLevel.Clear();
                        break;
                    }
                    else
                    {
                        Console.Write(listLevel[i].Value + "=>");
                        if (listLevel[i].LeftChild != null) listNextLevel.Add(listLevel[i].LeftChild);
                        if (listLevel[i].RightChild != null) listNextLevel.Add(listLevel[i].RightChild);
                    }
                }
                listLevel.Clear();
                listLevel.AddRange(listNextLevel);
                level++;
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
            TreeNode firstNode = this.FirstNodeTree; //нахожу первый элемент
            Console.Clear();
            int level = this.ShowTreeConsole(1, 0, firstNode);
            Console.SetCursorPosition(0, level * 4 + 8);
            Console.WriteLine("Отображаю список значений: \n");
            for (int i = 0; i < this.ListValueTree.Count; i++)
            {
                Console.Write(this.ListValueTree[i] + "\t");
                if (i + 1 % 10 == 0) Console.WriteLine("\n");

            }
        }

        /// <summary>
        /// </summary>
        /// <param name="level"></param>
        /// <param name="numInLevel"></param>
        /// <param name="node"></param>

        private int ShowTreeConsole(int level, int numInLevel, TreeNode node)
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
            level++;
            if (nodeLeft != null) ShowTreeConsole(level, numInLevelLeft, nodeLeft);
            TreeNode nodeRight = new TreeNode();
            nodeRight = node.RightChild;
            int numInLevelRight = GetNumInLevel(numInLevel, false);
            if (nodeRight != null) ShowTreeConsole(level, numInLevelRight, nodeRight);
            return level;
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

        public void GreatTree(int n)
        {
            if (n == 0)
                Console.WriteLine("Ничего не созданно");
            else
            {
                TreeNode firstNode = new TreeNode();
                this.FirstNodeTree = firstNode;
                var nl = n / 2;
                var nr = n - nl - 1;
                firstNode.Value = new Random().Next(1, 999);
                firstNode.LeftChild = GreatTreeParrent(nl, firstNode);
                firstNode.RightChild = GreatTreeParrent(nr, firstNode);
            }
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
                newNode.LeftChild = GreatTreeParrent(nl, newNode);
                newNode.RightChild = GreatTreeParrent(nr, newNode);

            }
            return newNode;
        }

        public void ShowChangeTree()
        {
            this.GetValueTreeNode();
            Console.WriteLine("Нажмите клавишу Enter для продолжения.");
            Console.ReadLine();
            this.ShowTree();
        }

    }
}
