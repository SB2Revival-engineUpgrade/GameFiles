// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =Label.cs=
// = 10/17/2014 =
// =SB2Revival=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace SB2Revival.Controls
{
    public class Label : Control
    {
        #region Constructor Region
        public Label()
        {
            this.tabStop = false;
        }
        #endregion
        #region Abstract Methods
        public override void Update(GameTime gameTime)
        {
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.SpriteFont, this.Text, this.Position, this.Color);
        }
        public override void HandleInput(PlayerIndex playerIndex)
        {
        }
        #endregion
    }
}