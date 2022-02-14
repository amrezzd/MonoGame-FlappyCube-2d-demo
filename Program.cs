using System;

namespace FlappyCube
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
            {
                game.IsFixedTimeStep = true;
                game.TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0f / 60);
                game.Run();
            }
        }
    }
}
