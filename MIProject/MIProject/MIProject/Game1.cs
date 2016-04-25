using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        int WINDOW_WIDTH = 800;
        int WINDOW_HEIGHT = 600;

        // Initializing Objects used in the game
        Texture2D sand , diamond , stone , player , concrete;
        Rectangle  rectanglesand , rectangleDiamond , rectanglePlayer , rectangleStone , rectangleConcrete;
        List<Rectangle> rectangles = new List<Rectangle>();
        List<Rectangle> diamonds = new List<Rectangle>();
        List<Rectangle> stones = new List<Rectangle>();
        List<Rectangle> concretes = new List<Rectangle>();
        KeyboardState oldKeyboardState;
        KeyboardState newkeyboardState = Keyboard.GetState();
        SpriteFont chillerRegular;
        Vector2 FontPos;
        SoundEffect pickupCoin;
        SoundEffect tada;
        bool isMarioFlipped = false;
        bool solveastar;
        int score = 0;
        

        // Variables
        int marioX, marioY;
        int diamondsCount;
        List<int> diamondsLocations;
        int rocksCount;
        List<int> rocksLocations;
        int concreteCount;
        List<int> concreteLocations;


        public Game1(int width, int height, int mariox, int marioy, int diamondsCounter,List<int>diamondsLoc,
                                    int rocksCounter, List<int> rocksLocs, int concreteCounter, List<int> concreteLocs)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


            //Initializing Variables();
            WINDOW_WIDTH = width;
            WINDOW_HEIGHT = height;
            marioX = mariox; marioY = marioy;
            diamondsCount = diamondsCounter;
            diamondsLocations = new List<int>(diamondsCount * 2);
            diamondsLocations = diamondsLoc;
            rocksCount = rocksCounter;
            rocksLocations = new List<int>(rocksCount * 2);
            rocksLocations = rocksLocs;

            concreteCount = concreteCounter;
            concreteLocations = new List<int>(concreteCount * 2);
            concreteLocations = concreteLocs;

            
            /// Changing resolution 
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
            
            // Load SpriteFont
            chillerRegular = Content.Load<SpriteFont>("Chiller Regular");
            FontPos = new Vector2(graphics.GraphicsDevice.Viewport.Width - 50 , 50);

            // Loading sound
            pickupCoin = Content.Load<SoundEffect>("Pickup_Coin4");
            tada = Content.Load<SoundEffect>("Tada");

            // Load sand and draw the rectangles
            sand = Content.Load<Texture2D>("dirt");
            diamond = Content.Load<Texture2D>("Diamond_Glowing");
            stone = Content.Load<Texture2D>("stone");
            player = Content.Load<Texture2D>("Mario1");
            concrete = Content.Load<Texture2D>("metalwall");

            // Drawing penetrable ground
            for (int i = 0; i < 800; i+=100 )
            {
                for (int j = 0; j < 600; j+=100 )
                {
                    rectanglesand = new Rectangle(i, j, 100, 100);
                    rectangles.Add(rectanglesand);
                }
                    
            }

                // Initializing rectangles for drawings
                rectanglePlayer = new Rectangle(marioX, marioY, 100, 100);
            for (int i = 0; i < diamondsCount * 2; i+=2 )
            {
                rectangleDiamond = new Rectangle(diamondsLocations[i], diamondsLocations[i+1], 100, 100);
                diamonds.Add(rectangleDiamond);
            }
            for (int i = 0; i < rocksCount * 2; i += 2)
            {
                rectangleStone = new Rectangle(rocksLocations[i], rocksLocations[i + 1], 100, 100);
                stones.Add(rectangleStone);
            }
            for (int i = 0; i < concreteCount * 2; i += 2)
            {
                rectangleConcrete = new Rectangle(concreteLocations[i], concreteLocations[i + 1], 100, 100);
                concretes.Add(rectangleConcrete);
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


        protected void checkCollision()
        {
            for (int i = 0; i < diamonds.Count; i++)
            {
                if (rectanglePlayer.Intersects(diamonds.ElementAt(i)))
                {
                    score++;
                    pickupCoin.Play();
                    diamonds.Remove(diamonds.ElementAt(i));

                    if (score == diamondsCount)
                        tada.Play();
                }
            }
            for (int i = 0; i < rectangles.Count; i++)
            {
                if (rectanglePlayer.Intersects(rectangles.ElementAt(i)))
                {
                    rectangles.Remove(rectangles.ElementAt(i));

                }
            }
            for (int i = 0; i < stones.Count; i++)
            {
                if (rectanglePlayer.Intersects(stones.ElementAt(i)) && !isMarioFlipped)
                {
                    rectanglePlayer.X = stones.ElementAt(i).Left - rectanglePlayer.Width;
                }
                else if (rectanglePlayer.Intersects(stones.ElementAt(i)) && isMarioFlipped)
                {
                    rectanglePlayer.X = stones.ElementAt(i).Right;
                }
            }
            for (int i = 0; i < concretes.Count; i++)
            {
                if (rectanglePlayer.Intersects(concretes.ElementAt(i)) && !isMarioFlipped)
                {
                    rectanglePlayer.X = concretes.ElementAt(i).Left - rectanglePlayer.Width;
                }
                else if (rectanglePlayer.Intersects(concretes.ElementAt(i)) && isMarioFlipped)
                {
                    rectanglePlayer.X = concretes.ElementAt(i).Right;
                }
            }


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
            checkCollision();

            if (solveastar)
                SolveAStar();

            base.Update(gameTime);
        }

        protected void SolveAStar()
        {

        }


        // This function lets mario face the opposite direction
        public static Texture2D Flip(Texture2D source, bool vertical, bool horizontal)
        {
            Texture2D flipped = new Texture2D(source.GraphicsDevice, source.Width, source.Height);
            Color[] data = new Color[source.Width * source.Height];
            Color[] flippedData = new Color[data.Length];

            source.GetData<Color>(data);

            for (int x = 0; x < source.Width; x++)
                for (int y = 0; y < source.Height; y++)
                {
                    int idx = (horizontal ? source.Width - 1 - x : x) + ((vertical ? source.Height - 1 - y : y) * source.Width);
                    flippedData[x + y * source.Width] = data[idx];
                }

            flipped.SetData<Color>(flippedData);

            return flipped;
        }  



        private void UpdateMarioKeyboard()
        {
            // Make Mario follow Keyboard
            oldKeyboardState = newkeyboardState;
            newkeyboardState = Keyboard.GetState();

            // If the left key is pressed
            if (newkeyboardState.IsKeyDown(Keys.Left) && oldKeyboardState.IsKeyUp(Keys.Left) )
            {
                rectanglePlayer.X -= 100;
                if (!isMarioFlipped)
                {
                    player = Flip(player, false, true);
                    isMarioFlipped = true;
                }
            }
            if (newkeyboardState.IsKeyDown(Keys.Right) && oldKeyboardState.IsKeyUp(Keys.Right))
            {
                rectanglePlayer.X += 100;
                if (isMarioFlipped)
                {
                    player = Flip(player, false, true);
                    isMarioFlipped = false;
                }
            }
            if (newkeyboardState.IsKeyDown(Keys.Up) && oldKeyboardState.IsKeyUp(Keys.Up))
            {
                rectanglePlayer.Y -= 100;
            }
            if (newkeyboardState.IsKeyDown(Keys.Down) && oldKeyboardState.IsKeyUp(Keys.Down))
            {
                rectanglePlayer.Y += 100;
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
            for (int i = 0; i < concretes.Count; i++ )
            {
                spriteBatch.Draw(concrete, concretes[i], Color.White);
            }
                spriteBatch.Draw(player, rectanglePlayer, Color.Wheat);


                Vector2 FontOrigin = chillerRegular.MeasureString(score.ToString()) / 2;
                // Draw the string
                spriteBatch.DrawString(chillerRegular, score.ToString(), FontPos, Color.Red,
                    0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);


            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
