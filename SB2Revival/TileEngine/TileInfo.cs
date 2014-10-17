// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TileInfo.cs=
// = 10/17/2014 =
// =SB2Revival=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SB2Revival.TileEngine
{
    public class TileInfo
    {
        #region Virtial
        int tileIndex;
        int tileSet;
        #endregion
        #region gets/sets
        public int TileIndex
        {
            get
            {
                return this.tileIndex;
            }
            private set
            {
                this.tileIndex = value;
            }
        }
        public int TileSet
        {
            get
            {
                return this.tileSet;
            }
            private set
            {
                this.tileSet = value;
            }
        }
        #endregion
        #region class
        public TileInfo(int tileIndex, int tileset)
        {
            this.TileIndex = tileIndex;
            this.TileSet = tileset;
        }
        #endregion
        #region logic
        #endregion
    }
}