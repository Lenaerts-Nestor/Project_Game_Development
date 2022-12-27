using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectGameDevelopment.Characters
{
    public interface IGameObject
    {

        /// <summary>
        /// een Object waar je iets mee kan doen of clicken, 
        /// het concept object in deze game kan zijn een Entiteit, een MenuButton , een rectangle van een map, etc...
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>

        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        void Update(GameTime gameTime);




    }
}
