// See https://aka.ms/new-console-template for more information
using System;
using System.Threading;
class Program
{
    static void Main()
    {
        int birdY = 10;
        int pipeX = 30;
        int gapY = 8;
        int gapSize = 5;
        int velocity = 0;
        int score = 0;

        bool passedPipe = false; 

        Random rand = new Random();

        Console.CursorVisible = false;

        while (true)
        {
            // INPUT (press space to jump)
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Spacebar)
                {
                    velocity = -5;
                }
            }

            velocity++;
            birdY += velocity;


            pipeX--;

            if (pipeX < 0)
            {
                pipeX = 30;
                gapY = rand.Next(5, 15);
                passedPipe = false;
            }

            if (!passedPipe && pipeX < 5)
            {
                score++;
                passedPipe = true; 
            }
            if (birdY < 0 || birdY > 20)
            {
                break;
            }
            if (pipeX >= 4 && pipeX <= 6)
            {
                bool inGap = birdY >= gapY && birdY <= gapY + gapSize - 1;

                if (!inGap)
                    break;

            }

            Console.Clear();

            Console.SetCursorPosition(5, birdY);
            Console.Write("O");

            for (int x = 0; x < gapY; x++)
            {
                Console.SetCursorPosition(pipeX, x);
                Console.Write("|");
            }


            for (int x = gapY + gapSize; x < 25; x++)
            {
                Console.SetCursorPosition(pipeX, x);
                Console.Write("|");

            }
            Console.SetCursorPosition(0, 0);
            Console.Write("Score: " + score);

            Thread.Sleep(100);
        }

        Console.Clear();
        Console.WriteLine("Game Over!");
        Console.WriteLine("Score: " + score);
    }
}    


