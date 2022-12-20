using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGameDevelopment.AnimationSection;
using ProjectGameDevelopment.InputControl;
using ProjectGameDevelopment.MovementBehaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.Characters
{
    public class Player : Sprite
    {
        //Properties: [public fields] => UpperCamelCase || [Private fields] lowerCamelCase
        public Animation[] PlayerAnimation;
        public AnimationMovement AnimationMovement;
        public CurrentMovementState CurrentMovementState;
    
        public KeyboardReader InputReader { get; set; }

        //Constructor
        public Player (Texture2D spriteIdle, Texture2D spriteRunning)
        {
            
            this.Spritesheet = spriteIdle;
            this.Position = new Vector2();
            this.Velocity = Position;
            this.Speed = -2f;
            this.InputReader = new KeyboardReader();

            //Basic Animatie
            PlayerAnimation = new Animation[2];                             //voor het moment 2
            PlayerAnimation[0] = new Animation(spriteIdle);
            PlayerAnimation[1] = new Animation(spriteRunning);

            //Player Movementstate =>
            CurrentMovementState = CurrentMovementState.Idle;               //de sprite begint altijd in idle
            AnimationMovement = new AnimationMovement(this.Spritesheet);
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            AnimationMovement.DrawCharacterMovement(this, PlayerAnimation, spriteBatch, this.Position, gameTime);
        }

        
        //TODO: onderzoek waarom game werkt zonder dit de override void Update =>
        public override void Update(GameTime gameTime)
        {
            
        }

        
    }
}
