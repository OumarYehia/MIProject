using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MI
{
    public static class Resources
    {
        // Backgrounds: Menu Background, Button Background
        public static Texture2D mainMenuBackground, scoresBackground, buttonBackground, startOptionsButtonBackground, checkboxCheckedBackground, checkboxUncheckedBackground, gameMapBackground, dirtTile, playerTile, emptyTile, diamondTile, rockTile, wallTile, deadTile;
        
        // Font
        public static SpriteFont menuButtonsFont;
        // Font Colors
        public static Color normalFontColor = Color.FromNonPremultiplied(239, 167, 20, 255), hoverFontColor = Color.FromNonPremultiplied(196, 18, 1, 255);

        // Audio
        public static SoundEffect pickupDiamond, tada, death;

        public static void LoadContent(ContentManager content)
        {
            mainMenuBackground = content.Load<Texture2D>("Images/MainMenuBackground");
            scoresBackground = content.Load<Texture2D>("Images/ScoresBackground");
            gameMapBackground = content.Load<Texture2D>("Images/GameMapBackground");            
            buttonBackground = content.Load<Texture2D>("Images/ButtonBackground");
            dirtTile = content.Load<Texture2D>("Images/Dirt");
            playerTile = content.Load<Texture2D>("Images/Player");
            diamondTile = content.Load<Texture2D>("Images/Diamond");
            emptyTile = content.Load<Texture2D>("Images/Empty");
            rockTile = content.Load<Texture2D>("Images/Rock");
            wallTile = content.Load<Texture2D>("Images/Wall");
            deadTile = content.Load<Texture2D>("Images/Dead");
            checkboxCheckedBackground = content.Load<Texture2D>("Images/CheckBox_Checked");
            checkboxUncheckedBackground = content.Load<Texture2D>("Images/CheckBox_Unchecked");
            startOptionsButtonBackground = content.Load<Texture2D>("Images/StartOptionsButtonBackground");
            menuButtonsFont = content.Load<SpriteFont>("Fonts/MenuButtonsFont");

            pickupDiamond = content.Load<SoundEffect>("Audio/Pickup_Coin4");
            tada = content.Load<SoundEffect>("Audio/Tada");
            death = content.Load<SoundEffect>("Audio/death2");
        }
    }
}
