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
    public abstract class Entity 
    {
        public Texture2D Spritesheet { get; set; }

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        public abstract void Update();
        


    }
}
