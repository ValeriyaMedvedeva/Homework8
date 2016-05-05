using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Gameplay;

namespace GameOfLife.Gameplay
{
    public class Controller
    {
        public void ItemSelection()
        {
            bool flag = true;
            int str;
            List<int> setting = new List<int>(5);
            ConsoleKeyInfo opt;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Введите 1,чтобы НАЧАТЬ НОВУЮ ИГРУ;");
                Console.WriteLine("2. Введите 2,чтобы ПРОДОЛЖИТЬ СОХРАНЕННУЮ ИГРУ;");
                Console.WriteLine("3. Введите Esc,чтобы произошел ВЫХОД из приложения;");
                opt = Console.ReadKey();
                switch (opt.Key)
                {
                    case ConsoleKey.D1:
                        setting.Add(10);
                        setting.Add(15);
                        setting.Add(3);
                        setting.Add(1);
                        setting.Add(2);
                        SelectionTypeOfGame(setting);
                        flag = false;
                        break;
                    case ConsoleKey.D2:
                        StreamReader sr = new StreamReader("GameSaving.txt");
                        if (sr.Peek() < 0)
                        {
                            Console.WriteLine("\nНе существует сохраненной игры,пожалуйста,начните новую игру");
                            sr.Close();
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            str = Int32.Parse(sr.ReadLine());
                            if (str == 1)
                            {
                                setting.Add(str = Int32.Parse(sr.ReadLine()));
                                setting.Add(str = Int32.Parse(sr.ReadLine()));
                                setting.Add(str = Int32.Parse(sr.ReadLine()));
                                setting.Add(str = Int32.Parse(sr.ReadLine()));
                                setting.Add(str = Int32.Parse(sr.ReadLine()));
                                GameObject1 ob1 = new GameObject1(setting);
                                str = Int32.Parse(sr.ReadLine());
                                ob1.age = str;
                                str = Int32.Parse(sr.ReadLine());
                                ob1.kolLife = str;
                                for (int i = 0; i < ob1.length; i++)
                                {
                                    for (int j = 0; j < ob1.width; j++)
                                    {
                                        str = Int32.Parse(sr.ReadLine());
                                        if (str == 1)
                                        {
                                            ob1.gameField[i, j].life = true;
                                        }
                                    }
                                }
                                sr.Close();
                                Game1Saving(ob1);

                            }
                            if (str == 2)
                            {
                                setting.Add(str = Int32.Parse(sr.ReadLine()));
                                setting.Add(str = Int32.Parse(sr.ReadLine()));
                                setting.Add(str = Int32.Parse(sr.ReadLine()));
                                setting.Add(str = Int32.Parse(sr.ReadLine()));
                                setting.Add(str = Int32.Parse(sr.ReadLine()));
                                GameObject2 ob2 = new GameObject2(setting);
                                str = Int32.Parse(sr.ReadLine());
                                ob2.age = str;
                                str = Int32.Parse(sr.ReadLine());
                                ob2.kolLife = str;
                                for (int i = 0; i < ob2.length; i++)
                                {
                                    for (int j = 0; j < ob2.width; j++)
                                    {
                                        str = Int32.Parse(sr.ReadLine());
                                        if (str == 1)
                                        {
                                            ob2.gameField[i, j].life = true;
                                        }
                                    }
                                }
                                sr.Close();
                                Game2Saving(ob2);
                            }
                            if (str == 3)
                            {
                                setting.Add(str = Int32.Parse(sr.ReadLine()));
                                setting.Add(str = Int32.Parse(sr.ReadLine()));
                                setting.Add(str = Int32.Parse(sr.ReadLine()));
                                setting.Add(str = Int32.Parse(sr.ReadLine()));
                                setting.Add(str = Int32.Parse(sr.ReadLine()));
                                GameObject3 ob3 = new GameObject3(setting);
                                str = Int32.Parse(sr.ReadLine());
                                ob3.age = str;
                                str = Int32.Parse(sr.ReadLine());
                                ob3.kolLife = str;
                                for (int i = 0; i < ob3.length; i++)
                                {
                                    for (int j = 0; j < ob3.width; j++)
                                    {
                                        str = Int32.Parse(sr.ReadLine());
                                        if (str == 1)
                                        {
                                            ob3.gameField[i, j].ob1.life = true;
                                        }
                                        if (str == 2)
                                        {
                                            ob3.gameField[i, j].ob2.life = true;
                                        }
                                    }
                                }
                                sr.Close();
                                Game3Saving(ob3);
                            }
                        }
                        flag = false;
                        break;
                    case ConsoleKey.Escape:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\nНе правильный ввод,пожалуйста,попробуйте еще раз!");
                        Console.ReadKey();
                        break;
                }
            } while (flag);
        }
        public void SelectionTypeOfGame(List<int> setting)
        {
            bool flag = true;
            ConsoleKeyInfo opt;
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Введите 1,чтобы начать игру со стандартным поведением;");
                Console.WriteLine("2. Введите 2,чтобы начать игру с возможностью размножения клеток;");
                Console.WriteLine("3. Введите 3,чтобы начать игру по смешанному типу;");
                opt = Console.ReadKey();
                switch (opt.Key)
                {
                    case ConsoleKey.D1:
                        Game1(setting);
                        flag = false;
                        break;
                    case ConsoleKey.D2:
                        Game2(setting);
                        flag = false;
                        break;
                    case ConsoleKey.D3:
                        Game3(setting);
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\nНе правильный ввод,пожалуйста,попробуйте еще раз!");
                        Console.ReadKey();
                        break;
                }
            } while (flag);
            Console.ResetColor();
        }
        public void Game1(List<int> setting)
        {
            Draw draw = new Draw();
            GameObject1 ob1 = new GameObject1(setting);
            ob1.Arrangement();
            bool flag = true;
            Console.Clear();
            while (flag)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Текущее поколение игры: {0}", ob1.age);
                Console.WriteLine("Текущее количество живых объектов: {0}", ob1.kolLife);
                Console.ResetColor();
                draw.Drawing(ob1);
                System.Threading.Thread.Sleep(ob1.pause * 1000);
                if (GameMenu())
                {

                    StreamWriter sw = new StreamWriter("GameSaving.txt", false);
                    sw.WriteLine(1);
                    sw.WriteLine(ob1.length);
                    sw.WriteLine(ob1.width);
                    sw.WriteLine(ob1.generation);
                    sw.WriteLine(ob1.death);
                    sw.WriteLine(ob1.pause);
                    sw.WriteLine(ob1.age);
                    sw.WriteLine(ob1.kolLife);
                    for (int i = 0; i < ob1.length; i++)
                    {
                        for (int j = 0; j < ob1.width; j++)
                        {
                            if (ob1.gameField[i, j].life)
                            {
                                sw.WriteLine(1);
                            }
                            else
                            {
                                sw.WriteLine(0);
                            }
                        }
                    }
                    sw.Close();
                    ItemSelection();
                    break;
                }
                Console.Clear();
                flag = ob1.Game();
            }
            Console.WriteLine("Игра закончена!");
            Console.ReadLine();
            ItemSelection();
        }
        public void Game2(List<int> setting)
        {
            Draw draw = new Draw();
            GameObject2 ob2 = new GameObject2(setting);
            ob2.Arrangement();
            bool flag = true;
            Console.Clear();
            while (flag)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Текущее поколение игры: {0}", ob2.age);
                Console.WriteLine("Текущее количество живых объектов: {0}", ob2.kolLife);
                Console.ResetColor();
                draw.Drawing(ob2);
                System.Threading.Thread.Sleep(ob2.pause * 1000);
                if (GameMenu())
                {

                    StreamWriter sw = new StreamWriter("GameSaving.txt", false);
                    sw.WriteLine(2);
                    sw.WriteLine(ob2.length);
                    sw.WriteLine(ob2.width);
                    sw.WriteLine(ob2.generation);
                    sw.WriteLine(ob2.death);
                    sw.WriteLine(ob2.pause);
                    sw.WriteLine(ob2.age);
                    sw.WriteLine(ob2.kolLife);
                    for (int i = 0; i < ob2.length; i++)
                    {
                        for (int j = 0; j < ob2.width; j++)
                        {
                            if (ob2.gameField[i, j].life)
                            {
                                sw.WriteLine(1);
                            }
                            else
                            {
                                sw.WriteLine(0);
                            }
                        }
                    }
                    sw.Close();
                    ItemSelection();
                    break;
                }
                Console.Clear();
                flag = ob2.Game();
            }
            Console.WriteLine("Игра закончена!");
            Console.ReadLine();
            ItemSelection();
        }
        public void Game3(List<int> setting)
        {
            Draw draw = new Draw();
            GameObject3 ob3 = new GameObject3(setting);
            draw.Drawing(ob3);
            ob3.Arrangement();
            bool flag = true;
            Console.Clear();
            while (flag)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Текущее поколение игры: {0}", ob3.age);
                Console.WriteLine("Текущее количество живых объектов: {0}", ob3.kolLife);
                Console.ResetColor();
                draw.Drawing(ob3);
                System.Threading.Thread.Sleep(ob3.pause * 1000);
                if (GameMenu())
                {

                    StreamWriter sw = new StreamWriter("GameSaving.txt", false);
                    sw.WriteLine(3);
                    sw.WriteLine(ob3.length);
                    sw.WriteLine(ob3.width);
                    sw.WriteLine(ob3.generation);
                    sw.WriteLine(ob3.death);
                    sw.WriteLine(ob3.pause);
                    sw.WriteLine(ob3.age);
                    sw.WriteLine(ob3.kolLife);
                    for (int i = 0; i < ob3.length; i++)
                    {
                        for (int j = 0; j < ob3.width; j++)
                        {
                            if (ob3.gameField[i, j].ob1.life)
                            {
                                sw.WriteLine(1);
                            }
                            else
                            {
                                if (ob3.gameField[i, j].ob2.life)
                                {
                                    sw.WriteLine(2);
                                }
                                else
                                    sw.WriteLine(0);
                            }
                        }
                    }
                    sw.Close();
                    ItemSelection();
                    break;
                }
                Console.Clear();
                flag = ob3.Game();
            }
            Console.WriteLine("Игра закончена!");
            Console.ReadLine();
            ItemSelection();
        }
        public void Game1Saving(GameObject1 ob1)
        {
            Draw draw = new Draw();
            bool flag = true;
            Console.Clear();
            while (flag)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Текущее поколение игры: {0}", ob1.age);
                Console.WriteLine("Текущее количество живых объектов: {0}", ob1.kolLife);
                Console.ResetColor();
                draw.Drawing(ob1);
                System.Threading.Thread.Sleep(ob1.pause * 1000);
                if (GameMenu())
                {

                    StreamWriter sw = new StreamWriter("GameSaving.txt", false);
                    sw.WriteLine(1);
                    sw.WriteLine(ob1.length);
                    sw.WriteLine(ob1.width);
                    sw.WriteLine(ob1.generation);
                    sw.WriteLine(ob1.death);
                    sw.WriteLine(ob1.pause);
                    sw.WriteLine(ob1.age);
                    sw.WriteLine(ob1.kolLife);
                    for (int i = 0; i < ob1.length; i++)
                    {
                        for (int j = 0; j < ob1.width; j++)
                        {
                            if (ob1.gameField[i, j].life)
                            {
                                sw.WriteLine(1);
                            }
                            else
                            {
                                sw.WriteLine(0);
                            }
                        }
                    }
                    sw.Close();
                    ItemSelection();
                    break;
                }
                Console.Clear();
                flag = ob1.Game();
            }
            Console.WriteLine("Игра закончена!");
            Console.ReadLine();
            ItemSelection();
        }
        public void Game2Saving(GameObject2 ob2)
        {
            Draw draw = new Draw();
            bool flag = true;
            Console.Clear();
            while (flag)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Текущее поколение игры: {0}", ob2.age);
                Console.WriteLine("Текущее количество живых объектов: {0}", ob2.kolLife);
                Console.ResetColor();
                draw.Drawing(ob2);
                System.Threading.Thread.Sleep(ob2.pause * 1000);
                if (GameMenu())
                {
                    StreamWriter sw = new StreamWriter("GameSaving.txt", false);
                    sw.WriteLine(1);
                    sw.WriteLine(ob2.length);
                    sw.WriteLine(ob2.width);
                    sw.WriteLine(ob2.generation);
                    sw.WriteLine(ob2.death);
                    sw.WriteLine(ob2.pause);
                    sw.WriteLine(ob2.age);
                    sw.WriteLine(ob2.kolLife);
                    for (int i = 0; i < ob2.length; i++)
                    {
                        for (int j = 0; j < ob2.width; j++)
                        {
                            if (ob2.gameField[i, j].life)
                            {
                                sw.WriteLine(1);
                            }
                            else
                            {
                                sw.WriteLine(0);
                            }
                        }
                    }
                    sw.Close();
                    ItemSelection();
                    break;
                }
                Console.Clear();
                flag = ob2.Game();
            }
            Console.WriteLine("Игра закончена!");
            Console.ReadLine();
            ItemSelection();
        }
        public void Game3Saving(GameObject3 ob3)
        {
            Draw draw = new Draw();
            bool flag = true;
            Console.Clear();
            while (flag)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Текущее поколение игры: {0}", ob3.age);
                Console.WriteLine("Текущее количество живых объектов: {0}", ob3.kolLife);
                Console.ResetColor();
                draw.Drawing(ob3);
                System.Threading.Thread.Sleep(ob3.pause * 1000);
                if (GameMenu())
                {

                    StreamWriter sw = new StreamWriter("GameSaving.txt", false);
                    sw.WriteLine(1);
                    sw.WriteLine(ob3.length);
                    sw.WriteLine(ob3.width);
                    sw.WriteLine(ob3.generation);
                    sw.WriteLine(ob3.death);
                    sw.WriteLine(ob3.pause);
                    sw.WriteLine(ob3.age);
                    sw.WriteLine(ob3.kolLife);
                    for (int i = 0; i < ob3.length; i++)
                    {
                        for (int j = 0; j < ob3.width; j++)
                        {
                            if (ob3.gameField[i, j].ob1.life)
                            {
                                sw.WriteLine(1);
                            }
                            else
                            {
                                if (ob3.gameField[i, j].ob2.life)
                                {
                                    sw.WriteLine(2);
                                }
                                else
                                    sw.WriteLine(0);
                            }
                        }
                    }
                    sw.Close();
                    ItemSelection();
                    break;
                }
                Console.Clear();
                flag = ob3.Game();
            }
            Console.WriteLine("Игра закончена!");
            Console.ReadLine();
            ItemSelection();
        }
        public bool GameMenu()
        {
            bool flag = true;
            ConsoleKeyInfo opt;
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.WriteLine("\n\n1. Нажмите Enter,чтобы ПРОДОЛЖИТЬ ТЕКУЩУЮ ИГРУ;");
                Console.WriteLine("2. Нажмите Esc,чтобы ЗАВЕРШИТЬ ИГРУ С СОХРАНЕНИЕМ;");
                opt = Console.ReadKey();
                switch (opt.Key)
                {
                    case ConsoleKey.Enter:
                        Console.ResetColor();
                        return false;
                    case ConsoleKey.Escape:
                        Console.ResetColor();
                        return true;
                    default:
                        Console.WriteLine("\nНе правильный ввод,пожалуйста,попробуйте еще раз!");
                        Console.ReadKey();
                        break;
                }
            } while (flag);
            return false;
        }
    }
}