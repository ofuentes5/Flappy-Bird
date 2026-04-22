// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
class Program
{
    static void Main()
    {
        int birdY = 10;
        int pipeX = 30;
        int gapY = 8;
        int velocity = 0;
        int score = 0;

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
                    velocity = -3;
                }
            }
            velocity++;
            birdY += velocity;


            pipeX--;

            if (pipeX < 0)
            {
                pipeX = 30;
                gapY = rand.Next(5, 15);
                score++;
            }
            if (birdY < 0 || birdY > 20)
                break;

            if (pipeX == 5 && (birdY < gapY || birdY > gapY + 4))
                break;

            Console.Clear();

            Console.SetCursorPosition(5, birdY);
            Console.Write("O");

            for (int i = 0; i < gapY; i++)
            {
                Console.SetCursorPosition(pipeX, i);
                Console.Write("|");
            }


            for (int i = gapY + 5; i < 25; i++)
            {
                Console.SetCursorPosition(pipeX, i);
                Console.Write("|");

            }
            Console.SetCursorPosition(0, 0);
            Console.Write("Score: " + score);
            Thread.Sleep(100);


        }
    }
}


