// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =LeftRightSelector.cs=
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
    public class LeftRightSelector : Control
    {
        #region Event Region
        public event EventHandler SelectionChanged;
        #endregion
        #region Field Region
        List<string> items = new List<string>();
        Texture2D leftTexture;
        Texture2D rightTexture;
        Texture2D stopTexture;
        Color selectedColor = Color.Red;
        int maxItemWidth;
        int selectedItem;
        #endregion
        #region Property Region
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
        public int SelectedIndex
        {
            get
            {
                return this.selectedItem;
            }
            set
            {
                this.selectedItem = (int)MathHelper.Clamp(value, 0f, this.items.Count);
            }
        }
        public string SelectedItem
        {
            get
            {
                return this.Items[this.selectedItem];
            }
        }
        public List<string> Items
        {
            get
            {
                return this.items;
            }
        }
        #endregion
        #region Constructor Region
        public LeftRightSelector(Texture2D leftArrow, Texture2D rightArrow, Texture2D stop)
        {
            this.leftTexture = leftArrow;
            this.rightTexture = rightArrow;
            this.stopTexture = stop;
            this.TabStop = true;
            this.Color = Color.CornflowerBlue;
        }
        #endregion
        #region Method Region
        public void SetItems(string[] items, int maxWidth)
        {
            this.items.Clear();
            foreach (string s in items)
            {
                this.items.Add(s);
            }
            this.maxItemWidth = maxWidth;
        }
        protected void OnSelectionChanged()
        {
            if (this.SelectionChanged != null)
            {
                this.SelectionChanged(this, null);
            }
        }
        #endregion
        #region Abstract Method Region
        public override void Update(GameTime gameTime)
        {
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 drawTo = this.position;
            if (this.selectedItem != 0)
            {
                spriteBatch.Draw(this.leftTexture, drawTo, Color.White);
            }
            else
            {
                spriteBatch.Draw(this.stopTexture, drawTo, Color.White);
            }
            drawTo.X += this.leftTexture.Width + 5f;
            float itemWidth = this.spriteFont.MeasureString(this.items[this.selectedItem]).X;
            float offset = (this.maxItemWidth - itemWidth) / 2;
            drawTo.X += offset;
            if (this.hasFocus)
            {
                spriteBatch.DrawString(this.spriteFont, this.items[this.selectedItem], drawTo, this.selectedColor);
            }
            else
            {
                spriteBatch.DrawString(this.spriteFont, this.items[this.selectedItem], drawTo, this.Color);
            }
            drawTo.X += -1 * offset + this.maxItemWidth + 5f;
            if (this.selectedItem != this.items.Count - 1)
            {
                spriteBatch.Draw(this.rightTexture, drawTo, Color.White);
            }
            else
            {
                spriteBatch.Draw(this.stopTexture, drawTo, Color.White);
            }
        }
        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (this.items.Count == 0)
            {
                return;
            }
            if (InputHandler.ButtonReleased(Buttons.LeftThumbstickLeft, playerIndex) ||
                InputHandler.ButtonReleased(Buttons.DPadLeft, playerIndex) ||
                InputHandler.KeyReleased(Keys.Left))
            {
                this.selectedItem--;
                if (this.selectedItem < 0)
                {
                    this.selectedItem = 0;
                }
                this.OnSelectionChanged();
            }
            if (InputHandler.ButtonReleased(Buttons.LeftThumbstickRight, playerIndex) ||
                InputHandler.ButtonReleased(Buttons.DPadRight, playerIndex) ||
                InputHandler.KeyReleased(Keys.Right))
            {
                this.selectedItem++;
                if (this.selectedItem >= this.items.Count)
                {
                    this.selectedItem = this.items.Count - 1;
                }
                this.OnSelectionChanged();
            }
        }
        #endregion
    }
}