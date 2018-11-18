using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityWar
{
   abstract class Character:Sprite
    {
        public Animation Movement;
        public Boolean isRight = true;

        public Character(Texture2D texture, Vector2 positie,Rectangle viewRectangle): base(texture, positie, viewRectangle)
        {
            Texture = texture;
            Positie = positie;
            ViewRectangle = viewRectangle;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Positie, Movement.CurrentFrame.SourceRectangle, Color.AliceBlue);
        }
    }
}
