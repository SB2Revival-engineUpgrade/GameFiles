// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =ResHandler.cs=
// = 10/17/2014 =
// =Brothel=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SB2R;
using SB2R_MU001.Screens.Active;
using SB2Revival;
namespace SB2R.MuCom
{
    public class ResHandler : GameComponent
    {
        #region Fields region
        protected Game1 GameRef;
        AcScreen Screens = new AcScreen();
        #endregion
        #region Properties region
        #endregion
        #region Constructor Region
        public ResHandler(Game game) : base(game)
        {
            this.GameRef = (Game1)game;
        }
        #endregion
        #region logic
        public void SetScreenRes()
        {
            this.Screens.Checker();
            this.Screens.reader();
            this.GameRef.Gra.PreferredBackBufferHeight = this.Screens.Height;
            this.GameRef.Gra.PreferredBackBufferWidth = this.Screens.Width;
            this.GameRef.Gra.IsFullScreen = this.Screens.Full;
            this.GameRef.ScreenRec = new Rectangle(
                0,
                0,
                this.Screens.Width,
                this.Screens.Height);
            this.GameRef.Gra.ApplyChanges();
        }
        #endregion
    }
}