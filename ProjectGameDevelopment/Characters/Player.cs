using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
    public class Player : Entity, IMovable
    {
        public Animation PlayerAnimation;
        public Vector2 Positie { get; set; }
        public float Snelheid { get; set; }

        public KeyboardReader KeyboardReader;
        public Player (Texture2D sprite)
        {
            this.Spritesheet = sprite;
            KeyboardReader = new KeyboardReader();
            Positie = new Vector2();
            PlayerAnimation = new Animation(this.Spritesheet);
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            PlayerAnimation.Draw(spriteBatch, this.Positie, gameTime);
        }
        public override void Update()
        {
            Positie = KeyboardReader.ReadInput(this);

        }
    }
}
