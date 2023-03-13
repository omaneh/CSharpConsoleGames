namespace Hangman;
class Program
{
    static void Main(string[] args)
    {
        Game newRound = new Game();
        newRound.WordGenerator();
        newRound.ProduceArray();

        for (int i = 0; i< 25; i++)
        {
            if (newRound.GameOver())
            {
                Console.WriteLine("Congratulations. You won!");
            }

            Console.Write($"ROUND: {i} ");
             newRound.DisplayArray();
            Console.Write(" Please guess a letter: ");
            char userGuess = char.Parse(Console.ReadLine());
            if (userGuess == null)
            {
                Console.WriteLine("Please enter a letter");
            }
            newRound.GuessTheWord(userGuess);
            

            
        }
        
    }
}
class Game
{
    internal string _wordChoice { get; set; }
    internal string[] _wordOptions { get; set; } = { "fly", "pet", "business", "cough", "tooth", "silk", "decision", "canvas", "cracker", "books", "jeans", "company", "creator", "effect", "plastic", "flag", "secretary", "wilderness", "scarecrow", "elbow", "head", "mind", "payment", "pancake", "hobbies" };
    internal char[] _wordChoiceArray { get; set; }
    internal char[] _displayWord { get; set; }
    internal int _letterLocation { get; set; }


    public void WordGenerator()
    {
        Random randomNumber = new Random();
        int arrayIndex = randomNumber.Next(0, 24);
        _wordChoice = _wordOptions[arrayIndex];
    }

    public void ProduceArray()
    {
        _wordChoiceArray = _wordChoice.ToCharArray();
        int lengthOfArray  = _wordChoiceArray.Length;
        _displayWord = new char[lengthOfArray];

    }

    public void DisplayArray()
    {
        foreach (char letter in _displayWord)
        {
            Console.Write(letter + " ");
        }
    }

    public void GuessTheWord(char userLetter)
    {
        for (int i = 0; i < _wordChoiceArray.Length; i++)
        {
            if (userLetter == _wordChoiceArray[i])
            {
                _letterLocation = i; //only returns the first in words with repeating letters
                 UncoverLetter(userLetter, _letterLocation);
            }
        }
       
    }

    public int UncoverLetter(char userLetter, int _letterLocation)
    {
        _displayWord[_letterLocation] = userLetter;
        return _letterLocation;
    }

    public bool GameOver()
    {
        if (_displayWord == _wordChoiceArray)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}

