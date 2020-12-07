using System;
using Raylib_cs;
namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Snake");
            Raylib.SetTargetFPS(60);
            GameObject snake = new Snake();
            
            

            while (!Raylib.WindowShouldClose())
            {
                snake.Update();
                
                //LOGIK




                //GRAFIK
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BROWN);

                GameObject.DrawAll();

                Raylib.EndDrawing();

            }
        }
    }
}
