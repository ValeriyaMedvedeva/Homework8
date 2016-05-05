using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using GameOfLife.Gameplay;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"GameSaving.txt";
            FileStream fs = File.Create(path);
            fs.Close();
            Controller mn = new Controller();
            mn.ItemSelection();
        }
    }
}