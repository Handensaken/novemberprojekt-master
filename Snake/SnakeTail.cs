using System.Collections.Generic;
using System.Globalization;
using System;
using Raylib_cs;
namespace Snake
{
    public class SnakeTail : Snake
    {
        Directions direction;

        public SnakeTail(Directions d, Rectangle r)
        {
            gameObjects.Add(this);

            direction = d;
            switch (d)
            {
                case Directions.Up:
                    {
                        rectangle = r;
                        rectangle.y += 20;
                    }
                    break;
                case Directions.Right:
                    {
                        rectangle = r;
                        rectangle.x -= 20;
                    }
                    break;
                case Directions.Down:
                    {
                        rectangle = r;
                        rectangle.y -= 20;
                    }
                    break;
                case Directions.Left:
                    {
                        rectangle = r;
                        rectangle.x += 20;
                    }
                    break;
            }

        }
        public void Update(List<Directions> dir)
        {
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

            if (points.Count > 0)
            {
                System.Console.WriteLine("tail x pos: " + rectangle.x);
                System.Console.WriteLine("tail y pos: " + rectangle.y);

                //if (rectangle.x >= points[0][0] - 1 && rectangle.x <= points[0][0] + 1) { rectangle.x = points[0][0]; }
                //if (rectangle.y >= points[0][1] - 1 && rectangle.y <= points[0][1] + 1) { rectangle.y = points[0][1]; }


                if (tail[tail.Count - 1].rectangle.x == points[0][0] && tail[tail.Count - 1].rectangle.y == points[0][1])
                {
                    direction = dir[0];
                    points.RemoveAt(0);
                    dir.RemoveAt(0);
                }
                else if (rectangle.x == points[0][0] && rectangle.y == points[0][1])
                {
                    direction = dir[0];
                }
            }
        }
    }
}