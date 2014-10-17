// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =LinkLabel.cs=
// = 10/17/2014 =
// =SB2Revival=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace SB2Revival.Controls
{
    public class LinkLabel : Control
    {
        #region Fields and Properties
        Color selectedColor = Color.Black;
        public Color SelectedColor
        {
            get
            {
                return this.selectedColor;
            }
            set
            {
                this.selectedColor = value;
            }
        }
        #endregion
        #region Constructor Region
        public LinkLabel()
        {
            this.TabStop = true;
            this.HasFocus = false;
            this.Position = Vector2.Zero;
        }
        #endregion
        #region Abstract Methods
        public override void Update(GameTime gameTime)
        {
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.hasFocus)
            {
                spriteBatch.DrawString(this.SpriteFont, this.Text, this.Position, this.selectedColor);
            }
            else
            {
                spriteBatch.DrawString(this.SpriteFont, this.Text, this.Position, this.Color);
            }
        }
        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (!this.HasFocus)
            {
                return;
            }
            if (InputHandler.KeyReleased(Keys.Enter) ||
                InputHandler.ButtonReleased(Buttons.A, playerIndex))
            {
                base.OnSelected(null);
            }
        }
        #endregion
    }
}