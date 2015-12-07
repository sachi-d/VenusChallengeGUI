using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace VenusTankv_v1
{
    public struct CellData
    {
        public Vector2 position;
        public int health;
        public string type;
    }
    public struct Tank
    {
        public Vector2 tankPos;
        public float Angle;
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

        int screenWidth;
        int screenHeight;

        CellData[,] grid;
        Tank myt;
        int cellcount = 10;

        int upcount = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 675;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Venus Challenge - Tank Game";

            //this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f);

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
            myt = new Tank();
            myt.Angle = 0;
            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;
            SetUpGrid();
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
            if (upcount == 60)
            {
                upcount = 0;
                // Allows the game to exit
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    this.Exit();

                ProcessKeyboard();

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
            DrawTank();

            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void DrawTank()
        {

            myt.tankPos = new Vector2(330, 66);

            Vector2 rotationPoint = new Vector2(30, 30);
            spriteBatch.Draw(tankTexture, myt.tankPos, null, Color.White, myt.Angle, rotationPoint, 1, SpriteEffects.None, 1);

        }
        private void ProcessKeyboard()
        {
            KeyboardState keybState = Keyboard.GetState();
            if (keybState.IsKeyDown(Keys.Left))
            {
                Console.WriteLine(myt.Angle);
                myt.Angle -= MathHelper.ToRadians(90);
            }
            if (keybState.IsKeyDown(Keys.Right))
            {
                myt.Angle += MathHelper.ToRadians(90);
            }
            if (keybState.IsKeyDown(Keys.Space))
            {
                Console.WriteLine("SPACE PRESSED!!!");
            }
        }


        private void DrawScenery()
        {
            Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);
            spriteBatch.Draw(foregroundTexture, screenRectangle, Color.White);
        }
        private void DrawCells()
        {
            foreach (CellData cell in grid)
            {
                if (cell.type == "brick")
                {
                    spriteBatch.Draw(brickTexture, cell.position, Color.White);
                }
                else if (cell.type == "stone")
                {
                    spriteBatch.Draw(stoneTexture, cell.position, Color.White);
                }
                else if (cell.type == "water")
                {
                    spriteBatch.Draw(waterTexture, cell.position, Color.White);
                }
                else
                {
                    spriteBatch.Draw(cellTexture, cell.position, Color.White);
                }
            }
        }

        private void SetUpGrid()
        {
            grid = new CellData[10, 10];
            int[] brickvals = { 2, 3, 45, 55, 56, 80 };
            int[] stonevals = { 12, 13, 35, 53, 89, 93 };
            int[] watervals = { 22, 31, 40, 75, 76, 83 };
            int bc = 0;
            int wc = 0;
            int sc = 0;
            int top = 36;
            int left = 300;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grid[i, j].health = 100;
                    grid[i, j].position = new Vector2(left + i * 60, top + j * 60);
                    if (bc < 6 && brickvals[bc] == (i * 10 + j))
                    {
                        grid[i, j].type = "brick";
                        bc++;
                    }
                    else if (sc < 6 && stonevals[sc] == (i * 10 + j))
                    {
                        grid[i, j].type = "stone";
                        sc++;
                    }
                    else if (wc < 6 && watervals[wc] == (i * 10 + j))
                    {
                        grid[i, j].type = "water";
                        wc++;
                    }
                    else
                    {
                        grid[i, j].type = "cell";
                    }
                }
            }
        }
    }
}
