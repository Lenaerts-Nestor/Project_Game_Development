using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.Characters;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.MovementBehaviour
{
    public class Following_Movement : IEnemyMovement
    {
        //deze classe houd zich bezig om de Movement van de player te lezen en de Enemy moet de player/Hero volgen
        public void EnemysMovement(NPC npc, Player player)
        {
            Vector2 Velocity = npc.Velocity;


            if (player.IsFalling)
            {
                Velocity.Y += npc.FallVelocity;
            }

            if (player.Position.X > npc.Position.X)
            {
                Velocity.X += npc.Speed;
            }
            else if (player.Position.X < npc.Position.X)
            {
                Velocity.X -= npc.Speed;
            }

            npc.Position = Velocity + npc.Position;
            npc.Hitbox.X = (int)npc.Position.X;
            npc.Hitbox.Y = (int)npc.Position.Y;
            
        }

    }
}
