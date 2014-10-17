// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =GamePlayScreen.cs=
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
using SB2Revival;
using SB2Revival.Controls;
namespace SB2R.Screes
{
    public class GamePlayScreen : BaseGameState
    {
        #region Field Region
        #endregion
        #region Property Region
        #endregion
        #region Constructor Region
        public GamePlayScreen(Game game, GameStateManager manager) : base(game, manager)
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
        #region Abstract Method Region
        #endregion
    }
}