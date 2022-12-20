using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.MovementBehaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.AnimationSection
{
    public class AnimationMovement : Animation
    {
        public AnimationMovement(Texture2D spritesheet, float width = 32, float height = 32) : base(spritesheet, width, height) { }
        public void DrawCharacterMovement(Player character, Animation[] entity, SpriteBatch spriteBatch, GameTime gameTime)
        {
            switch (character.currentMovementState)
            {
                case CurrentMovementState.Idle:
                    entity[0].Draw(spriteBatch, character.Position, gameTime, character.SpriteMoveDirection);
                    break;
                case CurrentMovementState.Run:
                    entity[1].Draw(spriteBatch, character.Position, gameTime,character.SpriteMoveDirection);
                    break;
                default:
                    break;
            }
        }
    }
}
