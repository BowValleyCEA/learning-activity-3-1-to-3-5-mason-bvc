// See https://aka.ms/new-console-template for more information
LearningActivity31();
LearningActivity32();
LearningActivity33();
LearningActivity34();
LearningActivity35();

void LearningActivity31()
{
    while (true)
    {
        Console.Write("Enter a temperature in celcius: ");

        if (!float.TryParse(Console.ReadLine(), out float celcius))
        {
            Console.WriteLine("Not a valid decimal!");
            continue;
        }

        Console.WriteLine($"The equivalent value in fahrenheit is {(celcius * 1.8) + 32}.");
        break;
    }
}
void LearningActivity32()
{
    // apparently C# has "collection expressions" now which can be initialized
    // with [] instead of {} for raw arrays.
    string[] classmates = [
        "Hoang Quan Dinh",
        "Emre Vatansever",
        "Hamish Harrison",
        "Anna Victoria Gubert Katlauskas",
        "Ahamed Maahin Siddiq Rahuman",
        "Canyon Anderson",
        "Cat Finley",
        "Camilo Soto Cordovez",
        "Jose Quinones Davila",
        "Bruno Castro-Gonzalez",
        "Julianna Scouras",
        "Keegan Paxton",
        "Lucas Ladan",
        "Lukas Hoch",
        "Mason Watfa",
        "Muhammad Moid Ali",
        "Shea Couglin", // I'm a trailing comma type of guy
    ];

    // in production code I would really just use int[] but I have a feeling
    // we're supposed to use the most parsimonious types for learning purposes
    // here.
    // I am going to be the first person that lives to 256.
    byte[] classmateAges = [
        20, // Hoang Quan Dinh
        20, // Emre Vatansever
        35, // Hamish Harrison
        20, // Anna Victoria Gubert Katlauskas
        20, // Ahamed Maahin Siddiq Rahuman
        20, // Canyon Anderson
        20, // Cat Finley
        20, // Camilo Soto Cordovez
        20, // Jose Quinones Davila
        20, // Bruno Castro-Gonzalez
        20, // Julianna Scouras
        20, // Keegan Paxton
        20, // Lucas Ladan
        20, // Lukas Hoch
        29, // Mason Watfa
        20, // Muhammad Moid Ali
        20, // Shea Couglin
    ];

    string[] wondersOfTheWorld = [
        "Great Wall of China",
        "Chichen Itza",
        "Petra",
        "Machu Picchu",
        "Christ the Redeemer",
        "Colosseum",
        "Taj Mahal",
    ];
}

void LearningActivity33()
{
    int[,] board = {
        {1, 1, 2},
        {1, 2, 0},
        {2, 0, 0},
    };

    int rowValue;
    int columnValue;
    var diagonalValue = 1;
    var diagonalValue2 = 1;
    var winner = 0;

    for (var y = 0; y < 3; y++)
    {
        rowValue = 1;
        columnValue = 1;

        for (var x = 0; x < 3; x++)
        {
            rowValue *= board[y, x];
            columnValue *= board[x, y];
        }

        diagonalValue *= board[y, y];
        diagonalValue2 *= board[2 - y, y];
        winner = ((ICollection<int>)[rowValue, columnValue, diagonalValue, diagonalValue2])
            .Aggregate((_, value) => ((ICollection<int>)[1, (int)Math.Pow(2, 3)]).Contains(value) ? value : 0);

        if (winner != 0)
        {
            winner = (int)Math.Pow(winner, 1.0 / 3.0);
            Console.WriteLine($"Winner is {winner}.");
            break;
        }
    }

    if (winner == 0)
    {
        Console.WriteLine("No one wins! Or loses!");
    }
}

void LearningActivity34()
{
    while (true)
    {
        Console.Write("Enter your age: ");

        if (!uint.TryParse(Console.ReadLine(), out uint number))
        {
            Console.WriteLine("Not a valid integer!");
            continue;
        }

        // "Between" = exclusive by default? I hope. If not I'll just change
        // the signs to < and >.
        if (number <= 10 || number >= 50)
        {
            Console.WriteLine($"I hate to discriminate, but I cannot accept an age of {number}.");
            continue;
        }

        Console.WriteLine($"If I heard you right, your age is {number}.");
        break;
    }
}

void LearningActivity35()
{
    int[] highScores = [
        1272700,
        1271100,
        1243000,
        1218000,
        1214300,
        1210800,
        1210400,
        1206800,
        1178400,
    ];

    // Using C#'s LINQ I can do:
    // Console.WriteLine(highScores.Average());

    var average = 0.0;

    foreach (var score in highScores)
    {
        average += score;
    }

    average /= highScores.Length;
    Console.WriteLine($"The average is {average} ({Math.Round(average)}).");

    var standardDeviation = 0.0;

    foreach (var score in highScores)
    {
        standardDeviation += Math.Pow(score - average, 2);
    }

    standardDeviation /= highScores.Length - 1;
    standardDeviation = Math.Sqrt(standardDeviation);
    Console.WriteLine($"Standard deviation: {standardDeviation} ({Math.Round(standardDeviation)}).");

    // I can't imagine a reason why averages in this case should be displayed as
    // a decimal, but for the sake of comparison in the backend, it should be
    // considered a decimal for the sake of accuracy...? Maybe?
}
