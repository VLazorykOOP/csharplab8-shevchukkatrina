using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Lab8Task4
{
    public void Run()
    {
        Console.Write("Введіть шлях до вхідного двійкового файлу: ");
        string inputPath = Console.ReadLine();

        Console.Write("Введіть шлях до вихідного двійкового файлу: ");
        string outputPath = Console.ReadLine();

        try
        {
            if (!File.Exists(inputPath))
            {
                CreateTestBinaryFile(inputPath);
                Console.WriteLine("Створено вхідний файл з тестовими словами.");
            }

            List<string> words = ReadBinaryFile(inputPath);

            if (words.Count == 0)
            {
                Console.WriteLine("Файл порожній.");
                return;
            }

            string lastWord = words.Last();
            char firstChar = char.ToLower(lastWord[0]);

            var filteredWords = words
                .Where(word => char.ToLower(word[0]) == firstChar)
                .ToList();

            WriteBinaryFile(outputPath, filteredWords);

            Console.WriteLine($"\nСлова, що починаються на '{firstChar}', записано у файл:");
            foreach (string word in filteredWords)
            {
                Console.WriteLine(word);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    private void CreateTestBinaryFile(string path)
    {
        var testWords = new List<string> { "Apple", "Banana", "Avocado", "apricot", "blueberry", "Almond" };

        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            foreach (var word in testWords)
            {
                writer.Write(word);
            }
        }
    }

    private List<string> ReadBinaryFile(string path)
    {
        List<string> words = new List<string>();

        using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                string word = reader.ReadString();
                words.Add(word);
            }
        }

        return words;
    }

    private void WriteBinaryFile(string path, List<string> words)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            foreach (string word in words)
            {
                writer.Write(word);
            }
        }
    }
}
