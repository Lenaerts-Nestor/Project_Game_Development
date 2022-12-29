using Microsoft.Xna.Framework;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.MovementBehaviour;

namespace ProjectGameDevelopment.Characters
{
    public class NPC : Entity
    {
        public bool IsInteligent;
        public bool isFacingRight;

        public Rectangle Pathway;


        public Player Player;
        public PathWayMovement PathWayMovement;
        public Following_Movement FollowingMovement;

    }
}
