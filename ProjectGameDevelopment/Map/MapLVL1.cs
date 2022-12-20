using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace ProjectGameDevelopment.Map
{
    internal class MapLVL1 : MapManager
    {
        public MapLVL1(TmxMap _map, Texture2D _tileset, int _tilesetWide, int _tileWidth, int _tileHeight) : base(_map, _tileset, _tilesetWide, _tileWidth, _tileHeight) { }

    }
}
