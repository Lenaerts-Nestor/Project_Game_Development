using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.InputControl;
using ProjectGameDevelopment.Map;
using System.Collections.Generic;
using System.Linq;
using TiledSharp;

namespace ProjectGameDevelopment
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

      


        #region Player

        private Player _player;
        #endregion



        #region Enemy
        private Enemy npc1;
        private Enemy npc2;
        private Enemy npc3;
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

        //map fabricatie
        private MapMaker _map1;
        private MapMaker _map2;

        //TODO : DESIGN PATTERN DOEN 
        private List<Rectangle> _collisionTiles;
        private Rectangle _startZone;
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

            #region Collision

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
               Content.Load<Texture2D>("Sprite Pack 5\\2 - Lil Wiz\\Idle_(32 x 32)"),
               Content.Load<Texture2D>("Sprite Pack 5\\2 - Lil Wiz\\Running_(32 x 32)"),
               Content.Load<Texture2D>("Sprite Pack 5\\2 - Lil Wiz\\Ducking_(32 x 32)")
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
            npc3 = new Enemy(Content.Load<Texture2D>("Sprite Pack 4\\8 - Roach_Running (32 x 32)"),new Rectangle(),2f,
               false,true,_player, new Vector2(_RespawnZone[1].X, _RespawnZone[1].Y)
               );
            //voeg de Enemies in de lijst => 
            _enemyList.Add(npc1);
            _enemyList.Add(npc2);
            _enemyList.Add(npc3); //deze is de Intiligente Enemy die de Player/Hero zal volgen


            #endregion
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

         

            #region Entity Gravity
            var initpos = _player.Position;
            var enemyInitPos = _enemyList[2].Position;

            //PLAYER COLLISION
            _player.Update(gameTime);
            foreach (var rect in _collisionTiles)
            {
                if (!_player.IsJumping)
                    _player.IsFalling = true;
                if (rect.Intersects(_player.Hitbox))
                {
                    _player.Position.X = initpos.X;
                    _player.Position.Y = initpos.Y;
                    _player.IsFalling = false;
                   
                   
                    break;
                }
            }

            //ENEMY COLLISION
            foreach (var enemy in _enemyList)
            {
                enemy.Update(gameTime);
            }
            foreach (var rect in _collisionTiles)
            {
                if (!_player.IsJumping)
                    _enemyList[2].IsFalling = true;

                if (rect.Intersects(_enemyList[2].Hitbox))
                {

                    _enemyList[2].Position.X = enemyInitPos.X;
                    _enemyList[2].Position.Y = enemyInitPos.Y;
                    _enemyList[2].IsFalling = false;
                    break;
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
            //teken de Character
            foreach (var enemy in _enemyList)
            {
                enemy.Draw(_spriteBatch, gameTime);
            }

            _player.Draw(_spriteBatch, gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}