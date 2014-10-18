// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =Camera.cs=
// = 10/17/2014 =
// =SB2Revival=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SB2Revival.SpriteCl;
namespace SB2Revival.TileEngine
{
    public enum CameraMode
    {
        Free,
        Follow
    }
    public class Camera
    {
        #region Field Region
        Vector2 position;
        float speed;
        float zoom;
        Rectangle viewportRectangle;
        CameraMode mode;
        #endregion
        #region Property Region
        public Matrix Transformation
        {
            get
            {
                return Matrix.CreateScale(this.zoom) *
                       Matrix.CreateTranslation(new Vector3(-this.Position, 0f));
            }
        }
        public Rectangle ViewportRectangle
        {
            get
            {
                return new Rectangle(
                    this.viewportRectangle.X,
                    this.viewportRectangle.Y,
                    this.viewportRectangle.Width,
                    this.viewportRectangle.Height);
            }
        }
        public Vector2 Position
        {
            get
            {
                return this.position;
            }
            private set
            {
                this.position = value;
            }
        }
        public float Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                this.speed = (float)MathHelper.Clamp(this.speed, 1f, 16f);
            }
        }
        public float Zoom
        {
            get
            {
                return this.zoom;
            }
        }
        public CameraMode CameraMode
        {
            get
            {
                return this.mode;
            }
        }
        #endregion
        #region Constructor Region
        public Camera(Rectangle viewportRect)
        {
            this.speed = 4f;
            this.zoom = 1f;
            this.viewportRectangle = viewportRect;
            this.mode = CameraMode.Follow;
        }
        public Camera(Rectangle viewportRect, Vector2 position)
        {
            this.speed = 4f;
            this.zoom = 1f;
            this.viewportRectangle = viewportRect;
            this.Position = position;
            this.mode = CameraMode.Follow;
        }
        #endregion
        #region Method Region
        public void Update(GameTime gameTime)
        {
            if (this.mode == CameraMode.Follow)
            {
                return;
            }
            Vector2 motion = Vector2.Zero;
            if (InputHandler.KeyDown(Keys.Left) ||
                InputHandler.ButtonDown(Buttons.RightThumbstickLeft, PlayerIndex.One))
            {
                motion.X = -this.speed;
            }
            else if (InputHandler.KeyDown(Keys.Right) ||
                     InputHandler.ButtonDown(Buttons.RightThumbstickRight, PlayerIndex.One))
            {
                motion.X = this.speed;
            }
            if (InputHandler.KeyDown(Keys.Up) ||
                InputHandler.ButtonDown(Buttons.RightThumbstickUp, PlayerIndex.One))
            {
                motion.Y = -this.speed;
            }
            else if (InputHandler.KeyDown(Keys.Down) ||
                     InputHandler.ButtonDown(Buttons.RightThumbstickDown, PlayerIndex.One))
            {
                motion.Y = this.speed;
            }
            if (motion != Vector2.Zero)
            {
                motion.Normalize();
                this.position += motion * this.speed;
                this.LockCamera();
            }
        }
        public void LockToSprite(AnimatedSprite sprite)
        {
            this.position.X = (sprite.Position.X + sprite.Width / 2) * this.zoom -
                              (this.viewportRectangle.Width / 2);
            this.position.Y = (sprite.Position.Y + sprite.Height / 2) * this.zoom -
                              (this.viewportRectangle.Height / 2);
            this.LockCamera();
        }
        public void ZoomIn()
        {
            this.zoom += .25f;
            if (this.zoom > 2.5f)
            {
                this.zoom = 2.5f;
            }
            Vector2 newPosition = this.Position * this.zoom;
            this.SnapToPosition(newPosition);
        }
        public void ZoomOut()
        {
            this.zoom -= .25f;
            if (this.zoom < .5f)
            {
                this.zoom = .5f;
            }
            Vector2 newPosition = this.Position * this.zoom;
            this.SnapToPosition(newPosition);
        }
        private void SnapToPosition(Vector2 newPosition)
        {
            this.position.X = newPosition.X - this.viewportRectangle.Width / 2;
            this.position.Y = newPosition.Y - this.viewportRectangle.Height / 2;
            this.LockCamera();
        }
        private void LockCamera()
        {
            this.position.X = MathHelper.Clamp(this.position.X,
                0,
                TileMap.WidthInPixels * this.zoom - this.viewportRectangle.Width);
            this.position.Y = MathHelper.Clamp(this.position.Y,
                0,
                TileMap.HeightInPixels * this.zoom - this.viewportRectangle.Height);
        }
        public void ToggleCameraMode()
        {
            if (this.mode == CameraMode.Follow)
            {
                this.mode = CameraMode.Free;
            }
            else if (this.mode == CameraMode.Free)
            {
                this.mode = CameraMode.Follow;
            }
        }
        #endregion
    }
}