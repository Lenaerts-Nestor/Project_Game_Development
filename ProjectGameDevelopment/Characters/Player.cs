using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGameDevelopment.AnimationSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.Characters
{
    public class Player : Entity
    {
        public float PlayerSpeed = 2;
        public Animation PlayerAnimation;
        public Player (Texture2D sprite)
        {
            this.Spritesheet = sprite;
            this.Speed = new Vector2(); //TODO: na testen van Speed, zet het tussen de () van deze constructor.
            PlayerAnimation = new Animation(this.Spritesheet);
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            PlayerAnimation.Draw(spriteBatch, this.Position, gameTime);
        }

        public override void Update()
        {
            //TODO: beweeg Keyboard naar een eigen klasse =>
            //TODO: onderzoek waarom left is plus en right is min
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Left))
            {
                Speed.X += PlayerSpeed;
            }
            else if (keyboard.IsKeyDown(Keys.Right))
            {
                Speed.X -= PlayerSpeed;
            }

            Position = Speed;

        }
    }
}
