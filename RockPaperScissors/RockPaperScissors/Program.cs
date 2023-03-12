namespace RockPaperScissors;
class Program
{
    static void Main(string[] args)
    {
        
       for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"ROCK, PAPER, SCISSORS \nROUND: {i}");
            Console.Write("Player 1, please enter your choice for this round: ");
            string playerOneChoice = Console.ReadLine();
            playerOneChoice.ToLower();
            GameOptions playerOneEnum;


            if (playerOneChoice == null)
            {
                Console.WriteLine("Please enter one of the following: rock, paper, or sicssor");
            }

            if (playerOneChoice == "rock" || playerOneChoice == "rocks")
            {
                playerOneEnum = GameOptions.Rock;
            } else if (playerOneChoice == "paper")
            {
                playerOneEnum = GameOptions.Paper;
            } else
            {
                playerOneEnum = GameOptions.Scissor;
            }

            //player two

            Console.Write("Player 2, please enter your choice for this round: ");
            string playerTwoChoice = Console.ReadLine();
            playerTwoChoice.ToLower();
            GameOptions playerTwoEnum;


            if (playerTwoChoice == null)
            {
                Console.WriteLine("Please enter one of the following: rock, paper, or sicssor");
            }

            if (playerTwoChoice == "rock")
            {
                playerTwoEnum = GameOptions.Rock;
            }
            else if (playerOneChoice == "paper")
            {
                playerTwoEnum = GameOptions.Paper;
            }
            else
            {
                playerTwoEnum = GameOptions.Scissor;
            }

            Game gameRound = new Game(playerOneEnum, playerTwoEnum);
            gameRound.GameRound(playerOneEnum, playerTwoEnum);

            Console.WriteLine($"Player 1 selected {gameRound._playerOneChoice}. Player 2 selected {gameRound._playerTwoChoice}");
            Console.WriteLine($"The result of the round: {gameRound._resultOfGame}. \nPlayer 1 score: {gameRound._playerOneScore}. \nPlayer 2 score: {gameRound._playerTwoScore}.\nNumber of draws: {gameRound._totalDraws}.");
        }

       
    }
}
class Game
{
    //two players --> keep track of their answers and compare the two
    // we need to keep track of total draws
    //keep track of total score -- display who wins the game

    internal GameOptions _playerOneChoice { get; set; }
    internal GameOptions _playerTwoChoice { get; set; }
    internal GameResult _resultOfGame { get; set; }
    internal int _playerOneScore { get; set; } = 0;
    internal int _playerTwoScore { get; set; } = 0;
    internal int _totalDraws { get; set; } = 0;

    public Game(GameOptions playerOneChoice, GameOptions playerTwoChoice)
    {
        _playerOneChoice = playerOneChoice;
        _playerTwoChoice = playerTwoChoice;
    }

    public void GameRound(GameOptions _playerOneChoice, GameOptions _playerTwoChoice)
    {
        if (_playerOneChoice == GameOptions.Rock && _playerTwoChoice == GameOptions.Rock || _playerOneChoice == GameOptions.Paper && _playerTwoChoice == GameOptions.Paper || _playerOneChoice == GameOptions.Scissor && _playerTwoChoice == GameOptions.Scissor)
        {
            RoundScore(GameResult.Draw);
        }
        else if (_playerOneChoice == GameOptions.Rock && _playerTwoChoice == GameOptions.Paper || _playerOneChoice == GameOptions.Paper && _playerTwoChoice == GameOptions.Scissor || _playerOneChoice == GameOptions.Scissor && _playerTwoChoice == GameOptions.Rock)
        {
            RoundScore(GameResult.PlayerTwoWin);
        }
        else 
        {
            RoundScore(GameResult.PlayerOneWin);
        } 
        
    }

    public void RoundScore(GameResult _resultOfGame)
    {
        switch (_resultOfGame)
        {
            case GameResult.PlayerOneWin:
                _playerOneScore++;
                break;
            case GameResult.PlayerTwoWin:
                _playerTwoScore++;
                break;
            case GameResult.Draw:
                _totalDraws++;
                break;
        }
    }

}
public enum GameOptions
{
    Rock,
    Paper,
    Scissor
}
public enum GameResult
{
    Draw,
    PlayerOneWin,
    PlayerTwoWin,
}


