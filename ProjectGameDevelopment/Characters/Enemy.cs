using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.AnimationSection;
using ProjectGameDevelopment.MovementBehaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.Characters
{
    public class Enemy : NPC, IGameObject, IJump
    {
        #region public fields
        public Animation[] NPCAnimation;

        public CurrentMovementState CurrentMovementState;
        public AnimationMovement AnimationMovement;

        public float StartY { get; set; }
        public float JumpSpeed { get; set; } = 0;
        public bool IsJumping { get; set; }
        public bool IsFalling { get; set; }
        public bool CanJump { get; set; }


        
        #endregion

        public Enemy(Texture2D _enemySpriteSheet, Rectangle _pathway, float speed, bool _canJump, bool _isInteligent, Player _player, Vector2 inteligentPosition)
        {
            this.StartY = this.Velocity.Y ;



            if (_isInteligent)
            {
                this.Position = new Vector2(inteligentPosition.X, inteligentPosition.Y);
                this.Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 25, 32);

            }
            else
            {
                this.Position = new Vector2(_pathway.X, _pathway.Y);
                this.Hitbox = new Rectangle((int)this.Position.X, (int)this.Position.Y, 32, 32);

            }

            this.Spritesheet = _enemySpriteSheet;
            this.Pathway = _pathway;
            this.Speed = speed;
            this.isFacingRight = true;
            this.IsInteligent = _isInteligent;
            this.Player = _player;

            NPCAnimation = new Animation[1];                             //voor het moment 2
            NPCAnimation[0] = new Animation(_enemySpriteSheet);

            currentMovementState =  CurrentMovementState.Running;
            AnimationMovement = new AnimationMovement(this.Spritesheet);


            this.SpriteMoveDirection = SpriteEffects.None;
            this.PathWayMovement = new PathWayMovement();
            this.FollowingMovement = new Following_Movement();

            

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            AnimationMovement.Draw(spriteBatch, this.Position, gameTime, this.SpriteMoveDirection);
                
        
        }

        public void Update(GameTime gameTime)
        {
            if(!this.IsInteligent)
                PathWayMovement.EnemysMovement(this, this.Player);
            else
                FollowingMovement.EnemysMovement(this, this.Player);
                           
        }
    }
}
