using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameDevelopment.Menu
{
    public enum currentGameState { level1, level2, Menu}
    public interface GameState
    {
        public currentGameState stateOfGame { get; set; }
        



    }
}
