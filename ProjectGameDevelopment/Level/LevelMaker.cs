using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.Map;
using ProjectGameDevelopment.Objects;
using System.Collections.Generic;
using TiledSharp;

namespace ProjectGameDevelopment.Level
{
    public abstract class LevelMaker : GameScreen, IPlayerconditionCheck
    {
        public LevelMaker(Game game) : base(game) { }       //dit is van gamescreen
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
        public LevelInteraction LevelCollisionControler { get; set; } = new LevelInteraction();

        // Items => 
        public List<BuffItem> _buffItemList { get; set; } = new List<BuffItem>();
        public BuffItem _buffItem { get; set; }


        //Game Condition Kijken => 
        public bool PlayerIsAlive { get; set; }
        public bool GameIsOver { get; set; }



        public void GetCollisionOfMap()
        {
            CollisionTiles = _collisionController.GetTilesCollision(_map, CollisionTiles);
            EnemyPathWay = _collisionController.GetEnemyPathWayCollision(_map, EnemyPathWay);
            RespawnZone = _collisionController.GetRespawnCollision(_map, RespawnZone);
            EndZone = _collisionController.GetEndCollision(_map, EndZone);
        }

        //UPDATE EN DRAW THE LEVEL
        public void DrawTheLevel(GameTime gameTime, Vector2 hpPos, Vector2 score, Color color, bool showpoints) 
        {
            _spriteBatch.Begin();

            _collisionController.DrawLevelMap(_spriteBatch, _mapMaker); // Tekenen van de map

            //Teken de TEXT Punten en Extra's 
            _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts\\Font"), $"HP: {Player.HealthPoints}", score, color);
            if (showpoints)
                _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts\\Font"), $"POINTS: {Player.Points}", hpPos, color);

            if (_buffItemList.Count > 0)
                _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts\\Font"), $"Item", new Vector2(RespawnZone[2].X - 10, RespawnZone[2].Y - 20), Color.White);


            Player.Draw(_spriteBatch, gameTime);                                                //Tekenen van Player
            foreach (var enemy in _enemyList) { enemy.Draw(_spriteBatch, gameTime); }           // Tekenen van Enemie's 
            foreach (var bullet in _bullets.ToArray()) { bullet.Draw(_spriteBatch, gameTime); } //Tekenen van bu;llet
            foreach (var buffitem in _buffItemList) { buffitem.Draw(_spriteBatch, gameTime); }

            _spriteBatch.End();
        }

        public void UpdateTheLevel(GameTime gameTime, Game1 Game, int NextState, int buffSpeed)
        {
            LevelCollisionControler.GetPlayerToNextZone(Player, EndZone, Game, NextState);
            LevelCollisionControler.GetItemBuff(_buffItemList, Player,buffSpeed);
            EnemyInitPos = LevelCollisionControler.GetEnemyPosition(_enemyList, EnemyInitPos);
            PlayerInitPosition = Player.Position;

            Player.Update(gameTime);
            LevelCollisionControler.GetPlayerLifeCondition(Player, _enemyList, gameTime);

            LevelCollisionControler.GetPlayerCollides(Player, CollisionTiles, PlayerInitPosition);
            LevelCollisionControler.GetBulletCollides(Player, _bullets, _enemyList, CollisionTiles, gameTime);
            LevelCollisionControler.GetEnemyCollides(CollisionTiles, _enemyList, EnemyInitPos);
            LevelCollisionControler.GetBullets(_bullets, Player, _time_x_bullet, _bulletTexture, this);
            //LevelConditionControl.GetItemBuff(this._buffItemList, this.Player);

            LevelCollisionControler.GetPlayerGameState(Player, Game);
        }

        public int Getnumer()
        {
            return 9;
        }


    }
}
