using GameOfLife;
using System;

namespace GameOfLife
{
    public class Game_Graphic
    {
        protected string buffer = "";

        private Game gol;

        // constructor

        public Game_Graphic(Game gameObj)
        {
            gol = gameObj;
            Console.CursorVisible = false;

            Console.SetWindowSize(120, 30);

        }

        // update and draw the scene 
        public void DrawBoard()
        {
            buffer = "";

            for (int i = 0; i < gol.Height; i++)

                for (int j = 0; j < gol.Width; j++)
                {
                    if (gol.currentGen[i, j] == 1)
                        buffer += "*";
                    else
                        buffer += " ";
                }
            buffer += "\n";


            // draw board

            Console.SetCursorPosition(0, 0);
            Console.WriteLine(buffer);
        }

    }
}
