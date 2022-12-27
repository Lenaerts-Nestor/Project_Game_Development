using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectGameDevelopment.AnimationSection
{
    public interface IAnimation
    {
        //dit is het basic om de Sprite te tekenen
        public int Frames { get; set; }
        public int Row { get; set; }
        public int Teller { get; set; }

        void Draw(SpriteBatch spriteBatch, Vector2 position, GameTime gameTime, SpriteEffects spriteEffects, float miliSecPerFrame = 300);
    }
}
