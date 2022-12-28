using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectGameDevelopment.Menu
{
    public abstract class State
    {
        #region Fields

        public ContentManager _content;
        public Game1 _game1;
        public GraphicsDevice _graphicsDevice;
        #endregion

        #region Methods

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);

        #endregion

        public State(Game1 game1)
        {
            _game1 = game1;

        }


    }
}
