using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.MovementBehaviour;

namespace ProjectGameDevelopment.InputControl
{
    public class KeyboardReader
    {
        public void ReadInput(Player player, GameTime gameTime)
        {
            Players_Jumping Jumpcontrol = new();

            KeyboardState KeyboardState = Keyboard.GetState();
            Vector2 Velocity = player.Velocity;


            player.currentMovementState = CurrentMovementState.Idle;

            Jumpcontrol.Jumps(player, KeyboardState);

            player.IsShooting = KeyboardState.IsKeyDown(Keys.R);

            //GRAVITY
            if (player.IsFalling)
            {
                Velocity.Y += player.FallVelocity;
            }
            if (player.IsShooting)
            {
                player.currentMovementState = CurrentMovementState.Shooting;
            }

            if (KeyboardState.IsKeyDown(Keys.A))
            {
                Velocity.X -= player.Speed;
                player.SpriteMoveDirection = SpriteEffects.FlipHorizontally;
                player.currentMovementState = CurrentMovementState.Running;

            }
            else if (KeyboardState.IsKeyDown(Keys.D))
            {
                Velocity.X += player.Speed;

                player.currentMovementState = CurrentMovementState.Running;
                player.SpriteMoveDirection = SpriteEffects.None;
            }



            player.Position = Velocity + player.Position;
            player.Hitbox.X = (int)player.Position.X;
            player.Hitbox.Y = (int)player.Position.Y;



            // player.Position = Velocity + player.Position;







        }

    }
}
