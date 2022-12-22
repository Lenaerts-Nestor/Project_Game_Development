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
        public float FallSpeed { get; set; }

        //Entity Position
        public Vector2 Position;
        public Vector2 Velocity;

        //Gravity
        public Rectangle Hitbox;
       

        //IMovable
        public float Speed { get; set; }
        public SpriteEffects SpriteMoveDirection { get; set; }
        public CurrentMovementState currentMovementState { get; set; }
    }
}
