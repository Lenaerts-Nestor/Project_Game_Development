using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.MovementBehaviour;
using ProjectGameDevelopment.Objects;

namespace ProjectGameDevelopment.Characters
{

    public abstract class Entity : Object, IMovable, IJump, IShooting
    {


        //IMovable
        public SpriteEffects SpriteMoveDirection { get; set; }
        public CurrentMovementState currentMovementState { get; set; }

        //IJUMP
        public float FallSpeed { get; set; }
        public float FallVelocity { get; set; } = 2;
        public float StartY { get; set; }
        public float JumpSpeed { get; set; }
        public bool IsJumping { get; set; }
        public bool IsFalling { get; set; }

        //IShooting
        public bool CanShoot { get; set; } = false;
        public bool IsShooting { get; set; }

        //IConditionCheck
        public bool IsAlive { get; set; } = true;



    }
}
