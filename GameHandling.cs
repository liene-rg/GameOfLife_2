using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife;

namespace GameOfLife
{
    public static class GameHandling
    {
        public static void RunGame(Game gameObject, GameGraphic gameGraphic)
        {
            while (true)
            {
                gameGraphic.DrawBoard();
                gameObject.GenerateNextGeneration();
                Thread.Sleep(1000);
                gameGraphic.CalculateLiveCellsCurrentGeneration();
            }
        }
    }
}