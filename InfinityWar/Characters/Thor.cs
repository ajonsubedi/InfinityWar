using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using InfinityWar.Levels;
using Microsoft.Xna.Framework.Audio;

namespace InfinityWar.Characters
{
    /// <summary>
    /// Dit is een klasse voor de hero Thor, hier gebeuren al zijn bewegingen en acties
    /// </summary>
    class Thor : Character
    {
        public Controls _controls = new Controls();
        public Boolean isMoving = false;
        int state = 0;
        int nextMoveState = 68;
        public bool isHurt = false;
        public int health;

        public Thor(Texture2D texture, Vector2 positie, int nHealth) : base(texture, positie)
        {
            Positie = positie;
            Texture = texture;
            ///Animatie voor movement
            Movement = new Animation();
            for (int i = 0; i < 11; i++)
            {
                Movement.AddFrame(new Rectangle(state, 0, 68, 59));
                state += nextMoveState;
            }
            Movement.AantalBewegingenPerSeconde = 8;
            ViewRectangle = new Rectangle((int)positie.X, (int)positie.Y, 68, 59);
            health = nHealth;
        }


        public void Update(GameTime gameTime, SoundEffect jump, SoundEffect mjolnir)
        {
            Positie += Velocity;
            _controls.Update();
            Velocity.Y += 0.15f;
            ViewRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, 68, 59);

            if (_controls.Left || _controls.Right)
            {
                Movement.Update(gameTime);
                isMoving = true;
                Console.WriteLine("Positie X: " + Positie.X + "   " + "Positie Y: " + Positie.Y);
            }

            if (isMoving)
            {
                if (_controls.Left)
                {
                    Velocity.X = -3f; ;
                    flipSprite = SpriteEffects.FlipHorizontally;
                }
                else if (_controls.Right)
                {
                    Velocity.X = 3f;
                    flipSprite = SpriteEffects.None;
                }
                else
                {
                    Velocity.X = 0f;
                }

                ///Hier is de code om te springen
                if(_controls.Jump && !isJumping)
                {
                    Positie.Y -= 10f;
                    Velocity.Y = -6f;
                    isJumping = true;
                    jump.Play();
                }
                if (_controls.Throw)
                {
                    mjolnir.Play();
                }
            }
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            if (health >= 1 || Positie.Y > 0)
            base.Draw(spriteBatch);
        }
    }
}
