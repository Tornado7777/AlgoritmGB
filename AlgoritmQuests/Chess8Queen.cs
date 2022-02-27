using System;
using System.Collections.Generic;

namespace AlgoritmQuests
{
    public class Chess8Queen
    {
        public class Board8x8
        {
            public int[] Board { get; set; } // массив для доски 8х8 0-разрешенное положение, 1- ферзь (королева), 2 - запрещенное положение
            public int NumberQueens { get; set; }
            public Board8x8()
            {
                Board = new int[64];
                NumberQueens = 0;
            }
        }

        /// <summary>
        /// Отвечает за реализацию логики задачи
        /// </summary>
        internal void Logic8Queen()
        {
            Board8x8 board8X8 = new Board8x8();
            int rnd = new Random().Next(0, 63);
            board8X8.NumberQueens++;
            board8X8.Board[rnd] = 1; //размешаю первого Ферзя(Королеву)
            board8X8.Board = NotAllowedPosition(rnd, board8X8.Board); //размечаю на доске запрещенные позиции
            ShowChessBoard(board8X8.Board);
            NextQueens(board8X8.Board);

        }
        /// <summary>
        /// метод отбражения шахматной доски
        /// </summary>
        private void ShowChessBoard(int[] board8X8)
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
                    if (board8X8[j + i * 8] == 1) Console.Write("Ф");
                    else
                    {
                        if (board8X8[j + i * 8] == 2) Console.Write("x"); else Console.Write(" ");
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
            NumberQueen(board8X8, true);
            Console.WriteLine("Нажмите Enter, чтобы продолжить.");
            Console.ReadLine();
        }

        private int NumberQueen(int [] board8X8, bool visible = false)
        {
            int numberQueens = 0;
            for (int i = 0; i < board8X8.Length; i++) if (board8X8[i] == 1) numberQueens++;
            if (visible)
            {
                Console.WriteLine("Количество ферзей на доске = " + numberQueens);
                if (numberQueens == 8)
                {
                    Console.WriteLine("Найден вариант решения для данного первого положения Ферзя");
                }
            }
            return numberQueens;
        }

        /// <summary>
        /// Метод обозначающий запрещенные позиции нового Ферзя
        /// </summary>
        private int[] NotAllowedPosition(int position, int[] board)
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
                    if (board[i] != 1) board[i] = 2; else Console.WriteLine("Недопустимость позиции");
                }
            }
            //по вертикали

            for (int i = 0; i < 8; i++)
            {
                if ((positionX + 8 * i) != position & ((positionX + 8 * i) < 64))
                {
                    if (board[positionX + 8 * i] != 1) board[positionX + 8 * i] = 2; else Console.WriteLine("Недопустимость позиции");
                }
            }
            //по диагоналям
            int currentPoint = position;
            //рисую диагональ от позиции вверх и налево
            while (currentPoint - 9 >= 0 && (currentPoint % 8) > 0) //рисую до границ
            {
                currentPoint = currentPoint - 9;
                if (board[currentPoint] == 1)
                {
                    Console.WriteLine("Недопустимость позиции");
                    break;
                }
                board[currentPoint] = 2;
            }

            //рисую диагональ от позиции вверх и направо
            currentPoint = position;
            while ((currentPoint % 8) < 7 && currentPoint - 7 >= 0)
            {
                currentPoint = currentPoint - 7;
                if (board[currentPoint] == 1)
                {
                    Console.WriteLine("Недопустимость позиции");
                    break;
                }
                board[currentPoint] = 2;
                if (currentPoint % 8 == 7) break;
            }
            //рисую диагональ от позиции вниз и направо
            currentPoint = position;
            while ((currentPoint % 8) < 7 && currentPoint + 9 < 64)
            {
                currentPoint = currentPoint + 9;
                if (board[currentPoint] == 1)
                {
                    Console.WriteLine("Недопустимость позиции");
                    break;
                }
                board[currentPoint] = 2;
                if (currentPoint % 8 == 7) break;
            }
            //рисую диагональ от позиции вниз и налево
            currentPoint = position;
            while ((currentPoint % 8) > 0 && currentPoint + 7 < 64)
            {
                currentPoint = currentPoint + 7;
                if (board[currentPoint] == 1)
                {
                    Console.WriteLine("Недопустимость позиции");
                    break;
                }
                board[currentPoint] = 2;
                if (currentPoint % 8 == 0) break;
            }
            return board;
        }

        private void NextQueens(int[] board8x8)
        {
            List<int> variantNewQueen = new List<int>();

            int numbersQueens = NumberQueen(board8x8);

            //отсеиваю список разрешенных вариантов для следующего Ферзя
            for (int i = 0; i < board8x8.Length; i++)
            {
                if (board8x8[i] == 0) variantNewQueen.Add(i);
            }
            
            if (variantNewQueen != null && variantNewQueen.Count > 0 && numbersQueens < 8)
            {
                for (int i = 0; i < variantNewQueen.Count; i++)
                {
                    int[] board = new int[board8x8.Length];
                    board8x8.CopyTo(board, 0);
                    board[variantNewQueen[i]] = 1; // обозначаю позицию ферзя на доске
                    numbersQueens = NumberQueen(board, true);
                    board = NotAllowedPosition(variantNewQueen[i], board); //размечаю на доске запрещенные позиции для нового Ферзя
                    if (numbersQueens == 8 || variantNewQueen.Count == 0)
                    {
                        ShowChessBoard(board);
                        Environment.Exit(0);
                    }
                    else
                        NextQueens(board);
                }
            }
        }
    }
}
//для реализации перебора, нужно реализовать список решений, и каждое новое решение сравнивать с предыдущими
