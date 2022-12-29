using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.Map;
using ProjectGameDevelopment.Menu;
using System.Diagnostics;

namespace ProjectGameDevelopment
{
    public class Game1 : Game, GameState
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ScreenManager _screenManager;

        public currentGameState StateOfGame { get; set; }
        public currentPlayerState StateOfPlayer { get; set; }
        public currentGameState PreviousStateOfGame { get; set; }

        public Player Player { get; set; }


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
            StateOfGame = currentGameState.Menu;
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

            Debug.WriteLine(StateOfGame);


            if (PreviousStateOfGame != StateOfGame)
                switch (StateOfGame)
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
                    case currentGameState.GameOver:
                        LoadGameOverPanel();
                        break;
                    default:
                        break;
                }

            PreviousStateOfGame = StateOfGame;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            if (StateOfGame == currentGameState.GameOver)
                if (StateOfPlayer == currentPlayerState.Win)
                    _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts\\Font"), $"You WIN", new Vector2(330, 150), Color.Green);
                else
                    _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts\\Font"), $"You Lost", new Vector2(330, 150), Color.Red);

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
        private void LoadGameOverPanel()
        {
            _screenManager.LoadScreen(new GameOverPanel(this), new FadeTransition(GraphicsDevice, Color.Black));
        }


    }
}