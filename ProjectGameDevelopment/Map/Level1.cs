using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.Objects;
using System.Collections.Generic;
using System.Linq;
using TiledSharp;

namespace ProjectGameDevelopment.Map
{
    public class Level1 : GameScreen, ILevelDesigner
    {
        private new Game1 Game => (Game1)base.Game;

        #region ILEVELDESIGNER
        //PLAYER
        public Player _player { get; set; }
        public List<Bullet> _bullets { get; set; }
        public Texture2D _bulletTexture { get; set; }

        public int _playerHP { get; set; } = 10;
        public int _time_x_hurt { get; set; } = 80;
        public int _time_x_bullet { get; set; }

        public int _points { get; set; } = 0;
        public Vector2 _initPos { get; set; }


        //ENEMY
        public Enemy npc1 { get; set; }
        public Enemy npc2 { get; set; }
        public Enemy npc3 { get; set; }


        public int _time_X_attacking { get; set; }
        public List<Enemy> _enemyList { get; set; }
        public List<Rectangle> _enemyPathway { get; set; }
        public Vector2 _enemyInitPos { get; set; }

        //MAP

        public TmxMap _map { get; set; }
        public Texture2D _tileset { get; set; }
        public MapMaker _mapMaker { get; set; }

        public List<Rectangle> _collisionTiles { get; set; }
        public List<Rectangle> _respawnZone { get; set; }

        public Rectangle _endZone { get; set; }


        public BuffItem _buffItem { get; set; }
        public List<BuffItem> _buffItemList { get; set; }

        //Player Condition
        public bool IsAlive { get; set; } = true;
        public bool GameIsOver { get; set; }
        public bool CanFly { get; set; }

        #endregion

        public SpriteBatch _spriteBatch;
        public LoadCollisions _collisionController { get; set; }


        public Level1(Game1 game) : base(game)
        {

        }


        public override void LoadContent()
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _enemyList = new List<Enemy>();
            _collisionTiles = new List<Rectangle>();
            _respawnZone = new List<Rectangle>();
            _enemyPathway = new List<Rectangle>();
            _bullets = new List<Bullet>();
            _collisionController = new LoadCollisions();
            _endZone = new Rectangle();
            _buffItemList = new List<BuffItem>();

            _enemyList = new List<Enemy>();

            #region Map

            //Definieren van de Map [de tilemap]
            _map = new TmxMap("Content\\Level1.tmx");


            //Definieren van de Tileset
            _tileset = Content.Load<Texture2D>("Final\\Assets\\" + _map.Tilesets[0].Name.ToString());


            //creer de Mappen
            _mapMaker = new MapMaker(_map, _tileset);

            #endregion

            #region Collision Bewaren
            //BEWAAR DE COLLISIONS =>

            _collisionTiles = _collisionController.GetCollisionTiles(_map, _collisionTiles);

            _enemyPathway = _collisionController.GetEnemyPathWay(_map, _enemyPathway);

            _respawnZone = _collisionController.GetRespawnZone(_map, _respawnZone);

            _endZone = _collisionController.GetEnd(_map, _endZone);

            #endregion

            #region Player Creation 

            // creer Player => 
            _player = new Player(new Vector2(_respawnZone[0].X, _respawnZone[0].Y), true,
               Content.Load<Texture2D>("Sprite Pack 5\\2 - Lil Wiz\\Idle_(32 x 32)"),
               Content.Load<Texture2D>("Sprite Pack 5\\2 - Lil Wiz\\Running_(32 x 32)"),
               Content.Load<Texture2D>("Sprite Pack 5\\2 - Lil Wiz\\Ducking_(32 x 32)"),
                Content.Load<Texture2D>("Sprite Pack 5\\2 - Lil Wiz\\Casting_Spell_Aerial_(32 x 32)")
               );

            _buffItem = new BuffItem(Content.Load<Texture2D>("Health_Kit (16 x 16)"),
                new Vector2(_respawnZone[2].X, _respawnZone[2].Y), 2
                );
            _buffItemList.Add(_buffItem);


            #endregion

            #region Enemy Creation
            //creer de Enemies =>
            npc1 = new Enemy(Content.Load<Texture2D>("Sprite Pack 5\\9 - Wispy Fire\\Weak_Flicker_(32 x 32)"), _enemyPathway[0], 0f,
                false, false, _player, new Vector2()
                );
            npc2 = new Enemy(Content.Load<Texture2D>("Sprite Pack 4\\7 - Orchid_Owl_Flying (32 x 32)"), _enemyPathway[1], 0.5f,
                false, false, _player, new Vector2()
                );
            npc3 = new Enemy(Content.Load<Texture2D>("Sprite Pack 4\\8 - Roach_Running (32 x 32)"), new Rectangle(), 0.5f,
               false, true, _player, new Vector2(_respawnZone[1].X, _respawnZone[1].Y)
               );

            //ENEMIES TOEVOEGEN AAN DE LIJST =>
            _enemyList.Add(npc1);
            _enemyList.Add(npc2);
            _enemyList.Add(npc3);


            #endregion

            #region Bullet Creation

            _bullets = new List<Bullet>();
            _bulletTexture = Content.Load<Texture2D>("Sprite Pack 5\\2 - Lil Wiz\\Sparkles_(8 x 8)");


            #endregion
        }
        public override void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here
            _spriteBatch.Begin();



            //teken de map
            _collisionController.DrawLevelMap(_spriteBatch, _mapMaker);
            //teken de punten boven links Text
            _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts\\Font"), $"POINTS : {this._points}", new Vector2(50, 50), Color.White);
            _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts\\Font"), $"HP : {this._playerHP}", new Vector2(50, 80), Color.White);
            _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts\\Font"), $"3 POINTS = Win&Game over", new Vector2(50, 250), Color.White);



            //teken end game portal
            _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts\\Font"), $"END PORTAL", new Vector2(670, 45), Color.White);


            //teken de buff text boven buff als de buff Item bestaat
            if (!_player._touchedBuff)
                _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts\\Font"), $"Buff Item", new Vector2(390, 320), Color.White);


            //teken de Objecten
            #region Enemy
            foreach (var enemy in _enemyList)
            {
                enemy.Draw(_spriteBatch, gameTime);
            }
            #endregion
            #region Player
            _player.Draw(_spriteBatch, gameTime);
            foreach (var buffItem in _buffItemList.ToArray())
            {
                buffItem.Draw(_spriteBatch, gameTime);
            }

            foreach (var bullet in _bullets.ToArray())
            {
                bullet.Draw(_spriteBatch, gameTime);
            }
            #endregion
            _spriteBatch.End();

        }

        public override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Game.Exit();

            if (_endZone.Intersects(_player.Hitbox))
            {
                Game.stateOfGame = Menu.currentGameState.level2;
            }

            #region Positie updaten van Entiteiten

            //ENEMY POSITIE =>
            if (_enemyList.Count > 0)
                _enemyInitPos = _enemyList.Last().Position;
            else
                _enemyInitPos = new Vector2();

            //PLAYER POSITIE =>
            _initPos = _player.Position;

            #endregion


            #region Entiteiten updaten

            _player.Update(gameTime);

            foreach (var enemy in _enemyList)
            {
                enemy.Update(gameTime);

                if (_player.TouchedEnemy(_enemyList))
                {
                    _time_X_attacking++;
                    if (_time_X_attacking > _time_x_hurt)
                    {
                        //TODO: HP MAKEN MISCHIEN ?
                        _playerHP--;
                        if (_playerHP == 0)
                            IsAlive = false;

                        _time_X_attacking = 0;
                    }
                }

            }


            #endregion


            #region Objecten Collision


            //de Player =>
            foreach (var rect in _collisionTiles)
            {

                if (!_player.IsJumping)
                    _player.IsFalling = true;

                if (rect.Intersects(_player.Hitbox))
                {
                    _player.Position.X = _initPos.X;
                    _player.Position.Y = _initPos.Y;
                    _player.IsFalling = false;
                    break;
                }

            }

            //de Bullet && Enemy =>
            foreach (var bullet in _bullets.ToArray())
            {
                bullet.Update(gameTime);
                foreach (var rect in _collisionTiles)
                {
                    if (rect.Intersects(bullet.Hitbox))
                    {
                        _bullets.Remove(bullet);
                        break;
                    }
                }

                //als een bullet een Enemy raakt
                foreach (var enemy in _enemyList.ToArray())
                {
                    if (bullet.Hitbox.Intersects(enemy.Hitbox))
                    {
                        _enemyList.Remove(enemy);
                        _bullets.Remove(bullet);
                        _points++;
                        break;
                    }
                }
            }

            //Inteligent ENEMY COLISION bugs voorkomen => 
            foreach (var rect in _collisionTiles)
            {

                foreach (var enemy in _enemyList)
                {

                    if (rect.Intersects(enemy.Hitbox))
                    {
                        enemy.IsFalling = true;
                        if (enemy.IsInteligent)
                        {
                            if (enemy.IsAlive)
                            {
                                enemy.Position.X = _enemyInitPos.X;
                                enemy.Position.Y = _enemyInitPos.Y;
                                enemy.IsFalling = false;
                            }
                        }
                        else
                        {
                            // dit is voor Enemies met een pathway, dus er hun positie worden niet aangepast
                        }

                        break;
                    }
                }
            }

            if (_player.IsShooting && _bullets.ToArray().Length < 20)
            {
                //na de gewenste tijd word de bullets herladen
                if (_time_x_bullet > 5)
                {
                    //dit is om te weten naar welke kant de bullet zal gaan, dus als we naar recht kijken gaat het naar recht
                    if (_player.SpriteMoveDirection == SpriteEffects.None)
                    {
                        // new Vector2(_player.Position.X -7, _player.Position.Y -13)
                        _bullets.Add(new Bullet(_bulletTexture, new Vector2((int)_player.Position.X + 13, (int)_player.Position.Y + 16), 4));
                    }
                    else if (_player.SpriteMoveDirection == SpriteEffects.FlipHorizontally)
                    {
                        _bullets.Add(new Bullet(_bulletTexture, new Vector2((int)_player.Position.X + 13, (int)_player.Position.Y + 16), -4));
                    }
                    _time_x_bullet = 0;
                }
                else
                {
                    _time_x_bullet += 1;
                }

            }


            #endregion


            #region BuffItem effect =>
            foreach (var item in _buffItemList.ToArray())
            {
                if (_player.Hitbox.Intersects(item.Hitbox))
                {
                    _player.Speed += 4;
                    _player._touchedBuff = true;
                    _buffItemList.Remove(item);
                }

            }
            #endregion

            #region gameOver condition

            if (!IsAlive)
                Game.stateOfGame = Menu.currentGameState.GameOver;
            if (_points == 3)
                Game.stateOfGame = Menu.currentGameState.GameOver;


            #endregion


        }






    }
}
