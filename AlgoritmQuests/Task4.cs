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

            /// <summary>
            /// Добавляет запись слева в дерево к текущей записи
            /// </summary>
            private void AddNodeLeft(int value)
            {
                var newNodeLeft = new TreeNode();
                this.LeftChild = newNodeLeft;
                newNodeLeft.Parrent = this;
                newNodeLeft.Value = value;
            }
            /// <summary>
            /// Добавляет запись справа в дерево к текущей записи
            /// </summary>
            private void AddNodeRight(int value)
            {
                var newNodeRight = new TreeNode();
                this.RightChild = newNodeRight;
                newNodeRight.Parrent = this;
                newNodeRight.Value = value;
            }

            /// <summary>
            /// Удаление текущей записи с удалением всех привязок к нему
            /// </summary>
            private void DeleteNode()
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
            private void DeleteLeftNode()
            {
                var parrentNode = this.Parrent;
                var rightNode = this.RightChild;
                var leftNode = this.LeftChild;
                if (parrentNode.LeftChild == this && parrentNode != null)
                {
                    parrentNode.LeftChild = leftNode;
                }
                else
                {
                    parrentNode.RightChild = leftNode;
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
            private void DeleteRightNode()
            {
                var parrentNode = this.Parrent;
                var rightNode = this.RightChild;
                var leftNode = this.LeftChild;
                if (parrentNode.LeftChild == this && parrentNode != null)
                {
                    parrentNode.LeftChild = rightNode;
                }
                else
                {
                    parrentNode.RightChild = rightNode;
                }
                if (rightNode != null) rightNode.Parrent = parrentNode;
                if (leftNode != null) leftNode.Parrent = null;
                this.Value = 0;
                this.RightChild = null;
                this.LeftChild = null;
            }


            /// <summary>
            /// Поиск записи по значению
            /// Возвращает уровень на котором находится элемент и значение родителя
            /// Отображает значения: родителя(справа или слева), свое значение 
            /// и значение ближайщих ветвей при наличии(при отсутствии пишет null)
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public (int, int) FindNode(int value)
            {
                var currentNode = this;
                int level = 1;
                int valueParent = 0;
                return (level, valueParent);
            }

            /// <summary>
            /// метод отображения дерева
            /// </summary>
            public void ShowTree()
            {
                TreeNode firstNode = this.FindFirstNode(); //нахожу первый элемент
                NodeInfo nodeInfo = new NodeInfo();
                nodeInfo.Level = 1;
                nodeInfo.Node = firstNode;
                nodeInfo.NumInLevel = 0;
                TreeNode currentNode = firstNode;
                
                Console.Clear();
                while (nodeInfo.Node != null)
                {
                    
                    nodeInfo.ShowTreeConsole(nodeInfo);
                }

            }
            
            public class NodeInfo
            {
                public int Level { get; set; }
                public int NumInLevel { get; set; }
                public TreeNode Node { get; set; }
                public void ShowTreeConsole(NodeInfo nodeInfo)
                {
                    int cursorXPosithon = (Console.WindowWidth * (1 + nodeInfo.NumInLevel) / (2 * nodeInfo.Level)) - 1;
                    int cursorYPosition = nodeInfo.Level;
                    Console.SetCursorPosition(cursorXPosithon, cursorYPosition);
                    Console.Write(nodeInfo.Node.Value);
                    NodeInfo nodeInfoLeft = new NodeInfo();
                    nodeInfoLeft.Node = nodeInfo.Node.LeftChild;
                    nodeInfoLeft.NumInLevel = 0;
                    if (nodeInfoLeft.Node != null) ShowTreeConsole(nodeInfoLeft);
                    NodeInfo nodeInfoRight = new NodeInfo();
                    nodeInfoRight.Node = nodeInfo.Node.RightChild;
                    nodeInfoRight.NumInLevel = 1;
                    if (nodeInfoRight.Node != null) ShowTreeConsole(nodeInfoRight);

                }
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
                    var nl = n / 2;
                    var nr = n - nl - 1;
                    this.Value = new Random().Next(0, 1000);
                    this.LeftChild = GreatTreeParrent(nl, this);
                    this.RightChild = GreatTreeParrent(nr, this);

                }

            }
            //создает элементы с родителем
            private TreeNode GreatTreeParrent(int n, TreeNode parrent)
            {
                TreeNode newNode = null;
                if (n == 0)
                    return null;
                else
                {
                    var nl = n / 2;
                    var nr = n - nl - 1;
                    newNode = new TreeNode();
                    newNode.Value = new Random().Next(0, 1000);
                    newNode.Parrent = parrent;
                    newNode.LeftChild = GreatTreeParrent(nl, newNode);
                    newNode.RightChild = GreatTreeParrent(nr, newNode);

                }
                return newNode;
            }

            private TreeNode FindFirstNode()
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
            TreeNode TaskLesson4 = new TreeNode();
            TaskLesson4.GreatTree(20);
            TaskLesson4.ShowTree();
        }
    }
}
