using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Xsl;

namespace lab15._2
{
    internal class Program
    {
        public static void Write(List<int> list)
        {
            StreamWriter writer = new StreamWriter("..\\..\\task1.txt", false, Encoding.UTF8);
            string st = "";
            int count = 0;
            foreach (var i in list)
            {
                st += i.ToString() + ",";
                count++;
                if (count == 7)
                {
                    st += "\n";
                    count = 0;
                }
                
            }
            writer.Write(st);
            writer.Close();
        }

        public static List<int> Read()
        {
            StreamReader reader = new StreamReader("..\\..\\task1.txt");
            string info = reader.ReadToEnd();
            reader.Close();
            info = info.Remove('\n');
            info = info.Trim(',');
            var array = info.Split(',');
            List<int> list = new List<int>();
            foreach (var s in array)
            {
                list.Add(Convert.ToInt32(s));
            }
            
            return list;
        }
        public static void Menu()
        {
            List<int> list = new List<int>();
            while (true)
            {
                Console.WriteLine("\n1 - Read list\n2 - Write list\nq - Leave ");
                string opt = Console.ReadLine();
                if (opt == "1")
                {
                    list = Read();
                    list.ForEach(delegate(int i) {Console.Write($"{i}, ");  });
                }
                
                else if (opt == "2")
                {
                    var left = new List<int>();
                    var right = new List<int>();
                    Console.WriteLine("Enter number of elements: ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    for (int i = 1; i < num+1; i++)
                    {
                        left.Add(i);
                        if(num - i != 0)
                            right.Add(num-i);
                    }
                    list.AddRange(left);
                    list.AddRange(right);
                    Write(list);
                    if (opt == "q")
                        break;
                }
            }
        }
        
        public static void Main(string[] args)
        {
            Menu();
        }
    }
}