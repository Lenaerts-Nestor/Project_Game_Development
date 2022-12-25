using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.Characters.Playable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.MovementBehaviour
{
    public interface IEnemyMovement
    {
        public void EnemysMovement(NPC npc, Player player = null);

    }
}
