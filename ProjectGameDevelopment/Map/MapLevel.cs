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
    public class MapLevel :Map
    {
        public MapLevel(TmxMap _map,Texture2D _tileset)
        {
            this.TileMap = _map;
            this.Tileset = _tileset;

            //deze waarden gaan altijd zo zijn =>
            this.TileWidth = _map.Tilesets[0].TileWidth;
            this.TilesetTilesWide = _tileset.Width / TileWidth;
            this.TileHeight = _map.Tilesets[0].TileHeight;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < TileMap.TileLayers.Count; i++)
            {
                for (int j = 0; j < TileMap.TileLayers[i].Tiles.Count; j++)
                {
                    int gid = TileMap.TileLayers[i].Tiles[j].Gid;
                    if (gid == 0)
                    {
                        //do niks
                    }
                    else
                    {
                        int tileFrame = gid - 1;
                        int column = tileFrame % TilesetTilesWide;
                        int row = (int)Math.Floor(tileFrame / (double)TilesetTilesWide);
                        float x = j % TileMap.Width * TileMap.TileWidth;
                        float y = (float)Math.Floor(j / (double)TileMap.Width) * TileMap.TileHeight;
                        Rectangle TilesetRec = new Rectangle(TileWidth * column, TileHeight * row, TileWidth, TileHeight);
                        spriteBatch.Draw(Tileset, new Rectangle((int)x, (int)y, TileWidth, TileHeight), TilesetRec, Color.White);
                    }
                }
            }
        }

    }
}
