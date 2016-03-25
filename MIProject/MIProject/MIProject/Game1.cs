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

        // Initializing Objects used in the game
        Texture2D sand,diamond,stone,player;
        Rectangle  rectanglesand,rectangleDiamond,rectanglePlayer,rectangleStone;
        List<Rectangle> rectangles = new List<Rectangle>();
        List<Rectangle> diamonds = new List<Rectangle>();
        List<Rectangle> stones = new List<Rectangle>();


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            /// Changing resolution to 800x600
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
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
            
            // Load sand and draw the rectangles
            sand = Content.Load<Texture2D>("sand2");
            diamond = Content.Load<Texture2D>("diamond");
            stone = Content.Load<Texture2D>("stone");
            player = Content.Load<Texture2D>("Mario0");

            rectanglePlayer = new Rectangle(300, 100, 100, 100);
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

            // TODO: Add your update logic here

            base.Update(gameTime);
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
