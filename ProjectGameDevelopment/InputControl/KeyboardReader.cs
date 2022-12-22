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
            Jumping Jumpcontrol = new Jumping();
            KeyboardState KeyboardState = Keyboard.GetState();



            Jumpcontrol.Jumps(player, KeyboardState);
            Vector2 Velocity = player.Velocity;

            

            player.currentMovementState = MovementBehaviour.CurrentMovementState.Idle;
            if (player.IsFalling)
            {
                Velocity.Y += player.FallVelocity;
            }

            

            if (KeyboardState.IsKeyDown(Keys.A))
            {
                Velocity.X -= player.Speed;
                player.currentMovementState = MovementBehaviour.CurrentMovementState.Run;
                player.SpriteMoveDirection = SpriteEffects.FlipHorizontally;
            }
            
            else if (KeyboardState.IsKeyDown(Keys.D))
            {
                Velocity.X += player.Speed;
                player.currentMovementState = MovementBehaviour.CurrentMovementState.Run;
                player.SpriteMoveDirection = SpriteEffects.None;

            }
            

           // player.Position = Velocity + player.Position;

            player.Position = Velocity + player.Position;


            player.Hitbox.X = (int)player.Position.X;
            player.Hitbox.Y = (int)player.Position.Y;

        } 

    }
}
