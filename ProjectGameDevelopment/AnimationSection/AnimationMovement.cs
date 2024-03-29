﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.MovementBehaviour;

namespace ProjectGameDevelopment.AnimationSection
{
    public class AnimationMovement : Animation
    {
        public AnimationMovement(Texture2D spritesheet, float width = 32, float height = 32) : base(spritesheet, width, height) { }
        public void DrawCharacterMovement(Entity character, Animation[] _spriteAnimation, SpriteBatch spriteBatch, GameTime gameTime)
        {
            switch (character.currentMovementState)
            {
                case CurrentMovementState.Idle:
                    _spriteAnimation[0].Draw(spriteBatch, character.Position, gameTime, character.SpriteMoveDirection);
                    break;
                case CurrentMovementState.Running:
                    _spriteAnimation[1].Draw(spriteBatch, character.Position, gameTime, character.SpriteMoveDirection);
                    break;
                case CurrentMovementState.Jumping:
                    _spriteAnimation[2].Draw(spriteBatch, character.Position, gameTime, character.SpriteMoveDirection);
                    break;
                case CurrentMovementState.Shooting:
                    _spriteAnimation[3].Draw(spriteBatch, character.Position, gameTime, character.SpriteMoveDirection);
                    break;

                default:
                    break;
            }
        }




    }
}
