// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =ControlManager.cs=
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
    public class ControlManager : List<Control>
    {
        #region Fields and Properties
        int selectedControl = 0;
        static SpriteFont spriteFont;
        public static SpriteFont SpriteFont
        {
            get
            {
                return spriteFont;
            }
        }
        #endregion
        #region Constructors
        public ControlManager(SpriteFont spriteFont) : base()
        {
            ControlManager.spriteFont = spriteFont;
        }
        public ControlManager(SpriteFont spriteFont, int capacity) : base(capacity)
        {
            ControlManager.spriteFont = spriteFont;
        }
        public ControlManager(SpriteFont spriteFont, IEnumerable<Control> collection) : base(collection)
        {
            ControlManager.spriteFont = spriteFont;
        }
        #endregion
        #region Methods
        public void Update(GameTime gameTime, PlayerIndex playerIndex)
        {
            if (this.Count == 0)
            {
                return;
            }
            foreach (Control c in this)
            {
                if (c.Enabled)
                {
                    c.Update(gameTime);
                }
                if (c.HasFocus)
                {
                    c.HandleInput(playerIndex);
                }
            }
            if (InputHandler.ButtonPressed(Buttons.LeftThumbstickUp, playerIndex) ||
                InputHandler.ButtonPressed(Buttons.DPadUp, playerIndex) ||
                InputHandler.KeyPressed(Keys.Up))
            {
                this.PreviousControl();
            }
            if (InputHandler.ButtonPressed(Buttons.LeftThumbstickDown, playerIndex) ||
                InputHandler.ButtonPressed(Buttons.DPadDown, playerIndex) ||
                InputHandler.KeyPressed(Keys.Down))
            {
                this.NextControl();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Control c in this)
            {
                if (c.Visible)
                {
                    c.Draw(spriteBatch);
                }
            }
        }
        public void NextControl()
        {
            if (this.Count == 0)
            {
                return;
            }
            int currentControl = this.selectedControl;
            this[this.selectedControl].HasFocus = false;
            do
            {
                this.selectedControl++;
                if (this.selectedControl == this.Count)
                {
                    this.selectedControl = 0;
                }
                if (this[this.selectedControl].TabStop && this[this.selectedControl].Enabled)
                {
                    if (this.FocusChanged != null)
                    {
                        this.FocusChanged(this[this.selectedControl], null);
                    }
                    break;
                }
            }
            while (currentControl != this.selectedControl);
            this[this.selectedControl].HasFocus = true;
        }
        public void PreviousControl()
        {
            if (this.Count == 0)
            {
                return;
            }
            int currentControl = this.selectedControl;
            this[this.selectedControl].HasFocus = false;
            do
            {
                this.selectedControl--;
                if (this.selectedControl < 0)
                {
                    this.selectedControl = this.Count - 1;
                }
                if (this[this.selectedControl].TabStop && this[this.selectedControl].Enabled)
                {
                    if (this.FocusChanged != null)
                    {
                        this.FocusChanged(this[this.selectedControl], null);
                    }
                    break;
                }
            }
            while (currentControl != this.selectedControl);
            this[this.selectedControl].HasFocus = true;
        }
        #endregion
        #region Event Region
        public event EventHandler FocusChanged;
        #endregion
    }
}