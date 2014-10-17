// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =MapLayer.cs=
// = 10/17/2014 =
// =SB2Revival=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SB2Revival.TileEngine
{
    public class MapLayer
    {
        #region Field Region
        TileInfo[,] map;
        #endregion
        #region Property Region
        public int Width
        {
            get
            {
                return this.map.GetLength(1);
            }
        }
        public int Height
        {
            get
            {
                return this.map.GetLength(0);
            }
        }
        #endregion
        #region Constructor Region
        public MapLayer(TileInfo[,] map)
        {
            this.map = (TileInfo[,])map.Clone();
        }
        public MapLayer(int width, int height)
        {
            this.map = new TileInfo[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    this.map[y, x] = new TileInfo(0, 0);
                }
            }
        }
        #endregion
        #region Method Region
        public TileInfo GetTile(int x, int y)
        {
            return this.map[y, x];
        }
        public void SetTile(int x, int y, TileInfo tile)
        {
            this.map[y, x] = tile;
        }
        public void SetTile(int x, int y, int tileIndex, int tileset)
        {
            this.map[y, x] = new TileInfo(tileIndex, tileset);
        }
        #endregion
    }
}