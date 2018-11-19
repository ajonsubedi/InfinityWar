using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using InfinityWar.Levels;

namespace InfinityWar.Characters
{
    class Thor : Character
    {
        public Vector2 Velocity = new Vector2(0, 0);
        public Controls _controls = new Controls();
        public Boolean isMoving = false;
        const float gravity = 100f;
        float startY, jumpSpeed = 500f;
        public Boolean isJumping = false;
        public Animation Idle;
        int state = 0;
        int nextMoveState = 68;
        int nextIdleState = 52;



        public Thor(Texture2D texture, Vector2 positie, Rectangle viewRectangle) : base(texture, positie, viewRectangle)
        {
            startY = Positie.Y;
            ///Animatie voor movement
            Movement = new Animation();
            for (int i = 0; i < 11; i++)
            {
                Movement.AddFrame(new Rectangle(state, 0, 68, 59));
                state += nextMoveState;
            }
            Movement.AantalBewegingenPerSeconde = 8;

            ///Animatie als Thor stilstaat
            Idle = new Animation();
            for (int i = 0; i < 7; i++)
            {
                Idle.AddFrame(new Rectangle(state, 0, 52, 59));
                state += nextIdleState;
            }

        }

        public void Update(GameTime gameTime)
        {
            Positie += Velocity;
            _controls.Update();

            if (_controls.Left || _controls.Right)
            {
                Movement.Update(gameTime);
                isMoving = true;
            }

            if (isMoving)
            {
                if (_controls.Left)
                {
                    Velocity.X = -3f; ;
                    Console.WriteLine("Thor gaat naar links!");
                    isRight = false;
                }

                else if (_controls.Right)
                {
                    Velocity.X = 3f;
                    Console.WriteLine("Thor gaat naar rechts!");
                    isRight = true;

                }
                else
                {
                    Velocity.X = 0f;
                }


                ///Hier is de code om te springen en voor de zwaartekracht
                if(_controls.Jump && !isJumping)
                {
                    Positie.Y -= 10f;
                    Velocity.Y = -5f;
                    isJumping = true;

                }
                if (isJumping)
                {
                    float i = 1;
                    Velocity.Y += 0.3f * i;
                }
                else
                {
                    Velocity.Y = 0f;
                }

                if (Positie.Y + Texture.Height >= 450)
                {
                    isJumping = false;
                }  
            }
            else
            {
                Idle.Update(gameTime);
                Positie.X += ViewRectangle.X;
            }
        }    
          



        public override void Draw(SpriteBatch spriteBatch)
        {       
           base.Draw(spriteBatch);
        }
    }
}
