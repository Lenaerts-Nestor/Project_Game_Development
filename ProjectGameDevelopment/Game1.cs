using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.InputControl;
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
        private TmxMap map;
        private MapManager tilemapManager;
        private Texture2D tileset;
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


            //Map
            //TODO: MAP GOED MAKEN ==> 
            //TODO: MAP SIZE AANPASSEN of character AANPASSEN
            //TODO: Tilemap 3grote blokjes gebruiken
            //TODO: ervoor zorgen dat de manneke op zelfde nieuvau land
            map = new TmxMap("Content\\Level1.tmx");
            tileset = Content.Load<Texture2D>("Final\\Assets\\" + map.Tilesets[0].Name.ToString());
            int tileWidth = map.Tilesets[0].TileWidth;
            int tileHeight = map.Tilesets[0].TileHeight;
            int tilesetTileWidth = tileset.Width / tileWidth;

            tilemapManager = new MapManager(map, tileset, tilesetTileWidth, tileWidth, tileHeight);
            // Player
            _player = new Player(
               Content.Load<Texture2D>("Sprite Pack 4\\1 - Agent_Mike_Idle (32 x 32)")
              , Content.Load<Texture2D>("Sprite Pack 4\\1 - Agent_Mike_Running (32 x 32)"));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _player.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            tilemapManager.draw(_spriteBatch);
            _player.Draw(_spriteBatch, gameTime);

           
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}