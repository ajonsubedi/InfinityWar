using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityWar.Levels.Level2
{
    class ThanosHealth
    {
        public static SpriteFont healthFont { get; set; }
        public Vector2 healthPos { get; set; }
        public int health = 100;
        public Rectangle rectangle = new Rectangle(0, 0, 30, 15);
        Matrix m;
        public ThanosHealth(SpriteFont nHealthFont, Vector2 nHealthPos)
        {
            m = new Matrix();
            healthFont = nHealthFont;
            healthPos = nHealthPos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(healthFont,health.ToString(), healthPos, Color.White);
        }
    }
}
