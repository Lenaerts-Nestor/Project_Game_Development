namespace ProjectGameDevelopment.Objects
{
    public interface IPlayerconditionCheck
    {
        public bool IsAlive { get; set; }
        public bool GameIsOver { get; set; }
        public bool CanFly { get; set; }
    }
}
