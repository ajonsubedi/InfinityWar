using InfinityWar.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityWar
{
   abstract class Character:Sprite
    {
        protected Animation Movement;
        protected SpriteEffects flipSprite;
        public Color bgColor = Color.Aquamarine;
        protected Vector2 Velocity = new Vector2(0, 0);
        public bool isCollide;
        protected Boolean isJumping = false;


        public Character(Texture2D texture, Vector2 positie) : base( texture, positie)
        {
            Texture = texture;
            Positie = positie;
        }

        public virtual void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (ViewRectangle.TouchTopOf(newRectangle))
            {
                ViewRectangle.Y = newRectangle.Y - ViewRectangle.Height;
                Velocity.Y = 0f;
                isJumping = false;
            }
            if (ViewRectangle.TouchLeftOf(newRectangle))
            {
                Positie.X = newRectangle.X - ViewRectangle.Width - 2;
            }
            if (ViewRectangle.TouchRightOf(newRectangle))
            {
                Positie.X = newRectangle.X + 17 ;
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
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(Texture, Positie, Movement.CurrentFrame.SourceRectangle, Color.AliceBlue, 0f, Vector2.Zero, 1f,flipSprite, 0f);
        }
    }
}
