using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace InfinityWar.Characters
{
    class Thor : Character
    {
        public Vector2 Velocity = new Vector2(2, 0);
        
        public Controls _controls = new Controls();
        float rotation;

        public Thor(Texture2D texture, Vector2 positie) : base(texture, positie)
        {
            _animation = new Animation();
            _animation.AddFrame(new Rectangle(0, 0, 134, 100));
            _animation.AddFrame(new Rectangle(134, 0, 134, 100));
            _animation.AddFrame(new Rectangle(268, 0, 134, 100));
            _animation.AddFrame(new Rectangle(402, 0, 134, 100));
            _animation.AddFrame(new Rectangle(536, 0, 134, 100));
            _animation.AddFrame(new Rectangle(670, 0, 134, 100));
            _animation.AddFrame(new Rectangle(804, 0, 134, 100));
            _animation.AddFrame(new Rectangle(938, 0, 134, 100));
            _animation.AddFrame(new Rectangle(1072, 0, 134, 100));
            _animation.AddFrame(new Rectangle(1206, 0, 134, 100));
            _animation.AddFrame(new Rectangle(1340, 0, 134, 100));
            _animation.AantalBewegingenPerSeconde = 8;

        }

        SpriteEffects flipThor = SpriteEffects.None;
        public override void Update(GameTime gameTime)
        {
            _controls.Update();

            if (_controls.Left || _controls.Right)
                _animation.Update(gameTime);
            if (_controls.Left)
            {
                Positie -= Velocity;
                Console.WriteLine("Left button is ingedrukt");
                flipThor = SpriteEffects.FlipHorizontally;
            }
                
            if (_controls.Right)
            {
                Positie += Velocity;
                Console.WriteLine("Right button is ingedrukt");
                flipThor = SpriteEffects.None;

            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

       }
    }
}
