// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =Engine.cs=
// = 10/17/2014 =
// =SB2Revival=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace SB2Revival.TileEngine
{
    public class Engine
    {
        #region field
        static int tileWidth;
        static int tileHight;
        #endregion
        #region Gets/sets
        public static int TileWidth
        {
            get
            {
                return tileWidth;
            }
        }
        public static int TileHeight
        {
            get
            {
                return tileHight;
            }
        }
        #endregion
        #region Class
        public Engine(int tileWidth, int tileHeight)
        {
            Engine.tileHight = tileHeight;
            Engine.tileWidth = tileWidth;
        }
        #endregion
        #region Logic
        public static Point VectorToCell(Vector2 position)
        {
            return new Point((int)position.X / tileWidth, (int)position.Y / tileHight);
        }
        #endregion
    }
}