using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmQuests
{
    internal class NodeTwoLinks : ILinkedList
    {
        public int Value { get; set; }
        public NodeTwoLinks NextNode { get; set; }
        public NodeTwoLinks PrevNode { get; set; }

        public NodeTwoLinks(int value)
        {
            Value = value;
        }

        /// <summary>
        /// добавляет элемент в конец списка
        /// </summary>
        /// <param name="value"></param>
        public void AddNode(int value) //
        {
            var node = this; //получаю доступ данным startNode

            while (node.NextNode != null) //ищу последнюю запись
            {
                node = node.NextNode;
            }

            var newNode = new NodeTwoLinks(value); //создаю новый Node со значением value
            node.NextNode = newNode; //записываю ссылку на текущую запись в последний найденный node
            newNode.PrevNode = node; // записываю в новый newNode ссылку на предыдущий
            // запись в newNode.NextNode не производится т.к. запись в конец списка
        }

        /// <summary>
        /// операция вставки между двумя Node (двухсвязанные списки)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        public void AddNodeAfter(NodeTwoLinks node, int value) //
        {
            var newNode = new NodeTwoLinks(Value = value); //создаем новый node со значение value
            var nextItem = node.NextNode; // сохраняем ссылку из пердыдущей записи на слудующую
            node.NextNode = newNode; // записываем в значение предыдущей node ссылку на текущую
            var nextNode = node.NextNode; // получаю доступ к следующей Node 
            nextNode.PrevNode = newNode; // записываем в значение следующей Node ссылку на вставляемую
            newNode.NextNode = nextItem; //записываем в текущую Node сохраненную ссылку
            newNode.PrevNode = node; // записываем ссылку на предыдущую Node
        }

        /// <summary>
        /// ищет элемент по его значению
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public NodeTwoLinks FindNode(int searchValue)
        {
            var node = this; //получаю доступ данным 

            do //ищу запись в прямом направлении
            {
                if (node.Value == searchValue) break;
                node = node.NextNode;

            }
            while (node.NextNode != null);
            do   //ищу запись в обратном направлении
            {
                if (node.Value == searchValue) break;
                node = node.PrevNode;
            }
            while (node.PrevNode != null);
            return node;
        }
        /// <summary>
        /// Возвращает кол-во элементов в массиве
        /// </summary>

        public int GetCount()
        {
            var node = this;
            //var node = startNode; //получаю доступ данным startNode
            int i = 1;
            while (node.PrevNode != null) //перехожу к 0 записи
            {
                node = node.PrevNode;
            }
            while (node.NextNode != null) //считаю записи в прямом направлении
            {
                node = node.NextNode;
                i++;
            }
            return i;
        }
        /// <summary>
        /// удаляет элемент по порядковому номеру
        /// </summary>
        /// <param name="index"></param>
        public void RemoveNode(int index)
        {
            var removeNode = this;
            int count = removeNode.GetCount();
            if (count > index)
            {
                while (removeNode.PrevNode != null) //перехожу к 0 записи
                {
                    removeNode = removeNode.PrevNode;
                }
                int i = 0;
                while (removeNode.NextNode != null && (i != index)) //считаю записи
                {
                    removeNode = removeNode.NextNode;
                    i++;
                }
                var nextItem = removeNode.NextNode; // сохраняем ссылку на следующую запись
                var prevItem = removeNode.PrevNode; // сохраняем ссылку на предудующую запись
                prevItem.NextNode = removeNode.NextNode; //заменяю ссылки
                nextItem.PrevNode = removeNode.PrevNode;
            }
            else Console.WriteLine("Элемента с таким индексом не существует");
        }
        /// <summary>
        /// удаляет указанный элемент
        /// </summary>
        public void RemoveNode()
        {
            var removeNode = this;
            if (removeNode.NextNode != null)
            {
                var nextItem = removeNode.NextNode; // сохраняем ссылку на следующую запись
                nextItem.PrevNode = removeNode.PrevNode;
            }
            else //если удаляем последний элемент списка
            {
                var prevItem = removeNode.PrevNode; // сохраняем ссылку на предудующую запись
                prevItem.NextNode = null; //заменяю ссылки
            }
            if (removeNode.PrevNode != null)
            {
                var prevItem = removeNode.PrevNode; // сохраняем ссылку на предудующую запись
                prevItem.NextNode = removeNode.NextNode; //заменяю ссылки
            }
            else //если удаляем первый элемент в списке
            {
                var nextItem = removeNode.NextNode; // сохраняем ссылку на следующую запись
                nextItem.PrevNode = null;
            }
        }
        public void ShowNodes()
        {
            NodeTwoLinks node = this;
            int count = node.GetCount();

            while (node.PrevNode != null) //перехожу к 0 записи
            {
                node = node.PrevNode;
            }
            Console.WriteLine("Значения списка");
            do
            {
                Console.Write(node.Value + "\t");
                node = node.NextNode;
            }
            while (node.NextNode != null);
            Console.Write(node.Value + "\t");

            Console.WriteLine("Кол-во элементов в списке - " + count);
        }

        public void ShowNum()
        {
            var node = this;
            Console.Write("Номерация списка значений\n");
            while (node.PrevNode != null) //перехожу к 0 записи
            {
                node = node.PrevNode;
            }
            Console.Write("№1 ");
            int i = 1;
            while (node.NextNode != null) //считаю записи
            {
                node = node.NextNode;
                i++;
                Console.Write("\t" + i + "  ");
            }
            Console.WriteLine("\n");
        }
    }
}
