using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace ProjectGameDevelopment.Map
{
    public class LoadLevel
    {

        public TmxMap _mapLevel;
        public Texture2D _tileset;
        public MapMaker _mapMaker;

        public List<MapMaker> _mapMakers2;
        public List<Rectangle> _collisionTiles;
        public List<Rectangle> _respawnZone;


        public Player _player;

        public List<Enemy> _enemyList;

        public List<Bullet> _bullets;
        public Texture2D _bulletTexture;




        //bewaren van elke collision in de lijst

        public void DrawLevel(SpriteBatch spriteBatch, MapMaker _desiredMap)
        {

            _desiredMap.Draw(spriteBatch);
        }

        
        
    }
}
