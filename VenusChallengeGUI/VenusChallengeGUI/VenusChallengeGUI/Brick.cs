using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenusChallengeGUI
{
    class Brick : GameEntity
    {
        int health;
        public Brick(int xx, int yy)
            : base(xx, yy)
        {
            health = 100;
            playerName = "BB";
        }
        public void updateDamage()
        {

        }
    }
}
