using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VenusChallengeGUI
{
     class GameEntity
    {
        public int x; //horizontal position
        public int y; //vertical position
        public Vector2 pos;
        public string playerName;
        //Texture2D texture;
        public GameEntity(int xx, int yy)
        {
            x = xx;
            y = yy;
            pos = new Vector2(x, y);
        }
        public GameEntity()
        {
            playerName = "CELL";
        }

        public override string ToString()
        {
            return playerName;
        }
    }
}
