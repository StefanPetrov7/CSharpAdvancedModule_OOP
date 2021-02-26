namespace Practice_Polymorphism
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            GamesMagazine games = new GamesMagazine();
            games.AddGame(new FoodBallGame());
            games.AddGame(new Chess(new Player("Stefan"), new Player("Lubinbin")));

            games.AddGame(new Tennis(new Player("Vaider"), new Player("Like")));
            games.StartGame();
            games.StopGame();
            games.PrintDiscriptions();

            Chess chess = new Chess(new Player("Ivon"), new Player("BinBin"));

        }
    }
}
