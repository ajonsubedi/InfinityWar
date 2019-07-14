using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityWar
{
    abstract class Sprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Positie;
        public Rectangle ViewRectangle;
        public Rectangle Bounds
        {
           get { return new Rectangle((int)Positie.X, (int)Positie.Y, 92, 50); }
        }


        public Sprite(Texture2D texture, Vector2 positie)
        {
            Texture = texture;
            Positie = positie;
        }




        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Positie, Color.AliceBlue);
        }
    }
}
