using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Lab8Task3
{
    public void Run()
    {
        Console.Write("Введіть шлях до вхідного файлу: ");
        string inputPath = Console.ReadLine();

        Console.Write("Введіть шлях до вихідного файлу: ");
        string outputPath = Console.ReadLine();

        try
        {
            // Читання файлу 
            string inputText = File.ReadAllText(inputPath);

            Task<string[]> task = Task.Run(() => FindOrderedWords(inputText));
            task.Wait(); 
            string[] orderedWords = task.Result;

            File.WriteAllLines(outputPath, orderedWords);

            Console.WriteLine("Результат записано у файл.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка: {ex.Message}");
        }
    }

    private string[] FindOrderedWords(string text)
    {
        var words = Regex.Matches(text.ToLower(), @"\b[a-z]+\b")
                         .Cast<Match>()
                         .Select(m => m.Value);

        return words.Where(IsLexicographicallyOrdered).ToArray();
    }

    private bool IsLexicographicallyOrdered(string word)
    {
        return word.SequenceEqual(word.OrderBy(c => c));
    }
}
