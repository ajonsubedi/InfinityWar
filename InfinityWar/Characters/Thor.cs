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
        int state = 0;
        int nextState = 68;



        public Thor(Texture2D texture, Vector2 positie, Rectangle viewRectangle) : base(texture, positie, viewRectangle)
        {
            startY = Positie.Y;
            ///Animatie voor movement
             Movement = new Animation();
            for (int i = 0; i < 11; i++)
            {
                Movement.AddFrame(new Rectangle(state, 0, 68, 59));
                state += nextState;
            }
            Movement.AantalBewegingenPerSeconde = 8;

            ///Animatie als Thor stilstaat
            ///            Idle.AddFrame(new Rectangle(0, 0, 52, 59));

        }

        public void Update(GameTime gameTime)
        {
            _controls.Update();

            if (_controls.Left || _controls.Right)
            {
                Movement.Update(gameTime);
                isMoving = true;
            }

                
            if (_controls.Left)
            {
                Positie -= Velocity;
                Console.WriteLine("Thor gaat naar links!");
                isRight = false;
            }
                
            else if (_controls.Right)
            {
                Positie += Velocity;
                Console.WriteLine("Thor gaat naar rechts!");
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
            else if (_controls.Jump)
            {
                    isJumping = true;
                    jumpSpeed = -14;
                    Console.WriteLine("Thor is nu aan het springen!");
            }
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {       
           base.Draw(spriteBatch);
        }
    }
}
