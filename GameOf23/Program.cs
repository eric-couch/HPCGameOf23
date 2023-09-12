string userInput = String.Empty;
int toothpicks = 23;

Console.WriteLine("Welcome to the Game of 23!");
Console.Write("Enter player name: ");
string? playerName = Console.ReadLine();
do
{
    Console.Write("Select 1-3 toothpicks (Q to quit):");
    userInput = Console.ReadLine()!;
    if (Int32.TryParse(userInput, out int _numOfToothpicks) && _numOfToothpicks >= 1 && _numOfToothpicks <= 3)
    {
        // Make sure the user takes fewer than what is available
        if (_numOfToothpicks < toothpicks)
        {
            toothpicks -= _numOfToothpicks;
            Console.WriteLine($"number of toothpicks left: {toothpicks}");
        }
        // If the user takes more than what is available, tell them they can't do that
        else if (_numOfToothpicks > toothpicks)
        {
            Console.WriteLine("that's too many.  there aren't that many left.");
        }
        // user takes the last toothpick, they lose
        else
        {
            Console.WriteLine("You lost!");
        }
        // Computer's turn, generate random number between 1 and 3 (or what's left if it's less than 3)
        Random rnd = new Random();
        int computerTurn = rnd.Next(1, Math.Min(3, toothpicks + 1));
        // no need to validate the computer's turn since we've set the boundaries
        toothpicks -= _numOfToothpicks;
        Console.WriteLine($"Computer selects: {computerTurn}");
        Console.WriteLine($"Toothpicks left: {toothpicks}");
        // if the computer took the last toothpick, they lose
        if (toothpicks < 1)
        {
            Console.WriteLine("Computer loses!!!");
        }
    }
    // if the user input doesn't parse to an int, check if they want to quit
    else if (userInput.ToUpper() != "Q")
    {
        Console.WriteLine("Bad input try again.");
    }
} while (toothpicks > 0 && userInput.ToUpper() != "Q");
//userInput.ToUpper() != "Q"
//userInput != "Q" && userInput != "q"