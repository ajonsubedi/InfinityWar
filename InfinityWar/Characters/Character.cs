using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityWar
{
    class Character
    {
        public Texture2D Texture;
        public Rectangle ViewRectangle;
        public Vector2 Positie;
        public Animation Movement;
        public Boolean isRight = true;

        public Character(Texture2D texture, Vector2 positie, Rectangle viewRectangle)
        {
            Texture = texture;
            Positie = positie;
            ViewRectangle = viewRectangle;
        }

        public Character(Texture2D texture, Rectangle viewRectangle)
        {
            Texture = texture;
            ViewRectangle = viewRectangle;
        }

        public virtual void Update(GameTime gameTime)
        {

            /*_viewRectangle.X += 136;
            if (_viewRectangle.X > 1504)
                _viewRectangle.X = 0;*/
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Positie, Movement.CurrentFrame.SourceRectangle, Color.AliceBlue);
        }
    }
}
