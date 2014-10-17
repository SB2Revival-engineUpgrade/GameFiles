// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =PictureBox.cs=
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
    public class PictureBox : Control
    {
        #region Field Region
        Texture2D image;
        Rectangle sourceRect;
        Rectangle destRect;
        #endregion
        #region Property Region
        public Texture2D Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
            }
        }
        public Rectangle SourceRectangle
        {
            get
            {
                return this.sourceRect;
            }
            set
            {
                this.sourceRect = value;
            }
        }
        public Rectangle DestinationRectangle
        {
            get
            {
                return this.destRect;
            }
            set
            {
                this.destRect = value;
            }
        }
        #endregion
        #region Constructors
        public PictureBox(Texture2D image, Rectangle destination)
        {
            this.Image = image;
            this.DestinationRectangle = destination;
            this.SourceRectangle = new Rectangle(0, 0, image.Width, image.Height);
            this.Color = Color.White;
        }
        public PictureBox(Texture2D image, Rectangle destination, Rectangle source)
        {
            this.Image = image;
            this.DestinationRectangle = destination;
            this.SourceRectangle = source;
            this.Color = Color.White;
        }
        #endregion
        #region Abstract Method Region
        public override void Update(GameTime gameTime)
        {
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.destRect, this.sourceRect, this.Color);
        }
        public override void HandleInput(PlayerIndex playerIndex)
        {
        }
        #endregion
        #region Picture Box Methods
        public void SetPosition(Vector2 newPosition)
        {
            this.destRect = new Rectangle(
                (int)newPosition.X,
                (int)newPosition.Y,
                this.sourceRect.Width,
                this.sourceRect.Height);
        }
        #endregion
    }
}