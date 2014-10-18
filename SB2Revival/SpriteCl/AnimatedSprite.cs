// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =AnimatedSprite.cs=
// = 10/17/2014 =
// =SB2Revival=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SB2Revival.TileEngine;
namespace SB2Revival.SpriteCl
{
    public class AnimatedSprite
    {
        #region Field Region
        Dictionary<AnimationKey, Animation> animations;
        AnimationKey currentAnimation;
        bool isAnimating;
        Texture2D texture;
        Vector2 position;
        Vector2 velocity;
        float speed = 2.0f;
        #endregion
        #region Property Region
        public AnimationKey CurrentAnimation
        {
            get
            {
                return this.currentAnimation;
            }
            set
            {
                this.currentAnimation = value;
            }
        }
        public bool IsAnimating
        {
            get
            {
                return this.isAnimating;
            }
            set
            {
                this.isAnimating = value;
            }
        }
        public int Width
        {
            get
            {
                return this.animations[this.currentAnimation].FrameWidth;
            }
        }
        public int Height
        {
            get
            {
                return this.animations[this.currentAnimation].FrameHeight;
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
                this.speed = MathHelper.Clamp(this.speed, 1.0f, 16.0f);
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
            }
        }
        public Vector2 Velocity
        {
            get
            {
                return this.velocity;
            }
            set
            {
                this.velocity = value;
                if (this.velocity != Vector2.Zero)
                {
                    this.velocity.Normalize();
                }
            }
        }
        #endregion
        #region Constructor Region
        public AnimatedSprite(Texture2D sprite, Dictionary<AnimationKey, Animation> animation)
        {
            this.texture = sprite;
            this.animations = new Dictionary<AnimationKey, Animation>();
            foreach (AnimationKey key in animation.Keys)
            {
                this.animations.Add(key, (Animation)animation[key].Clone());
            }
        }
        #endregion
        #region Method Region
        public void Update(GameTime gameTime)
        {
            if (this.isAnimating)
            {
                this.animations[this.currentAnimation].Update(gameTime);
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Draw(
                this.texture,
                this.position,
                this.animations[this.currentAnimation].CurrentFrameRect,
                Color.White);
        }
        public void LockToMap()
        {
            this.position.X = MathHelper.Clamp(this.position.X, 0, TileMap.WidthInPixels - this.Width);
            this.position.Y = MathHelper.Clamp(this.position.Y, 0, TileMap.HeightInPixels - this.Height);
        }
        #endregion
    }
}