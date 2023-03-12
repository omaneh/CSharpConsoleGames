namespace RockPaperScissors;
class Program
{
    static void Main(string[] args)
    {
        Game gameRound = new Game();

       for (int i = 1; i < 5; i++)
        {
            
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"ROCK, PAPER, SCISSORS \nROUND: {i}");
            Console.Write("Player 1, please enter your choice for this round: ");
            string playerOneChoice = Console.ReadLine();
            playerOneChoice.ToLower();


            if (playerOneChoice == null)
            {
                Console.WriteLine("Please enter one of the following: rock, paper, or sicssor");
            }


            gameRound.PlayerOneSelect(playerOneChoice);

            //player two

            Console.Write("Player 2, please enter your choice for this round: ");
            string playerTwoChoice = Console.ReadLine();
            playerTwoChoice.ToLower();


            if (playerTwoChoice == null)
            {
                Console.WriteLine("Please enter one of the following: rock, paper, or sicssor");
            }

            gameRound.PlayerTwoSelect(playerTwoChoice);

            gameRound.GameRound(gameRound._playerOneChoice, gameRound._playerTwoChoice);

            Console.WriteLine($"Player 1 selected {gameRound._playerOneChoice}. Player 2 selected {gameRound._playerTwoChoice}");
            Console.WriteLine($"The result of the round: {gameRound._resultOfGame}. \nPlayer 1 score: {gameRound._playerOneScore}. \nPlayer 2 score: {gameRound._playerTwoScore}.\nNumber of draws: {gameRound._totalDraws}.");
        }

       if (gameRound._playerOneScore > gameRound._playerTwoScore)
        {
            Console.WriteLine($"Player 1 wins with a score of {gameRound._playerOneScore}");
        } else if (gameRound._playerOneScore < gameRound._playerTwoScore)
        {
            Console.WriteLine($"Player 2 wins with a total score of {gameRound._playerTwoScore}");
        } else
        {
            Console.WriteLine($"This game ended in a draw. There were {gameRound._totalDraws} total draws in the game");
        }
        Console.ReadKey();

       
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

    public Game() { }
    public void GameRound(GameOptions _playerOneChoice, GameOptions _playerTwoChoice)
    {
        if (_playerOneChoice == GameOptions.Rock && _playerTwoChoice == GameOptions.Rock || _playerOneChoice == GameOptions.Paper && _playerTwoChoice == GameOptions.Paper || _playerOneChoice == GameOptions.Scissor && _playerTwoChoice == GameOptions.Scissor)
        {
            _resultOfGame = GameResult.Draw;
             RoundScore(GameResult.Draw);
        }
        else if (_playerOneChoice == GameOptions.Rock && _playerTwoChoice == GameOptions.Paper || _playerOneChoice == GameOptions.Paper && _playerTwoChoice == GameOptions.Scissor || _playerOneChoice == GameOptions.Scissor && _playerTwoChoice == GameOptions.Rock)
        {
            _resultOfGame = GameResult.PlayerTwoWin;
             RoundScore(GameResult.PlayerTwoWin);
        }
        else 
        {
            _resultOfGame = GameResult.PlayerOneWin;
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

    public GameOptions PlayerOneSelect(string playerOneChoice)
    {
        if (playerOneChoice == "rock")
        {
            _playerOneChoice = GameOptions.Rock;
            return _playerOneChoice;
        }
        else if (playerOneChoice == "paper")
        {
            _playerOneChoice = GameOptions.Paper;
            return _playerOneChoice;
        }
        else 
        {
            _playerOneChoice = GameOptions.Scissor;
            return _playerOneChoice;
        }

    }

    public GameOptions PlayerTwoSelect(string playerTwoChoice)
    {
        if (playerTwoChoice == "rock")
        {
            _playerTwoChoice = GameOptions.Rock;
            return _playerTwoChoice;

        }
        else if (playerTwoChoice == "paper")
        {
            _playerTwoChoice = GameOptions.Paper;
            return _playerTwoChoice;
        }
        else 
        {
            _playerTwoChoice = GameOptions.Scissor;
            return _playerTwoChoice;
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


