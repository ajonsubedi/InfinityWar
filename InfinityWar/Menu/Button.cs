using InfinityWar.Characters;
using InfinityWar.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityWar.Menu
{
    class Button
    {
        //Dit is een klasse dat wordt gebruikt om buttons aan te maken. Hiervoor heb ik hulp gehad langs de volgende link --> https://www.youtube.com/watch?v=lcrgj26G5Hg
        private MouseState currentMouse;
        private bool isHovering;
        private MouseState previousMouse;
        private Texture2D texture;

        public event EventHandler ClickPlay;
        public event EventHandler ClickBack;
        public event EventHandler ClickInstruction;
        public event EventHandler ClickPause;
        public event EventHandler ClickResume;
        public event EventHandler ClickQuit;
        public event EventHandler ClickRestart;

        public bool Clicked { get;set; }
        public Vector2 Positie { get; set; }
        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Positie.X, (int)Positie.Y, texture.Width, texture.Height); }
        }
        public string Text { get; set; }

        public Button(Texture2D nTexture)
        {
            texture = nTexture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var colour = Color.White;
            if (isHovering)
                colour = Color.Gray;
            spriteBatch.Draw(texture, Rectangle, colour);
        }

        public void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);
            isHovering = false;
            if (mouseRectangle.Intersects(Rectangle))
            {
                isHovering = true;
            }

            if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed && isHovering)
            {
                ClickPlay?.Invoke(this, new EventArgs());
                ClickBack?.Invoke(this, new EventArgs());
                ClickInstruction?.Invoke(this, new EventArgs());
                ClickPause?.Invoke(this, new EventArgs());
                ClickResume?.Invoke(this, new EventArgs());
                ClickQuit?.Invoke(this, new EventArgs());
                ClickRestart?.Invoke(this, new EventArgs());
            }

        }
    }
}
