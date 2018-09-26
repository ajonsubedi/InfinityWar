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
        public Texture2D _texture;
        public Rectangle _viewRectangle;
        public Vector2 Positie;
        public Animation _animation;

        public Character(Texture2D texture, Vector2 positie)
        {
            _texture = texture;
            Positie = positie;
            _viewRectangle = new Rectangle(0, 0, 136, 104);
        }

        public virtual void Update(GameTime gameTime)
        {

            /*_viewRectangle.X += 136;
            if (_viewRectangle.X > 1504)
                _viewRectangle.X = 0;*/
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Positie, _animation.CurrentFrame.SourceRectangle, Color.AliceBlue);
        }
    }
}
