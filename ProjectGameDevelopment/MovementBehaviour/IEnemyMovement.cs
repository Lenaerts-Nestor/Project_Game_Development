using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.Characters.Playable;

namespace ProjectGameDevelopment.MovementBehaviour
{
    public interface IEnemyMovement
    {
        public void EnemysMovement(NPC npc, Player player = null);

    }
}
