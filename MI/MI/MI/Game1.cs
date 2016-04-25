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

namespace MI
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public GameState gameState = GameState.MAIN_MENU;

        Texture2D customCursor;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
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
            this.Window.Title = "DIAMOND DIGGER";

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
            customCursor = Content.Load<Texture2D>("Cursors/Select");
            Resources.LoadContent(Content);
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

            // TODO: Add your update logic here
            switch (gameState)
            {
                case GameState.MAIN_MENU:
                    MainMenu.Update(gameTime, this);
                    break;
                case GameState.SCORES:
                    Scores.Update(gameTime, this);
                    break;
                case GameState.MANUAL_MODE:
                    GameHandler.Update(gameTime, this, gameState);
                    break;
                case GameState.ASTAR_MODE:
                    GameHandler.Update(gameTime, this, gameState);
                    break;
                case GameState.IDDFS_MODE:
                    GameHandler.Update(gameTime, this, gameState);
                    break;
                case GameState.CSP_MODE:
                    GameHandler.Update(gameTime, this, gameState);
                    break;
                case GameState.SA_MODE:
                    GameHandler.Update(gameTime, this, gameState);
                    break;
            }

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

            switch (gameState)
            {
                case GameState.MAIN_MENU:
                    MainMenu.Draw(gameTime, spriteBatch);
                    break;
                case GameState.SCORES:
                    Scores.Draw(gameTime, spriteBatch);
                    break;
                case GameState.MANUAL_MODE:
                    GameHandler.Draw(gameTime, spriteBatch, gameState);
                    break;
                case GameState.ASTAR_MODE:
                    GameHandler.Draw(gameTime, spriteBatch, gameState);
                    break;
                case GameState.IDDFS_MODE:
                    GameHandler.Draw(gameTime, spriteBatch, gameState);
                    break;
                case GameState.CSP_MODE:
                    GameHandler.Draw(gameTime, spriteBatch, gameState);
                    break;
                case GameState.SA_MODE:
                    GameHandler.Draw(gameTime, spriteBatch, gameState);
                    break;
            }

            // Cursor
            spriteBatch.Draw(customCursor, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
