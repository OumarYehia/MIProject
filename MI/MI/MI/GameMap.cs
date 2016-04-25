using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MI
{
    public static class GameMap
    {
        //  Positions: Buttons, Buttons Texts
        private static Vector2 backButtonPosition = new Vector2(600, 525);
        private static Vector2 backButtonTextPosition = new Vector2(650.0f, 547.5f);
        
        // Previous Mouse State: Used for detecting single clicks
        private static MouseState prevMouseState = Mouse.GetState();
        
        // Buttons Hover Booleans
        private static Boolean backHover = false;

        public static void Update(GameTime gameTime, Game1 game)
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.X < backButtonPosition.X || mouseState.Y < backButtonPosition.Y || mouseState.X > backButtonPosition.X + Resources.buttonBackground.Width || mouseState.Y > backButtonPosition.Y + Resources.buttonBackground.Height)
                backHover = false;
            else
            {
                backHover = true;
                if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    game.gameState = GameState.MAIN_MENU;
                    Reset();
                }
            }

            if (game.gameState != GameState.MAIN_MENU && game.gameState != GameState.SCORES)
                prevMouseState = mouseState;
        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Resources.gameMapBackground, new Vector2(0, 0), Color.White);

            // BackButton
            spriteBatch.Draw(Resources.buttonBackground, backButtonPosition, Color.White);
            spriteBatch.DrawString(Resources.menuButtonsFont, "back", backButtonTextPosition, backHover ? Resources.hoverFontColor : Resources.normalFontColor);
        }

        public static void Reset()
        {
            backHover = false;
            prevMouseState = new MouseState(0, 0, 0, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
        }
    }
}
