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
        Client2 c;
        private Timer _pingTimer;
        GameGrid grid;
        int count;
        int score;
        Tank t;
        GameEntity cell;
        List<GameEntity> children;
        List<GameEntity> tankList;
        List<GameEntity> emptyCells;

        public AI(Game1 g)
        {

            this._pingTimer = new Timer();
            this._pingTimer.Interval = 1000;
            this._pingTimer.Elapsed += new ElapsedEventHandler(this.TimeElapsed);
            this._pingTimer.Enabled = true;
            setGrid(g.Gamegrid);
            setTank();
            count = 0;
            score = 0;
            cell = new GameEntity();

        }



        // Configure a Timer for use

        public void setGrid(GameGrid g)
        {
            this.grid = g;
        }
        public GameGrid getGrid()
        {
            return grid;
        }


        public void setTank()
        {
            t = grid.mytank;

        }

        public void TimeElapsed(Object sender, ElapsedEventArgs eventArgs)
        {
            GetBestScore();
            grid.gameGrid[t.x,t.y] = new GameEntity();
            grid.gameGrid[cell.x, cell.y] = t;


            //   Console.WriteLine(this.Iterate(startNode, int.MaxValue, int.MinValue, MaxPlayer)+"Final Score");
        }
        public List<GameEntity> Children()
        {
            children = new List<GameEntity>();
            tankList = new List<GameEntity>();
            emptyCells = new List<GameEntity>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    if ((grid.gameGrid[i, j].ToString().Equals("CELL")) || (grid.gameGrid[i, j].ToString().Equals("LP")) || (grid.gameGrid[i, j].ToString().Equals("CC")))
                    {
                        if ((grid.mytank.x + 1 >= i || grid.mytank.x - 1 <= i) && (grid.mytank.y + 1 >= i || grid.mytank.y - 1 <= i))
                        {

                            children.Add(grid.gameGrid[i, j]);
                        }
                        emptyCells.Add(grid.gameGrid[i, j]);
                    }
                    if (grid.gameGrid[i, j].ToString().Substring(0, 2).Equals("PP"))
                    {
                        tankList.Add(grid.gameGrid[i, j]);
                    }
                }
                // Console.WriteLine("\n");
            }


            return children;
        }

        public void GetBestScore()
        {
            int totalScore = 0;
            int bestScore = 0;

            List<GameEntity> ne;
            ne = Children();
            for (int i = 0; i < ne.Count; i++)
            {

                totalScore = evaluateScore(ne[i]);
                if (bestScore < totalScore)
                {
                    bestScore = totalScore;
                    cell = ne[i];

                }
            }
            score = bestScore;
           
        }
        public int evaluateScore(GameEntity node)
        {
            int tankCount = 0;
            int score = 0;


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((node.x != i && node.y != j) || (node.x != t.x && node.y != t.y))
                    {
                        foreach(GameEntity c in tankList){
                            if (i == c.x || j == c.y)
                            {
                                break;

                            }


                        }
                        if (emptyCells.Contains(grid.gameGrid[i, j]))
                        {

                            if ((i <= node.x + 1 && i >= node.x - 1) || (j <= node.y + 1 && j >= node.y - 1))
                            {
                                if (emptyCells.Contains(grid.gameGrid[i, j]))
                                    if (grid.gameGrid[i, j].GetType() == typeof(Tank))
                                    {

                                        score += -1000;

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
                            else if ((i <= node.x + 2 && i >= node.x - 2) || (j <= node.y + 2 && j >= node.y - 2))
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
                            else if ((i <= node.x + 3 && i >= node.x - 3) || (j <= node.y + 3 && j >= node.y - 3))
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
                            else if ((i <= node.x + 4 && i >= node.x - 4) || (j <= node.y + 4 && j >= node.y - 4))
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

                            else if ((i <= node.x + 5 && i >= node.x - 5) || (j <= node.y + 5 && j >= node.y - 5))
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
                            else if ((i <= node.x + 6 && i >= node.x - 6) || (j <= node.y + 6 && j >= node.y - 6))
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
                            else if ((i <= node.x + 7 && i >= node.x - 7) || (j <= node.y + 7 && j >= node.y - 7))
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
                            else if ((i <= node.x + 8 && i >= node.x - 8) || (j <= node.y + 8 && j >= node.y - 8))
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
                            else if ((i <= node.x + 9 && i >= node.x - 9) || (j <= node.y + 9 && j >= node.y - 9))
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

                }
            }
            return score;

        }
        
    }


    //if (node.IsTerminal())
    //{int n = node.GetTotalScore(Player).Row;
    //int m = node.GetTotalScore(Player).Column;
    //    t.x = n;
    //    t.y = m;
    //    Console.WriteLine("sferfhgfj");
    //    return node.GetTotalScore(Player).score;
    //}

    //if (Player == MaxPlayer)
    //{
    //    foreach (Node child in node.Children(Player))
    //    {
    //        alpha = Math.Max(alpha, Iterate(child, alpha, beta, !Player));
    //        if (beta < alpha)
    //        {
    //            break;
    //        }

    //    }

    //    return alpha;
    //}
    //else
    //{
    //    foreach (Node child in node.Children(Player))
    //    {
    //        beta = Math.Min(beta, Iterate(child, alpha, beta, !Player));

    //        if (beta < alpha)
    //        {
    //            break;
    //        }
    //    }

    //    return beta;
    //}



}
