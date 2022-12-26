using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.InputControl;
using ProjectGameDevelopment.Map;
using ProjectGameDevelopment.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TiledSharp;

namespace ProjectGameDevelopment
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;



        private bool _gameOver = false;

        #region Player

        private Player _player;
        private List<Bullet> _bullets;
        private Texture2D _bulletTexture;
        private int _playerHP = 10;
        private int _time_x_hurt = 80;
        private int _points = 0;
        private Vector2 _initPos;
        private int _time_x_bullet;

        #endregion



        #region Enemy
        private Enemy npc1;
        private Enemy npc2;
        private Enemy npc3;
        private int _time_X_attacking;
        private List<Enemy> _enemyList;
        private List<Rectangle> _enemyPathway;

        #endregion

        #region Map
        // map zelf

        private TmxMap _mapLevel1;
        private TmxMap _mapLevel2;
        
        //tekening van de map
        private Texture2D _tileset1;
        private Texture2D _tileset2;

        public Vector2 enemyInitPos;
        //map fabricatie
        private MapMaker _map1;
        private MapMaker _map2;

        //TODO : DESIGN PATTERN DOEN 
        private List<Rectangle> _collisionTiles;
        private List<Rectangle> _RespawnZone;
        


        #endregion

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _enemyList = new List<Enemy>();
            
            _collisionTiles = new List<Rectangle>();
            _enemyPathway = new List<Rectangle>();
            _RespawnZone = new List<Rectangle>();



            #region Map

            //Definieren van de Map [de tilemap]
            _mapLevel1 = new TmxMap("Content\\Level1.tmx");
            _mapLevel2 = new TmxMap("Content\\Level2.tmx");


            //Definieren van de Tileset
            _tileset1 = Content.Load<Texture2D>("Final\\Assets\\" + _mapLevel1.Tilesets[0].Name.ToString());
            _tileset2 = Content.Load<Texture2D>("Final\\Assets\\" + _mapLevel2.Tilesets[0].Name.ToString());


            //creer de Mappen
            _map1 = new MapMaker(_mapLevel1, _tileset1);
            _map2 = new MapMaker(_mapLevel2, _tileset2);


            #endregion

            #region Collision Bewaren

            //het bewaren van de collision in de maps
            foreach (var CollisionRect in _mapLevel1.ObjectGroups["Collisions"].Objects)
            {
                if (CollisionRect.Name == "")
                {
                    _collisionTiles.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width-10, (int)CollisionRect.Height-10));
                }
                //de player zal verschijnen op het gewenste plaats
                else if (CollisionRect.Name == "Respawn")
                {
                    _RespawnZone.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width-10 , (int)CollisionRect.Height));
                }
                

            }
            foreach (var CollisionRect in _mapLevel1.ObjectGroups["EnemyPathWay"].Objects)
            {
                _enemyPathway.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width, (int)CollisionRect.Height));
            }


            #endregion

            #region Player Creation 

            // creer Player => 
            _player = new Player(new Vector2(_RespawnZone[0].X, _RespawnZone[0].Y),true,
               Content.Load<Texture2D>("Sprite Pack 4\\1 - Agent_Mike_Idle (32 x 32)"),
               Content.Load<Texture2D>("Sprite Pack 4\\1 - Agent_Mike_Running (32 x 32)"),
               Content.Load<Texture2D>("Sprite Pack 4\\1 - Agent_Mike_Hurt (32 x 32)")
               );


            #endregion

            #region Enemy Creation
            //creer de Enemies =>
            npc1 = new Enemy( Content.Load<Texture2D>("Sprite Pack 4\\2 - Martian_Red_Running (32 x 32)"),_enemyPathway[0],0.5f,
                false,false,_player,new Vector2()
                ) ;
            npc2 = new Enemy(Content.Load<Texture2D>("Sprite Pack 4\\8 - Roach_Running (32 x 32)"),_enemyPathway[1],0.5f,
                false,false,_player,new Vector2()
                );
            npc3 = new Enemy(Content.Load<Texture2D>("Sprite Pack 4\\8 - Roach_Running (32 x 32)"),new Rectangle(),1f,
               false,true,_player, new Vector2(_RespawnZone[1].X, _RespawnZone[1].Y)
               );
            //voeg de Enemies in de lijst => 
            _enemyList.Add(npc1);
            _enemyList.Add(npc2);
            _enemyList.Add(npc3); //deze is de Intiligente Enemy die de Player/Hero zal volgen


            #endregion

            #region Bullet Creation

            _bullets = new List<Bullet>();
            _bulletTexture = Content.Load<Texture2D>("Sprite Pack 4\\1 - Agent_Mike_Bullet (16 x 16)");


            #endregion
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            #region Positie updaten van Entiteiten
            //dit is om de inteligente enemy positie goed te kunnen updaten en bugs voorkomen
            if (_enemyList.Count > 0)
                enemyInitPos = _enemyList.Last().Position;
            else
                enemyInitPos= new Vector2();

            //dit is om de Player positie goed te kunnen updaten en bugs voorkomen
            _initPos = _player.Position;

            #endregion


            #region Entiteiten updaten

            _player.Update(gameTime);

            foreach (var enemy in _enemyList)
            {
                enemy.Update(gameTime);

                if (_player.TouchedEnemy(_enemyList)){
                    _time_X_attacking++;
                    if(_time_X_attacking > _time_x_hurt)
                    {
                        _playerHP--;
                        _time_X_attacking = 0;
                    }
                }
                
            }

            
            Debug.WriteLine(_playerHP);

            

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
                                enemy.Position.X = enemyInitPos.X;
                                enemy.Position.Y = enemyInitPos.Y;
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

            if (_player.IsShooting && _bullets.ToArray().Length < 5)
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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            //teken de map
            _map1.Draw(_spriteBatch);
            //teken de Objecten
            #region Enemy
            foreach (var enemy in _enemyList)
            {
                enemy.Draw(_spriteBatch, gameTime);
            }
            #endregion
            #region Player
            _player.Draw(_spriteBatch, gameTime);
            foreach (var bullet in _bullets.ToArray())
            {
                bullet.Draw(_spriteBatch,gameTime);
            }
            #endregion
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}