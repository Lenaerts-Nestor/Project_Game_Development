using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.Characters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.MovementBehaviour
{
    public class PathWayMovement : IEnemyMovement
    {

        public void EnemysMovement(NPC npc, Player player)
        {

            if (!npc.Pathway.Contains(npc.Hitbox))
            {
                npc.Speed = -npc.Speed;
                npc.isFacingRight = !npc.isFacingRight; 
            }
           
            //dit is voor alle type ENEMIES
            npc.Position.X += npc.Speed;
            npc.Hitbox.X = (int)npc.Position.X;
            npc.Hitbox.Y = (int)npc.Position.Y;

            //dit om de effect te geven naar welke kant hij gaat =>
            #region extratje movement
            if (!npc.isFacingRight)
            {
                npc.SpriteMoveDirection = SpriteEffects.FlipHorizontally;
            }
            else
            {
                npc.SpriteMoveDirection = SpriteEffects.None;
            }

            #endregion
        }
    }
}
