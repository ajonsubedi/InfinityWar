using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace InfinityWar.Levels
{
    class Coin : Sprite
    {
        public Animation _animation;
        public Vector2 _velocity;
        public bool isRemoved = false;
        public Coin(Texture2D texture, Vector2 positie) : base(texture, positie)
        {
            _animation = new Animation();
            _animation.AddFrame(new Rectangle(0, 0, 30, 30));
            _animation.AddFrame(new Rectangle(30, 0, 30, 30));
            _animation.AddFrame(new Rectangle(60, 0, 30, 30));
            _animation.AddFrame(new Rectangle(90, 0, 30, 30));
            _animation.AddFrame(new Rectangle(120, 0, 30, 30));
            _animation.AddFrame(new Rectangle(150, 0, 30, 30));
            _animation.AantalBewegingenPerSeconde = 8;
        }

        public void Update(GameTime gameTime)
        {
            //coin een gravity geven
            Positie += _velocity;
            ViewRectangle = new Rectangle((int)Positie.X, (int)Positie.Y + 10, 30, 30);


            //Coin laten draaien
            _animation.Update(gameTime);
            ViewRectangle.X += 30;
            if (ViewRectangle.X > 999999999999999999)
                ViewRectangle.X = 0;
            if (_velocity.Y < 30)
                _velocity.Y += 0.4f;
        }

        public void AddCoinsLevel1(List<Coin> coins, Texture2D coinTex)
        {
            coins.Add(new Coin(coinTex, new Vector2(150, 0)));
            coins.Add(new Coin(coinTex, new Vector2(200, 0)));

            coins.Add(new Coin(coinTex, new Vector2(100, 300)));
            coins.Add(new Coin(coinTex, new Vector2(150, 300)));
            coins.Add(new Coin(coinTex, new Vector2(200, 300)));

            coins.Add(new Coin(coinTex, new Vector2(350, 390)));
            coins.Add(new Coin(coinTex, new Vector2(400, 390)));
            coins.Add(new Coin(coinTex, new Vector2(450, 390)));

            coins.Add(new Coin(coinTex, new Vector2(650, 495)));

            coins.Add(new Coin(coinTex, new Vector2(350, 590)));
            coins.Add(new Coin(coinTex, new Vector2(400, 590)));
            coins.Add(new Coin(coinTex, new Vector2(450, 590)));

            coins.Add(new Coin(coinTex, new Vector2(100, 690)));
            coins.Add(new Coin(coinTex, new Vector2(150, 690)));
            coins.Add(new Coin(coinTex, new Vector2(200, 690)));

            coins.Add(new Coin(coinTex, new Vector2(0, 800)));
            coins.Add(new Coin(coinTex, new Vector2(50, 800)));
            coins.Add(new Coin(coinTex, new Vector2(100, 800)));
            coins.Add(new Coin(coinTex, new Vector2(150, 800)));
            coins.Add(new Coin(coinTex, new Vector2(200, 800)));
            coins.Add(new Coin(coinTex, new Vector2(250, 800)));
            coins.Add(new Coin(coinTex, new Vector2(300, 800)));
            coins.Add(new Coin(coinTex, new Vector2(350, 800)));
            coins.Add(new Coin(coinTex, new Vector2(400, 800)));
            coins.Add(new Coin(coinTex, new Vector2(450, 800)));
            coins.Add(new Coin(coinTex, new Vector2(500, 800)));
            coins.Add(new Coin(coinTex, new Vector2(550, 800)));
            coins.Add(new Coin(coinTex, new Vector2(600, 800)));
            coins.Add(new Coin(coinTex, new Vector2(700, 690)));
            coins.Add(new Coin(coinTex, new Vector2(750, 690)));
            coins.Add(new Coin(coinTex, new Vector2(950, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1000, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1050, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1100, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1150, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1200, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1250, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1300, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1350, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1400, 590)));
            coins.Add(new Coin(coinTex, new Vector2(1650, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1900, 640)));
            coins.Add(new Coin(coinTex, new Vector2(2150, 640)));
            coins.Add(new Coin(coinTex, new Vector2(2400, 640)));
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
