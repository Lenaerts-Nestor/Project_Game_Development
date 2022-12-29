using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.Characters.Playable;

namespace ProjectGameDevelopment.MovementBehaviour
{
    public class PathWayMovement : IEnemyMovement
    {

        public void EnemysMovement(NPC npc, Player player)
        {
            //Controleren als het de einde heeft geraakt of een iets met hitbox
            if (!npc.Pathway.Contains(npc.Hitbox))
            {
                npc.Speed = -npc.Speed;
                npc.isFacingRight = !npc.isFacingRight;
            }

            if (!npc.isFacingRight)
            {
                npc.SpriteMoveDirection = SpriteEffects.FlipHorizontally;
            }
            else
            {
                npc.SpriteMoveDirection = SpriteEffects.None;
            }

            npc.Position.X += npc.Speed;
            npc.Hitbox.X = (int)npc.Position.X;
            npc.Hitbox.Y = (int)npc.Position.Y;

        }
    }
}
