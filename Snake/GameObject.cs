using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Snake
{
    public class GameObject
    {
        public static List<GameObject> gameObjects = new List<GameObject>();
        public Rectangle rectangle;
        public virtual void Update(){
                        
        }

        public virtual void Draw(){
            Raylib.DrawRectangleRec(rectangle, Color.BLACK);
        }
        public static void DrawAll(){
            foreach (GameObject g in gameObjects)
            {
                g.Draw();
            }
        }
    }
}
