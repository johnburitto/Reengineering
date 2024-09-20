using System.Text.RegularExpressions;

public class Main
{

    public static String cleanText(String url)
    {
        String content = new String(File.ReadAllText(url));
        content = Regex.Replace(content,"[^A-Za-z ]"," ").ToLower();
        return content;
    }

    public static void main(String[] args)
    {

        DateTime start = DateTime.Now;
        // Path path = Paths.get()
        String content = new String(File.ReadAllText("Resources/harry.txt"));

        content = Regex.Replace(content,"[^A-Za-z ']"," ").ToLower();

        String[] words = content.Split(" +"); // 400 000

        Array.Sort(words);

        String distinctString = " ";

        for (int i = 0; i < words.Length; i++)
        {
            if (!distinctString.Contains(words[i]))
            {
                distinctString += words[i] + " ";
            }
        }

        String[] distincts = distinctString.Split(" ");
        int[] freq = new int[distincts.Length];

        for (int i = 0; i < distincts.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < words.Length; j++)
            {
                if (distincts[i].Equals(words[j]))
                {
                    count++;
                }
            }

            freq[i] = count;
        }

        for (int i = 0; i < distincts.Length; i++)
        { // 5 000
            distincts[i] += " " + freq[i];
        }

        Array.Sort(distincts, (str1, str2) =>
        {
            int num1 = int.Parse(Regex.Replace(str1, "[^0-9]", ""));
            int num2 = int.Parse(Regex.Replace(str2, "[^0-9]", ""));
            return num1.CompareTo(num2);
        });

        for (int i = 0; i < 30; i++)
        {
            Console.WriteLine(distincts[distincts.Length - 1 - i]);
        }
        DateTime finish = DateTime.Now;

        Console.WriteLine("------");
        Console.WriteLine((finish - start).TotalMilliseconds);

    }
}