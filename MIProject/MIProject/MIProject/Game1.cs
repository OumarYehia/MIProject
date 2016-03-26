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

namespace MIProject
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        // Initializing Objects used in the game
        Texture2D sand,diamond,stone,player;
        Rectangle  rectanglesand,rectangleDiamond,rectanglePlayer,rectangleStone;
        List<Rectangle> rectangles = new List<Rectangle>();
        List<Rectangle> diamonds = new List<Rectangle>();
        List<Rectangle> stones = new List<Rectangle>();
        KeyboardState oldKeyboardState;
        
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            /// Changing resolution to 800x600
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            IsMouseVisible = true;
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
            oldKeyboardState = Keyboard.GetState();

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
            
            // Load sand and draw the rectangles
            sand = Content.Load<Texture2D>("sand2");
            diamond = Content.Load<Texture2D>("diamond");
            stone = Content.Load<Texture2D>("stone");
            player = Content.Load<Texture2D>("Mario0");

            // Initializing rectangles for drawings
            rectanglePlayer = new Rectangle(400, 200, 100, 100);
            for(int i=0 ; i<800 ; i+=100)
            {
                for (int j = 0; j < 600; j+=100 )
                {
                    if(i%300 == 0 && j%400 == 0 && i != j)
                    {
                        rectangleDiamond = new Rectangle(i, j, 100, 100);
                        diamonds.Add(rectangleDiamond);
                    }
                    else if(i%200 == 0 && j % 500 == 0)
                    {
                        rectangleStone = new Rectangle(i, j, 100, 100);
                        stones.Add(rectangleStone);
                    }
                    else
                    {
                        rectanglesand = new Rectangle(i, j, 100, 100);
                        rectangles.Add(rectanglesand);
                    }
                }
                    
            }
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

            UpdateMarioKeyboard();

            // TODO: Add your update logic here
            // Make Mario follow mouse
            /*MouseState mouseState = Mouse.GetState();
            rectanglePlayer.X = mouseState.X - rectanglePlayer.Width /2;
            rectanglePlayer.Y = mouseState.Y - rectanglePlayer.Height / 2;
            
            // Limit movement of mario to within window
            if (rectanglePlayer.Left < 0) rectanglePlayer.X = 0;
            if (rectanglePlayer.Right > WINDOW_WIDTH) rectanglePlayer.X = WINDOW_WIDTH - rectanglePlayer.Width;
            if (rectanglePlayer.Top < 0) rectanglePlayer.Y = 0;
            if (rectanglePlayer.Bottom > WINDOW_HEIGHT) rectanglePlayer.Y = WINDOW_HEIGHT - rectanglePlayer.Height;*/



            base.Update(gameTime);
        }


        private void UpdateMarioKeyboard()
        {
            // Make Mario follow Keyboard
            KeyboardState newkeyboardState = Keyboard.GetState();

            // If the left key is pressed
            if (newkeyboardState.IsKeyDown(Keys.Left))
            {
                // If it was just pressed
                if (!oldKeyboardState.IsKeyDown(Keys.Left))
                    rectanglePlayer.X -= 10;
                else
                    rectanglePlayer.X -= 5;
            }
            // If the right key is pressed
            if (newkeyboardState.IsKeyDown(Keys.Right))
            {
                // If it was just pressed
                if (!oldKeyboardState.IsKeyDown(Keys.Right))
                    rectanglePlayer.X += 10;
                else
                    rectanglePlayer.X += 5;
            }
            // If the up key is pressed
            if (newkeyboardState.IsKeyDown(Keys.Up))
            {
                // If it was just pressed
                if (!oldKeyboardState.IsKeyDown(Keys.Up))
                    rectanglePlayer.Y -= 10;
                else
                    rectanglePlayer.Y -= 5;
            }
            // If the down key is pressed
            if (newkeyboardState.IsKeyDown(Keys.Down))
            {
                // If it was just pressed
                if (!oldKeyboardState.IsKeyDown(Keys.Down))
                    rectanglePlayer.Y += 10;
                else
                    rectanglePlayer.Y += 5;
            }

            // Limit movement of mario to within window
            if (rectanglePlayer.Left < 0) rectanglePlayer.X = 0;
            if (rectanglePlayer.Right > WINDOW_WIDTH) rectanglePlayer.X = WINDOW_WIDTH - rectanglePlayer.Width;
            if (rectanglePlayer.Top < 0) rectanglePlayer.Y = 0;
            if (rectanglePlayer.Bottom > WINDOW_HEIGHT) rectanglePlayer.Y = WINDOW_HEIGHT - rectanglePlayer.Height;


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            // Drawing sand & Mush

            spriteBatch.Begin();

            for (int i = 0; i < rectangles.Count; i++)
            {
                spriteBatch.Draw(sand, rectangles[i], Color.White);
            }
            for (int i = 0; i < diamonds.Count; i++)
            {
                spriteBatch.Draw(diamond, diamonds[i], Color.White);
            }
            for (int i = 0; i < stones.Count; i++)
            {
                spriteBatch.Draw(stone, stones[i], Color.White);
            }
            spriteBatch.Draw(player, rectanglePlayer, Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
