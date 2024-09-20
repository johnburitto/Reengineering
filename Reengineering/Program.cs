using Reengineering.Good;

var textManager = new TextManager();

textManager.CalcTime(() =>
{
    var freq = textManager.CalcFreq(textManager.CleanText(textManager.ReadText("Resources/harry.txt")));

    for (int i = 0; i < 30; i++)
    {
        Console.WriteLine($"{freq.ElementAt(i).Key} => {freq.ElementAt(i).Value}");
    }
});
