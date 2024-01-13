// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

int RollDie(int die)
{
    Random random = new Random();
    int dieValueForMethod = die + 1;
    int result = random.Next(1, dieValueForMethod);
    return result;
}

int roll2d6()
{
    return RollDie(6) + RollDie(6);
}

int roll1d12()
{
    return RollDie(12);
}

int roll2d6withadvantage()
{
    int a = roll2d6();
    int b = roll2d6();
    if (a > b)
    {
        return a;
    }
    else
    {
        return b;
    }
}

void testAdvantage() { 
int runs = 1000;
var sum = 0;
for(int i = 0; i < runs; i++)
{
    sum = sum + roll2d6withadvantage();
}
double result = (double)sum / (double)runs;
Console.WriteLine(result);
}

//testAdvantage();

void testOpposingRolls()
{
    Dictionary<int, int> occurrences = new Dictionary<int, int>();
    Random rand = new Random();
    for (int i = 0; i < 1000; i++)
    {
        //int num = rand.Next(1, 13); // Generates a random number between 1 and 12
        int num = roll1d12() - roll1d12();
        if (!occurrences.ContainsKey(num))
        {
            occurrences[num] = 1;
        }
        else
        {
            occurrences[num]++;
        }
    }
    //var sortedOccurrences = occurrences.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
    var sortedOccurrences = occurrences.OrderByDescending(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

    foreach (var entry in sortedOccurrences)
    {
        Console.WriteLine($"Number {entry.Key}: {entry.Value} occurrences");
    }
}

testOpposingRolls();
// Ah, nu så jeg det - min intuition var, at opposing rolls er mere svingende. Det viste sig at være sandt. Lad os sige at man skal klare en DC på en d10+2. De +2 rykker udfaldsrummet 2, ca 20%. Men er det 1d10 vs 1d10+2, så er udfaldsrummet langt større og udfaldsrummet bliver kun rykket med ca 10%.
// MEN - Det betyder også, at opposing rolls er ok, hvis man fordobler begges bonuser!