using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.Characters
{
    public class Player : Entity
    {
        public float playerSpeed = 2;
        public Player (Texture2D sprite)
        {
            this.Spritesheet = sprite;
            this.Speed = new Vector2(); //TODO: na testen van Speed, zet het tussen de () van deze constructor.
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Spritesheet, Position, Color.White);
        }

        public override void Update()
        {
            //TODO: beweeg Keyboard naar een eigen klasse =>
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.A))
            {
                Speed.X -= playerSpeed;
            }
            else if (keyboard.IsKeyDown(Keys.D))
            {
                Speed.X += playerSpeed;
            }

            Position = Speed;

        }
    }
}
