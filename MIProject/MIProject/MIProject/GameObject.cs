using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace MIProject
{
    static class GameObject
    {
        Texture2D objectTexture;
        Rectangle boundingRectangle;
        int objectCount;
        List<int> objectCountLocations;


        public void LoadContent(Game1 game, String textureName, int rectx, int recty)
        {
            objectTexture = game.Content.Load<Texture2D>(textureName);
            boundingRectangle = new Rectangle(rectx,recty,100,100);
        }

        public void Update()
        {

        }

        public void moveLeft()
        {
            boundingRectangle.X -= 100;
        }
        public void moveRight()
        {
            boundingRectangle.X += 100;
        }
        public void moveUp()
        {
            boundingRectangle.Y -= 100;
        }
        public void moveDown()
        {
            boundingRectangle.Y += 100;
        }

    }
}
