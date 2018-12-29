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
        Texture2D thorMovingTex, thorIdleTex, gameBackgroundTex, enemyTex;
        Thor thor, thorIdle;
        Enemy enemy;
        Stage1 stage1 = new Stage1();
        Camera2D camera;
        Background background;
        List<Enemy> enemiesLevel1 = new List<Enemy>();


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
        protected override void LoadContent()
        {
            camera = new Camera2D(GraphicsDevice.Viewport);
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //hier worden alle objecten op het scherm getoond
            thorMovingTex = Content.Load<Texture2D>("ThorMoving");
            thor = new Thor(thorMovingTex, new Vector2(0, 0));

            enemyTex = Content.Load<Texture2D>("enemy");
            enemy = new Enemy(enemyTex, new Vector2(200, 0));
           // enemiesLevel1.Add(new Enemy(enemyTex, new Vector2(300, 0)));

            Tile.Content = Content;
            stage1.DrawLevel1();

            thorIdleTex = Content.Load<Texture2D>("ThorIdle");
            //thorIdle = new Thor(thorIdleTex, new Vector2(0, 400));

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
           // enemiesLevel1[0].Update(gameTime);
            foreach (CollisionTiles tile in stage1.CollisionTiles)
            {
                thor.Collision(tile.Rectangle, stage1.Width, stage1.Height);
                camera.Update(thor.Positie, stage1.Width, stage1.Height);
                enemy.Collision(tile.Rectangle, stage1.Width, stage1.Height);

            }

            //enemies
            // enemiesLevel1[0].MoveEnemyAround(400, 300);






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


            spriteBatch.Begin(SpriteSortMode.Deferred,
                              BlendState.AlphaBlend,
                              null, null, null, null,
                              camera.Transform);
            stage1.Draw(spriteBatch);
            thor.Draw(spriteBatch);
            foreach (Enemy enemy in enemiesLevel1)
            {
                enemy.Draw(spriteBatch, SpriteEffects.FlipHorizontally);
            }
            spriteBatch.End();

            
            base.Draw(gameTime);
        }
    }
}
