using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Windows.Forms;

namespace VenusChallengeGUI
{
    public struct CellData
    {
        public Vector2 position;
        public int health;
        public string type;
    }

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;

        Texture2D backgroundTexture;
        Texture2D cellTexture;
        Texture2D brickTexture;
        Texture2D stoneTexture;
        Texture2D waterTexture;
        Texture2D foregroundTexture;
        Texture2D tankTexture;
        Texture2D lifepackTexture;
        Texture2D coinTexture;
        Texture2D op0Texture;
        Texture2D op1Texture;
        Texture2D op2Texture;
        Texture2D op3Texture;
        Texture2D op4Texture;

        int screenWidth = 1200; //FIXED BACKGROUND WIDTH
        int screenHeight = 675;   //FIXED BACKGROUNDHEIGHT
        int cellsize = 60;      //FIXED CELL WIDTH

        int topBoundary;
        int leftBoundary;

        GameGrid gamegrid;

        internal GameGrid Gamegrid
        {
            get { return gamegrid; }
            set { gamegrid = value; }
        }
        int cellcount;

        int upcount = 0;


        public Game1()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gamegrid = new GameGrid(this);
            cellcount = gamegrid.size;
            topBoundary = (screenHeight - (cellcount * cellsize)) / 2;
            leftBoundary = (screenWidth - (cellcount * cellsize)) / 2;
            //clientconnection = cli;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Venus Challenge - Tank Game";
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;
            backgroundTexture = Content.Load<Texture2D>("background");
            foregroundTexture = Content.Load<Texture2D>("foreground");
            cellTexture = Content.Load<Texture2D>("cell");
            brickTexture = Content.Load<Texture2D>("brick");
            stoneTexture = Content.Load<Texture2D>("stone");
            waterTexture = Content.Load<Texture2D>("water");
            tankTexture = Content.Load<Texture2D>("tank");
            lifepackTexture = Content.Load<Texture2D>("lifepack");
            coinTexture = Content.Load<Texture2D>("coin");
            op0Texture = Content.Load<Texture2D>("op0");
            op1Texture = Content.Load<Texture2D>("op1");
            op2Texture = Content.Load<Texture2D>("op2");
            op3Texture = Content.Load<Texture2D>("op3");
            op4Texture = Content.Load<Texture2D>("op4");
            //gamegrid.mytank.angle = 0;
            //screenWidth = device.PresentationParameters.BackBufferWidth;
            //screenHeight = device.PresentationParameters.BackBufferHeight;
            //SetUpGrid();


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (upcount == 30)
            {
                upcount = 0;
                // Allows the game to exit
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                    this.Exit();


                base.Update(gameTime);

            }
            else
            {
                upcount++;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            DrawScenery();
            DrawCells();
            DrawBars();
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawTank(Tank t, Texture2D tex)
        {
            Vector2 position = new Vector2(t.x * cellsize + leftBoundary + cellsize / 2, t.y * cellsize + topBoundary + cellsize / 2);
            spriteBatch.Draw(tex, position, null, Color.White, t.angle, t.rotationPoint, 1, SpriteEffects.None, 0);
        }
        public void readMessage(String m) { gamegrid.readServerMessage(m); }

        private void DrawScenery()
        {
            Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);
            spriteBatch.Draw(foregroundTexture, screenRectangle, Color.White);
        }

        private void DrawBars()
        {
            //drAW health n coins display
        }
        private void DrawCells()
        {
            Texture2D tex = cellTexture;
            for (int i = 0; i < gamegrid.size; i++)
            {
                for (int j = 0; j < gamegrid.size; j++)
                {
                    GameEntity m = gamegrid.gameGrid[i, j];
                    Vector2 mpos = new Microsoft.Xna.Framework.Vector2(leftBoundary + i * cellsize, topBoundary + j * cellsize);
                    //Console.WriteLine("iiiiiiiiiiiiiiiiiiiiii" + m.ToString());


                    switch (m.ToString().Substring(0, 2))
                    {
                        case "BB":
                            tex = brickTexture;
                            break;
                        case "SS":
                            tex = stoneTexture;
                            break;
                        case "WW":
                            tex = waterTexture;
                            break;
                        case "CC":
                            tex = coinTexture;
                            break;
                        case "LP":
                            tex = lifepackTexture;
                            break;
                        case "PP":
                            switch (m.ToString().Substring(2))
                            {
                                case "0":
                                    tex = op0Texture;
                                    break;
                                case "1":
                                    tex = op1Texture;
                                    break;
                                case "2":
                                    tex = op2Texture;
                                    break;
                                case "3":
                                    tex = op3Texture;
                                    break;
                                case "4":
                                    tex = op4Texture;
                                    break;
                                default:
                                    tex = tankTexture;
                                    break;
                            }
                            break;

                        default:
                            tex = cellTexture;
                            break;
                    }
                    switch (m.ToString().Substring(0,2))
                    {
                        case "PP":
                            //spriteBatch.Draw(tex, mpos, Color.White);
                            //DrawTank(gamegrid.mytank, tex);
                            spriteBatch.Draw(tex, mpos, Color.White);
                            break;
                        
                        default:
                            spriteBatch.Draw(tex, mpos, Color.White);
                            break;
                    }

                }
            }

        }

        public void Communicate(string msg)
        {
            gamegrid.updateLocalMoves(msg);
        }
        public void ProcessKey()
        {
            KeyboardState keybState = Keyboard.GetState();
            if (keybState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left))
                gamegrid.mytank.move("LEFT#");
            if (keybState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right))
                gamegrid.mytank.move("RIGHT#");
        }
    }
}
