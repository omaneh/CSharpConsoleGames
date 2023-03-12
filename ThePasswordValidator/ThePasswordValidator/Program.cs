namespace ThePasswordValidator;
class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 25; i++)
        {
            Console.Write("Hello there and welcome to the password validator. Please enter your password: ");
            string userPasswordString = Console.ReadLine();
            PasswordValidator userPassword = new PasswordValidator(userPasswordString);
            Console.WriteLine(userPassword.IsValidPassword(userPassword._newPassword));
            Console.ReadLine();
        }

        
    }
}
class PasswordValidator
{
    internal string _newPassword { get; set; } = string.Empty;

    public PasswordValidator(string newPassword) => _newPassword = newPassword;

    public bool IsValidPassword(string input)
    {

        bool result;
        char[] inputCharArray = input.ToCharArray();
        foreach(char letter in inputCharArray)
        {
            if (char.IsUpper(letter))
            {
                if(char.IsLower(letter))
                {
                    if(char.IsNumber(letter))
                    {
                       if (letter != 'T')
                        {
                            if (letter != '&')
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                }
            }

        }
        if (result = true && inputCharArray.Length < 13 && inputCharArray.Length > 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

