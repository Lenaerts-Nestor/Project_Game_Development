using Microsoft.Xna.Framework;
using ProjectGameDevelopment.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.InputControl
{
    public interface IReadInput
    {
        //dit is voor de charachter dat we willen de input van de keyboard lezen || rechten hebben, dus geen NPC
        Vector2 ReadInput(Player player, GameTime gameTime);
    }
}
