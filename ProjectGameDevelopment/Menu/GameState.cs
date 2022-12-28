namespace ProjectGameDevelopment.Menu
{
    public enum currentGameState { level1, level2, Menu, GameOver }
    public interface GameState
    {
        public currentGameState stateOfGame { get; set; }




    }
}
