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
        Texture2D Texture;
        Vector2 Positie;
        public  Rectangle Rectangle;
        enum GameState //Gamestate wordt bepaald
        {
            MainMenu,
            Playing,
            Instructions,
            Info,
            GameOver
        }
        GameState CurrentGameState = GameState.MainMenu;


        Color colour = new Color(255, 255, 255, 255);

        public Vector2 size;
        public Button(Texture2D texture, GraphicsDevice graphics)
        {
            Texture = texture;
            size = new Vector2(graphics.Viewport.Width / (int)9.6, graphics.Viewport.Height / (int)5.4);
        }

        bool down;
        public bool isClicked;
        public void Update(MouseState mouse)
        {
            Rectangle = new Rectangle((int)Positie.X, (int)Positie.Y, (int)size.X, (int)size.Y);
            Rectangle mouseRect = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRect.Intersects(Rectangle))
            {
                if (colour.A == 255) down = false;
                if (colour.A == 0) down = true;
                if (down) colour.A += 3; else colour.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;
            }

            else if(colour.A < 255)
            {
                colour.A += 3;
                isClicked = false;
            }
        }

        public void setPosition(Vector2 newPosition)
        {
            Positie = newPosition;
        }

        public void ChangingGameState(Button play, Button instruction,Button info, Thor thor, List<Coin> coins, Stage1 stage1) //Van state veranderen, bv. Menu, Game Over, Instructions en Playing
        {
            MouseState mouse = Mouse.GetState();
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (play.isClicked == true) CurrentGameState = GameState.Playing;
                    play.Update(mouse);

                    if (instruction.isClicked == true) CurrentGameState = GameState.Instructions;
                    instruction.Update(mouse);
                    break;
                case GameState.Playing:
                    if (thor.health < 0)
                    {
                        CurrentGameState = GameState.GameOver;
                        coins.Clear();
                        // AddCoinsLevel1();
                        stage1.ClearMap();
                        stage1.DrawLevel();
                    }
                    break;
                case GameState.Instructions:
                    if (info.isClicked == true) CurrentGameState = GameState.Info;
                    info.Update(mouse);
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle, colour);
        }
    }
}
