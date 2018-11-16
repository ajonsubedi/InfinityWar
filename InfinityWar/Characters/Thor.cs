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
        public Boolean isMoving = false;
        const float gravity = 100f;
        float startY, jumpSpeed = 500f;
        public Boolean isJumping = false;
        public Animation Idle;



        public Thor(Texture2D texture, Vector2 positie, Rectangle viewRectangle) : base(texture, positie, viewRectangle)
        {
            startY = Positie.Y;
            ///Animatie voor movement
            Movement = new Animation();
            Movement.AddFrame(new Rectangle(0, 0, 68, 59));
            Movement.AddFrame(new Rectangle(68, 0, 68, 59));
            Movement.AddFrame(new Rectangle(136, 0, 68, 59));
            Movement.AddFrame(new Rectangle(204, 0, 68, 59));
            Movement.AddFrame(new Rectangle(272, 0, 68, 59));
            Movement.AddFrame(new Rectangle(340, 0, 68, 59));
            Movement.AddFrame(new Rectangle(408, 0, 68, 59));
            Movement.AddFrame(new Rectangle(476, 0, 68, 59));
            Movement.AddFrame(new Rectangle(544, 0, 68, 59));
            Movement.AddFrame(new Rectangle(612, 0, 68, 59));
            Movement.AddFrame(new Rectangle(680, 0, 68, 59));
            Movement.AddFrame(new Rectangle(748, 0, 68, 59));
            Movement.AantalBewegingenPerSeconde = 8;

            ///Animatie als Thor stilstaat
           /* Idle = new Animation();
            Idle.AddFrame(new Rectangle(0, 0, 52, 59));
            Idle.AddFrame(new Rectangle(52, 0, 52, 59));
            Idle.AddFrame(new Rectangle(104, 0, 52, 59));
            Idle.AddFrame(new Rectangle(156, 0, 52, 59));
            Idle.AddFrame(new Rectangle(208, 0, 52, 59));
            Idle.AddFrame(new Rectangle(260, 0, 52, 59));
            Idle.AddFrame(new Rectangle(312, 0, 52, 59));
            Idle.AddFrame(new Rectangle(364, 0, 52, 59));
            Idle.AantalBewegingenPerSeconde = 8;*/
        }

        public override void Update(GameTime gameTime)
        {
            _controls.Update();

            if (_controls.Left || _controls.Right)
            {
                Movement.Update(gameTime);
                isMoving = true;
            }
           /* else
            {
                Idle.Update(gameTime);
                isMoving = false;
            }*/
                
            if (_controls.Left)
            {
                Positie -= Velocity;
                Console.WriteLine("Left button is ingedrukt");
                isRight = false;
            }
                
            else if (_controls.Right)
            {
                Positie += Velocity;
                Console.WriteLine("Right button is ingedrukt");
                isRight = true;

            }


            //Gravity update
            if (isJumping)
            {
                Positie.Y += jumpSpeed;
                jumpSpeed += 1;
                if(Positie.Y >= startY)
                {
                    Positie.Y = startY;
                    isJumping = false;
                }
            }
            else
            {
                if (_controls.Jump)
                {
                    isJumping = true;
                    jumpSpeed = -14;
                }
            }
          /*  if (_controls.Jump && hasJumped == false)
            {
                Positie.Y -= 10f;
                Velocity.Y = -5f;
                hasJumped = true;
            }

            if(hasJumped == true)
            {
                float i = 1;
                Velocity.Y += 0.20f * i;
            }

            if (Positie.Y + Texture.Height >= 450)
                hasJumped = false;

            if (hasJumped == false)
                Velocity.Y = 0f;*/
           

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {       
           base.Draw(spriteBatch);
        }
    }
}
