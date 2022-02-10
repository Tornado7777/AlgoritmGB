using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmQuests
{
    internal interface ILinkedList
    {
        int Value { get;  set; } //нельзя изменить список снаружи
        NodeTwoLinks NextNode { get; set; }
        NodeTwoLinks PrevNode { get; set; }
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка в конец списка
        void AddNodeAfter(NodeTwoLinks node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(); // удаляет указанный элемент
        NodeTwoLinks FindNode(int searchValue); // ищет элемент по его значению
    }
}
