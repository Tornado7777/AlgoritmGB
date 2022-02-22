using System;


namespace TaskLibrary
{
    public class Task2 : ILessons
    {
        public string NameTask { get; set; }
        public string Description { get; set; }

        //Выполняем только задание 1 - реализация типа двусвязного списка. 
        //И контрольный пример, демонстрирующий использование методов.
        //Интерактивный режим (взаимодействие с пользователем) не требуется.

        public void StartTask()
        {
            NameTask = "\nЗадание №1:\n";
            Description = "Требуется реализовать класс двусвязного списка и операции вставки, \nудаления и поиска элемента в нём в соответствии с интерфейсом.";
            Console.Clear(); //очищаем консоль
            ShowTask();
            TaskLogic();
        }

        public void TaskLogic()
        {
            int countNewNode = 10; // указываю кол-во элементов в массиве
            var masNode = new NodeTwoLinks[countNewNode]; //создаю массив Node
            Random rnd = new Random();                   //Создание объекта для генерации чисел

            for (int i = 0; i < countNewNode; i++)
            {
                masNode[i] = new NodeTwoLinks(rnd.Next(0, 1000));//создаю i-тый элемент массива с рандомным значением Value 
                if (i > 0)
                {

                    masNode[i].PrevNode = masNode[i - 1];
                    masNode[i - 1].NextNode = masNode[i];
                }

            }


            //

            masNode[4].ShowNodes();
            masNode = overWritingMassiv(masNode, masNode[0].GetCount());

            //проверка удаления
            int numDel = rnd.Next(1, countNewNode - 1);
            masNode[numDel].RemoveNode();
            Console.WriteLine("\n Удаляем элемент под номером " + (numDel + 1) + " со значением " + masNode[numDel].Value + " .");
            Console.WriteLine(" Поиск удаляемого элемент происходит по значению. ");
            masNode[numDel].ShowNodes();
            masNode = overWritingMassiv(masNode, masNode[0].GetCount());

            //добавление новой записи в конец списка
            int newValue = rnd.Next(0, 1000);
            Console.WriteLine("\n \n Добавляю элемент в конец списка  со значением " + newValue + " .");
            masNode[0].AddNode(newValue);
            masNode[0].ShowNodes();
            masNode = overWritingMassiv(masNode, masNode[0].GetCount());

            //удаляем элемент по порядковому номеру начиная с 1
            numDel = rnd.Next(1, countNewNode - 1);
            masNode[numDel].RemoveNode(numDel);
            Console.WriteLine("\n Удаляем элемент под номером " + (numDel + 1) + " со значением " + masNode[numDel].Value + " .");
            Console.WriteLine(" Поиск удаляемого элемент происходит по порядковому номеру. ");
            masNode[numDel].ShowNodes();
            masNode = overWritingMassiv(masNode, masNode[0].GetCount());

            //добавление новой записи после элемента
            newValue = rnd.Next(0, 1000);
            int numNodeAfter = rnd.Next(1, countNewNode - 1);
            Console.WriteLine("\n \n Добавляю новый элемент после " + (numNodeAfter + 1) + " элемента.");
            masNode[0].AddNodeAfter(masNode[numNodeAfter], newValue);
            masNode[0].ShowNodes();
            masNode = overWritingMassiv(masNode, masNode[0].GetCount());

            //поиск элемента по значению
            int numNodeFind = rnd.Next(1, countNewNode - 1);
            Console.WriteLine("\n \n Поиск элемента по значению " + masNode[numNodeFind].Value);
            var findNode = masNode[0].FindNode(masNode[numNodeFind].Value);
            var findNodePrev = findNode.PrevNode;
            var findNodeNext = findNode.NextNode;
            Console.WriteLine("Пред\tТек\tПосле");
            if (findNodePrev == null) Console.WriteLine(findNode.Value + "\t" + findNodeNext.Value);
            else
            {
                if (findNodeNext == null) Console.WriteLine(findNodePrev.Value + "\t" + findNode.Value);
                else Console.WriteLine(findNodePrev.Value + "\t" + findNode.Value + "\t" + findNodeNext.Value);
            }

        }


        /// <summary>
        /// Перезапись значений массива (нужна доработка, в случае удаления 0 элемента массива)
        /// </summary>
        /// <param name="masNode"></param>
        /// <param name="countMasNode"></param>
        /// <returns></returns>
        private static NodeTwoLinks[] overWritingMassiv(NodeTwoLinks[] masNode, int countMasNode)
        {
            var node = masNode[0];
            while (node.PrevNode != null)  //перехожу к 0 записи
            {
                node = node.PrevNode;
            }

            int i = 0;
            masNode[i] = node;
            masNode[0].ShowNum();
            Console.WriteLine("Список значений массива");
            Console.Write(masNode[i].Value + "\t");
            while (node.NextNode != null)
            {
                node = node.NextNode;
                i++;
                masNode[i] = node;
                Console.Write(masNode[i].Value + "\t");
            }
            if (i < masNode.Length - 1)
            {
                i++;
                while (i < masNode.Length - 1)
                {
                    masNode[i].Value = -1;
                    masNode[i].NextNode = null;
                    masNode[i].PrevNode = null;
                    i++;
                }
            }
            Console.WriteLine("\n");
            return masNode;
        }

        public void ShowTask()
        {
            Console.WriteLine(NameTask);
            Console.WriteLine(Description);
            Console.WriteLine("Нажмите клавишу Enter для продолжения.");
            Console.ReadLine();
        }
    }
}
