using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public void ReadInput(Player player, GameTime gameTime)
        {
            KeyboardState KeyboardState = Keyboard.GetState();
            Vector2 Velocity = player.Velocity;
            

            if (KeyboardState.IsKeyDown(Keys.A))
            {
                Velocity.X -= player.Speed;
                player.currentMovementState = MovementBehaviour.CurrentMovementState.Run;
                player.SpriteDirection = SpriteEffects.FlipHorizontally;
            }
            
            else if (KeyboardState.IsKeyDown(Keys.D))
            {
                Velocity.X += player.Speed;
                player.currentMovementState = MovementBehaviour.CurrentMovementState.Run;
                player.SpriteDirection = SpriteEffects.None;

            }
            else
            {
                player.currentMovementState = MovementBehaviour.CurrentMovementState.Idle;
                Velocity.X += 0;
            }

            player.Position = Velocity + player.Position;


            

        } 

    }
}
