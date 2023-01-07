using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.Map;
using TiledSharp;

namespace ProjectGameDevelopment.Level
{
    public class Level2 : LevelMaker
    {
        private new Game1 Game => (Game1)base.Game;
        public Level2(Game game) : base(game) { }
        public override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //Map maken => 
            _map = new TmxMap("Content\\Level2.tmx");
            _tileset = Content.Load<Texture2D>("Final\\Season\\" + _map.Tilesets[0].Name.ToString());
            _mapMaker = new MapDrawer(_map, _tileset);

            //BEWAAR DE COLLISIONS =>
            CollisionTiles = _collisionController.GetTilesCollision(_map, CollisionTiles);
            EnemyPathWay = _collisionController.GetEnemyPathWayCollision(_map, EnemyPathWay);
            RespawnZone = _collisionController.GetRespawnCollision(_map, RespawnZone);
            EndZone = _collisionController.GetEndCollision(_map, EndZone);
            Player = new Player(new Vector2(RespawnZone[0].X, RespawnZone[0].Y), true,
              Content.Load<Texture2D>("Sprite Pack 6\\4 - Orange\\Idle (32 x 32)"), Content.Load<Texture2D>("Sprite Pack 6\\4 - Orange\\Rolling (32 x 32)"),
              Content.Load<Texture2D>("Sprite Pack 6\\4 - Orange\\Squished (32 x 32)"), Content.Load<Texture2D>("Sprite Pack 6\\4 - Orange\\Kick_Attack (32 x 32)"), false) ;

            //Enemy Creatie => 
            _enemyList.Add(new Enemy(Content.Load<Texture2D>("Sprite Pack 4\\8 - Roach_Running (32 x 32)"), EnemyPathWay[0], 1f, false, false, Player, new Vector2()));
            _enemyList.Add(new Enemy(Content.Load<Texture2D>("Sprite Pack 6\\2 - Fairy\\Idle_Flying (32 x 32)"), EnemyPathWay[1], 1f, false, false, Player, new Vector2()));
            _enemyList.Add(new Enemy(Content.Load<Texture2D>("Sprite Pack 4\\8 - Roach_Running (32 x 32)"), EnemyPathWay[2], 1f, false, false, Player, new Vector2()));


        }
        public override void Draw(GameTime gameTime)
        {
            DrawTheLevel(gameTime, new Vector2(30,220), new Vector2(30,250), Color.Black,false);
        }
        public override void Update(GameTime gameTime)
        {
            UpdateTheLevel(gameTime, this.Game,3,2);
        }
    }
}
