using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjectGameDevelopment.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.InputControl
{
    public class KeyboardReader
    {
        public Vector2 ReadInput(Player player, GameTime gameTime)
        {
            KeyboardState KeyboardState = Keyboard.GetState();
            Vector2 Velocity = player.Velocity;
            
            
            if (KeyboardState.IsKeyDown(Keys.A))
            {
                Velocity.X -= player.Speed;
            }
            else if (KeyboardState.IsKeyDown(Keys.D))
            {
                Velocity.X += player.Speed;
            }
            else
            {
                Velocity.X += 0;
            }

           
            return Velocity+player.Position;

        } 

    }
}
