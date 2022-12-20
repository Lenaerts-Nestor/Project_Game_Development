using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace ProjectGameDevelopment.Map
{
    public class MapManager
    {
        //properties:

        public TmxMap Map;
        public Texture2D Tileset;
        public int TilesetTilesWide;
        public int TileWidth;
        public int TileHeight;


        public MapManager(TmxMap _map, Texture2D _tileset, int _tilesetWide, int _tileWidth, int _tileHeight)
        {

            Map = _map;
            Tileset = _tileset;
            TilesetTilesWide = _tilesetWide;
            TileWidth = _tileWidth;
            TileHeight = _tileHeight;
        }
        public void draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Map.TileLayers.Count; i++)
            {
                for (int j = 0; j < Map.TileLayers[i].Tiles.Count; j++)
                {
                    int gid = Map.TileLayers[i].Tiles[j].Gid;
                    if (gid == 0)
                    {
                        //do niks
                    }
                    else
                    {
                        int tileFrame = gid - 1;
                        int column = tileFrame % TilesetTilesWide;
                        int row = (int)Math.Floor(tileFrame / (double)TilesetTilesWide);
                        float x = j % Map.Width * Map.TileWidth;
                        float y = (float)Math.Floor(j / (double)Map.Width) * Map.TileHeight;
                        Rectangle TilesetRec = new Rectangle(TileWidth * column, TileHeight * row, TileWidth, TileHeight);
                        spriteBatch.Draw(Tileset, new Rectangle((int)x, (int)y, TileWidth, TileHeight), TilesetRec, Color.White);
                    }
                }
            }
        }
    }
}
