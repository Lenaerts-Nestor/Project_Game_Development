using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.Objects;
using System.Collections.Generic;
using TiledSharp;

namespace ProjectGameDevelopment.Map
{
    public abstract class LevelMaker : GameScreen,IPlayerconditionCheck
    {
        /// <summary>
        /// Alle levels gaan de volgende Properties gebruiken om het Level te maken [het map , de player , de enemies, de bullets enzovoort]
        /// </summary>
        /// <param name="game"></param>

        public LevelMaker(Game game) : base(game) { }
        public SpriteBatch _spriteBatch { get; set; }


        public Texture2D _bulletTexture { get; set; }
        public List<Bullet> _bullets { get; set; } = new List<Bullet>();
        public int _time_x_bullet { get; set; } = 0;


        public Player Player { get; set; }
        public Vector2 PlayerInitPosition { get; set; }

        public Vector2 EnemyInitPos { get; set; }

        public Enemy npc1 { get; set; }
        public Enemy npc2 { get; set; }
        public Enemy npc3 { get; set; }
        public List<Rectangle> EnemyPathWay { get; set; } = new List<Rectangle>();
        public List<Enemy> _enemyList { get; set; } = new List<Enemy>();

        public TmxMap _map { get; set; }
        public Texture2D _tileset { get; set; }
        public MapDrawer _mapMaker { get; set; }




        public List<Rectangle> CollisionTiles { get; set; } = new List<Rectangle>();
        public List<Rectangle> RespawnZone { get; set; } = new List<Rectangle>();

        public Rectangle EndZone { get; set; } = new Rectangle();
        public MapCollision _collisionController { get; set; } = new MapCollision();
        public LevelInteraction LevelConditionControl { get; set; } = new LevelInteraction();

        // Items => 
        public List<BuffItem> _buffItemList { get; set; } = new List<BuffItem>();
        public BuffItem _buffItem { get; set; }


        //Game Condition Kijken => 
        public bool PlayerIsAlive { get; set; }
        public bool GameIsOver { get; set; }



    }
}
