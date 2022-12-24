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
    public class Player : Entity,IGameObject,IJump
    {
        //Properties: [public fields] => UpperCamelCase || [Private fields] lowerCamelCase
        public Animation[] PlayerAnimation;
        public AnimationMovement AnimationMovement;
        public CurrentMovementState CurrentMovementState;
        public Rectangle playerFallRect;
        public KeyboardReader InputReader { get; set; }

        //IJUMP
        public float FallVelocity { get; set; } = 2;
        public float JumpSpeed { get; set; } = 0;
        public bool IsJumping { get; set; } 
        public bool IsFalling { get; set; } 
        public float StartY { get; set; }



        //Constructor
        public Player (Vector2 _position,bool canJump,Texture2D _spriteIdle, Texture2D _spriteRunning, Texture2D _jumping)
        {
            
            this.Spritesheet = _spriteIdle;
            this.Position = _position;
            this.StartY = this.Velocity.Y;
            this.InputReader = new KeyboardReader();

            if (canJump == true)
            {
                this.IsJumping = false;
                this.IsFalling = true;
            }


            //Basic Animatie
            PlayerAnimation = new Animation[4];                             //voor het moment 2
            PlayerAnimation[0] = new Animation(_spriteIdle);
            PlayerAnimation[1] = new Animation(_spriteRunning);
            PlayerAnimation[2] = new Animation(_jumping);
            //Player Movementstate =>
            CurrentMovementState = CurrentMovementState.Idle;               //de sprite begint altijd in idle
            AnimationMovement = new AnimationMovement(this.Spritesheet);


            this.Hitbox= new Rectangle((int)this.Position.X, (int)this.Position.Y,25,32);
           
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            AnimationMovement.DrawCharacterMovement(this, PlayerAnimation, spriteBatch, gameTime);
        }

        
    
        public void Update(GameTime gameTime)
        {
            
            InputReader.ReadInput(this, gameTime);
            

        }

        
    }
}
