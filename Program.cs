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
        }
    }
}


