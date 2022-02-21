using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmQuests
{
    public class Chess8Queen
    {
        internal int[] Board { get; private set; } // массив для доски 8х8 0-разрешенное положение, 1- ферзь (королева), 2 - запрещенное положение
        internal Chess8Queen()
        {
            Board = new int[64];
        }

        private class Queen
        {
            internal int Position { get; set; }
            internal int[] VariantNewQueen { get; set; }
            internal Queen(int position)
            {
                Position = position;
                /*создаю массив с возможными положениями следующих ферзей, 
                 * номерация массива относительно позиции показана ниже
                 *  *0*1*  значения относительно     * -17 * -15 *
                 *  7***2  текущей позиции          -10 *  *  * -6
                 *  **Ф**   ферзя                   *   *  Ф  *  *
                 *  6***3                           +6  *  *  * +10
                 *  *5*4*                            * +15 * +17 *
                 */
                VariantNewQueen = new int[8] { position - 17, position - 15, position - 6, position + 10, position + 17, position + 15, position + 6, position - 10 };
                //рассматриваю граничные условия, зануляю соответствующие значения
                //по горизонтали
                if (position < 16) //если позиция находится на 2 ряду по горизонтали
                {
                    VariantNewQueen[0] = 0;
                    VariantNewQueen[1] = 0;
                }
                else
                {
                    if (position >= 48) //на 7 ряду по горизонтали
                    {
                        VariantNewQueen[5] = 0;
                        VariantNewQueen[4] = 0;
                    }
                    if (position >= 56) //на 8 ряду по горизонтали
                    {
                        VariantNewQueen[3] = 0;
                        VariantNewQueen[6] = 0;
                    }
                }
                if (position < 8) //если позиция находится на 1 ряду по горизонтали
                {
                    VariantNewQueen[2] = 0;
                    VariantNewQueen[7] = 0;
                }
                // по вертикали
                if ((position % 8) < 2 || position < 2) //2 ряд по вертикали
                {
                    VariantNewQueen[0] = 0;
                    VariantNewQueen[5] = 0;
                }
                else
                {
                    if ((position % 8) > 5 || position > 5) //7 ряд по вертикали
                    {
                        VariantNewQueen[2] = 0;
                        VariantNewQueen[3] = 0;
                    }
                    if ((position % 8) > 6 || position > 6) //8 ряд по вертикали
                    {
                        VariantNewQueen[1] = 0;
                        VariantNewQueen[4] = 0;
                    }
                }
                if ((position % 8) == 0 || position == 0) //1 ряд по вертикали
                {
                    VariantNewQueen[6] = 0;
                    VariantNewQueen[7] = 0;
                }
            }
        }
        /// <summary>
        /// Отвечает за реализацию логики задачи
        /// </summary>
        internal void Logic8Queen()
        {
            ShowChessBoard();
            int rnd = new Random().Next(0, 63);
            Queen currentQueen = new Queen(rnd); //создаю первого Ферзя(Королеву)
            Board[rnd] = 1; //размешаю первого Ферзя(Королеву)
            NotAllowedPosition(rnd); //размечаю на доске запрещенные позиции
            ShowChessBoard();
            NextQueens(currentQueen.VariantNewQueen);

        }
        /// <summary>
        /// метод отбражения шахматной доски
        /// </summary>
        private void ShowChessBoard()
        {
            Console.Clear();
            Console.WriteLine("Обозначения: пусто-разрешенное положение, х - запрещенное, Ф - ферзь(королева).\n");
            Console.Write("╔");
            int sizeX = 31; //кол-во символов занимемых доской по Х координате
            for (int i = 0; i < sizeX; i++) Console.Write("═");
            Console.Write("╗\n");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("║");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(" ");
                    if (Board[j + i * 8] == 1) Console.Write("Ф");
                    else
                    {
                        if (Board[j + i * 8] == 2) Console.Write("x"); else Console.Write(" ");
                    }
                    Console.Write(" ");
                    Console.Write("║");
                }
                Console.Write("\n");
                if (i == 7)
                {
                    Console.Write("╚");
                    for (int k = 0; k < sizeX; k++) Console.Write("═");
                    Console.Write("╝\n");
                }
                else
                {
                    Console.Write("╠");
                    for (int k = 0; k < sizeX; k++) Console.Write("═");
                    Console.Write("╣\n");
                }

            }
            Console.WriteLine("Нажмите Enter, чтобы продолжить.");
            Console.ReadLine();
        }

        /// <summary>
        /// Метод обозначающий запрещенные позиции нового Ферзя
        /// </summary>
        private void NotAllowedPosition(int position)
        {
            //по горизонтали
            //нахожу позицию в горизонтальном ряду
            int positionX = position;
            if (position > 7) positionX = position % 8;
            int startHorizontall = position - positionX;

            for (int i = startHorizontall; i < startHorizontall + 8; i++)
            {
                if (i != position)
                {
                    if (Board[i] != 1) Board[i] = 2; else Console.WriteLine("Недопустимость позиции");
                }
            }
            //по вертикали

            for (int i = 0; i < 8; i++)
            {
                if ((positionX + 8 * i) != position & ((positionX + 8 * i) < 64))
                {
                    if (Board[positionX + 8 * i] != 1) Board[positionX + 8 * i] = 2; else Console.WriteLine("Недопустимость позиции");
                }
            }
            //по диагоналям
            int currentPoint = position;
            //рисую диагональ от позиции вверх и налево
            while (currentPoint - 9 >= 0 && (currentPoint % 8) > 0) //рисую до границ
            {
                currentPoint = currentPoint - 9;
                if (Board[currentPoint] == 1)
                {
                    Console.WriteLine("Недопустимость позиции");
                    break;
                }
                Board[currentPoint] = 2;
            }

            //рисую диагональ от позиции вверх и направо
            currentPoint = position;
            while ((currentPoint % 8) < 7 && currentPoint - 7 >= 0)
            {
                currentPoint = currentPoint - 7;
                if (Board[currentPoint] == 1)
                {
                    Console.WriteLine("Недопустимость позиции");
                    break;
                }
                Board[currentPoint] = 2;
                if (currentPoint % 8 == 7) break;
            }
            //рисую диагональ от позиции вниз и направо
            currentPoint = position;
            while ((currentPoint % 8) < 7 && currentPoint + 9 < 64)
            {
                currentPoint = currentPoint + 9;
                if (Board[currentPoint] == 1)
                {
                    Console.WriteLine("Недопустимость позиции");
                    break;
                }
                Board[currentPoint] = 2;
                if (currentPoint % 8 == 7) break;
            }
            //рисую диагональ от позиции вниз и налево
            currentPoint = position;
            while ((currentPoint % 8) > 0 && currentPoint + 7 < 64)
            {
                currentPoint = currentPoint + 7;
                if (Board[currentPoint] == 1)
                {
                    Console.WriteLine("Недопустимость позиции");
                    break;
                }
                Board[currentPoint] = 2;
                if (currentPoint % 8 == 0) break;
            }
        }

        private void NextQueens(int [] variantNewQueen)
        {
            List<int> variantQueens = new List<int>(0);
            int rnd = 0;
            //отсеиваю список разрешенных вариантов для следующего Ферзя
            for (int i=0; i< variantNewQueen.Length; i++)
            {
                if (variantNewQueen[i] != 0 && Board[variantNewQueen[i]] != 1 && Board[variantNewQueen[i]] != 2) variantQueens.Add(variantNewQueen[i]);
            }
            //выбираю рандомно из списка позицию может лучше просто перебрать доступные позиции
            if (variantQueens.Count > 1)
            {
                rnd = new Random().Next(0, variantQueens.Count - 1);
            }
            Queen currentQueen = new Queen(variantQueens[rnd]);
            Board[currentQueen.Position] = 1;
            NotAllowedPosition(currentQueen.Position); //размечаю на доске запрещенные позиции
            ShowChessBoard();
            //нужно сделать рекурсию с перебором досупных вариантов и их проверкой
        }
    }
}
