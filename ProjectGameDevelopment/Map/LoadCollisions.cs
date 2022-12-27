using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDevelopment.Characters;
using ProjectGameDevelopment.Characters.Playable;
using ProjectGameDevelopment.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace ProjectGameDevelopment.Map
{
    public class LoadCollisions
    {

        //bewaren van elke collision in de lijst

        public void DrawLevel(SpriteBatch spriteBatch, MapMaker _desiredMap)
        {
            _desiredMap.Draw(spriteBatch);
        }

        public List<Rectangle> GetCollisionTiles(TmxMap _map, List<Rectangle> _collisionTiles)
        {
            foreach (var CollisionRect in _map.ObjectGroups["Collisions"].Objects)
            {
                if (CollisionRect.Name == "")
                {
                    _collisionTiles.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width - 10, (int)CollisionRect.Height - 10));
                }
            }
            return _collisionTiles;
        }

        public List<Rectangle> GetRespawnZone(TmxMap _map, List<Rectangle> _collisionTiles)
        {
            foreach (var CollisionRect in _map.ObjectGroups["Collisions"].Objects)
            {
                if (CollisionRect.Name == "Respawn")
                {
                    _collisionTiles.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width - 10, (int)CollisionRect.Height));
                }
            }
            return _collisionTiles;
        }


        public List<Rectangle> GetEnemyPathWay(TmxMap _map, List<Rectangle> _enemyPathway)
        {
            foreach (var CollisionRect in _map.ObjectGroups["EnemyPathWay"].Objects)
            {
                _enemyPathway.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width, (int)CollisionRect.Height));
            }

            return _enemyPathway;
        }

        public Rectangle GetEnd(TmxMap _map, Rectangle _endRect)
        {
            foreach (var CollisionRect in _map.ObjectGroups["Collisions"].Objects)
            {
                if (CollisionRect.Name == "END")
                {
                    _endRect = new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width - 10, (int)CollisionRect.Height);
                }
            }
            return _endRect;

        }
        
    }
}
