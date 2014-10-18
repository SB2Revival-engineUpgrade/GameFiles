// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TileMap.cs=
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
    public class TileMap
    {
        #region Field Region
        List<TileSet> tilesets;
        List<MapLayer> mapLayers;
        static int mapWidth;
        static int mapHeight;
        #endregion
        #region Property Region
        public static int WidthInPixels
        {
            get
            {
                return mapWidth * Engine.TileWidth;
            }
        }
        public static int HeightInPixels
        {
            get
            {
                return mapHeight * Engine.TileHeight;
            }
        }
        #endregion
        #region Constructor Region
        public TileMap(List<TileSet> tilesets, List<MapLayer> layers)
        {
            this.tilesets = tilesets;
            this.mapLayers = layers;
            mapWidth = this.mapLayers[0].Width;
            mapHeight = this.mapLayers[0].Height;
            for (int i = 1; i < layers.Count; i++)
            {
                if (mapWidth != this.mapLayers[i].Width || mapHeight != this.mapLayers[i].Height)
                {
                    throw new Exception("Map layer size exception");
                }
            }
        }
        public TileMap(TileSet tileset, MapLayer layer)
        {
            this.tilesets = new List<TileSet>();
            this.tilesets.Add(tileset);
            this.mapLayers = new List<MapLayer>();
            this.mapLayers.Add(layer);
            mapWidth = this.mapLayers[0].Width;
            mapHeight = this.mapLayers[0].Height;
        }
        #endregion
        #region Method Region
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Rectangle destination = new Rectangle(0, 0, Engine.TileWidth, Engine.TileHeight);
            TileInfo tile;
            foreach (MapLayer layer in this.mapLayers)
            {
                for (int y = 0; y < layer.Height; y++)
                {
                    destination.Y = y * Engine.TileHeight;
                    for (int x = 0; x < layer.Width; x++)
                    {
                        tile = layer.GetTile(x, y);
                        if (tile.TileIndex == -1 || tile.TileSet == -1)
                        {
                            continue;
                        }
                        destination.X = x * Engine.TileWidth;
                        spriteBatch.Draw(
                            this.tilesets[tile.TileSet].Texture,
                            destination,
                            this.tilesets[tile.TileSet].SourceRecs[tile.TileIndex],
                            Color.White);
                    }
                }
            }
        }
        public void AddLayer(MapLayer layer)
        {
            if (layer.Width != mapWidth && layer.Height != mapHeight)
            {
                throw new Exception("Map layer size exception");
            }
            this.mapLayers.Add(layer);
        }
        #endregion
    }
}