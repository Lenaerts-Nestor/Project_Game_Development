namespace ProjectGameDevelopment.Menu
{
    public enum currentGameState { level1, level2, level3,level4, Menu, GameOver }
    public enum currentPlayerState { Win, Lost }
    public interface GameState
    {
        public currentGameState StateOfGame { get; set; }
        public currentPlayerState StateOfPlayer { get; set; }

    }
}
