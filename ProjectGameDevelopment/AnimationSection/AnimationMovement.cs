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
        public void DrawCharacterMovement(Player character, Animation[] _spriteAnimation, SpriteBatch spriteBatch, GameTime gameTime)
        {
            switch (character.currentMovementState)
            {
                case CurrentMovementState.Idle:
                    _spriteAnimation[0].Draw(spriteBatch, character.Position, gameTime,character.SpriteMoveDirection);
                    break;
                case CurrentMovementState.Running:
                    _spriteAnimation[1].Draw(spriteBatch, character.Position, gameTime,character.SpriteMoveDirection);
                 
                    break;
                case CurrentMovementState.Jumping:
                    _spriteAnimation[2].Draw(spriteBatch, character.Position, gameTime,character.SpriteMoveDirection);
                    break;
                default:
                    break;
            }
        }
        
        public void DrawNPCmovement(NPC npc, Animation[] _spriteAnimation, SpriteBatch spriteBatch, GameTime gameTime)
        {

            switch (npc.currentMovementState)
            {
                case CurrentMovementState.Idle:
                    _spriteAnimation[0].Draw(spriteBatch, npc.Position, gameTime, npc.SpriteMoveDirection,250);
                    break;
                case CurrentMovementState.Running:
                    _spriteAnimation[1].Draw(spriteBatch, npc.Position, gameTime, npc.SpriteMoveDirection, 250);
                    break;
                case CurrentMovementState.Jumping:
                    _spriteAnimation[2].Draw(spriteBatch, npc.Position, gameTime, npc.SpriteMoveDirection, 250);
                    break;
                default:
                    break;
            }
        }
    
    
    }
}
