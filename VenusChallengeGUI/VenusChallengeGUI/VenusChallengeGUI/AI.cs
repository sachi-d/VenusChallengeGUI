using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace VenusChallengeGUI
{
    class AI
    {
        bool MaxPlayer = true;
        public bool gameOver = false;
        Client c;
        private Timer _pingTimer;
        GameGrid grid;
        Tank t;
        public AI()
        {

            this._pingTimer = new Timer();
            this._pingTimer.Interval = 1000;
            this._pingTimer.Elapsed += new ElapsedEventHandler(this.TimeElapsed);
            this._pingTimer.Enabled = true;
        }



        // Configure a Timer for use

        public void setGrid(GameGrid g)
        {
            this.grid = g;
        }


        public void setTank()
        {
            t = grid.GetTank();

        }

        public void TimeElapsed(Object sender, ElapsedEventArgs eventArgs)
        {
            this.Iterate(new Node(t.x, t.y), int.MaxValue, int.MinValue, MaxPlayer);
        }

        public int Iterate(Node node, int alpha, int beta, bool Player)
        {
            if (node.IsTerminal())
            {
                return node.GetTotalScore(Player);
            }

            if (Player == MaxPlayer)
            {
                foreach (Node child in node.Children(Player))
                {
                    alpha = Math.Max(alpha, Iterate(child, alpha, beta, !Player));
                    if (beta < alpha)
                    {
                        break;
                    }

                }

                return alpha;
            }
            else
            {
                foreach (Node child in node.Children(Player))
                {
                    beta = Math.Min(beta, Iterate(child, alpha, beta, !Player));

                    if (beta < alpha)
                    {
                        break;
                    }
                }

                return beta;
            }
        }
        public void getGameOverNotifications(bool value)
        {
            gameOver = value;
        }
    }
}
