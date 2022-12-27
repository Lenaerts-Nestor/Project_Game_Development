using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace ProjectGameDevelopment.Map
{
    public abstract class Map
    {
        public TmxMap TileMap { get; set; }
        public Texture2D Tileset { get; set; }
        public int TilesetTilesWide { get; set; }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
    }
}
