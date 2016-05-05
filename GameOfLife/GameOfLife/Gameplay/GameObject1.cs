using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Gameplay
{
    public class GameObject1
    {
        public Object1[,] gameField;
        public int length, width, generation, death;
        public int pause;
        public int age = 1;
        public int kolLife;
        public GameObject1(List<int> setting)
        {
            gameField = new Object1[setting[0], setting[1]];
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    gameField[i, j] = new Object1();
                }
            }
            length = setting[0];
            width = setting[1];
            generation = setting[2];
            death = setting[3];
            pause = setting[4];
            kolLife = 0;
        }
        public void Arrangement()
        {
            Random random = new Random();
            int r;
            for (int i = 1; i < gameField.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < gameField.GetLength(1) - 1; j++)
                {
                    r = random.Next(0, 2);
                    if (r == 0)
                    {
                        gameField[i, j].life = false;
                    }
                    else
                    {
                        gameField[i, j].life = true;
                        kolLife++;
                    }
                }
            }
        }
        public bool Game()
        {
            int str = gameField.GetLength(0);
            int stb = gameField.GetLength(1);
            int neighborLife = 0;
            bool flag1 = false;
            bool flag2 = false;
            age++;
            for (int i = 1; i < str - 1; i++)
            {
                for (int j = 1; j < stb - 1; j++)
                {
                    if (!gameField[i, j].life)
                    {
                        neighborLife = NumberOfLife(i, j);
                        if (neighborLife == generation)
                        {
                            flag1 = true;
                            gameField[i, j].life = true;
                            kolLife++;
                        }
                    }
                    else
                    {
                        neighborLife = NumberOfLife(i, j);
                        if (neighborLife > death || neighborLife < death - 1)
                        {
                            flag2 = true;
                            gameField[i, j].life = false;
                            kolLife--;
                        }
                    }
                }

            }
            if (flag1 || flag2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int NumberOfLife(int k, int m)
        {
            int kol = 0;
            for (int i = k - 1; i < k + 2; i++)
            {
                for (int j = m - 1; j < m + 2; j++)
                {
                    if (i != k || j != m)
                    {
                        if (gameField[i, j].life)
                        {
                            kol++;
                        }
                    }
                }
            }
            return kol;
        }
    }
}