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
            //TODO: uitvinden waarom + naar links gaat en - naar rechts gaat....., Logica is ineens weg.
            if (KeyboardState.IsKeyDown(Keys.Left))
            {
                Velocity.X += 2;
            }
            else if (KeyboardState.IsKeyDown(Keys.Right))
            {
                Velocity.X -= 2;
            }
            else
            {
                Velocity.X += 0;
            }

           
            return Velocity;

        } 

    }
}
