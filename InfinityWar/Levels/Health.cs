using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityWar.Levels
{
    class Health
    {
        public static SpriteFont HealthFont { get; set; }
        public Vector2 HealthPos { get; set; }
        public int health = 100;
        public Rectangle rectangle = new Rectangle(0, 0, 30, 15);
        Matrix m;
        public Health(SpriteFont nHealthFont, Vector2 nHealthPos)
        {
            m = new Matrix();
            HealthFont = nHealthFont;
            HealthPos = nHealthPos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(HealthFont, "Health: " + health.ToString(), HealthPos, Color.White);
        }
    }
}
