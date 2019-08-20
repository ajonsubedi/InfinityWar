using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InfinityWar.Characters
{
    /// <summary>
    /// Dit is een klasse voor de hamer van Thor, hier gebeuren al de acties
    /// </summary>
    class Mjolnir
    {
        public Boolean isVisible, hasKilled = false, isMoving = false;
        public int speed;
        public Vector2 Positie, Velocity;
        public Rectangle ViewRectangle;
        public Texture2D Texture;
        public SpriteEffects flipSprite;
        public Controls _controls = new Controls();
        public Mjolnir(Texture2D texture)
        {
            Positie = new Vector2(0, 0);
            ViewRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, 40, 25);
            speed = 10;
            isVisible = false;
            Texture = texture;
        }
        public void Update(GraphicsDeviceManager graphics, GameTime gameTime)
        {
            Positie.X += Velocity.X;
            //Velocity.X += 0.1f;
            ViewRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, 40, 25);

            if (Positie.X > graphics.PreferredBackBufferWidth)
            {
                isVisible = false;
            }


            
        }
        public void Throw(Vector2 thorPositie, Texture2D thorTexture, SpriteEffects thorSprite)
        {
            _controls.Update();
            if (_controls.Throw)
            {
                Positie.X = thorPositie.X;
                Positie.Y = thorPositie.Y + thorTexture.Height / 4;
                isVisible = true;
                if (thorSprite == SpriteEffects.FlipHorizontally)
                {
                    Velocity.X = -8f;
                    flipSprite = SpriteEffects.FlipHorizontally;
                }

                else if (thorSprite == SpriteEffects.None)
                {
                    Velocity.X = 8f;
                    flipSprite = SpriteEffects.None;

                }
            }
        }

        public void KillEnemy(Rectangle enemyRect, List<Enemy> enemies)
        {
            if (ViewRectangle.Intersects(enemyRect))
            {
                foreach (Enemy enemy in enemies)
                {
                    enemy.isKilled = true;
                }
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].isKilled)
                {
                    enemies.RemoveAt(i);
                }
            }
        }

        public  void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (ViewRectangle.TouchTopOf(newRectangle))
            {
                ViewRectangle.Y = newRectangle.Y - ViewRectangle.Height;
                Velocity.Y = 0f;
            }
            if (ViewRectangle.TouchLeftOf(newRectangle))
            {
                Positie.X = newRectangle.X - ViewRectangle.Width - 2;
            }
            if (ViewRectangle.TouchRightOf(newRectangle))
            {
                Positie.X = newRectangle.X + 17;
            }
            if (ViewRectangle.TouchBottomOf(newRectangle))
            {
                Velocity.Y = 1f;
            }

            if (Positie.X < 0) Positie.X = 0;
            if (Positie.X > xOffset - ViewRectangle.Width) Positie.X = xOffset - ViewRectangle.Width;
            if (Positie.Y < 0) Velocity.Y = 1f;
            if (Positie.Y > yOffset - ViewRectangle.Height) Positie.Y = yOffset - ViewRectangle.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Positie,null, Color.AliceBlue, 0f, Vector2.Zero, 1f, flipSprite, 0f);
        }
    }
}
