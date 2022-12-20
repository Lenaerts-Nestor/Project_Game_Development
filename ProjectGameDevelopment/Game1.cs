using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.InputControl;
using ProjectGameDevelopment.Map;
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

        #endregion

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //TODO: mischien de maplevel in een array steken, dat onderzoeken


            //Definieren van de Map [de tilemap]
            _mapLevel1 = new TmxMap("Content\\Level1.tmx");
            _mapLevel2 = new TmxMap("Content\\Level2.tmx");
            //Definieren van de Tileset
            _tileset1 = Content.Load<Texture2D>("Final\\Assets\\" + _mapLevel1.Tilesets[0].Name.ToString());
            _tileset2 = Content.Load<Texture2D>("Final\\Assets\\" + _mapLevel2.Tilesets[0].Name.ToString());

            //creer de Mappen
            _map1 = new MapMaker(_mapLevel1, _tileset1);
            _map2 = new MapMaker(_mapLevel2, _tileset2);

            // creer Player
            _player = new Player(
               Content.Load<Texture2D>("Sprite Pack 4\\1 - Agent_Mike_Idle (32 x 32)")
              , Content.Load<Texture2D>("Sprite Pack 4\\1 - Agent_Mike_Running (32 x 32)"));
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Update de Character
            _player.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            //teken de map
            _map2.Draw(_spriteBatch);
            //teken de Character
            _player.Draw(_spriteBatch, gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}