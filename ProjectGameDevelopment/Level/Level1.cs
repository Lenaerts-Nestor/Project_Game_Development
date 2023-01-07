using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.Map;
using ProjectGameDevelopment.Objects;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TiledSharp;

namespace ProjectGameDevelopment.Level
{
    public class Level1 : LevelMaker
    {
        private new Game1 Game => (Game1)base.Game;   //dit is van gamescreen
        public Level1(Game game) : base(game) { }
        public override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //Map maken => 
            _map = new TmxMap("Content\\Level1.tmx");
            _tileset = Content.Load<Texture2D>("Final\\Assets\\" + _map.Tilesets[0].Name.ToString());
            _mapMaker = new MapDrawer(_map, _tileset);

            CollisionTiles = _collisionController.GetTilesCollision(_map, CollisionTiles);
            EnemyPathWay = _collisionController.GetEnemyPathWayCollision(_map, EnemyPathWay);
            RespawnZone = _collisionController.GetRespawnCollision(_map, RespawnZone);
            EndZone = _collisionController.GetEndCollision(_map, EndZone);



            Player = new Player(new Vector2(RespawnZone[0].X, RespawnZone[0].Y), true,
              Content.Load<Texture2D>("Sprite Pack 5\\3 - Big Red\\Idle_(32 x 32)"), Content.Load<Texture2D>("Sprite Pack 5\\3 - Big Red\\Running_(32 x 32)"),
              Content.Load<Texture2D>("Sprite Pack 5\\3 - Big Red\\Hurt_(32 x 32)"), Content.Load<Texture2D>("Sprite Pack 5\\3 - Big Red\\Hurt_(32 x 32)"),false);
            //Ik vind de Hurt_ sprite grappiger
            
            _enemyList = new List<Enemy>()
            {
                new Enemy(Content.Load<Texture2D>("Sprite Pack 5\\9 - Wispy Fire\\Weak_Flicker_(32 x 32)"), EnemyPathWay[0], 0f, false, false, Player, new Vector2()),
                new Enemy(Content.Load<Texture2D>("Sprite Pack 4\\7 - Orchid_Owl_Flying (32 x 32)"), EnemyPathWay[1], 1f, false, false, Player, new Vector2()),
                new Enemy(Content.Load<Texture2D>("Sprite Pack 4\\8 - Roach_Running (32 x 32)"), new Rectangle(), 1f, false, true, Player, new Vector2(RespawnZone[1].X, RespawnZone[1].Y))
            };
            _buffItemList.Add(new BuffItem(Content.Load<Texture2D>("Health_Kit (16 x 16)"), new Vector2(RespawnZone[2].X, RespawnZone[2].Y), 0));
        }


        public override void Draw(GameTime gameTime)
        {
            DrawTheLevel(gameTime, new Vector2(50, 40), new Vector2(50, 60), Color.Red, false);
        }

        public override void Update(GameTime gameTime)
        {
            UpdateTheLevel(gameTime,this.Game,2,3);
        }
    }
}
