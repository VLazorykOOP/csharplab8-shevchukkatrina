using System;
using System.IO;
using System.Linq;

class Lab8Task2
{
    public void Run()
    {
        Console.Write("Введіть шлях до вхідного файлу: ");
        string inputFilePath = Console.ReadLine();

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Файл не знайдено. Перевірте шлях і спробуйте знову.");
            return;
        }

        Console.Write("Введіть шлях до вихідного файлу: ");
        string outputFilePath = Console.ReadLine();

        try
        {
            string text = File.ReadAllText(inputFilePath);

            var result = new string(text.Where(c => !char.IsPunctuation(c) && !char.IsDigit(c)).ToArray());

            File.WriteAllText(outputFilePath, result);

            Console.WriteLine($"Файл успішно оброблено! Результат збережено у: {outputFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
