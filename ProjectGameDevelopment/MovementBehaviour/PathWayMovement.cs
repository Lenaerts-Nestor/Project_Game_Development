using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.MovementBehaviour
{
    public class PathWayMovement : INpcMovements
    {

        public void UpdateMovement(NPC npc)
        {
            npc.currentMovementState = CurrentMovementState.Running;
            
            if (!npc.Pathway.Contains(npc.Hitbox))
            {
                npc.Speed = -npc.Speed;
                npc.SpriteMoveDirection = SpriteEffects.FlipHorizontally;
            }
            
            npc.Position.X += npc.Speed;
            npc.Hitbox.X = (int)npc.Position.X;
            npc.Hitbox.Y = (int)npc.Position.Y;
        }
    }
}
