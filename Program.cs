using System.Runtime.CompilerServices;

class RollingDice
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the dice throwing simulator!\n");
        Console.WriteLine("How many dice rolls would you like to simulate?");

        int numberOfRolls = int.Parse(Console.ReadLine());

        DiceRoller roller = new DiceRoller();
        int[] rollResults = roller.RollDice(numberOfRolls);

        Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine($"Total number of rolls = {numberOfRolls}.\n");

        for (int i = 2; i <= 12; i++)
        {
            Console.Write($"{i}: ");
            int percentage = (int)((rollResults[i] / (double)numberOfRolls) * 100);
            Console.WriteLine(new String('*', percentage));
        }

        Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
    }
}

class DiceRoller
{
    private Random random = new Random();

    public int[] RollDice(int numberOfRolls)
    {
        int[] results = new int[13]; // Indices 2-12 will be used

        for (int i = 0; i < numberOfRolls; i++)
        {
            int rollOne = random.Next(1, 7);
            int rollTwo = random.Next(1, 7);
            results[rollOne + rollTwo]++;
        }

        return results;
    }
}