using System;
using System.IO;

public class Lab8Task5
{
    public void Run()
    {
        string basePath = @"D:\temp";
        string shevchuk1 = Path.Combine(basePath, "Шевчук1");
        string shevchuk2 = Path.Combine(basePath, "Шевчук2");

        // 1. Створення папок
        Directory.CreateDirectory(shevchuk1);
        Directory.CreateDirectory(shevchuk2);

        // 2. Створення t1.txt і t2.txt у Шевчук1
        string t1 = Path.Combine(shevchuk1, "t1.txt");
        string t2 = Path.Combine(shevchuk1, "t2.txt");

        File.WriteAllText(t1, "<Шевченко Степан Іванович, 2001> року народження, місце проживання <м. Суми>");
        File.WriteAllText(t2, "<Комар Сергій Федорович, 2000> року народження, місце проживання <м. Київ>");

        // 3. У Шевчук2 створити t3.txt з вмістом t1 + t2
        string t3 = Path.Combine(shevchuk2, "t3.txt");
        string text1 = File.ReadAllText(t1);
        string text2 = File.ReadAllText(t2);
        File.WriteAllText(t3, text1 + Environment.NewLine + text2);

        // 4. Вивести інформацію про t1, t2, t3
        Console.WriteLine("Інформація про створені файли:");
        PrintInfo(t1);
        PrintInfo(t2);
        PrintInfo(t3);

        // 5. Перемістити t2.txt до Шевчук2
        string newT2 = Path.Combine(shevchuk2, "t2.txt");
        File.Move(t2, newT2);

        // 6. Копіювати t1.txt у Шевчук2
        string copyT1 = Path.Combine(shevchuk2, "t1.txt");
        File.Copy(t1, copyT1, overwrite: true);

        // 7. Перейменувати Шевчук2 у ALL, видалити Шевчук1
        string all = Path.Combine(basePath, "ALL");
        if (Directory.Exists(all))
            Directory.Delete(all, true); // очистка, якщо вже є

        Directory.Move(shevchuk2, all);
        Directory.Delete(shevchuk1, true);

        // 8. Вивести інформацію про файли у ALL
        Console.WriteLine("\nІнформація про файли у папці ALL:");
        string[] files = Directory.GetFiles(all);
        foreach (string file in files)
        {
            PrintInfo(file);
        }
    }

    private void PrintInfo(string path)
    {
        FileInfo fi = new FileInfo(path);
        Console.WriteLine($"\nНазва: {fi.Name}");
        Console.WriteLine($"Повний шлях: {fi.FullName}");
        Console.WriteLine($"Розмір: {fi.Length} байт");
        Console.WriteLine($"Створено: {fi.CreationTime}");
        Console.WriteLine($"Остання зміна: {fi.LastWriteTime}");
    }
}
