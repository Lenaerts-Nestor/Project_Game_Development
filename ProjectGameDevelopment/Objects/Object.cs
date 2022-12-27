using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectGameDevelopment.Characters
{
    public class Object
    {
        /// <summary>
        /// Een Object heeft altijd een Hitbox, Een Positie, een Velocity (als de object wilt bewegen of voor iets anders)
        /// en heeft een Texture om het te kunnen zien
        /// </summary>
        public Rectangle Hitbox;
        public Vector2 Velocity = new Vector2();
        public Vector2 Position;

        public float Speed { get; set; } = 2;
        public Texture2D Spritesheet { get; set; }

    }
}
