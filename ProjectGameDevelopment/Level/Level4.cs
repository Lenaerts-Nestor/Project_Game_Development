using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.Map;
using ProjectGameDevelopment.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace ProjectGameDevelopment.Level
{
    public class Level4: LevelMaker
    {
        private new Game1 Game => (Game1)base.Game;
        public Level4(Game game) : base(game) { }

        public override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //Map maken => 
            _map = new TmxMap("Content\\Level4.tmx");
            _tileset = Content.Load<Texture2D>("Final\\Season\\" + _map.Tilesets[0].Name.ToString());
            _mapMaker = new MapDrawer(_map, _tileset);

            //BEWAAR DE COLLISIONS =>
            GetCollisionOfMap();

            Player = new Player(new Vector2(RespawnZone[0].X, RespawnZone[0].Y), true,
            Content.Load<Texture2D>("Sprite Pack 5\\2 - Lil Wiz\\Idle_(32 x 32)"), Content.Load<Texture2D>("Sprite Pack 5\\2 - Lil Wiz\\Running_(32 x 32)"),
              Content.Load<Texture2D>("Sprite Pack 5\\2 - Lil Wiz\\Ducking_(32 x 32)"), Content.Load<Texture2D>("Sprite Pack 5\\2 - Lil Wiz\\Casting_Spell_Aerial_(32 x 32)"));

            //Enemy Creatie => 
            _enemyList.Add(new Enemy(Content.Load<Texture2D>("Sprite Pack 4\\2 - Martian_Red_Running (32 x 32)"), EnemyPathWay[0], 1f, false, false, Player, new Vector2()));
            _enemyList.Add(new Enemy(Content.Load<Texture2D>("Sprite Pack 5\\1 - Robo Retro\\Flying_(32 x 32)"), new Rectangle(), 0.5f, false, true, Player, new Vector2(RespawnZone[1].X, RespawnZone[1].Y)));

            _buffItemList.Add(new BuffItem(Content.Load<Texture2D>("Health_Kit (16 x 16)"), new Vector2(RespawnZone[2].X, RespawnZone[2].Y), 0));
            //Bullets creatie 
            _bulletTexture = Content.Load<Texture2D>("Sprite Pack 5\\2 - Lil Wiz\\Sparkles_(8 x 8)");
        }

        public override void Draw(GameTime gameTime)
        {
            DrawTheLevel(gameTime, new Vector2(50, 40), new Vector2(50, 60),Color.Black,true);
        }

        public override void Update(GameTime gameTime)
        {
            UpdateTheLevel(gameTime, this.Game, 0, 1);
        }
    }
}
