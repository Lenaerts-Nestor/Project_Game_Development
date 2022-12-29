﻿using Microsoft.Xna.Framework.Input;
using ProjectGameDevelopment.Characters.Playable;

namespace ProjectGameDevelopment.MovementBehaviour
{
    public class Players_Jumping
    {
        public void Jumps(Player player, KeyboardState keyboardstate)
        {
            if (player.IsJumping)
            {
                player.Velocity.Y += player.JumpSpeed;
                player.JumpSpeed += 1;
                //de jump gaat te snel => zoek een manier om de jump trager te doen omhoog, om te tonnen de animatie
                player.currentMovementState = CurrentMovementState.Jumping;
                if (player.Velocity.Y >= player.StartY)
                //als het verder is dan de grond
                {
                    player.Velocity.Y = player.StartY;
                    player.IsJumping = false;
                }
            }
            else
            {
                if (keyboardstate.IsKeyDown(Keys.Up) && !player.IsFalling)
                {
                    player.IsJumping = true;
                    player.IsFalling = false;
                    player.JumpSpeed = -4;

                }
            }




        }

    }
}
