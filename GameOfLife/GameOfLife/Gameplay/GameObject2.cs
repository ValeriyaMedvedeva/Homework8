using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Gameplay
{
    public class GameObject2
    {
        public Object2[,] gameField;
        public int length, width, generation, death;
        public int pause;
        public int age = 1;
        public int kolLife;
        public GameObject2(List<int> setting)
        {
            gameField = new Object2[setting[0], setting[1]];
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    gameField[i, j] = new Object2();
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
                    if (gameField[i, j].life)
                    {
                        neighborLife = NumberOfLife(i, j);
                        if (neighborLife > death)
                        {
                            flag1 = true;
                            gameField[i, j].life = false;
                            kolLife--;
                            break;
                        }
                        if (neighborLife > generation - 1 && neighborLife < generation + 1)
                        {
                            if (neighborLife < 8)
                            {
                                for (int k = i - 1; k < i + 2; k++)
                                {
                                    for (int m = j - 1; m < j + 2; m++)
                                    {
                                        if (!gameField[k, m].life && k != 0 && m != 0 && k != str - 1 && m != stb - 1)
                                        {
                                            flag2 = true;
                                            gameField[k, m].life = true;
                                            kolLife++;
                                            break;
                                        }
                                    }
                                }
                            }
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
