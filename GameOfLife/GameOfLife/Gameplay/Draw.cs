using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Gameplay
{
    class Draw
    {
        public void Drawing(GameObject1 ob1)
        {
            Console.ResetColor();
            Console.WriteLine();
            for (int i = 0; i < ob1.length; i++)
            {
                Console.WriteLine();
                for (int k = 0; k < ob1.width; k++)
                {
                    Console.Write(" _");
                }
                Console.WriteLine();
                Console.Write("|");
                for (int j = 0; j < ob1.width; j++)
                {
                    if (ob1.gameField[i, j].life)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.ResetColor();
                    }
                    else
                        Console.Write(" ");
                    Console.Write("|");
                }
            }
            Console.WriteLine();
            for (int k = 0; k < ob1.width; k++)
            {
                Console.Write(" _");
            }
        }
        public void Drawing(GameObject2 ob2)
        {
            Console.ResetColor();
            Console.WriteLine();
            for (int i = 0; i < ob2.length; i++)
            {
                Console.WriteLine();
                for (int k = 0; k < ob2.width; k++)
                {
                    Console.Write(" _");
                }
                Console.WriteLine();
                Console.Write("|");
                for (int j = 0; j < ob2.width; j++)
                {
                    if (ob2.gameField[i, j].life)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("O");
                        Console.ResetColor();
                    }
                    else
                        Console.Write(" ");
                    Console.Write("|");
                }
            }
            Console.WriteLine();
            for (int k = 0; k < ob2.width; k++)
            {
                Console.Write(" _");
            }
        }
        public void Drawing(GameObject3 ob3)
        {
            Console.ResetColor();
            Console.WriteLine();
            for (int i = 0; i < ob3.length; i++)
            {
                Console.WriteLine();
                for (int k = 0; k < ob3.width; k++)
                {
                    Console.Write(" _");
                }
                Console.WriteLine();
                Console.Write("|");
                for (int j = 0; j < ob3.width; j++)
                {
                    if (ob3.gameField[i, j].ob2.life)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("O");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (ob3.gameField[i, j].ob1.life)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("X");
                            Console.ResetColor();
                        }
                        else
                            Console.Write(" ");
                    }
                    Console.Write("|");
                }
            }
            Console.WriteLine();
            for (int k = 0; k < ob3.width; k++)
            {
                Console.Write(" _");
            }
        }
    }
}