// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =StartMenuScreen.cs=
// = 10/17/2014 =
// =Brothel=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SB2R.GameScreens;
using SB2Revival;
using SB2Revival.Controls;
namespace SB2R.Screes
{
    public class StartMenuScreen : BaseGameState
    {
        #region Field region
        PictureBox backgroundImage;
        PictureBox arrowImage;
        LinkLabel startGame;
        LinkLabel loadGame;
        LinkLabel exitGame;
        LinkLabel continueGame;
        LinkLabel optGame;
        float maxItemWidth = 0f;
        #endregion
        #region Property Region
        #endregion
        #region Constructor Region
        public StartMenuScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }
        #endregion
        #region XNA Method Region
        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            ContentManager Content = this.Game.Content;
            this.backgroundImage = new PictureBox(this.GameRef.ImaHandel.LoadImage(string.Format("{0}{1}", this.GameRef.locs.GetBackLoc(), @"MainMenu.jpg")), this.GameRef.ScreenRec);
            this.ControlManager.Add(this.backgroundImage);
            Texture2D arrowTexture = this.GameRef.ImaHandel.LoadImage(string.Format("{0}{1}", this.GameRef.locs.GetGUi(), @"leftarrowUp.png"));
            this.arrowImage = new PictureBox(
                arrowTexture,
                new Rectangle(
                    0,
                    0,
                    arrowTexture.Width,
                    arrowTexture.Height));
            this.ControlManager.Add(this.arrowImage);
            this.startGame = new LinkLabel();
            this.startGame.Text = "New Game";
            this.startGame.Size = this.startGame.SpriteFont.MeasureString(this.startGame.Text);
            this.startGame.Selected += new EventHandler(this.menuItem_Selected);
            this.loadGame = new LinkLabel();
            this.loadGame.Text = "Load Game";
            this.loadGame.Size = this.loadGame.SpriteFont.MeasureString(this.loadGame.Text);
            this.loadGame.Selected += this.menuItem_Selected;
            this.exitGame = new LinkLabel();
            this.exitGame.Text = "Exit";
            this.exitGame.Size = this.exitGame.SpriteFont.MeasureString(this.exitGame.Text);
            this.exitGame.Selected += this.menuItem_Selected;
            this.continueGame = new LinkLabel();
            this.continueGame.Text = "Continue";
            this.continueGame.Size = this.continueGame.SpriteFont.MeasureString(this.continueGame.Text);
            this.continueGame.Selected += this.menuItem_Selected;
            this.optGame = new LinkLabel();
            this.optGame.Text = "Options";
            this.optGame.Size = this.optGame.SpriteFont.MeasureString(this.optGame.Text);
            this.optGame.Selected += new EventHandler(this.menuItem_Selected);
            this.ControlManager.Add(this.startGame);
            this.ControlManager.Add(this.continueGame);
            this.ControlManager.Add(this.loadGame);
            this.ControlManager.Add(this.optGame);
            this.ControlManager.Add(this.exitGame);
            this.ControlManager.NextControl();
            this.ControlManager.FocusChanged += new EventHandler(this.ControlManager_FocusChanged);
            Vector2 position = new Vector2(
                this.GameRef.Gra.PreferredBackBufferWidth / 2,
                this.GameRef.Gra.PreferredBackBufferHeight / 2);
            foreach (Control c in this.ControlManager)
            {
                if (c is LinkLabel)
                {
                    if (c.Size.X > this.maxItemWidth)
                    {
                        this.maxItemWidth = c.Size.X;
                    }
                    c.Position = position;
                    position.Y += c.Size.Y + 5f;
                    c.UpX();
                }
            }
            this.ControlManager_FocusChanged(this.startGame, null);
            this.GameRef.musPlayer.beGinMus(string.Format("{0}{1}", Environment.CurrentDirectory, @"\Data\Music\PrinceDefeat.ogg"));
            this.GameRef.musPlayer.BeEnd(true);
        }
        void ControlManager_FocusChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Vector2 position = new Vector2(control.Position.X + this.maxItemWidth + 10f,
                control.Position.Y);
            this.arrowImage.SetPosition(position);
        }
        private void menuItem_Selected(object sender, EventArgs e)
        {
            if (sender == this.startGame)
            {
                this.StateManager.PushState(this.GameRef.GamePlay);
            }
            if (sender == this.loadGame)
            {
                this.StateManager.PushState(this.GameRef.GamePlay);
            }
            if (sender == this.optGame)
            {
                this.StateManager.PushState(this.GameRef.OptMen);
            }
            if (sender == this.exitGame)
            {
                this.GameRef.Exit();
            }
        }
        public override void Update(GameTime gameTime)
        {
            this.ControlManager.Update(gameTime, this.playerIndexInControl);
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            this.GameRef.SrtBatch.Begin();
            base.Draw(gameTime);
            this.ControlManager.Draw(this.GameRef.SrtBatch);
            this.GameRef.SrtBatch.End();
        }
        #endregion
        #region Game State Method Region
        #endregion
    }
}