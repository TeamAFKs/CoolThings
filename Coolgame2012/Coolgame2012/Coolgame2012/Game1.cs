using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Coolgame2012
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D arrow;
        Texture2D ball;
        Texture2D stars;
        Texture2D moonground;
        private ScrollingBackground myBackground;
        
        //Andre: Arrow Rotation Stuff
        Vector2 arrowOrigin;
        private float rotationAngle;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 550;
            graphics.PreferredBackBufferWidth = 700;
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
            myBackground = new ScrollingBackground();
            arrow = Content.Load<Texture2D>("Arrow");
            ball = Content.Load<Texture2D>("NewBall");
            stars = Content.Load<Texture2D>("Starybackground");
            moonground = Content.Load<Texture2D>("moonground");
            myBackground.Load(GraphicsDevice, stars);

            //Andre: Arrow will be rotated based on its own dimensions
            arrowOrigin.X = arrow.Width/2;
            arrowOrigin.Y = arrow.Height;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            // TODO: Add your game logic here.
            myBackground.Update(elapsed * 100);
            // TODO: Add your update logic here

            rotationAngle += elapsed;
            float circle = MathHelper.Pi * 2;
            rotationAngle = rotationAngle % circle;
            //Console.WriteLine(rotationAngle);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            //spriteBatch.Draw(stars, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(moonground, new Vector2(0, 400), Color.White);
            spriteBatch.Draw(arrow, new Vector2 ( graphics.PreferredBackBufferWidth /2 - arrow.Width /2, 400), null, Color.White, rotationAngle, arrowOrigin, 1.0f, SpriteEffects.None, 0.0f);
            myBackground.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);

            //Andre: test Comment
        }
    }
}
