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

namespace ProjectGameDevelopment.Characters.Playable
{
    public class Player : Entity, IGameObject, IJump
    {
        //Properties: [public fields] => UpperCamelCase || [Private fields] lowerCamelCase
        public Animation[] PlayerAnimation;
        public AnimationMovement AnimationMovement;
        public CurrentMovementState CurrentMovementState;
        public KeyboardReader InputReader { get; set; }



        //Constructor
        public Player(Vector2 _position, bool canJump, Texture2D _spriteIdle, Texture2D _spriteRunning, Texture2D _jumping)
        {

            Spritesheet = _spriteIdle;
            Position = _position;
            StartY = Velocity.Y;
            InputReader = new KeyboardReader();

            CanShoot = true;
            IsShooting = false;


            if (canJump == true)
            {
                IsJumping = false;
                IsFalling = true;
            }


            //Basic Animatie
            PlayerAnimation = new Animation[4];                             //voor het moment 2
            PlayerAnimation[0] = new Animation(_spriteIdle);
            PlayerAnimation[1] = new Animation(_spriteRunning);
            PlayerAnimation[2] = new Animation(_jumping);
            //Player Movementstate =>
            CurrentMovementState = CurrentMovementState.Idle;               //de sprite begint altijd in idle
            AnimationMovement = new AnimationMovement(Spritesheet);


            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 25, 32);

        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            AnimationMovement.DrawCharacterMovement(this, PlayerAnimation, spriteBatch, gameTime);
        }


        public void Update(GameTime gameTime)
        {

            InputReader.ReadInput(this, gameTime);


        }

        public bool HasHit(Rectangle objectHitbox)
        {
            return true;
        }
    }
}
