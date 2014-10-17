// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =Control.cs=
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
    public abstract class Control
    {
        #region Field Region
        protected string name;
        protected string text;
        protected Vector2 size;
        protected Vector2 position;
        protected object value;
        protected bool hasFocus;
        protected bool enabled;
        protected bool visible;
        protected bool tabStop;
        protected SpriteFont spriteFont;
        protected Color color;
        protected string type;
        #endregion
        #region Event Region
        public event EventHandler Selected;
        #endregion
        #region Property Region
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value; 
            }
        }
        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }
        public Vector2 Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }
        public Vector2 Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
                this.position.Y = (int)this.position.Y;
            }
        }
        public object Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
        public bool HasFocus
        {
            get
            {
                return this.hasFocus;
            }
            set
            {
                this.hasFocus = value;
            }
        }
        public bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }
        public bool Visible
        {
            get
            {
                return this.visible;
            }
            set
            {
                this.visible = value;
            }
        }
        public bool TabStop
        {
            get
            {
                return this.tabStop;
            }
            set
            {
                this.tabStop = value;
            }
        }
        public SpriteFont SpriteFont
        {
            get
            {
                return this.spriteFont;
            }
            set
            {
                this.spriteFont = value;
            }
        }
        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
        #endregion
        #region Constructor Region
        public Control()
        {
            this.Color = Color.White;
            this.Enabled = true;
            this.Visible = true;
            this.SpriteFont = ControlManager.SpriteFont;
        }
        #endregion
        #region Abstract Methods
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void HandleInput(PlayerIndex playerIndex);
        #endregion
        #region Virtual Methods
        protected virtual void OnSelected(EventArgs e)
        {
            if (this.Selected != null)
            {
                this.Selected(this, e);
            }
        }
        public void UpX()
        {
            this.position.X = this.position.X - (this.spriteFont.MeasureString(this.text).X / 2);
        }
        #endregion
    }
}