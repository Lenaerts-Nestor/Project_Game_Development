﻿using Microsoft.Xna.Framework;
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
        //Properties
        public Animation PlayerAnimation;
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public float Speed { get; set; }

        /*
        public float JumpVelocity { get; set; }
        public bool IsJumping { get; set; }
        public bool CanJump { get; set; }
        */

        public KeyboardReader KeyboardReader;
        

        //Constructor
        public Player (Texture2D sprite)
        {
            this.Spritesheet = sprite;
            this.Position = new Vector2();
            this.Velocity = Vector2.Zero;

            //TODO: vind uit hoe je gravity doet
            //this.Speed = 200f;
            //this.JumpVelocity = -500f;
            //this.CanJump = true;
            //this.IsJumping = false;


            KeyboardReader = new KeyboardReader();
            

            PlayerAnimation = new Animation(this.Spritesheet);
            
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            PlayerAnimation.Draw(spriteBatch, this.Position, gameTime);
        }
        public override void Update(GameTime gameTime)
        {
            Position += KeyboardReader.ReadInput(this, gameTime);
          
        }
    }
}
