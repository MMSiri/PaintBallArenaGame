using System;

namespace PaintBallArenaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBalls = ReadInt(20, "Number of balls");
            int magazineSize = ReadInt(16, "Magazine size");

            Console.Write($"Loaded [false]: ");
            bool.TryParse(Console.ReadLine(), out bool isLoaded);


            PaintballGun gun = new PaintballGun(numberOfBalls, magazineSize, isLoaded);

            while (true)
            {
                Console.WriteLine($"{gun.Balls} balls, {gun.BallsLoaded} loaded");
                if (gun.IsEmpty()) Console.WriteLine("WARNING: Out of Ammo!");
                Console.WriteLine("'Space' = shoot, 'R' = reload, '+' = add ammo, 'Q' = quit");
                char key = Console.ReadKey(true).KeyChar;
                if (key == ' ') Console.WriteLine($"Shooting returned {gun.Shoot()}");
                else if (key == 'R' || key == 'r') gun.Reload();
                else if (key == '+') gun.Balls += gun.MagazineSize;
                else if (key == 'Q' || key == 'q') return;
            }
        }

        static int ReadInt(int lastValueUsed, string prompt)
        {
            Console.Write($"{prompt} [{lastValueUsed}]: ");
            string line = Console.ReadLine();
            if (int.TryParse(line, out int value))
            {
                Console.WriteLine($"using value {value}");
                return value;
            }
            else
            {
                Console.WriteLine($"using default value {lastValueUsed}");
                return lastValueUsed;
            }
        }
    }
}
