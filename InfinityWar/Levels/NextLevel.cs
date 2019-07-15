using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace InfinityWar.Levels
{
    class NextLevel : Sprite
    {
        public Animation _animation;
        public Vector2 _velocity;
        public NextLevel(Texture2D texture, Vector2 positie) : base(texture, positie)
        {
            _animation = new Animation();
            _animation.AddFrame(new Rectangle(0, 0, 100, 100));
            _animation.AddFrame(new Rectangle(100, 0, 100, 100));
            _animation.AantalBewegingenPerSeconde = 2;
        }

        public void Update(GameTime gameTime)
        {
            ViewRectangle = new Rectangle((int)Positie.X, (int)Positie.Y + 10, 100, 100);


            //Coin laten draaien
            _animation.Update(gameTime);
            ViewRectangle.X += 100;
            if (ViewRectangle.X > 100)
                ViewRectangle.X = 0;
            if (_velocity.Y < 100)
                _velocity.Y += 0.4f;
        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (ViewRectangle.TouchTopOf(newRectangle))
            {
                // _rectangle.Y = newRectangle.Y - _rectangle.Height;
                _velocity.Y = 0f;
            }


            /*if (_positie.X < 0) _positie.X = 0;
            if (_positie.X > xOffset - _rectangle.Width) _positie.X = xOffset - _rectangle.Width;
            if (_positie.Y < 0) _velocity.Y = 1f;
            if (_positie.Y > yOffset - _rectangle.Height) _positie.Y = yOffset - _rectangle.Height;*/

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Positie, _animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
