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
        public void Jumps(Player charr, KeyboardState keyboardstate)
        {
            if (charr.IsJumping)
            {
                charr.Velocity.Y += charr.JumpSpeed;
                charr.JumpSpeed += 6;

                if (charr.Velocity.Y >= charr.startY)
                {
                    charr.Velocity.Y = charr.startY;
                    charr.IsJumping = false;
                }

            }
            else
            {
                if (keyboardstate.IsKeyDown(Keys.Space) && !charr.IsFalling)
                {
                    charr.IsJumping = true;
                    charr.IsFalling = false;

                    charr.JumpSpeed = -12;
                }
            }


        }

    }
}
