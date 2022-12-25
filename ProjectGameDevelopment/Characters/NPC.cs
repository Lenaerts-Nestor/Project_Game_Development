using Microsoft.Xna.Framework;
using ProjectGameDevelopment.MovementBehaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.Characters
{
    public class NPC : Entity
    {
        public bool IsInteligent;

        public Rectangle Pathway;
        public bool isFacingRight;

        public Player Player;

        public PathWayMovement PathWayMovement;
        public Following_Movement FollowingMovement;
    }
}
