using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VenusChallengeGUI
{

    class Node
    {
        bool terminalNode;
        private GameGrid grid;

        internal GameGrid Grid
        {
            get { return grid; }
            set { grid = value; }
        }
        private int row;
        private int column;
        List<Node> children = new List<Node>();
        private AI ai;

        internal AI Ai
        {
            get { return ai; }
            set { ai = value; }
        }


        public int Column
        {
            get { return column; }
            set { column = value; }
        }

        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        private int coloumn;
        /*  public Node(GameGrid g)
          {
              grid = new GameGrid();
             grid = g;
             this.Ai = ai;
            
          }*/
        public Node()
        {

        }
        public Node(AI artfI)
        {
            ai = new AI();
            ai = artfI;
            this.Grid = grid;
        }
        public Node(int row, int column)
        {
            this.row = row;
            this.coloumn = coloumn;
        }

        public List<Node> Children(bool Player)
        {
            List<Node> children = new List<Node>();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    if (grid.gameGrid[i, j].Equals(null))
                    {
                        if ((grid.mytank.x + 1 >= i || grid.mytank.x - 1 <= i) && (grid.mytank.y + 1 >= i || grid.mytank.y - 1 <= i))
                        {
                            Row = i;
                            Column = j;
                            children.Add(new Node(i, j));

                        }
                    }

                    else
                    {
                        //  Console.Write("-- ");
                    }
                }
                // Console.WriteLine("\n");
            }


            return children;
        }
        public void getGameOverNotifications(bool value)
        {
            ai.gameOver = value;

        }

        public bool IsTerminal()
        {

            terminalNode = ai.gameOver;
            return terminalNode;
        }

        public int GetTotalScore(bool Player)
        {
            int totalScore = 0;
            List<Node> ne;
            ne = Children(Player);
            for (int i = 0; i < ne.Count; i++)
            {
                totalScore = evaluateScore(ne[i]);
            }

            // This method is a heuristic evaluation function to evaluate
            // the current situation of the player
            // It depends on the game. For example chess, tic-tac-to or other games suitable
            // for the minimax algorithm can have different evaluation functions.

            return totalScore;
        }
        public int evaluateScore(Node node)
        {
            int tankCount = 0;
            int score = 0;
            for (int i = 0; i < grid.TankList.Count; i++)
            {
                if
                    (grid.TankList[i].x != node.row && grid.TankList[i].y != node.coloumn)
                {
                    score += 10;

                }

            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    if ((i <= node.row + 1 && i >= node.row - 1) || (j <= node.row + 1 && j >= node.row - 1))
                    {
                        if (grid.gameGrid[i, j].GetType() == typeof(Tank))
                        {
                            tankCount++;
                            if (tankCount > 1)
                            {
                                score += -1000;
                            }
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(LifePack))
                        {
                            score += 600;
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(Coin))
                        {
                            score += 580;
                        }
                    }
                    else if ((i <= node.row + 2 && i >= node.row - 2) || (j <= node.row + 2 && j >= node.row - 2))
                    {
                        if (grid.gameGrid[i, j].GetType() == typeof(Tank))
                        {
                            tankCount++;
                            if (tankCount > 1)
                            {
                                score += -1000;
                            }
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(LifePack))
                        {
                            score += 570;
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(Coin))
                        {
                            score += 550;
                        }
                    }
                    else if ((i <= node.row + 3 && i >= node.row - 3) || (j <= node.row + 3 && j >= node.row - 3))
                    {
                        if (grid.gameGrid[i, j].GetType() == typeof(Tank))
                        {
                            tankCount++;
                            if (tankCount > 1)
                            {
                                score += -1000;
                            }
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(LifePack))
                        {
                            score += 540;
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(Coin))
                        {
                            score += 520;
                        }
                    }
                    else if ((i <= node.row + 4 && i >= node.row - 4) || (j <= node.row + 4 && j >= node.row - 4))
                    {
                        if (grid.gameGrid[i, j].GetType() == typeof(Tank))
                        {
                            tankCount++;
                            if (tankCount > 1)
                            {
                                score += -1000;
                            }
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(LifePack))
                        {
                            score += 510;
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(Coin))
                        {
                            score += 490;
                        }
                    }

                    else if ((i <= node.row + 5 && i >= node.row - 5) || (j <= node.row + 5 && j >= node.row - 5))
                    {
                        if (grid.gameGrid[i, j].GetType() == typeof(Tank))
                        {
                            tankCount++;
                            if (tankCount > 1)
                            {
                                score += -1000;
                            }
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(LifePack))
                        {
                            score += 480;
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(Coin))
                        {
                            score += 460;
                        }
                    }
                    else if ((i <= node.row + 6 && i >= node.row - 6) || (j <= node.row + 6 && j >= node.row - 6))
                    {
                        if (grid.gameGrid[i, j].GetType() == typeof(Tank))
                        {
                            tankCount++;
                            if (tankCount > 1)
                            {
                                score += -1000;
                            }
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(LifePack))
                        {
                            score += 450;
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(Coin))
                        {
                            score += 430;
                        }
                    }
                    else if ((i <= node.row + 7 && i >= node.row - 7) || (j <= node.row + 7 && j >= node.row - 7))
                    {
                        if (grid.gameGrid[i, j].GetType() == typeof(Tank))
                        {
                            tankCount++;
                            if (tankCount > 1)
                            {
                                score += -1000;
                            }
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(LifePack))
                        {
                            score += 410;
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(Coin))
                        {
                            score += 390;
                        }
                    }
                    else if ((i <= node.row + 8 && i >= node.row - 8) || (j <= node.row + 8 && j >= node.row - 8))
                    {
                        if (grid.gameGrid[i, j].GetType() == typeof(Tank))
                        {
                            tankCount++;
                            if (tankCount > 1)
                            {
                                score += -1000;
                            }
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(LifePack))
                        {
                            score += 380;
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(Coin))
                        {
                            score += 360;
                        }
                    }
                    else if ((i <= node.row + 9 && i >= node.row - 9) || (j <= node.row + 9 && j >= node.row - 9))
                    {
                        if (grid.gameGrid[i, j].GetType() == typeof(Tank))
                        {
                            tankCount++;
                            if (tankCount > 1)
                            {
                                score += -1000;
                            }
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(LifePack))
                        {
                            score += 340;
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(Coin))
                        {
                            score += 320;
                        }
                    }
                    else
                    {
                        if (grid.gameGrid[i, j].GetType() == typeof(Tank))
                        {
                            tankCount++;
                            if (tankCount > 1)
                            {
                                score += -1000;
                            }
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(LifePack))
                        {
                            score += 300;
                        }
                        if (grid.gameGrid[i, j].GetType() == typeof(Coin))
                        {
                            score += 280;
                        }
                    }

                }
            }
            return score;
        }

    }
}
