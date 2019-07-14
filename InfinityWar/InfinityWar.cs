﻿using InfinityWar.Characters;
using InfinityWar.Level;
using InfinityWar.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace InfinityWar
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class InfinityWar : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D thorMovingTex, gameBackgroundTex, enemyTex, coinTex, spikeTex, doorTex, keyTex, mjolnirTex;
        Thor thor, thorIdle;
        Enemy enemy;
        Stage1 stage1 = new Stage1();
        Camera2D camera;
        Background background;
        List<Coin> coins = new List<Coin>();
        List<Spike> spikes = new List<Spike>();
        List<Key> keys = new List<Key>();
        Door door;
        List<Enemy> enemies = new List<Enemy>();
        Mjolnir mjolnir;
        static Score score, finalScore;
        static SpriteFont scoreFont, finalScoreFont;
        static Vector2 scorePos, finalScorePos;
        bool doorisLocked = true;
        int heartX = 150;


        public InfinityWar()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 

        public void AddCoinsStage1()
        {
            coins.Add(new Coin(coinTex, new Vector2(150, 0)));
            coins.Add(new Coin(coinTex, new Vector2(200, 0)));

            coins.Add(new Coin(coinTex, new Vector2(100, 300)));
            coins.Add(new Coin(coinTex, new Vector2(150, 300)));
            coins.Add(new Coin(coinTex, new Vector2(200, 300)));

            coins.Add(new Coin(coinTex, new Vector2(350, 390)));
            coins.Add(new Coin(coinTex, new Vector2(400, 390)));
            coins.Add(new Coin(coinTex, new Vector2(450, 390)));

            coins.Add(new Coin(coinTex, new Vector2(650, 495)));

            coins.Add(new Coin(coinTex, new Vector2(350, 590)));
            coins.Add(new Coin(coinTex, new Vector2(400, 590)));
            coins.Add(new Coin(coinTex, new Vector2(450, 590)));

            coins.Add(new Coin(coinTex, new Vector2(100, 690)));
            coins.Add(new Coin(coinTex, new Vector2(150, 690)));
            coins.Add(new Coin(coinTex, new Vector2(200, 690)));

            coins.Add(new Coin(coinTex, new Vector2(0, 800)));
            coins.Add(new Coin(coinTex, new Vector2(50, 800)));
            coins.Add(new Coin(coinTex, new Vector2(100, 800)));
            coins.Add(new Coin(coinTex, new Vector2(150, 800)));
            coins.Add(new Coin(coinTex, new Vector2(200, 800)));
            coins.Add(new Coin(coinTex, new Vector2(250, 800)));
            coins.Add(new Coin(coinTex, new Vector2(300, 800)));
            coins.Add(new Coin(coinTex, new Vector2(350, 800)));
            coins.Add(new Coin(coinTex, new Vector2(400, 800)));
            coins.Add(new Coin(coinTex, new Vector2(450, 800)));
            coins.Add(new Coin(coinTex, new Vector2(500, 800)));
            coins.Add(new Coin(coinTex, new Vector2(550, 800)));
            coins.Add(new Coin(coinTex, new Vector2(600, 800)));
            coins.Add(new Coin(coinTex, new Vector2(700, 690)));
            coins.Add(new Coin(coinTex, new Vector2(750, 690)));
            coins.Add(new Coin(coinTex, new Vector2(950, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1000, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1050, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1100, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1150, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1200, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1250, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1300, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1350, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1400, 590)));
            coins.Add(new Coin(coinTex, new Vector2(1650, 640)));
            coins.Add(new Coin(coinTex, new Vector2(1900, 640)));
            coins.Add(new Coin(coinTex, new Vector2(2150, 640)));
            coins.Add(new Coin(coinTex, new Vector2(2400, 640)));
        }
        protected override void LoadContent()
        {
            camera = new Camera2D(GraphicsDevice.Viewport);
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //hier worden alle objecten op het scherm getoond
            thorMovingTex = Content.Load<Texture2D>("ThorMoving");
            thor = new Thor(thorMovingTex, new Vector2(0, 0), 10);

            enemyTex = Content.Load<Texture2D>("enemy");
            enemies.Add(new Enemy(enemyTex, new Vector2(100, 640), 100, 200));
            enemies.Add(new Enemy(enemyTex, new Vector2(350, 585), 350, 450));
            enemies.Add(new Enemy(enemyTex, new Vector2(350, 385), 350, 450));
            enemies.Add(new Enemy(enemyTex, new Vector2(100, 295), 100,200));
            enemies.Add(new Enemy(enemyTex, new Vector2(150, 0), 150, 200));
            enemies.Add(new Enemy(enemyTex, new Vector2(200, 790), 200, 550));




            coinTex = Content.Load<Texture2D>("coin");
            AddCoinsStage1();

            scoreFont = Content.Load<SpriteFont>("scoreFont");
            scorePos = new Vector2(5, 15);
            score = new Score(scoreFont, scorePos);

            spikeTex = Content.Load<Texture2D>("spike");
            spikes.Add(new Spike(spikeTex, new Vector2(800, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(850, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(900, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(950, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1000, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1050, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1100, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1150, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1200, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1250, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1300, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1350, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1400, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1450, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1500, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1550, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1600, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1650, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1700, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1750, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1800, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1850, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1900, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(1950, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2000, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2050, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2100, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2150, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2200, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2250, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2300, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2350, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2400, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2450, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2500, 800)));
            spikes.Add(new Spike(spikeTex, new Vector2(2550, 800)));

            doorTex = Content.Load<Texture2D>("door");
            door = new Door(doorTex, new Vector2(700, 700));

            keyTex = Content.Load<Texture2D>("key");
            keys.Add(new Key(keyTex, new Vector2(100, 90)));

            mjolnirTex = Content.Load<Texture2D>("mjolnir");
            mjolnir = new Mjolnir(mjolnirTex);



            Tile.Content = Content;
            stage1.DrawLevel1();

            ///Hier worden de achtergronden geïnitialiseerd
            gameBackgroundTex = Content.Load<Texture2D>("gameBackground");
            background = new Background(gameBackgroundTex, new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y), 
                                        new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));



        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            thor.Update(gameTime);
            //for (int i = 0; i < enemies.Count; i++)
            //{
            //    enemies[i].Update(gameTime);
            //    enemies[i].TurnEnemy(gameTime);
            //}
            foreach (Enemy enemy in enemies)
            {
                enemy.Update(gameTime);
                enemy.TurnEnemy(gameTime);
            }
            

            mjolnir.Update(graphics, gameTime);
            mjolnir.Throw(thor.Positie, thor.Texture, thor.flipSprite);
            foreach (Coin coin in coins) //coin laten draaien
            {
                coin.Update(gameTime);
            }
            foreach (CollisionTiles tile in stage1.CollisionTiles)
            {
                thor.Collision(tile.Rectangle, stage1.Width, stage1.Height);
                mjolnir.Collision(tile.Rectangle, stage1.Width, stage1.Height);
                camera.Update(thor.Positie, stage1.Width, stage1.Height);

                //for (int i = 0; i < enemies.Count; i++)
                //{
                //    enemies[i].Collision(tile.Rectangle, stage1.Width, stage1.Height);
                //   // mjolnir.KillEnemy(enemies[i].ViewRectangle, enemies);
                //    if (mjolnir.ViewRectangle.Intersects(enemies[i].ViewRectangle))
                //    {
                //        foreach (Enemy enemy in enemies)
                //        {
                //            enemy.isKilled = true;
                //        }
                //    }
                    
                //}
                //for (int j = 0; j < enemies.Count; j++)
                //{
                //    if (enemies[j].isKilled)
                //    {
                //        enemies.RemoveAt(j);
                //    }
                //}
                foreach (Coin coin in coins)
                {
                     coin.Collision(tile.Rectangle, stage1.Width, stage1.Height);
                    if (thor.ViewRectangle.Intersects(coin.ViewRectangle))
                    {
                        coin.isRemoved = true;
                    }
                }

                foreach (Enemy enemy in enemies)
                {
                    enemy.Collision(tile.Rectangle, stage1.Width, stage1.Height);
                    if(mjolnir.ViewRectangle.Intersects(enemy.ViewRectangle))
                    {
                        enemy.isKilled = true;
                    }
                }
                if (doorisLocked)
                {
                    thor.Collision(door.ViewRectangle, stage1.Width, stage1.Height);
                }
                foreach (Spike spike in spikes)
                {

                    spike.Collision(tile.Rectangle, stage1.Width, stage1.Height);
                    if (thor.ViewRectangle.Intersects(spike.ViewRectangle))
                    {
                        coins.Clear();
                        AddCoinsStage1();
                        thor.Positie.X = 0;
                        thor.Positie.Y = 0;
                        foreach (Key key in keys)
                        {
                            key.isTaken = false;
                        }
                        keys.Add(new Key(keyTex, new Vector2(100, 90)));
                        score._score = 0;
                        doorisLocked = true;
                        thor.isHurt = true;
                        if (thor.isHurt)
                        {
                            thor.health -= 20;
                        }
                    }
                }

                for (int i = 0; i < coins.Count; i++)
                {
                    if (coins[i].isRemoved)
                    {
                        coins.RemoveAt(i);
                        score._score++;
                    }
                }
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].isKilled)
                    {
                        enemies.RemoveAt(i);
                    }
                }

                foreach (Key key in keys)
                {
                    if (thor.ViewRectangle.Intersects(key.ViewRectangle))
                    {
                        key.isTaken = true;
                    }
                }
                for (int i = 0; i < keys.Count; i++)
                {
                    if (keys[i].isTaken)
                    {
                        keys.RemoveAt(i);
                        doorisLocked = false;
                        if (thor.ViewRectangle.Intersects(door.ViewRectangle))
                        {
                            door.isLocked = false;
                        }
                    }
                }

            }
            







            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(thor.bgColor);

            // TODO: Add your drawing code here

            //Objeten die niet met de camera bewegen
            spriteBatch.Begin();
            background.Draw(spriteBatch);
            spriteBatch.End();



            //canvas voor game
            spriteBatch.Begin(SpriteSortMode.Deferred,
                              BlendState.AlphaBlend,
                              null, null, null, null,
                              camera.Transform);
            stage1.Draw(spriteBatch);
            thor.Draw(spriteBatch);
            
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch, SpriteEffects.FlipHorizontally);
            }
            foreach (Coin coin in coins)
            {
                coin.Draw(spriteBatch);
            }
            foreach (Spike spike in spikes)
            {
                spike.Draw(spriteBatch);
            }

            foreach (Key key in keys)
            {
                if(key.isTaken == false)
                {
                    key.Draw(spriteBatch);
                }
            }


            if(doorisLocked)
            {
                door.Draw(spriteBatch);
            }
            mjolnir.Draw(spriteBatch);

            spriteBatch.End();


            //Scoreboard
            spriteBatch.Begin();
            score.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
