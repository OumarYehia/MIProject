using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MI
{
    public static class Scores
    {
        //  Positions: Buttons, Buttons Texts
        private static Vector2 backButtonPosition = new Vector2(50, 525), computerScoresButtonPosition = new Vector2(30, 150), humanScoresButtonPosition = new Vector2(30, 220), mixedScoresButtonPosition = new Vector2(30, 300), SAScoresButtonPosition = new Vector2(30, 380);
        private static Vector2 backButtonTextPosition = new Vector2(100.0f, 547.5f), computerScoresButtonTextPosition = new Vector2(130f, 172.5f), humanScoresButtonTextPosition = new Vector2(130f, 242.5f), mixedScoresButtonTextPosition = new Vector2(130f, 322.5f), SAScoresButtonTextPosition = new Vector2(130f, 402.5f);

        // Previous Mouse State: Used for detecting single clicks
        private static MouseState prevMouseState = Mouse.GetState();

        // Buttons Hover Booleans
        private static Boolean backHover = false, computerScoresHover = false, humanScoresHover = false, mixedScoresHover = false, SAScoresHover = false;

        private static ScoreType scoreType = ScoreType.COMPUTER;

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
                }
            }

            if (mouseState.X < computerScoresButtonPosition.X || mouseState.Y < computerScoresButtonPosition.Y || mouseState.X > computerScoresButtonPosition.X + Resources.checkboxCheckedBackground.Width || mouseState.Y > computerScoresButtonPosition.Y + Resources.checkboxCheckedBackground.Height)
                computerScoresHover = false;
            else
            {
                computerScoresHover = true;
                if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    scoreType = ScoreType.COMPUTER;
                }
            }

            if (mouseState.X < humanScoresButtonPosition.X || mouseState.Y < humanScoresButtonPosition.Y || mouseState.X > humanScoresButtonPosition.X + Resources.checkboxCheckedBackground.Width || mouseState.Y > humanScoresButtonPosition.Y + Resources.checkboxCheckedBackground.Height)
                humanScoresHover = false;
            else
            {
                humanScoresHover = true;
                if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    scoreType = ScoreType.HUMAN;
                }
            }

            if (mouseState.X < mixedScoresButtonPosition.X || mouseState.Y < mixedScoresButtonPosition.Y || mouseState.X > mixedScoresButtonPosition.X + Resources.checkboxCheckedBackground.Width || mouseState.Y > mixedScoresButtonPosition.Y + Resources.checkboxCheckedBackground.Height)
                mixedScoresHover = false;
            else
            {
                mixedScoresHover = true;
                if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    scoreType = ScoreType.MIXED;
                }
            }

            if (mouseState.X < SAScoresButtonPosition.X || mouseState.Y < SAScoresButtonPosition.Y || mouseState.X > SAScoresButtonPosition.X + Resources.checkboxCheckedBackground.Width || mouseState.Y > SAScoresButtonPosition.Y + Resources.checkboxCheckedBackground.Height)
                SAScoresHover = false;
            else
            {
                SAScoresHover = true;
                if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    scoreType = ScoreType.SA;
                }
            }

            if (game.gameState == GameState.SCORES)
                prevMouseState = mouseState;

        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Resources.scoresBackground, new Vector2(0, 0), Color.White);

            // BackButton
            spriteBatch.Draw(Resources.buttonBackground, backButtonPosition, Color.White);
            spriteBatch.DrawString(Resources.menuButtonsFont, "back", backButtonTextPosition, backHover ? Resources.hoverFontColor : Resources.normalFontColor);

            // ScoresButtons
            spriteBatch.Draw(scoreType == ScoreType.COMPUTER? Resources.checkboxCheckedBackground : Resources.checkboxUncheckedBackground, computerScoresButtonPosition, Color.White);
            spriteBatch.DrawString(Resources.menuButtonsFont, "PC", computerScoresButtonTextPosition, computerScoresHover ? Resources.hoverFontColor : Resources.normalFontColor);
            spriteBatch.Draw(scoreType == ScoreType.HUMAN ? Resources.checkboxCheckedBackground : Resources.checkboxUncheckedBackground, humanScoresButtonPosition, Color.White);
            spriteBatch.DrawString(Resources.menuButtonsFont, "human", humanScoresButtonTextPosition, humanScoresHover ? Resources.hoverFontColor : Resources.normalFontColor);
            spriteBatch.Draw(scoreType == ScoreType.MIXED ? Resources.checkboxCheckedBackground : Resources.checkboxUncheckedBackground, mixedScoresButtonPosition, Color.White);
            spriteBatch.DrawString(Resources.menuButtonsFont, "mixed", mixedScoresButtonTextPosition, mixedScoresHover ? Resources.hoverFontColor : Resources.normalFontColor);
            spriteBatch.Draw(scoreType == ScoreType.SA ? Resources.checkboxCheckedBackground : Resources.checkboxUncheckedBackground, SAScoresButtonPosition, Color.White);
            spriteBatch.DrawString(Resources.menuButtonsFont, "SA", SAScoresButtonTextPosition, SAScoresHover ? Resources.hoverFontColor : Resources.normalFontColor);
        }

        public static void Reset()
        {
            backHover = computerScoresHover = humanScoresHover = mixedScoresHover = SAScoresHover = false;
            scoreType = ScoreType.COMPUTER;
            prevMouseState = new MouseState(0, 0, 0, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
        }
    }

    public enum ScoreType
    {
        COMPUTER,
        HUMAN,
        MIXED,
        SA
    }
}
