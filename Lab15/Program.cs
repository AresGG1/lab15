using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Lab15
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            LinkedList list = new LinkedList(1);
            list.Append(2);
            list.AppendFirst(12);
            list.AppendPos(2,3);
            // list.DeleteByInd(4);
            // list.DeleteAllByValue(2);
            list.ReplaceAll(2,112);
            list.Show();
            DoubleLinkedList<int> sho = new DoubleLinkedList<int>();
        }
    }
}