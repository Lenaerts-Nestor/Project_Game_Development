using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;

namespace ProjectGameDevelopment.Menu
{
    public class GameOverPanel : GameScreen
    {
        private List<MenuComponent> _components;

        private new Game1 Game => (Game1)base.Game;

        public SpriteBatch _spriteBatch;

        public GameOverPanel(Game game) : base(game)
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var buttonTexture = game.Content.Load<Texture2D>("Controls\\ButtonImage");
            var buttonFont = game.Content.Load<SpriteFont>("Fonts\\Font");

            var QuitButton = new MenuButton(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "QUIT GAME",

            };

            QuitButton.Click += QuitButton_click;


            //LEVEL 2
            var MenuButton = new MenuButton(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "Back to Menu",
            };
            MenuButton.Click += MenuButton_click;

            _components = new List<MenuComponent>
            {
                MenuButton,
                QuitButton
            };
        }

        private void MenuButton_click(object sender, EventArgs e)
        {

            this.Game.stateOfGame = currentGameState.Menu;
        }

        private void QuitButton_click(object sender, EventArgs e)
        {
            this.Game.Exit();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {

            foreach (var component in _components)
            {
                component.Draw(_spriteBatch, gameTime);
            }
        }
    }
}
