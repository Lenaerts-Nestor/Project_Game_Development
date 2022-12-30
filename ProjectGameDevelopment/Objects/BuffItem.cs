using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.Characters;
using Object = ProjectGameDevelopment.Characters.Object;

namespace ProjectGameDevelopment.Objects
{
    public class BuffItem : Object, IGameObject
    {
        public BuffItem(Texture2D _bulletTexture, Vector2 _position, float _speed)
        {
            this.Spritesheet = _bulletTexture;
            this.Speed = _speed;
            this.Hitbox = new Rectangle((int)_position.X, (int)_position.Y, _bulletTexture.Width, _bulletTexture.Height);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(this.Spritesheet, this.Hitbox, Color.White);
        }
        public void Update(GameTime gameTime)
        {
            Hitbox.X += (int)Speed;
        }
    }
}
