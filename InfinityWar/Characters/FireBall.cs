using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityWar.Characters
{
    class FireBall
    {
        public Texture2D Texture;
        public Vector2 Positie, Velocity;
        public Rectangle ViewRectangle;
        public bool isVisible;

        public FireBall(Texture2D texture)
        {
            Texture = texture;
            isVisible = false;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Positie, null, Color.White);
        }
        public void Update()
        {
            ViewRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, 40, 25);
        }

    }
}
