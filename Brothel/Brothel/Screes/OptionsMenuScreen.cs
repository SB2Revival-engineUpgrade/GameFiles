// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =OptionsMenuScreen.cs=
// = 10/17/2014 =
// =Brothel=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SB2R.GameScreens;
using SB2R_MU001.Screens.Active;
using SB2R_MU001.Screens.AllOptions;
using SB2Revival;
using SB2Revival.Controls;
namespace SB2R.Screes
{
    public class OptionsMenuScreen : BaseGameState
    {
        #region Field Region
        LeftRightSelector genderSelector;
        PictureBox backgroundImage;
        string[] ScreenRes;
        ScreenOpt temp = new ScreenOpt();
        List<AcScreen> hehe = new List<AcScreen>();
        #endregion
        #region Property Region
        #endregion
        #region Constructor Region
        public OptionsMenuScreen(Game game, GameStateManager stateManager) : base(game, stateManager)
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
            this.temp.read();
            this.fillopts();
            this.CreateControls();
        }
        public override void Update(GameTime gameTime)
        {
            this.ControlManager.Update(gameTime, PlayerIndex.One);
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
        #region Method Region
        private void CreateControls()
        {
            Texture2D leftTexture = this.GameRef.ImaHandel.LoadImage(string.Format("{0}{1}", this.GameRef.locs.GetGUi(), @"leftarrowUp.png"));
            Texture2D rightTexture = this.GameRef.ImaHandel.LoadImage(string.Format("{0}{1}", this.GameRef.locs.GetGUi(), @"rightarrowUp.png"));
            Texture2D stopTexture = this.GameRef.ImaHandel.LoadImage(string.Format("{0}{1}", this.GameRef.locs.GetGUi(), @"StopBar.png"));
            this.backgroundImage = new PictureBox(this.GameRef.ImaHandel.LoadImage(string.Format("{0}{1}", this.GameRef.locs.GetBackLoc(), @"MainMenu.jpg")),
                this.GameRef.ScreenRec);
            this.ControlManager.Add(this.backgroundImage);
            Label label1 = new Label();
            label1.Text = "Change Screen Resolution";
            label1.Size = label1.SpriteFont.MeasureString(label1.Text);
            label1.Position = new Vector2((this.GameRef.Window.ClientBounds.Width - label1.Size.X) /
                                          2, 150);
            this.ControlManager.Add(label1);
            this.genderSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            this.genderSelector.SetItems(this.ScreenRes, 125);
            this.genderSelector.Position = new Vector2(label1.Position.X, 200);
            this.ControlManager.Add(this.genderSelector);
            LinkLabel linkLabel1 = new LinkLabel();
            linkLabel1.Text = "Accept this Resolution";
            linkLabel1.Position = new Vector2(label1.Position.X, 300);
            linkLabel1.Selected += new EventHandler(this.linkLabel1_Selected);
            this.ControlManager.Add(linkLabel1);
            this.ControlManager.NextControl();
        }
        void linkLabel1_Selected(object sender, EventArgs e)
        {
            AcScreen x = this.hehe[this.genderSelector.SelectedIndex];
            x.Writer();
            this.GameRef.ResHan.SetScreenRes();
            InputHandler.Flush();
            this.StateManager.PopState();
            //StateManager.PushState(GameRef.startMenu);
            this.StateManager.ChangeState(this.GameRef.startMenu);
        }
        #endregion
        public void fillopts()
        {
            List<string> x = new List<string>();
            this.hehe = this.temp.geSc();
            foreach (AcScreen pp in this.hehe)
            {
                string pd = string.Format("{0}X{1}:FullScreen:{2}", pp.Width, pp.Height, pp.Full);
                x.Add(pd);
            }
            this.ScreenRes = x.ToArray();
        }
    }
}