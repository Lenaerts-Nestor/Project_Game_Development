using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace ProjectGameDevelopment.Menu
{
    public abstract class State
    {
        #region Fields

        protected ContentManager _content;
        protected Game1 _game1;
        protected GraphicsDevice _graphicsDevice;
        #endregion


        #region Methods

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void PostUpdate(GameTime gameTime);
        public abstract void Update(GameTime gameTime);

        #endregion

        public State(Game1 game1, GraphicsDevice graphicDevice, ContentManager content)
        {
            _game1 = game1;
            _graphicsDevice = graphicDevice;
            _content = content;

        }


    }
}
