using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NotJustSokoban
{
    public class ConsoleRenderer : IRenderer
    {
        private int renderContextMatrixRows;
        private int renderContextMatrixCols;
        private char[,] renderContextMatrix;
        private Vector2D origin;

        public ConsoleRenderer(int visibleConsoleRows, int visibleConsoleCols, Vector2D origin)
        {
            renderContextMatrix = new char[visibleConsoleRows, visibleConsoleCols];

            this.renderContextMatrixRows = renderContextMatrix.GetLength(0);
            this.renderContextMatrixCols = renderContextMatrix.GetLength(1);
            this.origin = origin;

            Console.Title = "Sokoban";
            Console.CursorVisible = false;
            Console.OutputEncoding = UnicodeEncoding.Unicode;
            this.ClearQueue();
            this.Clear();
        }

        public void EnqueueForRender(IRenderable obj)
        {
            char objImage = obj.GetImage();


            Vector2D position = obj.GetPosition() - this.origin;
            if (position.X >= 0 && position.X < renderContextMatrixCols &&
                position.Y >= 0 && position.Y < renderContextMatrixRows)
            {
                renderContextMatrix[position.Y, position.X] = objImage;
            }
            
        }

        public void RenderAll()
        {
            Console.SetCursorPosition(0, 0);

            StringBuilder scene = new StringBuilder();

            for (int row = 0; row < this.renderContextMatrixRows; row++)
            {
                for (int col = 0; col < this.renderContextMatrixCols; col++)
                {
                    scene.Append(this.renderContextMatrix[row, col]);
                    //scene.Append(' ');
                }

                scene.Append(Environment.NewLine);
               // scene.Append(Environment.NewLine);
            }

            Console.WriteLine(scene.ToString());
        }

        //Clear the renderContextMatrix
        public void ClearQueue()
        {
            for (int row = 0; row < this.renderContextMatrixRows; row++)
            {
                for (int col = 0; col < this.renderContextMatrixCols; col++)
                {
                    this.renderContextMatrix[row, col] = ' ';
                }
            }
        }

        //Display message when player has won the game.
        public static void PlayerWon()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();

            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;

            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Congratulations!");

            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 + 1);
            Console.WriteLine("You have won.");
            Console.ReadKey();
        }

        //Display message when time is up.
        public static void DisplayTimeOut()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();

            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;

            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Time is up!");

            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 + 1);
            Console.WriteLine("Try again.");
            System.Threading.Thread.Sleep(2000);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        //Displays level info 
        public void DisplayLevel(int level)
        {
            Console.SetCursorPosition(this.renderContextMatrixCols + 6, 1);

            Console.Write("{0,-6}{1} {2}","Level",':',level);
        }

        //Displays level info 
        public void DisplayShowControls()
        {
            Console.SetCursorPosition(this.renderContextMatrixCols + 6, 3);
            Console.Write("{0,-6}{1} {2}", "R", ':', "Restart");
            Console.SetCursorPosition(this.renderContextMatrixCols + 6, 4);
            Console.Write("{0,-6}{1} {2}", "C", ':', "Controls");
        }
        //Displays time info 
        public void DisplayTimer(int time)
        {
            Console.SetCursorPosition(this.renderContextMatrixCols + 6, 2);

            Console.Write("{0,-6}{1} {2:000}", "Time",':', time);
        }
        //Displays contol info
        public void DisplayControls()
        {
            Console.SetCursorPosition(1, this.renderContextMatrixRows + 1);

            Console.Write("Player 1: up, down, left, right: Arrow keys");

            Console.SetCursorPosition(1, this.renderContextMatrixRows + 2);

            Console.Write("Player 2: up: W, down: S, left: A, right: D");
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
