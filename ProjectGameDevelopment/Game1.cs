using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.Map;
using ProjectGameDevelopment.Menu;
using System.Diagnostics;

namespace ProjectGameDevelopment
{
    public class Game1 : Game , GameState
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private ScreenManager _screenManager;

        public currentGameState stateOfGame { get; set; }
        
        public currentGameState previousStateOfGame { get; set; }

        private bool backtoMenu;


        public Player _player { get; set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


            _screenManager = new ScreenManager();
            Components.Add(_screenManager);
        }
        protected override void Initialize()
        {

            base.Initialize();

            //LoadLevel1();
            stateOfGame = currentGameState.Menu;
            LoadMenu();
            //_currentState = new MenuState(this);
            //LoadLevel2();
        }

        protected override void LoadContent()
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);


        }

        protected override void Update(GameTime gameTime)
        {

            Debug.WriteLine(stateOfGame);


            if(previousStateOfGame != stateOfGame)
                switch (stateOfGame)
                {
                    case currentGameState.level1:
                        LoadLevel1();
                        break;
                    case currentGameState.level2:
                        LoadLevel2();
                        break;
                    case currentGameState.Menu:
                        LoadMenu();
                        break;
                    default:
                        break;
                }

            previousStateOfGame = stateOfGame;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();


            _spriteBatch.End();
            
            base.Draw(gameTime);
        }


        private void LoadLevel1()
        {

            _screenManager.LoadScreen(new Level1(this), new FadeTransition(GraphicsDevice, Color.Black));

        }
        private void LoadLevel2()
        {
            _screenManager.LoadScreen(new Level2(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        private void LoadMenu()
        {
            _screenManager.LoadScreen(new MenuState(this), new FadeTransition(GraphicsDevice, Color.Black));
        }


    }
}