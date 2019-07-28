using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace InfinityWar.Levels
{
    class Door : Sprite
    {
        public Vector2 _velocity;
        public bool isLocked = true;
        public Door(Texture2D texture, Vector2 positie) : base(texture, positie)
        {
            ViewRectangle = new Rectangle((int)Positie.X, (int)Positie.Y + 10, 50, 50);
        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (ViewRectangle.TouchTopOf(newRectangle))
            {
                _velocity.Y = 0f;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(isLocked)
            spriteBatch.Draw(Texture, Positie, Color.White);
        }
    }
}
