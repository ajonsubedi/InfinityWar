using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace InfinityWar.Characters
{
    class Enemy : Character
    {
        public Animation Movement;
        public Boolean isKilled = false;
        private SpriteEffects flip;
        int state = 0;
        int nextMoveState = 46;
        int End, Start;

        public Enemy(Texture2D texture, Vector2 positie, int start, int end) : base(texture, positie)
        {
            Positie = positie;
            Texture = texture;
            End = end;
            Start = start;
            Movement = new Animation();
            for (int i = 0; i < 3; i++)
            {
                Movement.AddFrame(new Rectangle(state, 0, 46, 48));
                state += nextMoveState;
            }
            Movement.AantalBewegingenPerSeconde = 8;

            flip = SpriteEffects.None;
        }

        public virtual void Update(GameTime gameTime)
        {
            Positie += Velocity;
            ViewRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, 75, 55);
            if (Velocity.Y < 10)
                Velocity.Y += 0.4f;

            Movement.Update(gameTime);
        }


        public void TurnEnemy(GameTime gameTime)
        {
            Movement.Update(gameTime);
            if (Positie.X >= End)
            {
                flip = SpriteEffects.FlipHorizontally;
                Velocity.X = -1f;
            }
            else if(Positie.X <= Start)
            {
                flip = SpriteEffects.None;
                Velocity.X = 1f;
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteEffects spriteEffects)
        {
            Rectangle destinationRect = new Rectangle((int)Positie.X, (int)Positie.Y, Movement.CurrentFrame.SourceRectangle.Width, Movement.CurrentFrame.SourceRectangle.Height);
            spriteBatch.Draw(texture: Texture, destinationRectangle: destinationRect, sourceRectangle: Movement.CurrentFrame.SourceRectangle, color: Color.White, rotation: 0f, origin: new Vector2(0, 0), effects: flip, layerDepth: 0f);

        }
    }
}
