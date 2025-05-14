using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab8CSharp
{
    class Lab8Task1
    {
        public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("Введіть шлях до текстового файлу:");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не знайдено.");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            Regex ipRegex = new Regex(@"\b([0-1]{1,8}\.){3}[0-1]{1,8}\b");
            var ipAddresses = lines.SelectMany(line => ipRegex.Matches(line).Select(m => m.Value)).Distinct().ToList();

            if (ipAddresses.Count == 0)
            {
                Console.WriteLine("У файлі немає IP-адрес.");
                return;
            }

            Console.WriteLine($"\nЗнайдено {ipAddresses.Count} IP-адрес:");
            for (int i = 0; i < ipAddresses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ipAddresses[i]}");
            }

            while (true)
            {
                Console.WriteLine("\nВиберіть дію:");
                Console.WriteLine("1. Видалити IP-адресу");
                Console.WriteLine("2. Замінити IP-адресу");
                Console.WriteLine("3. Зберегти зміни в новий файл");
                Console.WriteLine("4. Вийти");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DeleteIPAddress(ref lines, ref ipAddresses);
                        break;
                    case "2":
                        ReplaceIPAddress(ref lines, ref ipAddresses);
                        break;
                    case "3":
                        SaveToFile(lines);
                        break;
                    case "4":
                        Console.WriteLine("Завершення роботи.");
                        return;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }

        static void DeleteIPAddress(ref string[] lines, ref System.Collections.Generic.List<string> ipAddresses)
        {
            Console.WriteLine("\nВведіть номер IP-адреси для видалення:");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= ipAddresses.Count)
            {
                string ipToDelete = ipAddresses[index - 1];
                ipAddresses.RemoveAt(index - 1);

                Regex ipRegex = new Regex(@"\b([0-1]{1,8}\.){3}[0-1]{1,8}\b");
                lines = lines.Select(line => ipRegex.Replace(line, match =>
                {
                    return match.Value == ipToDelete ? "" : match.Value;
                })).ToArray();

                Console.WriteLine("IP-адреса видалена.");
            }
            else
            {
                Console.WriteLine("Невірний номер.");
            }
        }

        static void ReplaceIPAddress(ref string[] lines, ref System.Collections.Generic.List<string> ipAddresses)
        {
            Console.WriteLine("\nВведіть номер IP-адреси для заміни:");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= ipAddresses.Count)
            {
                string oldIP = ipAddresses[index - 1];
                Console.WriteLine($"Поточна IP: {oldIP}");
                Console.WriteLine("Введіть нову IP-адресу:");
                string newIP = Console.ReadLine();

                ipAddresses[index - 1] = newIP;

                Regex ipRegex = new Regex(@"\b([0-1]{1,8}\.){3}[0-1]{1,8}\b");
                lines = lines.Select(line => ipRegex.Replace(line, match =>
                {
                    return match.Value == oldIP ? newIP : match.Value;
                })).ToArray();

                Console.WriteLine("IP-адреса замінена.");
            }
            else
            {
                Console.WriteLine("Невірний номер.");
            }
        }

        static void SaveToFile(string[] lines)
        {
            Console.WriteLine("\nВведіть шлях для збереження нового файлу:");
            string savePath = Console.ReadLine();

            File.WriteAllLines(savePath, lines, Encoding.UTF8);
            Console.WriteLine("Файл успішно збережено.");
        }
    }
}
