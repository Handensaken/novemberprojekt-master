using System.Diagnostics;
using System;
using System.Collections.Generic;
using Raylib_cs;
namespace Snake
{
    public class Snake : GameObject
    {
        public enum Directions
        {
            Up,
            Right,
            Down,
            Left
        }
        Directions direction = Directions.Right;
        public  static List<SnakeTail> tail = new List<SnakeTail>();

        public static List<List<float>> points = new List<List<float>>();

        public Snake()
        {
            rectangle = new Rectangle(800 / 2, 600 / 2, 20, 20);
            gameObjects.Add(this);
        }
        public void EatFood()
        {
            if (tail.Count > 0)
            {
                tail.Add(new SnakeTail(direction, tail[tail.Count - 1].rectangle));
            }
            else
            {
                tail.Add(new SnakeTail(direction, rectangle));
            }
        }

        public static List<Directions> pointDirs = new List<Directions>();
        private void AddPoint()     //Gets position which gets put into a list keeping turning positions
        {
            List<float> point = new List<float>();

            pointDirs.Add(direction);
            point.Add(rectangle.x);
            point.Add(rectangle.y);
            points.Add(point);
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < point.Count; j++)
                {
                    System.Console.WriteLine("point " + i + ": " + points[i][j]);
                }
            }
        }
        bool once = false;
        float timer = 15;
        float timerResetValue = 15;
        public override void Update()
        {
            timer -= 1;
            if (!once)
            {
                EatFood();
                once = true;
            }

            if (timer <= 0)
            {

                //Getting input and setting direction based on input
                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP) && direction != Directions.Up && direction != Directions.Down || Raylib.IsKeyDown(KeyboardKey.KEY_W) && direction != Directions.Up && direction != Directions.Down)
                {
                    direction = Directions.Up;
                    AddPoint();
                    timer = timerResetValue;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && direction != Directions.Right && direction != Directions.Left || Raylib.IsKeyDown(KeyboardKey.KEY_D) && direction != Directions.Right && direction != Directions.Left)
                {
                    direction = Directions.Right;
                    AddPoint();
                    timer = timerResetValue;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) && direction != Directions.Down && direction != Directions.Up || Raylib.IsKeyDown(KeyboardKey.KEY_S) && direction != Directions.Down && direction != Directions.Up)
                {
                    direction = Directions.Down;
                    AddPoint();
                    timer = timerResetValue;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && direction != Directions.Left && direction != Directions.Right || Raylib.IsKeyDown(KeyboardKey.KEY_A) && direction != Directions.Left && direction != Directions.Right)
                {
                    direction = Directions.Left;
                    AddPoint();
                    timer = timerResetValue;
                }

            }
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_E))
            {
                EatFood();
            }

            //Moving based on direction
            switch (direction)
            {
                case Directions.Up:
                    {
                        rectangle.y -= 1f;
                    }
                    break;
                case Directions.Right:
                    {
                        rectangle.x += 1f;
                    }
                    break;
                case Directions.Down:
                    {
                        rectangle.y += 1f;
                    }
                    break;
                case Directions.Left:
                    {
                        rectangle.x -= 1f;
                    }
                    break;
                default:
                    {
                        rectangle.x += 4f;
                    }
                    break;
            }

            foreach (SnakeTail t in tail)
            {
                t.Update(pointDirs);
            }

        }
    }
}
