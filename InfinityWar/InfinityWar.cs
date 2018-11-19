using InfinityWar.Characters;
using InfinityWar.Level;
using InfinityWar.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InfinityWar
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class InfinityWar : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D thorMovingTex, thorIdleTex, thorMovingLeftTex, tileTex;
        Thor thor, thor2, thorLeft, thorIdle;
        Stage1 stage1 = new Stage1();
        Collision collision = new Collision();
        Tile tile;
        
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
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //hier worden alle objecten op het scherm getoond
            thorMovingTex = Content.Load<Texture2D>("ThorMoving");
            thor = new Thor(thorMovingTex, new Vector2(0, 391), new Rectangle(0,0,68,59));
            thor2 = new Thor(thorMovingTex, new Vector2(0, 391), new Rectangle(0, 0, 68, 59));

            thorMovingLeftTex = Content.Load<Texture2D>("ThorMovingLeft");
            thorLeft = new Thor(thorMovingLeftTex, new Vector2(0, 391),new Rectangle(0,0,68,59));

            tileTex = Content.Load<Texture2D>("tile");
            stage1.tileTex = tileTex;

            thorIdleTex = Content.Load<Texture2D>("ThorIdle");
            thorIdle = new Thor(thorIdleTex, new Vector2(0, 400), new Rectangle(0, 0, 52, 59));

            tile = new Tile(tileTex, new Vector2(300, 400), new Rectangle(0, 0, 92, 24), true);



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
            stage1.CreateLevel();
            thor.Update(gameTime);
            thorLeft.Update(gameTime);
            thorIdle.Update(gameTime);
            //collision.SpriteCollide(thor,tile, thorLeft);
            
            
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            stage1.Draw(spriteBatch);
           /* if (thorIdle.isMoving == false)
            {
                thorIdle.Draw(spriteBatch);
            }*/
            if (/*thor.isMoving == true &&*/ thor.isRight == true)
            {
                thor.Draw(spriteBatch);
            }
            else if(thorLeft.isMoving == true && thorLeft.isRight == false)
            {
                thorLeft.Draw(spriteBatch);
            }
            tile.Draw(spriteBatch);

            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
