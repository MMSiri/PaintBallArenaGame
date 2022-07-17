using System;

namespace PaintBallArenaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            PaintballGun gun = new PaintballGun();

            while (true)
            {
                Console.WriteLine($"{gun.GetBalls()} balls, {gun.GetBallsLoaded()} loaded");
                if (gun.IsEmpty()) Console.WriteLine("WARNING: Out of Ammo!");
                Console.WriteLine("'Space' = shoot, 'R' = reload, '+' = add ammo, 'Q' = quit");
                char key = Console.ReadKey(true).KeyChar;
                if (key == ' ') Console.WriteLine($"Shooting returned {gun.Shoot()}");
                else if (key == 'R' || key == 'r') gun.Reload();
                else if (key == '+') gun.SetBalls(gun.GetBalls() + PaintballGun.MAGAZINE_SIZE);
                else if (key == 'Q' || key == 'q') return;
            }
        }
    }
}
