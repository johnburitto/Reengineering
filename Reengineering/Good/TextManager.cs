using System.Text.RegularExpressions;

namespace Reengineering.Good
{
    public class TextManager
    {
        public string ReadText(string path)
        {
            return File.ReadAllText(path);
        }

        public string CleanText(string text)
        {
            text = Regex.Replace(text, "[^A-Za-z ']", " ").ToLower();
            text = Regex.Replace(text, " +", " ");

            return text;
        }
        
        public List<string> DistinctWords(string text)
        {
            return text.Split(" ")
                       .Where(word => word != "")
                       .ToHashSet()
                       .ToList();
        }

        public Dictionary<string, int> CalcFreq(string text)
        {
            Dictionary<string, int> freq = new Dictionary<string, int>();

            DistinctWords(text).ForEach(word => freq.TryAdd(word, Regex.Matches(text, $" {word} ").Count));

            return freq.OrderByDescending(el => el.Value).ToDictionary();
        }

        public void CalcTime(Action action)
        {
            var start = DateTime.Now;

            action.Invoke();

            var end = DateTime.Now;

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Elapsed time: {(end - start).TotalMilliseconds}");
            Console.ReadKey();
        }
    }
}
