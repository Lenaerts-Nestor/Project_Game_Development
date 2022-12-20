using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.MovementBehaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.Characters
{
   
    public abstract class Entity : IMovable
    {
        public Texture2D Spritesheet { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public float Speed { get; set; }
        public float FallSpeed { get; set; }
        public Rectangle Hitbox;
        public SpriteEffects SpriteMoveDirection { get; set; }
        public CurrentMovementState currentMovementState { get; set; }
    }
}
