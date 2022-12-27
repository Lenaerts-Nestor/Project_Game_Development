using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.InputControl;
using ProjectGameDevelopment.Map;
using ProjectGameDevelopment.Menu;
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

        private ScreenManager _screenManager;
        

        private State _currentState;
        private State _Nextstate;

        public void Changestate(State state)
        {
            _Nextstate = state;
        }

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

            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content, new Level1(this));

            //LoadLevel2();
        }

        protected override void LoadContent()
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);


        }

        protected override void Update(GameTime gameTime)
        {
            if(_Nextstate != null)
            {
                _currentState = _Nextstate;
                _Nextstate = null;
            }


            _currentState.Update(gameTime);

           


            _currentState.PostUpdate(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _currentState.Draw(gameTime, _spriteBatch);
            



            
            base.Draw(gameTime);
        }
    }
}