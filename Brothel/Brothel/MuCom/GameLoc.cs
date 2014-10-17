// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =GameLoc.cs=
// = 10/17/2014 =
// =Brothel=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SB2R;
namespace SB2R.MuCom
{
    public class GameLoc : GameComponent
    {
        #region Fields region
        protected Game1 GameRef;
        private string GameLoc2 = Environment.CurrentDirectory;
        private string GuiLoc = @"\Data\Graphics\Engine\GUI\";
        private string BackGroundLoc = @"\Data\Graphics\Engine\Menus\Main\";
        #endregion
        #region Properties region
        #endregion
        #region Constructor Region
        public GameLoc(Game game) : base(game)
        {
            this.GameRef = (Game1)game;
        }
        #endregion
        #region logic
        public string GetGUi()
        {
            return string.Format("{0}{1}", this.GameLoc2, this.GuiLoc);
        }
        public string GetBackLoc()
        {
            return string.Format("{0}{1}", this.GameLoc2, this.BackGroundLoc);
        }
        #endregion
    }
}