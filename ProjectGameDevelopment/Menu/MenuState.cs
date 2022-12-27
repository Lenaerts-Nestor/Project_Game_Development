using Apos.Gui;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using ProjectGameDevelopment.Map;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.Menu
{
    public class MenuState : State
    {
        private List<MenuComponent> _components;


        private ScreenManager _screenManager;
        private Game1 tijdelijkeGame;
        private GraphicsDevice _device;
        public MenuState(Game1 game1, GraphicsDevice graphicDevice, ContentManager content, Level1 lvl1) : base(game1, graphicDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls\\ButtonImage");
            var buttonFont = _content.Load<SpriteFont>("Fonts\\Font");
            //LEVEL 1
            var Level1button = new MenuButton(buttonTexture, buttonFont)
            {
                Position = new Vector2(300,200),
                Text = "LEVEL 1",

            };

            _screenManager = new ScreenManager();
            tijdelijkeGame = game1;
            _device = graphicDevice;
            tijdelijkeGame.Components.Add(_screenManager);
            Level1button.Click += Level1Button_click;



            //LEVEL 2
            var Level2button = new MenuButton(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "LEVEL 2",
            };
            Level2button.Click += Level2Button_click;

            _components = new List<MenuComponent>
            {
                Level1button,
                Level2button
            };
        }

        private void Level2Button_click(object sender, EventArgs e)
        {
            Debug.WriteLine("op level 2 ");
            LoadLevel2();
        }

        private void Level1Button_click(object sender, EventArgs e)
        {
            Debug.WriteLine("op level 1 ");
            LoadLevel1();

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();


            foreach (var component in _components)
            {
                component.Draw(spriteBatch, gameTime);
            }






            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //momenteel geen used
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }


        private void LoadLevel1()
        {

            _screenManager.LoadScreen(new Level1(tijdelijkeGame), new FadeTransition(_device, Color.Black));

        }
        private void LoadLevel2()
        {
            _screenManager.LoadScreen(new Level2(tijdelijkeGame), new FadeTransition(_device, Color.Black));
        }



    }
}
