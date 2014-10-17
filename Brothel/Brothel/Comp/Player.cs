// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =Player.cs=
// = 10/17/2014 =
// =Brothel=
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SB2Revival;
using SB2Revival.TileEngine;
namespace SB2R.Comp
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Player
    {
        #region Field Region
        Camera camera;
        Game1 gameRef;
        #endregion
        #region Property Region
        public Camera Camera
        {
            get
            {
                return this.camera;
            }
            set
            {
                this.camera = value;
            }
        }
        #endregion
        #region Constructor Region
        public Player(Game game)
        {
            this.gameRef = (Game1)game;
            this.camera = new Camera(this.gameRef.ScreenRec);
        }
        #endregion
        #region Method Region
        public void Update(GameTime gameTime)
        {
            this.camera.Update(gameTime);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
        #endregion
    }
}