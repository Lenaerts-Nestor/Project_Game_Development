using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    internal class Enemy : NPC, IGameObject, IJump
    {
        public Animation[] NPCAnimation;
        public CurrentMovementState CurrentMovementState = CurrentMovementState.Running;
        public AnimationMovement AnimationMovement;
        public PathWayMovement pathWayMove;


        public float StartY { get; set; }
        public float FallVelocity { get; set; } = 2;
        public float JumpSpeed { get; set; } = 0;
        public bool IsJumping { get; set; }
        public bool IsFalling { get; set; }
        public bool CanJump { get; set; }



        public Enemy(Texture2D _spriteIdle, Texture2D _spriteRunning, Texture2D _jumping, Rectangle _pathway, float speed, bool _canJump )
        {
            this.StartY = this.Velocity.Y ;
            this.Position = new Vector2(_pathway.X, _pathway.Y);
            this.Spritesheet = _spriteIdle;
            this.Pathway = _pathway;
            this.Speed = speed;

            if (_canJump == true)
            {
                this.IsJumping = false;
                this.IsFalling = true;
            }

            NPCAnimation = new Animation[4];                             //voor het moment 2
            NPCAnimation[0] = new Animation(_spriteIdle);
            NPCAnimation[1] = new Animation(_spriteRunning);
            NPCAnimation[2] = new Animation(_jumping);

            pathWayMove = new PathWayMovement();
            AnimationMovement = new AnimationMovement(this.Spritesheet);
            this.Hitbox = new Rectangle(_pathway.X, _pathway.Y, 8, 8);
            

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
                AnimationMovement.DrawNPCmovement(this, NPCAnimation, spriteBatch, gameTime);
        
        
        }

        public void Update(GameTime gameTime)
        {

            pathWayMove.UpdateMovement(this);
        }
    }
}
