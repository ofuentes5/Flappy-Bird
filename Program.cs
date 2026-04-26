// See https://aka.ms/new-console-template for more information
using System;
using System.Threading;
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("FLAPPY BIRD");
            Console.WriteLine("Press SPACE to start");
            Console.WriteLine("Press Q to quit");

            var startKey = Console.ReadKey(true);

            if (startKey.Key == ConsoleKey.Q)
                return;

            RunGame();
        }
    }
    static void RunGame()
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
            velocity += 1;
            if (velocity > 3)
                velocity = 3;

            birdY += velocity;


            pipeX--;

            if (pipeX < 0)
            {
                pipeX = 40;
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
            if (pipeX <= 6 && pipeX + 2 >= 5)
            {
                bool inGap = birdY >= gapY && birdY <= gapY + gapSize - 1;

                if (!inGap)
                    break;

            }

            Console.Clear();

            Console.SetCursorPosition(5, birdY);
            Console.Write(velocity < 0 ? "^" : "v");

            for (int y = 0; y < gapY; y++)
            {
                for (int w = 0; w < 3; w++)
                {
                    Console.SetCursorPosition(pipeX + w, y);
                    Console.Write("|");
                }

            }


            for (int y = gapY + gapSize; y < 22; y++)
            {
                for (int w = 0; w < 3; w++)
                {
                    Console.SetCursorPosition(pipeX + w, y);
                    Console.Write("|");
                }

            }
            for (int i = 0; i < 50; i++)
            {
                Console.SetCursorPosition(i, 22);
                Console.Write("-");
            }

            Console.SetCursorPosition(0, 0);
            Console.Write("Score: " + score);

            Thread.Sleep(Math.Max(40, 100 - score * 2));
        }

        Console.Clear();
        Console.WriteLine("Game Over!");
        Console.WriteLine("Score: " + score);
        Console.WriteLine("Press R to restart");
        Console.WriteLine("Press Q to quit");

        while (true)
        {
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.R)
                return;

            if (key.Key == ConsoleKey.Q)
                Environment.Exit(0);
        }
    }
}  


