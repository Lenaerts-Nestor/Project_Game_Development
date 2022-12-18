using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.InputControl;
using ProjectGameDevelopment.MovementBehaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.Characters
{
    public abstract class Entity:IMovable
    {
        //Properties: [public fields] => UpperCamelCase || [Private fields] lowerCamelCase
        
        //public fields
        public Texture2D Spritesheet { get; set; }
        

        

        //IMovable properties
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public float Speed { get; set; }
        


        public CurrentMovementState currentMovementState { get; set; }
        public SpriteEffects SpriteDirection { get; set; } = SpriteEffects.None;    

        //abstract methodes
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        public abstract void Update(GameTime gameTime);
        


    }
}
