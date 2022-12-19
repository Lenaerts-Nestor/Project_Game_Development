﻿using Microsoft.Xna.Framework;
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
        public void DrawCharacterMovement(Player character, Animation[] entity, SpriteBatch spriteBatch, Vector2 Position, GameTime gameTime)
        {
            switch (character.currentMovementState)
            {
                case CurrentMovementState.Idle:
                    character.InputReader.ReadInput(character, gameTime);
                    entity[0].Draw(spriteBatch, Position, gameTime, character.SpriteDirection);
                    break;
                case CurrentMovementState.Run:
                    character.InputReader.ReadInput(character, gameTime);
                    entity[1].Draw(spriteBatch, Position, gameTime,character.SpriteDirection);
                    break;
                default:
                    break;
            }
        }
    }
}