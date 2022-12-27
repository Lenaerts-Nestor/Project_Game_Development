using Microsoft.Xna.Framework;
using ProjectGameDevelopment.Characters.Playable;

namespace ProjectGameDevelopment.InputControl
{
    public interface IReadInput
    {
        //dit is voor de charachter dat we willen de input van de keyboard lezen, dus geen NPC
        Vector2 ReadInput(Player player, GameTime gameTime);
    }
}
