using Microsoft.Xna.Framework;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.MovementBehaviour;

namespace ProjectGameDevelopment.Characters
{
    public class NPC : Entity
    {
        public bool IsInteligent;
        public bool isFacingRight = true;

        public Rectangle Pathway;

        public Player Player;
        public PathWayMovement PathWayMovement = new PathWayMovement();
        public Following_Movement FollowingMovement = new Following_Movement();

    }
}
