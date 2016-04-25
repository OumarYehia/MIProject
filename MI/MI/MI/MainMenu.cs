using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MI
{
    public static class MainMenu
    {
        //  Positions: Menu Buttons, Buttons Texts
        private static Vector2 startButtonPosition = new Vector2(300, 250), scoresButtonPosition = new Vector2(300, 330), quitButtonPosition = new Vector2(300, 410);
        private static Vector2 startButtonTextPosition = new Vector2(350.0f, 272.5f), scoresButtonTextPosition = new Vector2(345.0f, 352.5f), quitButtonTextPosition = new Vector2(350.0f, 432.5f);

        // Positions: Start Options
        private static Vector2 AStarPosition = new Vector2(500, 250), IDDFSPosition = new Vector2(500, 330), CSPPosition = new Vector2(500, 410), SAPosition = new Vector2(500, 490), manualPosition = new Vector2(100, 250);
        private static Vector2 AStarTextPosition = new Vector2(550.0f, 272.5f), IDDFSTextPosition = new Vector2(550.0f, 352.5f), CSPTextPosition = new Vector2(550.0f, 432.5f), SATextPosition = new Vector2(550.0f, 512.5f), manualTextPosition = new Vector2(150.0f, 272.5f);

        // MenuButtons Hover Booleans
        private static Boolean startHover = false, scoresHover = false, quitHover = false;

        // StartOptionsButtons Hover Booleans
        private static Boolean AStarHover = false, IDDFSHover = false, CSPHover = false, SAHover = false, manualHover = false;

        // Show Start Options Boolean
        private static Boolean showStartOptions = false;

        // Previous Mouse State: Used for detecting single clicks
        private static MouseState prevMouseState = Mouse.GetState();

        public static void Update(GameTime gameTime, Game1 game)
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.X < startButtonPosition.X || mouseState.Y < startButtonPosition.Y || mouseState.X > startButtonPosition.X + Resources.buttonBackground.Width || mouseState.Y > startButtonPosition.Y + Resources.buttonBackground.Height)
                startHover = false;
            else
            {
                startHover = true;
                if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    showStartOptions = !showStartOptions;
                }
            }

            if (mouseState.X < scoresButtonPosition.X || mouseState.Y < scoresButtonPosition.Y || mouseState.X > scoresButtonPosition.X + Resources.buttonBackground.Width || mouseState.Y > scoresButtonPosition.Y + Resources.buttonBackground.Height)
                scoresHover = false;
            else
            {
                scoresHover = true;
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    game.gameState = GameState.SCORES;
                    Reset();
                }
            }

            if (mouseState.X < quitButtonPosition.X || mouseState.Y < quitButtonPosition.Y || mouseState.X > quitButtonPosition.X + Resources.buttonBackground.Width || mouseState.Y > quitButtonPosition.Y + Resources.buttonBackground.Height)
                quitHover = false;
            else
            {
                quitHover = true;
                if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    game.Exit();
                }
            }

            if (mouseState.X < AStarPosition.X || mouseState.Y < AStarPosition.Y || mouseState.X > AStarPosition.X + Resources.startOptionsButtonBackground.Width || mouseState.Y > AStarPosition.Y + Resources.startOptionsButtonBackground.Height)
                AStarHover = false;
            else
            {
                AStarHover = true;
                if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    game.gameState = GameState.ASTAR_MODE;
                    Reset();
                }
            }

            if (mouseState.X < IDDFSPosition.X || mouseState.Y < IDDFSPosition.Y || mouseState.X > IDDFSPosition.X + Resources.startOptionsButtonBackground.Width || mouseState.Y > IDDFSPosition.Y + Resources.startOptionsButtonBackground.Height)
                IDDFSHover = false;
            else
            {
                IDDFSHover = true;
                if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    game.gameState = GameState.IDDFS_MODE;
                    Reset();
                }
            }

            if (mouseState.X < CSPPosition.X || mouseState.Y < CSPPosition.Y || mouseState.X > CSPPosition.X + Resources.startOptionsButtonBackground.Width || mouseState.Y > CSPPosition.Y + Resources.startOptionsButtonBackground.Height)
                CSPHover = false;
            else
            {
                CSPHover = true;
                if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    game.gameState = GameState.CSP_MODE;
                    Reset();
                }
            }

            if (mouseState.X < SAPosition.X || mouseState.Y < SAPosition.Y || mouseState.X > SAPosition.X + Resources.startOptionsButtonBackground.Width || mouseState.Y > SAPosition.Y + Resources.startOptionsButtonBackground.Height)
                SAHover = false;
            else
            {
                SAHover = true;
                if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    game.gameState = GameState.SA_MODE;
                    Reset();
                }
            }

            if (mouseState.X < manualPosition.X || mouseState.Y < manualPosition.Y || mouseState.X > manualPosition.X + Resources.startOptionsButtonBackground.Width || mouseState.Y > manualPosition.Y + Resources.startOptionsButtonBackground.Height)
                manualHover = false;
            else
            {
                manualHover = true;
                if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    game.gameState = GameState.MANUAL_MODE;
                    Reset();
                }
            }

            if(game.gameState == GameState.MAIN_MENU)
                prevMouseState = mouseState;

        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Resources.mainMenuBackground, new Vector2(0, 0), Color.White);
            
            // StartButton
            spriteBatch.Draw(Resources.buttonBackground, startButtonPosition, Color.White);
            spriteBatch.DrawString(Resources.menuButtonsFont, "start", startButtonTextPosition, startHover ? Resources.hoverFontColor : Resources.normalFontColor);

            // ScoresButton
            spriteBatch.Draw(Resources.buttonBackground, scoresButtonPosition, Color.White);
            spriteBatch.DrawString(Resources.menuButtonsFont, "scores", scoresButtonTextPosition, scoresHover ? Resources.hoverFontColor : Resources.normalFontColor);

            // QuitButton
            spriteBatch.Draw(Resources.buttonBackground, quitButtonPosition, Color.White);
            spriteBatch.DrawString(Resources.menuButtonsFont, "quit", quitButtonTextPosition, quitHover ? Resources.hoverFontColor : Resources.normalFontColor);

            // StartOptionsButtons
            if (showStartOptions)
            {
                spriteBatch.Draw(Resources.startOptionsButtonBackground, AStarPosition, Color.White);
                spriteBatch.DrawString(Resources.menuButtonsFont, "A*", AStarTextPosition, AStarHover ? Resources.hoverFontColor : Color.White);
                spriteBatch.Draw(Resources.startOptionsButtonBackground, IDDFSPosition, Color.White);
                spriteBatch.DrawString(Resources.menuButtonsFont, "IDDFS", IDDFSTextPosition, IDDFSHover ? Resources.hoverFontColor : Color.White);
                spriteBatch.Draw(Resources.startOptionsButtonBackground, CSPPosition, Color.White);
                spriteBatch.DrawString(Resources.menuButtonsFont, "CSP", CSPTextPosition, CSPHover ? Resources.hoverFontColor : Color.White);
                spriteBatch.Draw(Resources.startOptionsButtonBackground, SAPosition, Color.White);
                spriteBatch.DrawString(Resources.menuButtonsFont, "SA", SATextPosition, SAHover ? Resources.hoverFontColor : Color.White);
                spriteBatch.Draw(Resources.startOptionsButtonBackground, manualPosition, Color.White);
                spriteBatch.DrawString(Resources.menuButtonsFont, "Play", manualTextPosition, manualHover ? Resources.hoverFontColor : Color.White);
            }
        }

        public static void Reset()
        {
            startHover = scoresHover = quitHover = false;
            showStartOptions = false;
            AStarHover = IDDFSHover = CSPHover = SAHover = manualHover = false;
            prevMouseState = new MouseState(0,0,0,ButtonState.Released,ButtonState.Released,ButtonState.Released,ButtonState.Released,ButtonState.Released);
        }
    }
}
