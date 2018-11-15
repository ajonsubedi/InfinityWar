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

        public Thor(Texture2D texture, Vector2 positie, Rectangle viewRectangle) : base(texture, positie, viewRectangle)
        {
            Animation = new Animation();
            Animation.AddFrame(new Rectangle(0, 0, 68, 59));
            Animation.AddFrame(new Rectangle(68, 0, 68, 59));
            Animation.AddFrame(new Rectangle(136, 0, 68, 59));
            Animation.AddFrame(new Rectangle(204, 0, 68, 59));
            Animation.AddFrame(new Rectangle(272, 0, 68, 59));
            Animation.AddFrame(new Rectangle(340, 0, 68, 59));
            Animation.AddFrame(new Rectangle(408, 0, 68, 59));
            Animation.AddFrame(new Rectangle(476, 0, 68, 59));
            Animation.AddFrame(new Rectangle(544, 0, 68, 59));
            Animation.AddFrame(new Rectangle(612, 0, 68, 59));
            Animation.AddFrame(new Rectangle(680, 0, 68, 59));
            Animation.AddFrame(new Rectangle(748, 0, 68, 59));
            Animation.AantalBewegingenPerSeconde = 8;
        }

        SpriteEffects flipThor = SpriteEffects.None;
        public override void Update(GameTime gameTime)
        {
            _controls.Update();

            if (_controls.Left || _controls.Right)
            {
                Animation.Update(gameTime);
                isMoving = true;
            }
                
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
           // spriteBatch.Draw(texture: Texture, destinationRectangle: ViewRectangle, sourceRectangle: Animation.CurrentFrame.SourceRectangle, color: Color.AliceBlue, rotation: 0f, origin: null, effects: flipThor, layerDepth: 0f);


        }
    }
}
