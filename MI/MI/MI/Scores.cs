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
        private static Vector2 scoresTableHeaderPosition = new Vector2(300, 150);
        
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

            //Table
            spriteBatch.DrawString(Resources.scoresFont, String.Format("{0} {1,10} {2,10} {3,15} {4,5}", "Alg", "#Nodes", "#Diamonds", "All Diamonds", "Time"), scoresTableHeaderPosition, Color.White);
            switch (scoreType)
            {
                case(ScoreType.COMPUTER):
                    printScores(spriteBatch, GameHandler.ComputerScores);
                    break;
                case (ScoreType.HUMAN):
                    printScores(spriteBatch, GameHandler.HumanScores);
                    break;
                case (ScoreType.MIXED):
                    printScores(spriteBatch, GameHandler.Scores);
                    break;
                case (ScoreType.SA):
                    printScores(spriteBatch, GameHandler.SAScores);
                    break;
            }
        }

        public static void Reset()
        {
            backHover = computerScoresHover = humanScoresHover = mixedScoresHover = SAScoresHover = false;
            scoreType = ScoreType.COMPUTER;
            prevMouseState = new MouseState(0, 0, 0, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
        }

        private static void printScores(SpriteBatch spriteBatch, SortedSet<Score> scoresSet)
        {
            int j = 1;
            for (int i = 0; i < 10 && i < scoresSet.Count; i++)
            {
                Score s = scoresSet.ElementAt(i);
                switch (s.AlgorithmName)
                {
                    case "IDDFS":
                        spriteBatch.DrawString(Resources.scoresFont, String.Format("{0} {1,5} {2,14} {3,15} {4,15}", s.AlgorithmName, s.NumberOfNodes, s.NumberOfDiamonds, s.AllDiamondsCollected, s.TimeElapsed.ToString(@"mm\:ss\:ffff")), new Vector2(scoresTableHeaderPosition.X, scoresTableHeaderPosition.Y + (j * 50)), Color.White);
                        j++;
                        break;
                    case "A*":
                        spriteBatch.DrawString(Resources.scoresFont, String.Format("{0} {1,12} {2,15} {3,15} {4,15}", s.AlgorithmName, s.NumberOfNodes, s.NumberOfDiamonds, s.AllDiamondsCollected, s.TimeElapsed.ToString(@"mm\:ss\:ffff")), new Vector2(scoresTableHeaderPosition.X, scoresTableHeaderPosition.Y + (j * 50)), Color.White);
                        j++;
                        break;
                    case "SA":
                        spriteBatch.DrawString(Resources.scoresFont, String.Format("{0} {1,11} {2,15} {3,15} {4,15}", s.AlgorithmName, s.NumberOfNodes, s.NumberOfDiamonds, s.AllDiamondsCollected, s.TimeElapsed.ToString(@"mm\:ss\:ffff")), new Vector2(scoresTableHeaderPosition.X, scoresTableHeaderPosition.Y + (j * 50)), Color.White);
                        j++;
                        break;
                    case "CSP":
                        spriteBatch.DrawString(Resources.scoresFont, String.Format("{0} {1,10} {2,14} {3,15} {4,15}", s.AlgorithmName, s.NumberOfNodes, s.NumberOfDiamonds, s.AllDiamondsCollected, s.TimeElapsed.ToString(@"mm\:ss\:ffff")), new Vector2(scoresTableHeaderPosition.X, scoresTableHeaderPosition.Y + (j * 50)), Color.White);
                        j++;
                        break;
                    case "Human":
                        spriteBatch.DrawString(Resources.scoresFont, String.Format("{0} {1,5} {2,15} {3,15} {4,15}", s.AlgorithmName, s.NumberOfNodes, s.NumberOfDiamonds, s.AllDiamondsCollected, s.TimeElapsed.ToString(@"mm\:ss\:ffff")), new Vector2(scoresTableHeaderPosition.X, scoresTableHeaderPosition.Y + (j * 50)), Color.White);
                        j++;
                        break;
                }
            }
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
