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
        public void AddNode(int value) //добавляет элемент в конец списка
        {
            var node = this; //получаю доступ данным startNode

            while (node.NextNode != null) //ищу последнюю запись
            {
                node = node.NextNode;
            }

            var newNode = new NodeTwoLinks(value); //создаю новый Node со значением value
            node.NextNode = newNode; //записываю ссылку на текущую запись в последний найденный node
            newNode.PrevNode = node; // записываю в новый newNode ссылку на предыдущий
        }

        public void AddNodeAfter(NodeTwoLinks node, int value) //операция вставки между двумя Node (двухсвязанные списки)
        {
            var newNode = new NodeTwoLinks (Value = value); //создаем новый node со значение value
            var nextItem = node.NextNode; // сохраняем ссылку из пердыдущей записи на слудующую
            node.NextNode = newNode; // записываем в значение предыдущей node ссылку на текущую
            var nextNode = node.NextNode; // получаю доступ к следующей Node 
            nextNode.PrevNode = newNode; // записываем в значение следующей Node ссылку на вставляемую
            newNode.NextNode = nextItem; //записываем в текущую Node сохраненную ссылку
            newNode.PrevNode = node; // записываем ссылку на предыдущую Node
        }

        public NodeTwoLinks FindNode(int searchValue)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Возвращает кол-во элементов в массиве
        /// </summary>
        /// <param name="startNode"></param>
        /// <returns></returns>
        public int GetCount()
        {
            var node = this;
            //var node = startNode; //получаю доступ данным startNode
            int i = 1;
            int j = 0;
            while (node.NextNode != null) //считаю записи
            {
                node = node.NextNode;
                i++;
            }
            node = this;
            while (node.PrevNode != null) //считаю записи
            {
                node = node.PrevNode;
                j++;
            }
            return i +j;
        }

        public void RemoveNode(int index)
        {
            throw new NotImplementedException();
        }

        public void RemoveNode(NodeTwoLinks node)
        {
            throw new NotImplementedException();
        }
    }
}
