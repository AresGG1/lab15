using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Lab15_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            while (true)
            {
                Console.WriteLine("1. Single linked list\n2. Double linked list");
                string answer = Console.ReadLine()?.Trim();
                if (answer == "1")
                {
                    var list = new SingleLinkedList<Company>();
                    Console.WriteLine("Вставка в кінець: ");
                    list.Append(new Company("Renault,20100000, 20000"));
                    list.Show();
                    Console.WriteLine("Вставка на початок: ");
                    list.AppendPos(new Company("Volkswagen,30000100, 24000"),0);
                    list.Show();
                    Console.WriteLine("Вставка в певну позицію: ");
                    list.AppendPos(new Company("Silpo,200000, 13111"),1);
                    list.Show();
                    Console.WriteLine("Редагування елементів списку: ");
                    list[1] = new Company("IBM, 11010000, 1110");
                     list.Show();
                    Console.WriteLine("Перевірка на відсутність: ");
                    var cmp = new Company("IBM, 11010000, 1110");
                    Console.WriteLine(cmp.ToString() + "is in list? ");
                    Console.WriteLine(list.IsInList(cmp)? "Yes": "No");
                    Console.WriteLine("Визначення кількості елементів: ");
                    Console.WriteLine(list.Count());
                    Console.WriteLine("Заміна елементів з вказаним значенням: ");
                    list.ReplaceAll(cmp, new Company("Apple,302122020, 200201"));
                    list.Show();
                    Console.WriteLine("Пошук за полем: ");
                    var result = from s in list where s.Name == "Apple" select s;
                    foreach (var var in result)
                    {
                        Console.WriteLine(var);
                    }
                    Console.WriteLine("Сортування: ");
                    var sortedList = new SingleLinkedList<Company>(list.OrderBy(val => val));
                    list = sortedList;
                    list.Show();
                    Console.WriteLine("Запис у файл: ");
                    list.Write();
                    Console.WriteLine("Видалення по індексу: ");
                    list.Append(new Company(list[2].ToString()));
                    list.Append(new Company(list[2].ToString()));
                    list.Show();
                    list.DeleteByInd(4);
                    list.Show();
                    Console.WriteLine("Видалення всіх по значенню: ");
                    list.DeleteAllByValue(new Company(list[2].ToString()));
                    list.Show();
                    Console.WriteLine("Видалення одного по значенню: ");
                    list.DeleteByValue(new Company(list[0].ToString()));
                    list.Show();
                    Console.WriteLine("Видалення всіх: ");
                    list.Clear();
                    Console.WriteLine("К-сть елементів "+list.Count());
                    Console.WriteLine("Читання з файлу: ");
                    list.FromArray(FileReader.Read());
                    list.Show();

                }
                else if (answer == "2")
                {
                    var list = new DoubleLinkedList<UniversityUnit>();
                    Console.WriteLine("Вставка в кінець: ");
                    list.Append(new UniversityUnit("PZKS,CHNU, 20"));
                    list.Show();
                    Console.WriteLine("Вставка на початок: ");
                    list.AppendPos(new UniversityUnit("History faculty,CHNU, 100"),0);
                    list.Show();
                    Console.WriteLine("Вставка в певну позицію: ");
                    list.AppendPos(new UniversityUnit("Comp science,Lviv Politeh, 30"),1);
                    list.Show();
                    Console.WriteLine("Редагування елементів списку: ");
                    list[1] = new UniversityUnit("Philosophy, CHNU, 20");
                    list.Show();
                    Console.WriteLine("Перевірка на відсутність: ");
                    var cmp = new UniversityUnit("Philosophy, CHNU, 20");
                    Console.WriteLine(cmp.ToString() + "is in list? ");
                    Console.WriteLine(list.IsInList(cmp)? "Yes": "No");
                    Console.WriteLine("Визначення кількості елементів: ");
                    Console.WriteLine(list.Count());
                    Console.WriteLine("Заміна елементів з вказаним значенням: ");
                    list.ReplaceAll(cmp, new UniversityUnit("Philosophy, KNTEU, 9"));
                    list.Show();
                    Console.WriteLine("Пошук за полем: ");
                    var result = from s in list where s.UnitName == "Philosophy" select s;
                    foreach (var var in result)
                    {
                        Console.WriteLine(var);
                    }
                    Console.WriteLine("Сортування: ");
                    var sortedList = new DoubleLinkedList<UniversityUnit>(list.OrderBy(val => val));
                    list = sortedList;
                    list.Show();
                    Console.WriteLine("Запис у файл: ");
                    list.Write();
                    Console.WriteLine("Видалення по індексу: ");
                    list.Append(new UniversityUnit(list[2].ToString()));
                    list.Append(new UniversityUnit(list[2].ToString()));
                    list.Show();
                    list.DeleteByInd(4);
                    list.Show();
                    Console.WriteLine("Видалення всіх по значенню: ");
                    list.DeleteByAllValue(new UniversityUnit(list[2].ToString()));
                    list.Show();
                    Console.WriteLine("Видалення одного по значенню: ");
                    list.DeleteByValue(new UniversityUnit(list[0].ToString()));
                    list.Show();
                    Console.WriteLine("Видалення всіх: ");
                    list.Clear();
                    Console.WriteLine("К-сть елементів "+list.Count());
                    Console.WriteLine("Читання з файлу: ");
                    list.FromArray(FileReader.ReadUniversityUnits());
                    list.Show();
                }
                else
                    break;
            }
        }
        
    }
}