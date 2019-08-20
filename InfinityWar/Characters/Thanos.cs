using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace InfinityWar.Characters
{
    /// <summary>
    /// Dit is een klasse voor de Thanos, hier gebeuren al zijn bewegingen en acties
    /// </summary>
    class Thanos : Character
    {
        public Boolean isKilled = false;
        public int state = 0;
        public int nextMoveState = 74;
        public int End, Start;
        private SpriteEffects flip;
        public int health;
        //Fireballs
        public List<FireBall> fireballs = new List<FireBall>();
        Texture2D fireballTexture;

        public Thanos(Texture2D texture, Vector2 positie, int end, int start, int nHealth, Texture2D nFireballTexture) : base(texture, positie)
        {
            Positie = positie;
            Texture = texture;
            fireballTexture = nFireballTexture;
            End = end;
            Start = start;
            Movement = new Animation();
            for (int i = 0; i < 3; i++)
            {
                Movement.AddFrame(new Rectangle(state, 0, 74, 97));
                state += nextMoveState;
            }
            Movement.AantalBewegingenPerSeconde = 2;
            flip = SpriteEffects.None;
            health = nHealth;
        }

        public void UpdateFireball()
        {
            foreach (FireBall fireball in fireballs)
            {
                fireball.Positie += fireball.Velocity;
                if (fireball.Positie.X < 0)
                    fireball.isVisible = false;
            }

            for (int i = 0; i < fireballs.Count; i++)
            {
                if (!fireballs[i].isVisible)
                {
                    fireballs.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Shoot()
        {
            FireBall nFireball = new FireBall(fireballTexture);
            nFireball.Velocity.X = Velocity.X - 3f;
            nFireball.Positie = new Vector2(Positie.X + nFireball.Velocity.X,
                Positie.Y + (Texture.Height / 2) - (fireballTexture.Height / 2));
            nFireball.isVisible = true;
            if (fireballs.Count() < 10)
                fireballs.Add(nFireball);
        }


        float shoot = 0;
        public override void Update(GameTime gameTime)
        {
            Positie += Velocity;
            ViewRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, 74, 97);
            if (Velocity.Y < 5)
                Velocity.Y += 0.4f;

            Movement.Update(gameTime);
            shoot += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (shoot > 1)
            {
                shoot = 0;
                Shoot();
            }
            UpdateFireball();
            base.Update(gameTime);
        }

        public void TurnEnemy(GameTime gameTime)
        {
            Movement.Update(gameTime);
            if (Positie.X >= End)
            {
                flip = SpriteEffects.FlipHorizontally;
                Velocity.X = -1f;
            }
            else if (Positie.X <= Start)
            {
                flip = SpriteEffects.None;
                Velocity.X = 1f;
            }
        }

        public void GetDamage(Rectangle mjolnirRect)
        {
            if (mjolnirRect.Intersects(ViewRectangle))
            {
                health--;
                Console.WriteLine("Thanos is hurt");
                Console.WriteLine(health);
            }
        }


        public void GiveDamage(Rectangle thorRect, int thorHealth)
        {
            foreach (FireBall fireball in fireballs)
            {
                if (thorRect.Intersects(fireball.ViewRectangle))
                {
                    thorHealth--;
                }
                fireball.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteEffects spriteEffects)
        {
            foreach (FireBall fireball in fireballs)
            {
                fireball.Draw(spriteBatch);
            }
            Rectangle destinationRect = new Rectangle((int)Positie.X, (int)Positie.Y, Movement.CurrentFrame.SourceRectangle.Width, Movement.CurrentFrame.SourceRectangle.Height);
            spriteBatch.Draw(texture: Texture, destinationRectangle: destinationRect, sourceRectangle: Movement.CurrentFrame.SourceRectangle, color: Color.White, rotation: 0f, origin: new Vector2(0, 0), effects: flip, layerDepth: 0f);

        }
    }
}
