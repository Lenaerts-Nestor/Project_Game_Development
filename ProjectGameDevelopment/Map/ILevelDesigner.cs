using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.Objects;
using System.Collections.Generic;
using TiledSharp;

namespace ProjectGameDevelopment.Map
{
    public interface ILevelDesigner
    {
        //PLAYER
        public Player _player { get; set; }
        public List<Bullet> _bullets { get; set; }
        public Texture2D _bulletTexture { get; set; }

        public int _playerHP { get; set; }
        public int _time_x_hurt { get; set; }
        public int _time_x_bullet { get; set; }
        public int _points { get; set; }
        public Vector2 _initPos { get; set; }


        //ENEMY
        public Enemy npc1 { get; set; }
        public Enemy npc2 { get; set; }
        public Enemy npc3 { get; set; }

        public int _time_X_attacking { get; set; }
        public List<Enemy> _enemyList { get; set; }
        public List<Rectangle> _enemyPathway { get; set; }

        //MAP

        public TmxMap _map { get; set; }
        public Texture2D _tileset { get; set; }
        public Vector2 _enemyInitPos { get; set; }
        public MapMaker _mapMaker { get; set; }

        //Colision bewaren
        public List<Rectangle> _collisionTiles { get; set; }
        public List<Rectangle> _respawnZone { get; set; }
        public Rectangle _endZone { get; set; }
        public LoadCollisions _collisionController { get; set; }

    }
}
