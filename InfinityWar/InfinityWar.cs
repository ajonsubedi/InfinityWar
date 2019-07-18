using InfinityWar.Characters;
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
        Texture2D thorMovingTex, Level1BackgroundTex, Level2BackgroundTex, enemyTex, coinTex, spikeTex, doorTex, keyTex, mjolnirTex, nextLevelTex;
        Thor thor;
        Stage1 stage1 = new Stage1();
        Stage2 stage2 = new Stage2();
        Camera2D camera;
        Background backgroundLevel1, backgroundLevel2;
        List<Coin> coins = new List<Coin>();
        List<Spike> spikes = new List<Spike>();
        List<Key> keys = new List<Key>();
        List<NextLevel> nextlevels = new List<NextLevel>();
        List<Enemy> enemies = new List<Enemy>();
        Door door;
        Mjolnir mjolnir;
        Controls controls = new Controls();
        bool level1 = true, level2 = false;
        static Score score, finalScore;
        static SpriteFont scoreFont, finalScoreFont;
        static Vector2 scorePos, finalScorePos;
        bool doorIsVisible = true;
        int level1Coins;


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
            stage1.AddEnemiesLevel(enemies, enemyTex);




            coinTex = Content.Load<Texture2D>("coin");
            stage1.AddCoinsLevel(coins, coinTex);

            scoreFont = Content.Load<SpriteFont>("scoreFont");
            scorePos = new Vector2(5, 15);
            score = new Score(scoreFont, scorePos);

            spikeTex = Content.Load<Texture2D>("spike");
            stage1.AddSpikes(spikes, spikeTex);

            doorTex = Content.Load<Texture2D>("door");
            door = new Door(doorTex, new Vector2(700, 700));

            keyTex = Content.Load<Texture2D>("key");
            keys.Add(new Key(keyTex, new Vector2(100, 90)));

            mjolnirTex = Content.Load<Texture2D>("mjolnir");
            mjolnir = new Mjolnir(mjolnirTex);

            nextLevelTex = Content.Load<Texture2D>("nextlevel");

            nextlevels.Add(new NextLevel(nextLevelTex, new Vector2(2500, 500)));
            


            Tile.Content = Content;
            stage1.DrawLevel();

            ///Hier worden de achtergronden geïnitialiseerd


            Level1BackgroundTex = Content.Load<Texture2D>("gameBackground");
            Level2BackgroundTex = Content.Load<Texture2D>("level2BG");
            backgroundLevel1 = new Background(Level1BackgroundTex, new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y), 
                         new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            backgroundLevel2 = new Background(Level2BackgroundTex, new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y),
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
            controls.Update();
            foreach (Enemy enemy in enemies)
            {
                enemy.Update(gameTime);
                enemy.TurnEnemy(gameTime);
            }
            mjolnir.Update(graphics, gameTime);
            mjolnir.Throw(thor.Positie, thor.Texture, thor.flipSprite);
            foreach (NextLevel nextlevel in nextlevels)
            {
                nextlevel.Update(gameTime);
            }
            foreach (Coin coin in coins) //coin laten draaien
            {
                coin.Update(gameTime);
            }
            if (doorIsVisible)
            {
                thor.Collision(door.ViewRectangle, stage1.Width, stage1.Height);
            }

            //Level 1 herstarten als thor de enemy raakt
            if (level1)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (thor.ViewRectangle.Intersects(enemies[i].ViewRectangle))
                    {
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
                        thor.isHurt = true;
                        if (thor.isHurt)
                        {
                            thor.health -= 20;
                        }
                    }
                }
            }
            

            //Level 2 herstarten als thor de enemy aanraakt
            if (level2)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (thor.ViewRectangle.Intersects(enemies[i].ViewRectangle))
                    {
                        coins.Clear();
                        enemies.Clear();
                        stage2.AddCoinsLevel(coins, coinTex);
                        stage2.AddEnemiesLevel(enemies, enemyTex);
                        thor.Positie.X = 0;
                        thor.Positie.Y = 600;
                        score._score = level1Coins;
                    }
                }
            }

            //Level 1 herstarten als je op de knop "R" drukt
            if (controls.Restart)
            {
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
                thor.isHurt = true;
                if (thor.isHurt)
                {
                    thor.health -= 20;
                }
            }



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
                    if(mjolnir.ViewRectangle.Intersects(enemy.ViewRectangle))
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
                        thor.isHurt = true;
                        if (thor.isHurt)
                        {
                            thor.health -= 20;
                        }
                    }
                }
            }

            foreach (CollisionTiles tile in stage2.CollisionTiles)
            {
                thor.Collision(tile.Rectangle, stage2.Width, stage2.Height);
                mjolnir.Collision(tile.Rectangle, stage2.Width, stage2.Height);
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
                    enemy.Collision(tile.Rectangle, stage1.Width, stage1.Height);
                    if (mjolnir.ViewRectangle.Intersects(enemy.ViewRectangle))
                    {
                        enemy.isKilled = true;
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
            if(level1)
            backgroundLevel1.Draw(spriteBatch);

            if (level2)
                backgroundLevel2.Draw(spriteBatch);
            spriteBatch.End();



            //canvas voor game
            spriteBatch.Begin(SpriteSortMode.Deferred,
                              BlendState.AlphaBlend,
                              null, null, null, null,
                              camera.Transform);
            stage1.Draw(spriteBatch);
            stage2.Draw(spriteBatch);
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
            if(doorIsVisible)
            {
                door.Draw(spriteBatch);
            }
            mjolnir.Draw(spriteBatch);
            foreach (NextLevel nextlevel in nextlevels)
            {
                nextlevel.Draw(spriteBatch);
            }
            spriteBatch.End();


            //Scoreboard
            spriteBatch.Begin();
            score.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
