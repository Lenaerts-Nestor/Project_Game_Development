using Microsoft.Xna.Framework.Input;
using ProjectGameDevelopment.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.InputControl
{
    public class Jumping
    {
        public void Jumps(Player player, KeyboardState keyboardstate)
        {
           

            if (player.IsJumping)
            {
                player.Velocity.Y += player.JumpSpeed;
                player.JumpSpeed += 7;
                //de jump gaat te snel => zoek een manier om de jump trager te doen omhoog, om te tonnen de animatie
                player.currentMovementState = MovementBehaviour.CurrentMovementState.Jumping;
                if (player.Velocity.Y >= player.StartY)
                    //als het verder is dan de grond
                {
                    player.Velocity.Y = player.StartY;
                    player.IsJumping = false; 
                }
                
                
            }
            else
            {
                if (keyboardstate.IsKeyDown(Keys.Space) && !player.IsFalling)
                {
                    player.IsJumping = true;
                    player.IsFalling = false;
                    player.JumpSpeed = -14;
                    
                }
            }
            



        }

    }
}
