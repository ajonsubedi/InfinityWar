using InfinityWar.Characters;
using InfinityWar.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityWar.Level
{
    class Collision
    {
        public void SpriteCollide(Sprite obj1, Sprite obj2, Sprite obj3)
        {
            if(obj1.Positie.X < obj2.Positie.X + obj2.ViewRectangle.Width && 
               obj1.Positie.X + obj1.ViewRectangle.Width > obj2.Positie.X &&
               obj1.Positie.Y < obj2.Positie.Y + obj2.ViewRectangle.Height &&
               obj1.Positie.Y + obj1.ViewRectangle.Height > obj2.Positie.Y)
            {
                Console.WriteLine("Er werd collision gedetecteerd!");
                obj1.Positie.X = obj2.Positie.X - obj1.ViewRectangle.Width;
                obj1.Positie.Y = obj2.Positie.Y - obj1.ViewRectangle.Height;
            }
            else if(obj3.Positie.X < obj2.Positie.X + obj2.ViewRectangle.Width &&
                    obj3.Positie.X + obj3.ViewRectangle.Width > obj2.Positie.X &&
                    obj3.Positie.Y < obj2.Positie.Y + obj2.ViewRectangle.Height &&
                    obj3.Positie.Y + obj3.ViewRectangle.Height > obj2.Positie.Y)
            {
                Console.WriteLine("Er werd collision gedetecteerd!");
                obj3.Positie.X = obj2.Positie.X - obj3.ViewRectangle.Width;
                obj3.Positie.Y = obj2.Positie.Y - obj3.ViewRectangle.Height;
            }
        }
       
    }
}
