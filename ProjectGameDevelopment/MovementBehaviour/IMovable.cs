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

    public enum CurrentMovementState { Idle, Running, Jumping, Shooting }
    public interface IMovable
    {
        /// <summary>
        /// Deze interface zal geven de basis om te weten naar welke kant de Sprite zal kijken en het effect geven dat er een beweging is.
        /// BV: we kunnen het effect zien van idle en Running, we zullen weten als de Sprite is gestopt en/of is aan bewegen.
        /// </summary>
        public SpriteEffects SpriteMoveDirection { get; set; }
        public CurrentMovementState currentMovementState { get; set; }

    }
}
