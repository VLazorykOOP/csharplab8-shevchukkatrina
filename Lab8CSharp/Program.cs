using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab8CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("Виберіть завдання (1-5):");
            int taskNumber;

            if (int.TryParse(Console.ReadLine(), out taskNumber))
            {
                switch (taskNumber)
                {
                    case 1:
                        Lab8Task1 lab8task1 = new Lab8Task1();  // Створення екземпляру класу
                        lab8task1.Run(); 
                        break;

                    case 2:
                        Lab8Task2 lab8task2 = new Lab8Task2();
                        lab8task2.Run();
                        break;

                    case 3:
                        Lab8Task3 lab8task3 = new Lab8Task3();
                        lab8task3.Run();
                        break;

                    case 4:
                        Lab8Task4 task4 = new Lab8Task4();
                        task4.Run();
                        break;

                    case 5:
                        Lab8Task5 lab8task5 = new Lab8Task5();
                        lab8task5.Run();
                        break;

                    default:
                        Console.WriteLine("Невірний номер завдання. Виберіть від 1 до 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Будь ласка, введіть коректне число.");
            }
        }
    }
}
