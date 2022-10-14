using System;
using System.Collections;

namespace lab15_t4
{
    public class Task
    {
        public static void Func()
        {
            var list = new ArrayList();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1 - Add\n2 - Count\n3 - Clear\n4 - Show\nQ - exit\n");
                string opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        Console.WriteLine("Enter struct (nazv, numr, date, time)");
                        var timetable = Console.ReadLine();
                        var tA = timetable.Split(',');
                        Timetable tt = new Timetable();
                        tt.nazv = tA[0];
                        tt.numr = Convert.ToInt32(tA[1]);
                        var arr = tA[2].Split('-');
                        tt.date = new DateTime(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]), Convert.ToInt32(arr[2]));
                        var timeArr = tA[3].Split('-');
                        tt.time = new TimeSpan(
                            Convert.ToInt32(timeArr[0]),
                            Convert.ToInt32(timeArr[1]),
                            Convert.ToInt32(timeArr[2])
                            );
                        list.Add(tt);
                        break;
                    case "2":
                        Console.WriteLine($"Elements counted: {list.Count}");
                        break;
                    case "3":
                        list.Clear();
                        Console.WriteLine("Cleared...");
                        break;
                    case "4":
                        foreach (var o in list)
                        {
                            Console.WriteLine(o);
                        }
                        break;
                }
            }
        }
    }
}