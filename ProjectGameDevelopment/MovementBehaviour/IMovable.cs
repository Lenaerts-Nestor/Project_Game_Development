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

    public enum CurrentMovementState { Idle, Run }
    public interface IMovable
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public float Speed { get; set; }
        public SpriteEffects SpriteDirection { get; set; }
        public CurrentMovementState currentMovementState { get; set; }
    }
}
