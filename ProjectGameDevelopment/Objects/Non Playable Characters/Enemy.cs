using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.AnimationSection;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.MovementBehaviour;

namespace ProjectGameDevelopment.Characters
{
    public class Enemy : NPC, IJump, IGameObject
    {
        #region public fields
        public Animation[] NPCAnimation;
        public CurrentMovementState CurrentMovementState;
        public AnimationMovement AnimationMovement;
        #endregion

        public Enemy(Texture2D _enemySpriteSheet, Rectangle _pathway, float speed, bool _canJump, bool _isInteligent, Player _player, Vector2 inteligentPosition)
        {
            this.IsInteligent = _isInteligent;

            if (this.IsInteligent)
            {
                this.Position = new Vector2(inteligentPosition.X, inteligentPosition.Y);
                Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 25, 30);

            }
            else
            {
                this.Position = new Vector2(_pathway.X, _pathway.Y);
                Hitbox = new Rectangle((int)this.Position.X, (int)this.Position.Y, 32, 32);

            }

            this.StartY = this.Velocity.Y;
            this.Spritesheet = _enemySpriteSheet;
            this.Pathway = _pathway;
            this.Speed = speed;
            this.isFacingRight = true;
            this.Player = _player;
            this.SpriteMoveDirection = SpriteEffects.None;
            //IN DEZE GAME KUNNEN DE VIJANDEN GEWOON NIET SHIETEN, dus ik vraag ze ook niet in de constructor parameters

            CanShoot = false;
            IsShooting = false;


            NPCAnimation = new Animation[1];                             //voor het moment maar 1 animatie
            NPCAnimation[0] = new Animation(_enemySpriteSheet);

            currentMovementState = CurrentMovementState.Running;
            AnimationMovement = new AnimationMovement(this.Spritesheet);
        }



        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            AnimationMovement.Draw(spriteBatch, this.Position, gameTime, this.SpriteMoveDirection);
        }

        public void Update(GameTime gameTime)
        {
            //controleren welke type het is, INTELIGENT of PATHWAY TYPE
            if (!this.IsInteligent)
                PathWayMovement.EnemysMovement(this, this.Player);
            else
                FollowingMovement.EnemysMovement(this, this.Player);

        }
    }
}
