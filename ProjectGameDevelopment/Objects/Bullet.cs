using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.Characters;

namespace ProjectGameDevelopment.Objects
{
    public class Bullet : Characters.Object, IGameObject
    {
        public Bullet(Texture2D _bulletTexture, Vector2 _position, float _speed)
        {
            this.Spritesheet = _bulletTexture;
            this.Speed = _speed;
            this.Hitbox = new Rectangle((int)_position.X, (int)_position.Y, _bulletTexture.Width, _bulletTexture.Height);
        }

        //controleren als de bullet iets heeft geraakt
        public bool HasHit(Rectangle rect)
        {
            return Hitbox.Intersects(rect);
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
