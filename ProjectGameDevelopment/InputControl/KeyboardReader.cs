using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.MovementBehaviour;

namespace ProjectGameDevelopment.InputControl
{
    public class KeyboardReader : IReadInput
    {
        public void ReadInput(Player player, GameTime gameTime)
        {
            Players_Jumping Jumpcontrol = new();

            KeyboardState KeyboardState = Keyboard.GetState();
            Vector2 Velocity = player.Velocity;


            player.currentMovementState = CurrentMovementState.Idle;

            Jumpcontrol.Jumps(player, KeyboardState);
            if(player.CanShoot)
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

            if (KeyboardState.IsKeyDown(Keys.Left))
            {
                Velocity.X -= player.Speed;
                player.IsShooting = false;
                player.SpriteMoveDirection = SpriteEffects.FlipHorizontally;
                player.currentMovementState = CurrentMovementState.Running;

            }
            else if (KeyboardState.IsKeyDown(Keys.Right))
            {
                Velocity.X += player.Speed;
                player.IsShooting = false;
                player.currentMovementState = CurrentMovementState.Running;
                player.SpriteMoveDirection = SpriteEffects.None;
            }
            else if (KeyboardState.IsKeyDown(Keys.Down))
            {
                //de jumping en ducking is zelfde in deze game, ik vind het een moei annimatie
                player.currentMovementState = CurrentMovementState.Jumping;
            }



            player.Position = Velocity + player.Position;
            player.Hitbox.X = (int)player.Position.X;
            player.Hitbox.Y = (int)player.Position.Y;



            // player.Position = Velocity + player.Position;







        }

    }
}
