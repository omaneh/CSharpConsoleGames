using System;

namespace HuntingTheManticore
{
    public class Game
    {
        public static void Main(string[] args)
        {
            // declare the variables we will be using 
            int cityScore = 15;
            int manticoreScore = 10;
            int cannonDamage = 1;
            string roundResult;

            // Player 1 game instructions 
            Console.WriteLine("Player 1, how far away from the city do you want to station the Manticore? ");
            int manticoreDistance = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            // Player 2 instructions 
            Console.WriteLine("Player 2, it is your turn");

            for (int round = 1; round < 25; round++)
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine($"STATUS: Round: {round}  City: {cityScore}/15  Manticore: {manticoreScore}/10");
                Console.WriteLine($"The cannon is expected to deal {cannonDamage} damage this round.");
                Console.Write("Enter desired cannon range: ");
                int playTwoInput = Convert.ToInt32(Console.ReadLine());

                // calculate the result of the round
                roundResult = ResultOfRound(playTwoInput, manticoreDistance);

                Console.WriteLine($"That round {roundResult}");

                // predict cannon damage
                cannonDamage = RoundCannonDamage(round);

                //predict city score
                cityScore = cityScore - CalculateCityScore(roundResult);

                //predict Manticore score
                manticoreScore = manticoreScore - CalculateManticoreScore(roundResult, cannonDamage);


            }

            Console.WriteLine("You win. Click any button to exit");
            Console.ReadKey(true);

        }
        public static string ResultOfRound(int playerInput, int actualDistance)
        {
            if (playerInput == actualDistance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "was a DIRECT HIT!";
            }
            else if (playerInput < actualDistance)
            {
                return "FELL SHORT of the target.";
            }
            else
            {
                return "OVERSHOT the target";
            }

        }
        public static int RoundCannonDamage(int round)
        {
            if (round % 5 == 0 && round % 3 == 0)
            {
                return 10;
            }
            else if (round % 5 == 0 || round % 3 == 0)
            {
                return 3;
            }
            else
            {
                return 1;
            }
        }
        public static int CalculateCityScore(string result)
        {

            if (result == "was a DIRECT HIT!")
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }
        public static int CalculateManticoreScore(string result, int roundDamage)
        {
            if (result == "was a DIRECT HIT!")
            {
                return roundDamage;
            }
            else
            {
                return 0;
            }
        }
    }
}
