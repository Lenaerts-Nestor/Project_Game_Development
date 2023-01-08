using Microsoft.Xna.Framework;
using ProjectGameDevelopment.Characters.Playable;

namespace ProjectGameDevelopment.InputControl
{
    public interface IReadInput
    {
        //dit is voor de charachter dat we willen de input van de keyboard lezen, dus geen NPC
        void ReadInput(Player player, GameTime gameTime);
    }
}
