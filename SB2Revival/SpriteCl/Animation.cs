// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =Animation.cs=
// = 10/17/2014 =
// =Brothel=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace SB2Revival.SpriteCl
{
    public class Animation : ICloneable
    {
        #region Field Region
        Rectangle[] frames;
        int framesPerSecond;
        TimeSpan frameLength;
        TimeSpan frameTimer;
        int currentFrame;
        int frameWidth;
        int frameHeight;
        #endregion
        #region Property Region
        public int FramesPerSecond
        {
            get
            {
                return this.framesPerSecond;
            }
            set
            {
                if (value < 1)
                {
                    this.framesPerSecond = 1;
                }
                else if (value > 60)
                {
                    this.framesPerSecond = 60;
                }
                else
                {
                    this.framesPerSecond = value;
                }
                this.frameLength = TimeSpan.FromSeconds(1 / (double)this.framesPerSecond);
            }
        }
        public Rectangle CurrentFrameRect
        {
            get
            {
                return this.frames[this.currentFrame];
            }
        }
        public int CurrentFrame
        {
            get
            {
                return this.currentFrame;
            }
            set
            {
                this.currentFrame = (int)MathHelper.Clamp(value, 0, this.frames.Length - 1);
            }
        }
        public int FrameWidth
        {
            get
            {
                return this.frameWidth;
            }
        }
        public int FrameHeight
        {
            get
            {
                return this.frameHeight;
            }
        }
        #endregion
        #region Constructor Region
        public Animation(int frameCount, int frameWidth, int frameHeight, int xOffset, int yOffset)
        {
            this.frames = new Rectangle[frameCount];
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            for (int i = 0; i < frameCount; i++)
            {
                this.frames[i] = new Rectangle(
                    xOffset + (frameWidth * i),
                    yOffset,
                    frameWidth,
                    frameHeight);
            }
            this.FramesPerSecond = 5;
            this.Reset();
        }
        private Animation(Animation animation)
        {
            this.frames = animation.frames;
            this.FramesPerSecond = 5;
        }
        #endregion
        #region Method Region
        public void Update(GameTime gameTime)
        {
            this.frameTimer += gameTime.ElapsedGameTime;
            if (this.frameTimer >= this.frameLength)
            {
                this.frameTimer = TimeSpan.Zero;
                this.currentFrame = (this.currentFrame + 1) % this.frames.Length;
            }
        }
        public void Reset()
        {
            this.currentFrame = 0;
            this.frameTimer = TimeSpan.Zero;
        }
        #endregion
        #region Interface Method Region
        public object Clone()
        {
            Animation animationClone = new Animation(this);
            animationClone.frameWidth = this.frameWidth;
            animationClone.frameHeight = this.frameHeight;
            animationClone.Reset();
            return animationClone;
        }
        #endregion
    }
}