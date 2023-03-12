using System;

namespace FifteenPuzzzle;
class Program
{
    static void Main(string[] args)
    {
        PuzzleGame newRound = new PuzzleGame();

        for (int i = 0; i < 25; i++)
        {
            newRound.DisplayCurrentBoard();
            Console.WriteLine("What number would you like to switch the 0 with?");
            int userAnswer = int.Parse(Console.ReadLine());
            newRound.FindLocation(userAnswer);
            if (newRound.PossibleMove())
            {
                newRound.SwapPositions(0, userAnswer);

                if (newRound.GameOver())
                {
                    Console.WriteLine("Congratulations, you have won the game!");
                    break;
                }
            } else
            {
                Console.WriteLine("Not a valid move. You can only move either to your left or right or up and down. Please try again.");
            }
        }


    }
}
class PuzzleGame
{
    internal int _zeroLocationOutter { get; set; } = 3;
    internal int _zeroLocationInner { get; set; } = 1;
    internal int _movingNumberLocationOuter { get; set; }
    internal int _movingNumberLocationInner { get; set; }
    internal int[,] _currentBoard { get; set; } = { { 2, 3, 10, 4 }, { 1, 13, 12, 7 }, { 11, 6, 14, 15 }, { 9, 0, 5, 8 } };
    internal int[,] _finalBoard { get; } = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };




    internal void DisplayCurrentBoard()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write("[" + _currentBoard[i, j] + "]" + " ");
            }
            Console.WriteLine();
        }


    }
    public void FindLocation(int userInput)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (_currentBoard[i, j] == userInput)
                {
                    _movingNumberLocationOuter = i;
                    _movingNumberLocationInner = j;
                }
            }
        }

    }

    public bool PossibleMove()
    {
        int possibleHorizontalMoveUp = _zeroLocationOutter + 1;
        int possibleVerticalMoveUp = _zeroLocationInner + 1;
        int possibleHorizontalMoveDown = _zeroLocationOutter - 1;
        int possibleVerticalMoveDown = _zeroLocationInner - 1;
        if (possibleHorizontalMoveUp == _movingNumberLocationOuter || possibleVerticalMoveUp == _movingNumberLocationOuter || possibleHorizontalMoveDown == _movingNumberLocationInner || possibleVerticalMoveDown == _movingNumberLocationInner)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SwapPositions(int oldValue, int newValue)
    {
        _currentBoard[_movingNumberLocationOuter, _movingNumberLocationInner] = oldValue;
        _currentBoard[_zeroLocationOutter, _zeroLocationInner] = newValue;
        _zeroLocationOutter = _movingNumberLocationOuter;
        _zeroLocationInner = _movingNumberLocationInner;
    }

    public bool GameOver()
    {
        if (_currentBoard == _finalBoard)
        {
            return true;
        } else
        {
            return false;
        }
    }

}



