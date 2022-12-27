using Microsoft.Xna.Framework;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.MovementBehaviour;

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
