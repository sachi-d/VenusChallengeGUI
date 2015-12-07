using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VenusChallengeGUI
{
    abstract class GameEntity
    {
        public int x; //horizontal position
        public int y; //vertical position
        public Vector2 pos;
        public string playerName;
        public GameEntity(int xx, int yy)
        {
            x = xx;
            y = yy;
            pos = new Vector2(x, y);
        }
        public GameEntity()
        {
            x = 0;
            y = 0;
            playerName = "";
        }

        public override string ToString()
        {
            return playerName;
        }
    }
}
