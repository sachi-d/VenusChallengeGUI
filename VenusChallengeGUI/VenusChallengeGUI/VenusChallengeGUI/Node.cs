using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VenusChallengeGUI
{
    class Node
    {
        bool terminalNode;

        public List<Node> Children(bool Player)
        {
            List<Node> children = new List<Node>();

            // Create your subtree here and return the results

            return children;
        }

        public bool IsTerminal(bool Player)
        {
            terminalNode = false;

            // Game over?

            return terminalNode;
        }

        public int GetTotalScore(bool Player)
        {
            int totalScore = 0;

            // This method is a heuristic evaluation function to evaluate
            // the current situation of the player
            // It depends on the game. For example chess, tic-tac-to or other games suitable
            // for the minimax algorithm can have different evaluation functions.

            return totalScore;
        }
    }
}
