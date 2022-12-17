using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.MovementBehaviour
{
    public interface IMovable
    {
        public Vector2 Positie { get; set; }
        public float Snelheid { get; set; }
    }
}
