namespace TheLockedDoor;
class Program
{
    static void Main(string[] args)
    {
     
        Door userJourneyToOpeningTheDoor = new Door();
        Console.WriteLine($"Your new password is {userJourneyToOpeningTheDoor._userNewPassword}");
        Console.ReadKey(true);
    }
}
class Door
{
    internal static int _orignalPassword { get; } = 4567;
    internal int _userNewPassword { get; set; }
    internal DoorStatus _currentStatus { get; set; } = DoorStatus.Locked;

    public Door(int orginalPassword)
    {
     
        if(orginalPassword == _orignalPassword)
        {
            Console.Write("Please update the password: ");
            int userNewPassword = int.Parse(Console.ReadLine());
            _userNewPassword = userNewPassword;
        } else
        {
            Console.WriteLine("That is incorrect. Please try again");
            int userGuess = int.Parse(Console.ReadLine());
            Door tryingAgain = new Door(userGuess);
        }


    }

    public Door(DoorStatus currentStatus)
    {
        _currentStatus = currentStatus;
        if (currentStatus == DoorStatus.Open)
        {
            Console.Write("The door is open. Please enter the password to procede: ");
            int userGuessing = int.Parse(Console.ReadLine());
            Door passwordAttempt = new Door(userGuessing);
        }
        else if (currentStatus == DoorStatus.Closed)
        {
            ClosedDoor(_currentStatus);
        }
        else if (currentStatus == DoorStatus.Unlocked)
        {
            UnlockedDoor(_currentStatus);
        }
        else
        {
            LockedDoor();

        }

    }
    public Door() { Door doorJourney = new Door(_currentStatus); }

    public DoorStatus LockedDoor()
    {
        Console.WriteLine("Before you can put in the password, you will need to open the door. The door is locked so you can keep it locked or unlock it.\nWhat will you do?\n1.Lock\n2.Unlock");
        int userChoiceInt = int.Parse(Console.ReadLine());
        if (userChoiceInt == null)
        {
            Console.Write("That was not a valid answer. Please retry and enter the number correspoding to the avaliable choices.");
            return LockedDoor();
        }

        DoorStatus userChoice = (DoorStatus)userChoiceInt;
        if (userChoiceInt == 2)
        {
            _currentStatus = userChoice;
            return UnlockedDoor(_currentStatus);
        } else
        {
            return LockedDoor();
        }
    }

    public DoorStatus UnlockedDoor(DoorStatus _currentStatus)
    {
        Console.WriteLine("The door is unlocked so you have several options.\nWhat will you do?\n1. Lock\n2. Unlock \n3. Close\n4. Open");
        int userChoiceInt = int.Parse(Console.ReadLine());
        if (userChoiceInt == null)
        {
            Console.Write("That was not a valid answer. Please retry and enter the number correspoding to the avaliable choices.");
            return LockedDoor();
        }

        DoorStatus userChoice = (DoorStatus)userChoiceInt;
        _currentStatus = userChoice;

        if (userChoiceInt == 1)
        {
            return LockedDoor();
        } else if (userChoiceInt == 2)
        {
            return UnlockedDoor(_currentStatus);
        }
        else
        {
            return ClosedDoor(_currentStatus);
        }

    }

    public DoorStatus ClosedDoor(DoorStatus _currentStatus)
    {
        Console.WriteLine("The door is closed so you have several options. If you choose to open the door, you will be able to do this time.\nWhat will you do?\n1. Lock\n2. Unlock \n3. Close\n4. Open");
        int userChoiceInt = int.Parse(Console.ReadLine());
        if (userChoiceInt == null)
        {
            Console.Write("That was not a valid answer. Please retry and enter the number correspoding to the avaliable choices.");
            return LockedDoor();
        }

        DoorStatus userChoice = (DoorStatus)userChoiceInt;
        _currentStatus = userChoice;


        if (userChoiceInt == 1)
        {
            return LockedDoor();
        }
        else if (userChoiceInt == 2)
        {
            return UnlockedDoor(_currentStatus);
        }
        else
        {
            Door finalStep = new Door(_currentStatus);
            return _currentStatus;
        }

    }

}
public enum DoorStatus
{
    Locked =1,
    Unlocked,
    Closed,
    Open
}


