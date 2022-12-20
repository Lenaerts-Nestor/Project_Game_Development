using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.AnimationSection
{
    public class Animation : IAnimation
    {
        //Local variabele
        Texture2D spritesheet;

        public int Frames { get; set; }
        public int Row { get; set; }
        public int Teller { get; set; } = 0;

        float TslFrame = 0;     //tijds sinds laatste Frame
        public Animation(Texture2D spritesheet, float width = 32, float height = 32)
        {
            this.spritesheet = spritesheet;
            Frames = (int)(spritesheet.Width / width);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, GameTime gameTime, SpriteEffects spriteDirection, float miliSecPerFrame = 150)
        {
            if (Teller < Frames)
            {
                
                var rect = new Rectangle(32 * Teller, Row, 32, 32);
                var gewensteSize = new Rectangle((int)position.X, (int)position.Y, 45, 45);
                spriteBatch.Draw(spritesheet, gewensteSize, rect, Color.White, 0f, new Vector2(position.X, position.Y), spriteDirection, 0f);
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

