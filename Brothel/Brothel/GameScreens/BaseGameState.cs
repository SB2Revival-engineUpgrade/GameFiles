// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =BaseGameState.cs=
// = 10/17/2014 =
// =Brothel=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SB2R;
using SB2Revival;
using SB2Revival.Controls;
namespace SB2R.GameScreens
{
    public abstract partial class BaseGameState : GameState
    {
        #region Fields region
        protected Game1 GameRef;
        protected ControlManager ControlManager;
        protected PlayerIndex playerIndexInControl;
        #endregion
        #region Properties region
        #endregion
        #region Constructor Region
        public BaseGameState(Game game, GameStateManager manager) : base(game, manager)
        {
            this.GameRef = (Game1)game;
            this.playerIndexInControl = PlayerIndex.One;
        }
        #endregion
        #region XNA Method Region
        protected override void LoadContent()
        {
            ContentManager Content = this.Game.Content;
            SpriteFont menuFont = Content.Load<SpriteFont>(@"Graphics\Engine\Fonts\Script");
            this.ControlManager = new ControlManager(menuFont);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        #endregion
    }
}