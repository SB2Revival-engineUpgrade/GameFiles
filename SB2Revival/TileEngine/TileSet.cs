// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TileSet.cs=
// = 10/17/2014 =
// =SB2Revival=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace SB2Revival.TileEngine
{
    public class TileSet
    {
        #region Values
        Texture2D image;
        int tileWidthPix;
        int tileHeightPix;
        int tilesWide;
        int tilesHeight;
        Rectangle[] sourceRec;
        TileCo[] col;
        #endregion
        #region Gets/Sets
        public Texture2D Texture
        {
            get
            {
                return this.image;
            }
            private set
            {
                this.image = value;
            }
        }
        public int TileWidth
        {
            get
            {
                return this.tileWidthPix;
            }
            private set
            {
                this.tileWidthPix = value;
            }
        }
        public int TileHeight
        {
            get
            {
                return this.tileHeightPix;
            }
            private set
            {
                this.tileHeightPix = value;
            }
        }
        public int TilesWide
        {
            get
            {
                return this.tilesWide;
            }
            private set
            {
                this.tilesWide = value;
            }
        }
        public int TilesHigh
        {
            get
            {
                return this.tilesHeight;
            }
            private set
            {
                this.tilesHeight = value;
            }
        }
        public Rectangle[] SourceRecs
        {
            get
            {
                return (Rectangle[])this.sourceRec.Clone();
            }
        }
        public TileCo[] Col
        {
            get
            {
                return (TileCo[])this.col.Clone();
            }
        }
        #endregion
        #region Class
        public TileSet(Texture2D image, int tileswide, int tileshigh, int tilewidth, int tileheight, List<TileCo> colData)
        {
            this.Texture = image;
            this.TileWidth = tilewidth;
            this.TileHeight = tileheight;
            this.TilesHigh = tileshigh;
            this.TilesWide = tileswide;

            int tiles = this.TilesWide * this.TilesHigh;
            this.sourceRec = new Rectangle[tiles];
            int tile = 0;
            this.col = colData.ToArray();
            for (int y = 0; y < this.TilesHigh; y++)
            {
                for (int x = 0; x < this.TilesWide; x++)
                {
                    this.SourceRecs[tile] = new Rectangle(
                        x * this.TileWidth,
                        y * this.TileHeight,
                        this.TileWidth,
                        this.TileHeight);
                    tile++;
                }
            }
        }
        #endregion
        #region Logic
        #endregion
    }
}