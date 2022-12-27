using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectGameDevelopment.AnimationSection
{
    public class Animation : IAnimation
    {
        //Local variabele
        Texture2D _texture;

        public int Frames { get; set; }
        public int Row { get; set; }
        public int Teller { get; set; } = 0;

        float TslFrame = 0;     //tijds sinds laatste Frame
        public Animation(Texture2D spritesheet, float width = 32, float height = 32)
        {
            this._texture = spritesheet;
            Frames = (int)(spritesheet.Width / width);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, GameTime gameTime, SpriteEffects spriteDirection = SpriteEffects.None, float miliSecPerFrame = 150)
        {
            if (Teller < Frames)
            {

                var rect = new Rectangle(32 * Teller, 0, 32, 32);
                //var rectSize = new Rectangle(32 * Teller, Row, 45, 45);

                spriteBatch.Draw(_texture, position, rect, Color.White, 0f, new Vector2(), 1, spriteDirection, 0f);

                //spriteBatch.Draw(spritesheet, rectSize, rect, Color.White, 0f, position, spriteDirection, 0f);
                //spriteBatch.Draw(spritesheet, position,rect, Color.White);

                TslFrame += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (TslFrame > miliSecPerFrame)
                {
                    TslFrame -= miliSecPerFrame;
                    Teller++;
                    if (Teller == Frames)
                    {
                        Teller = 0;
                    }
                }
            }

        }


    }
}

