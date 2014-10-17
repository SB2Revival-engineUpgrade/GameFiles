// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =Game1.cs=
// = 10/17/2014 =
// =Brothel=
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
using SB2R.GameScreens;
using SB2R.MuCom;
using SB2R.Screes;
using SB2Revival;
namespace SB2R
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameStateManager stateManager;
        Rectangle screenRec;
        public ResHandler ResHan;
        ImLoader ImHand;
        public GameLoc locs;
        public StartMenuScreen startMenu;
        public GamePlayScreen GamePlay;
        public OptionsMenuScreen OptMen;
        public MusicPlayer musPlayer;
        #region get/set
        public GraphicsDeviceManager Gra
        {
            get
            {
                return this.graphics;
            }
            set
            {
                this.graphics = value;
            }
        }
        public Rectangle ScreenRec
        {
            get
            {
                return this.screenRec;
            }
            set
            {
                this.screenRec = value;
            }
        }
        public SpriteBatch SrtBatch
        {
            get
            {
                return this.spriteBatch;
            }
            set
            {
                this.spriteBatch = value;
            }
        }
        public ImLoader ImaHandel
        {
            get
            {
                return this.ImHand;
            }
            private set
            {
                this.ImHand = value;
            }
        }
        #endregion
        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Data";
            this.ScreenRec = new Rectangle(
                0,
                0,
                this.graphics.PreferredBackBufferWidth,
                this.graphics.PreferredBackBufferHeight);
            this.Components.Add(new InputHandler(this));
            this.stateManager = new GameStateManager(this);
            this.Components.Add(this.stateManager);
            this.ResHan = new ResHandler(this);
            this.Components.Add(this.ResHan);
            this.ResHan.SetScreenRes();
            this.locs = new GameLoc(this);
            this.ImHand = new ImLoader(this);
            this.Components.Add(this.ImHand);
            this.musPlayer = new MusicPlayer(this);
            this.Components.Add(this.musPlayer);
            this.startMenu = new StartMenuScreen(this, this.stateManager);
            this.GamePlay = new GamePlayScreen(this, this.stateManager);
            this.OptMen = new OptionsMenuScreen(this, this.stateManager);
            this.stateManager.ChangeState(this.startMenu);
        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            this.Window.Title = "Sim Brothel 2 Revival Xna convertion V0.0.0.1";
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            // TODO: use this.Content to load your game content here
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}