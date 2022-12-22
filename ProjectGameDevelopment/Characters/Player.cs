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
        
        public KeyboardReader InputReader { get; set; }

        //IJUMP
        public float FallVelocity { get; set; } = 2;
        public float JumpSpeed { get; set; } = 2;
        public bool IsJumping { get; set; } = false;
        public bool IsFalling { get; set; } = true;

        public float startY { get; set; }




        //Constructor
        public Player (Texture2D spriteIdle, Texture2D spriteRunning)
        {
            
            this.Spritesheet = spriteIdle;
            this.Position = new Vector2(30,60);
            this.Velocity = new Vector2();
            this.Speed = 2f;
            this.startY = this.Position.Y;
            this.InputReader = new KeyboardReader();

            //Basic Animatie
            PlayerAnimation = new Animation[2];                             //voor het moment 2
            PlayerAnimation[0] = new Animation(spriteIdle);
            PlayerAnimation[1] = new Animation(spriteRunning);

            //Player Movementstate =>
            CurrentMovementState = CurrentMovementState.Idle;               //de sprite begint altijd in idle
            AnimationMovement = new AnimationMovement(this.Spritesheet);


            this.Hitbox= new Rectangle((int)this.Position.X, (int)this.Position.Y,20,30);
          
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
