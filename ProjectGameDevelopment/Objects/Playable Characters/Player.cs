using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.AnimationSection;
using ProjectGameDevelopment.InputControl;
using ProjectGameDevelopment.MovementBehaviour;
using System.Collections.Generic;

namespace ProjectGameDevelopment.Characters.Playable
{
    public class Player : Entity, IGameObject, IJump
    {
        //Properties: [public fields] => UpperCamelCase || [Private fields] lowerCamelCase
        public Animation[] PlayerAnimation;
        public AnimationMovement AnimationMovement;
        public CurrentMovementState CurrentMovementState;
        public KeyboardReader InputReader { get; set; }
        public static int _playerPoint = 0;
        public bool _touchedBuff;
        //Constructor
        public Player(Vector2 _position, bool canJump, Texture2D _spriteIdle, Texture2D _spriteRunning, Texture2D _jumping, Texture2D _shooting)
        {

            Spritesheet = _spriteIdle;
            Position = _position;
            StartY = Velocity.Y;
            InputReader = new KeyboardReader();

            CanShoot = true;
            IsShooting = false;
            _touchedBuff = false;


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
            PlayerAnimation[3] = new Animation(_shooting);

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
        public bool TouchedEnemy(List<Enemy> enemyList)
        {
            foreach (var item in enemyList.ToArray())
            {
                if (this.Hitbox.Intersects(item.Hitbox))
                    return true;
            }
            return false;

        }

    }
}
