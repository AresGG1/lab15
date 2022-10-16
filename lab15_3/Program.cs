using System;
using System.Collections.Generic;

namespace lab15_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var rand = new Random(Guid.NewGuid().GetHashCode());
            var set = new Stack<string>(new string[]{ "Марченко", "Кузьменко" ,"Мельник", "Шевченко", "Коваленко", "Бондаренко", "Бойко", "Ткаченко", "Кравченко", "Ковальчук", "Коваль",
                "Олійник", "Шевчук", "Поліщук", "Ткачук", "Савченко", "Бондар", "Марченко", "Руденко", "Мороз", "Лисенко",
                "Петренко", "Клименко", "Павленко", "Кравчук", "Кузьменко", "Шило"});
            var cycle1 = new CycleList<string>();
            var cycle2 = new CycleList<string>();
            for (int i = 0; i < 10; i++)
            {
                cycle1.Append(set.Pop());
                cycle2.Append(set.Pop());
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{cycle1.Pop(rand.Next(0,cycle1.Count()))} VS {cycle2.Pop(rand.Next(0,cycle2.Count()))}");
            }
        }
    }
}