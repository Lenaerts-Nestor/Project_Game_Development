using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.InputControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.MovementBehaviour
{

    public enum CurrentMovementState { Idle, Running, Jumping, Falling }
    public interface IMovable
    {
        public float Speed { get; set; }
        public SpriteEffects SpriteMoveDirection { get; set; }
        public CurrentMovementState currentMovementState { get; set; }

    }
}
