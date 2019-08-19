using InfinityWar.Characters;
using InfinityWar.Level;
using InfinityWar.Levels;
using InfinityWar.Levels.Level2;
using InfinityWar.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        Texture2D thorMovingTex, Level1BackgroundTex, Level2BackgroundTex,backTex, mainMenuBGTex, instructionsBGTex,fireballTex, enemyTex, coinTex, spikeTex, doorTex, keyTex, mjolnirTex, nextLevelTex, thanosTex, playButtonTex, instructTex, pauseTex, pausedBGTex, resumeTex, quitTex, gameOverBGTex, restartTex, endgameTex;
        Thor thor;
        Thanos thanos;
        Stage1 stage1 = new Stage1();
        Stage2 stage2 = new Stage2();
        Camera2D camera;
        Background backgroundLevel1, backgroundLevel2, mainMenu, instructions, pausedBG, gameOverBG, endgameBG;
        List<Coin> coins = new List<Coin>();
        List<Spike> spikes = new List<Spike>();
        List<Key> keys = new List<Key>();
        List<NextLevel> nextlevels = new List<NextLevel>();
        List<Enemy> enemies = new List<Enemy>();
        List<FireBall> fireballs = new List<FireBall>();
        Door door;
        Mjolnir mjolnir;
        Button playButton, instructionButton, backButton, pauseButton, resumeButton, quitButton, restartButton;
        Controls controls = new Controls();
        bool level1 = true, level2 = false;
        static Score score;
        static ThanosHealth thanosHealth;
        static Health health;
        static SpriteFont font;
        static Vector2 scorePos, thanosHealthPos, healthPos;
        bool doorIsVisible = true;
        int level1Coins, level1Health;
        bool paused = false;
        Song bgMusic;
        SoundEffect jumpEffect, mjolnirEffect;
        enum GameState //GameState bepalen
        {
            MainMenu,
            Instructions,
            Playing,
            Pause,
            GameOver,
            EndGame
        }
        GameState CurrentGameState = GameState.MainMenu;


        public InfinityWar()
        {
            graphics = new GraphicsDeviceManager(this);
            this.IsMouseVisible = true;
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

        protected override void LoadContent()
        {
            camera = new Camera2D(GraphicsDevice.Viewport);
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //hier worden alle textures opgeladen
            thanosTex = Content.Load<Texture2D>("Thanos");
            enemyTex = Content.Load<Texture2D>("enemy");
            coinTex = Content.Load<Texture2D>("coin");
            spikeTex = Content.Load<Texture2D>("spike");
            doorTex = Content.Load<Texture2D>("door");
            keyTex = Content.Load<Texture2D>("key");
            nextLevelTex = Content.Load<Texture2D>("nextlevel");
            Level1BackgroundTex = Content.Load<Texture2D>("gameBackground");
            Level2BackgroundTex = Content.Load<Texture2D>("level2BG");
            mainMenuBGTex = Content.Load<Texture2D>("mainmenu");
            pausedBGTex = Content.Load<Texture2D>("pausedBG");
            instructionsBGTex = Content.Load<Texture2D>("instructionBG");
            thorMovingTex = Content.Load<Texture2D>("ThorMoving");
            mjolnirTex = Content.Load<Texture2D>("mjolnir");
            font = Content.Load<SpriteFont>("scoreFont");
            playButtonTex = Content.Load<Texture2D>("playButton");
            instructTex = Content.Load<Texture2D>("instructionButton");
            backTex = Content.Load<Texture2D>("back");
            pauseTex = Content.Load<Texture2D>("pause");
            resumeTex = Content.Load<Texture2D>("resume");
            quitTex = Content.Load<Texture2D>("quit");
            gameOverBGTex = Content.Load<Texture2D>("gameoverBG");
            restartTex = Content.Load<Texture2D>("restart");
            endgameTex = Content.Load<Texture2D>("endgame");
            fireballTex = Content.Load<Texture2D>("fireball");

            jumpEffect = Content.Load<SoundEffect>("jump");
            mjolnirEffect = Content.Load<SoundEffect>("mjolnir-sound");

            bgMusic = Content.Load<Song>("avengers-theme");
            for (int i = 0; i < 100; i++)
            {
                MediaPlayer.Play(bgMusic);
            }

            //Buttons
            playButton = new Button(playButtonTex)
            {
                Positie = new Vector2(50, 50),
            };
            playButton.ClickPlay += PlayButton_Click;

            instructionButton = new Button(instructTex)
            {
                Positie = new Vector2(50, 160),
                Text = "Instructions"
            };
            instructionButton.ClickInstruction += InstructionButton_Click1;

            backButton = new Button(backTex)
            {
                Positie = new Vector2(0, 0),
                Text = "Back"
            };
            backButton.ClickBack += BackButton_Click;

            pauseButton = new Button(pauseTex)
            {
                Positie = new Vector2(735, 5)
            };
            pauseButton.ClickPause += PauseButton_ClickPause;

            resumeButton = new Button(resumeTex)
            {
                Positie = new Vector2(200, 320)
            };
            resumeButton.ClickResume += ResumeButton_ClickResume;

            quitButton = new Button(quitTex)
            {
                Positie = new Vector2(450, 320)
            };
            quitButton.ClickQuit += QuitButton_ClickQuit;

            restartButton = new Button(restartTex)
            {
                Positie = new Vector2(200, 320)
            };
            restartButton.ClickRestart += RestartButton_ClickRestart;





            healthPos = new Vector2(175, 15);
            health = new Health(font, healthPos);
            thor = new Thor(thorMovingTex, new Vector2(0, 0), health.health);
            scorePos = new Vector2(5, 15);
            score = new Score(font, scorePos);




            thanosHealth = new ThanosHealth(font, healthPos);
            mjolnir = new Mjolnir(mjolnirTex);
            Tile.Content = Content;
            
            backgroundLevel2 = new Background(Level2BackgroundTex, new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y),
             new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            backgroundLevel1 = new Background(Level1BackgroundTex, new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y),
            new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            mainMenu = new Background(mainMenuBGTex, new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y),
            new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            instructions = new Background(instructionsBGTex, new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y),
            new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            pausedBG = new Background(pausedBGTex, new Vector2(150, 100),
            new Rectangle(150, 100, 533, 320));
            gameOverBG = new Background(gameOverBGTex, new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y),
            new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            endgameBG = new Background(endgameTex, new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y),
            new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));

            stage1.AddEnemiesLevel(enemies, enemyTex);
            stage1.AddCoinsLevel(coins, coinTex);
            stage1.AddSpikes(spikes, spikeTex);
            door = new Door(doorTex, new Vector2(700, 700));
            keys.Add(new Key(keyTex, new Vector2(100, 90)));
            nextlevels.Add(new NextLevel(nextLevelTex, new Vector2(2500, 500)));
            stage1.DrawLevel();

            if (level2)
            {
                stage2.AddEnemiesLevel(enemies, enemyTex);
                stage2.AddCoinsLevel(coins, coinTex);
                stage2.DrawLevel();
                quitButton = new Button(quitTex)
                {
                    Positie = new Vector2(450, 320)
                };
                quitButton.ClickQuit += QuitButton_ClickQuit;
            }
            thanos = new Thanos(thanosTex, new Vector2(1550, 700), 2500, 1550, thanosHealth.health, fireballTex);

        }

        private void RestartButton_ClickRestart(object sender, System.EventArgs e)
        {
            if (level1)
                RestartLevel1();
            keys.Add(new Key(keyTex, new Vector2(100, 90)));
            doorIsVisible = true;
            door.isLocked = true;
            if (level2)
                RestartLevel2();
        }

        private void QuitButton_ClickQuit(object sender, System.EventArgs e)
        {
            CurrentGameState = GameState.MainMenu;
            paused = false;
            health.health = 100;
        }

        private void ResumeButton_ClickResume(object sender, System.EventArgs e)
        {
            CurrentGameState = GameState.Playing;
            paused = false;
        }

        private void PauseButton_ClickPause(object sender, System.EventArgs e)
        {
            CurrentGameState = GameState.Pause;
        }

        private void BackButton_Click(object sender, System.EventArgs e)
        {
            CurrentGameState = GameState.MainMenu;
        }

        private void InstructionButton_Click1(object sender, System.EventArgs e)
        {
            CurrentGameState = GameState.Instructions;
        }

        private void PlayButton_Click(object sender, System.EventArgs e)
        {
            level2 = false;
            level1 = true;
            stage1.DrawLevel();
            RestartLevel1();
            keys.Add(new Key(keyTex, new Vector2(100, 90)));
            doorIsVisible = true;
            door.isLocked = true;
            CurrentGameState = GameState.Playing;
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

            MouseState mouse = Mouse.GetState();
            //Methodes die bij elke level moeten werken
            resumeButton.Update(gameTime);
            quitButton.Update(gameTime);
            if (!paused)
            {
                thor.Update(gameTime, jumpEffect, mjolnirEffect);
                controls.Update();
                playButton.Update(gameTime);
                instructionButton.Update(gameTime);
                backButton.Update(gameTime);
                pauseButton.Update(gameTime);
                restartButton.Update(gameTime);
                foreach (Enemy enemy in enemies)
                {
                    enemy.Update(gameTime);
                    enemy.TurnEnemy(gameTime);
                }
                mjolnir.Update(graphics, gameTime);
                mjolnir.Throw(thor.Positie, thor.Texture, thor.flipSprite);
                //Objecten laten verwijderen bij aanraking
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

                foreach (Coin coin in coins) //coin laten draaien
                {
                    coin.Update(gameTime);
                }

                if (health.health <= 0)
                    CurrentGameState = GameState.GameOver;



                //Methodes die gelden voor level 1
                if (level1)
                {
                    foreach (NextLevel nextlevel in nextlevels)
                    {
                        nextlevel.Update(gameTime);
                    }
                    if (doorIsVisible)
                    {
                        thor.Collision(door.ViewRectangle, stage1.Width, stage1.Height);
                    }


                    //Level 1 herstarten als thor de enemy raakt
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        if (thor.ViewRectangle.Intersects(enemies[i].ViewRectangle))
                        {
                            //CurrentGameState = GameState.GameOver;
                            //RestartLevel1();
                            health.health--;
                        }
                    }

                    //Level 1 herstarten als je op de knop "R" drukt
                    if (controls.Restart)
                    {
                        RestartLevel1();
                    }

                    foreach (CollisionTiles tile in stage1.CollisionTiles)
                    {
                        thor.Collision(tile.Rectangle, stage1.Width, stage1.Height);
                        mjolnir.Collision(tile.Rectangle, stage1.Width, stage1.Height);
                        camera.Update(thor.Positie, stage1.Width, stage1.Height);
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
                            if (mjolnir.ViewRectangle.Intersects(enemy.ViewRectangle))
                            {
                                enemy.isKilled = true;
                            }
                        }
                        //Level 1 herstarten als thor de naalden raakt
                        foreach (Spike spike in spikes)
                        {
                            spike.Collision(tile.Rectangle, stage1.Width, stage1.Height);
                            if (thor.ViewRectangle.Intersects(spike.ViewRectangle))
                            {
                                CurrentGameState = GameState.GameOver;
                                coins.Clear();
                                enemies.Clear();
                                stage1.AddCoinsLevel(coins, coinTex);
                                stage1.AddEnemiesLevel(enemies, enemyTex);
                                thor.Positie.X = 0;
                                thor.Positie.Y = 0;
                                foreach (Key key in keys)
                                {
                                    key.isTaken = false;
                                }
                                keys.Add(new Key(keyTex, new Vector2(100, 90)));
                                score._score = 0;
                                doorIsVisible = true;
                            }
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
                            doorIsVisible = false;
                            if (thor.ViewRectangle.Intersects(door.ViewRectangle))
                            {
                                door.isLocked = false;
                            }
                        }
                    }
                }




                //Methodes die gelden voor level 2
                if (level2)
                {
                    thanos.Update(gameTime);
                    thanos.TurnEnemy(gameTime);
                    thanos.GetDamage(mjolnir.ViewRectangle);
                   // thanos.GiveDamage(thor.ViewRectangle, health.health);
                   //give damage to thor from thanos
                    foreach (FireBall fireball in thanos.fireballs)
                    {
                        if (thor.ViewRectangle.Intersects(fireball.ViewRectangle))
                        {
                            health.health--;
                        }
                        fireball.Update();
                    }

                    for (int i = 0; i < enemies.Count; i++)
                    {
                        if (thor.ViewRectangle.Intersects(enemies[i].ViewRectangle))
                        {
                            //CurrentGameState = GameState.GameOver;
                            //RestartLevel1();
                            health.health--;
                        }
                    }

                    foreach (CollisionTiles tile in stage2.CollisionTiles)
                    {
                        thor.Collision(tile.Rectangle, stage2.Width, stage2.Height);
                        mjolnir.Collision(tile.Rectangle, stage2.Width, stage2.Height);
                        thanos.Collision(tile.Rectangle, stage2.Width, stage2.Height);
                        camera.Update(thor.Positie, stage2.Width, stage2.Height);
                        foreach (Coin coin in coins)
                        {
                            coin.Collision(tile.Rectangle, stage2.Width, stage2.Height);
                            if (thor.ViewRectangle.Intersects(coin.ViewRectangle))
                            {
                                coin.isRemoved = true;
                            }
                        }
                        foreach (Enemy enemy in enemies)
                        {
                            enemy.Collision(tile.Rectangle, stage2.Width, stage2.Height);
                            if (mjolnir.ViewRectangle.Intersects(enemy.ViewRectangle))
                            {
                                enemy.isKilled = true;
                            }
                        }
                        if (thanos.health <= 0)
                        {
                            CurrentGameState = GameState.EndGame;
                        }
                    }
                }

                //Naar level 2
                for (int i = 0; i < nextlevels.Count; i++)
                {
                    if (thor.ViewRectangle.Intersects(nextlevels[0].ViewRectangle))
                    {
                        level1 = false;
                        level2 = true;
                        coins.Clear();
                        enemies.Clear();
                        door.isLocked = false;
                        doorIsVisible = false;
                        spikes.Clear();
                        stage1.ClearMap();
                        stage2.DrawLevel();
                        stage2.AddCoinsLevel(coins, coinTex);
                        stage2.AddEnemiesLevel(enemies, enemyTex);
                        keys.Clear();
                        thor.Positie.X = 0;
                        thor.Positie.Y = 600;
                        nextlevels.Clear();
                        level1Coins = score._score;
                        level1Health = health.health;
                    }
                }
                base.Update(gameTime);
            }
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(thor.bgColor);

            // TODO: Add your drawing code here

            //GAME STATES DRAW
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Begin();
                    mainMenu.Draw(spriteBatch);
                    playButton.Draw(spriteBatch);
                    instructionButton.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
                case GameState.Playing:
                    //Objeten die niet met de camera bewegen
                    MediaPlayer.Volume = 0.2f;
                    spriteBatch.Begin();
                    if (level1)
                        backgroundLevel1.Draw(spriteBatch);

                    if (level2)
                        backgroundLevel2.Draw(spriteBatch);
                    spriteBatch.End();



                    //canvas voor game
                    spriteBatch.Begin(SpriteSortMode.Deferred,
                                      BlendState.AlphaBlend,
                                      null, null, null, null,
                                      camera.Transform);

                    //Objecten die worden getekend in elke level

                    thor.Draw(spriteBatch);

                    foreach (Enemy enemy in enemies)
                    {
                        enemy.Draw(spriteBatch, SpriteEffects.FlipHorizontally);
                    }
                    foreach (Coin coin in coins)
                    {
                        coin.Draw(spriteBatch);
                    }
                    mjolnir.Draw(spriteBatch);


                    //Objecten die worden getekend in level 1
                    if (level1)
                    {
                        stage1.Draw(spriteBatch);
                        foreach (Spike spike in spikes)
                        {
                            spike.Draw(spriteBatch);
                        }
                        foreach (Key key in keys)
                        {
                            if (key.isTaken == false)
                            {
                                key.Draw(spriteBatch);
                            }
                        }
                        if (doorIsVisible)
                        {
                            door.Draw(spriteBatch);
                        }
                        foreach (NextLevel nextlevel in nextlevels)
                        {
                            nextlevel.Draw(spriteBatch);
                        }
                    }

                    //Objecten die worden getekend in level 2
                    if (level2)
                    {
                        stage2.Draw(spriteBatch);
                        thanos.Draw(spriteBatch, SpriteEffects.FlipHorizontally);
                    }
                    spriteBatch.End();

                    //Scoreboard
                    spriteBatch.Begin();
                    score.Draw(spriteBatch);
                    health.Draw(spriteBatch);
                    pauseButton.Draw(spriteBatch);
                    if(level2)
                        thanosHealth.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
                case GameState.Instructions:
                    spriteBatch.Begin();
                    instructions.Draw(spriteBatch);
                    backButton.Draw(spriteBatch);
                    spriteBatch.End();
                    break;

                case GameState.Pause:
                    paused = true;
                    //Objeten die niet met de camera bewegen
                    spriteBatch.Begin();
                    if (level1)
                        backgroundLevel1.Draw(spriteBatch);


                    if (level2)
                        backgroundLevel2.Draw(spriteBatch);
                    spriteBatch.End();



                    //canvas voor game
                    spriteBatch.Begin(SpriteSortMode.Deferred,
                                      BlendState.AlphaBlend,
                                      null, null, null, null,
                                      camera.Transform);
                    //Objecten die worden getekend in elke level

                    thor.Draw(spriteBatch);

                    foreach (Enemy enemy in enemies)
                    {
                        enemy.Draw(spriteBatch, SpriteEffects.FlipHorizontally);
                    }
                    foreach (Coin coin in coins)
                    {
                        coin.Draw(spriteBatch);
                    }
                    mjolnir.Draw(spriteBatch);


                    //Objecten die worden getekend in level 1
                    if (level1)
                    {
                        stage1.Draw(spriteBatch);
                        foreach (Spike spike in spikes)
                        {
                            spike.Draw(spriteBatch);
                        }
                        foreach (Key key in keys)
                        {
                            if (key.isTaken == false)
                            {
                                key.Draw(spriteBatch);
                            }
                        }
                        if (doorIsVisible)
                        {
                            door.Draw(spriteBatch);
                        }
                        foreach (NextLevel nextlevel in nextlevels)
                        {
                            nextlevel.Draw(spriteBatch);
                        }
                    }

                    //Objecten die worden getekend in level 2
                    if (level2)
                    {
                        stage2.Draw(spriteBatch);
                        thanos.Draw(spriteBatch, SpriteEffects.FlipHorizontally);
                        }
                    spriteBatch.End();

                    //Scoreboard
                    spriteBatch.Begin();
                    score.Draw(spriteBatch);
                    pauseButton.Draw(spriteBatch);
                    pausedBG.Draw(spriteBatch);
                    resumeButton.Draw(spriteBatch);
                    quitButton.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
                case GameState.EndGame:
                    spriteBatch.Begin();
                    endgameBG.Draw(spriteBatch);

                    spriteBatch.End();
                    break;
                case GameState.GameOver:
                    spriteBatch.Begin();
                    gameOverBG.Draw(spriteBatch);
                    restartButton.Draw(spriteBatch);
                    quitButton.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
            }

            


            base.Draw(gameTime);
        }

        public void RestartLevel1()
        {
            coins.Clear();
            enemies.Clear();
            stage1.AddCoinsLevel(coins, coinTex);
            stage1.AddEnemiesLevel(enemies, enemyTex);
            stage1.AddSpikes(spikes, spikeTex);
            thor.Positie.X = 0;
            thor.Positie.Y = 0;
            foreach (Key key in keys)
            {
                key.isTaken = false;
            }
            keys.Add(new Key(keyTex, new Vector2(100, 90)));
            nextlevels.Add(new NextLevel(nextLevelTex, new Vector2(2500, 500)));
            score._score = 0;
            health.health = 100;
            doorIsVisible = true;
        }

        public void RestartLevel2()
        {
            level2 = true;
            coins.Clear();
            enemies.Clear();
            thanos.fireballs.Clear();
            stage2.AddCoinsLevel(coins, coinTex);
            stage2.AddEnemiesLevel(enemies, enemyTex);
            thor.Positie.X = 0;
            thor.Positie.Y = 600;
            health.health = 100;
            score._score = level1Coins;
        }
    }
}
