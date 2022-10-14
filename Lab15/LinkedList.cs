using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Lab15 
{
    public class Node
    {
        public Company data;
        public Node next = null;
    }

    public class LinkedList
    {
        public Node head;
        public Node last;
        public LinkedList(Company head)
        {
            this.head = new Node{data = head};
            this.last = this.head;
        }

        public void Sort()
        {
            
        }
        private LinkedList FromArray(string[] arr)
        {
            var info = arr[0].Split(',');
            var hd = new Company(info[0], Convert.ToInt32(info[1]), Convert.ToInt32(info[2]));
            head = new Node{data = hd};
            var tmp = head; 
            for (int i = 1; i < arr.Length; i++)
            {
                var cmp = new Company(info[i], Convert.ToInt32(info[i]), Convert.ToInt32(info[i]));
                tmp.next = new Node{data = cmp};
                tmp = tmp.next;
            }
            return this;
        }

        private Company[] ToArray()
        {
            var arr = new Company[this.Count()];
            var tmp = head;
            int count = 0;
            while (tmp != null)
            {
                arr[count] = tmp.data;
                tmp = tmp.next;
                count++;
            }
            return arr;
        }
        
        private void SetLast()
        {
            var tmp = head;
            while (tmp!=null)
            {
                if (tmp.next == null)
                {
                    last = tmp;
                    return;
                }

                tmp = tmp.next;
            }
        }

        public int Count()
        {
            int count = 0;
            var tmp = this.head;
            while (tmp != null)
            {
                tmp = tmp.next;
                count++;
            }

            return count;
        }

        public void Show()
        {
            var tmp = this.head;
            while (tmp != null)
            {
                Console.WriteLine(tmp.data);
                tmp = tmp.next;
            }
        }

        public bool IsInList(Company elem)
        {
            var tmp = this.head;
            while (tmp != null)
            {
                if (EqualityComparer<Company>.Default.Equals(tmp.data, elem))
                    return true;
                tmp = tmp.next;
            }

            return false;
        }
        public void AppendFirst(Company value)
        {
            var currentFirst = this.head;
            this.head = new Node {data = value};
            this.head.next = currentFirst;
        }
        public void AppendPos(Company value, int position)
        {
            if(position == this.Count())
            {
                this.Append(value);
                return;
            }
            int count = 0;
            var tmp = this.head;
            while (tmp != null)
            {
                if (count == position-1)
                {
                    var next = tmp.next;
                    var node = new Node {data = value};
                    node.next = next;
                    tmp.next = node;
                }
                tmp = tmp.next;
                count++;
            }
        }

        public void Append(Company value)
        {
            var node = new Node{data = value};
            last.next = node;
            last = node;
        }

        public void Clear()=>this.head = null;
        
        public void DeleteByInd(int id)
        {
            if (id == 0)
                this.head = this.head.next;
            int count = 0;
            var tmp = this.head;
            while (tmp != null)
            {
                if (count == id - 1)
                {
                    tmp.next = tmp.next.next;
                    break;
                }
                tmp = tmp.next;
                count++;
            }
            SetLast();
        }

        public void DeleteByValue(Company value)
        {
            int count = 0;
            var tmp = this.head;
            while (tmp != null)
            {
                if (tmp.data == value)
                {
                    DeleteByInd(count);
                    return;
                }
                count++;
                tmp = tmp.next;
            }
        }
        public void DeleteAllByValue(Company value)
        {
            int count = 0;
            var tmp = this.head;
            while (tmp != null)
            {
                if (tmp.data == value)
                {
                    DeleteByInd(count);
                    count = 0;
                    tmp = head;
                    continue;
                }
                count++;
                tmp = tmp.next;
            }
        }

        public void ReplaceByInd(int ind, Company value)
        {
            int count = 0;
            var tmp = head;
            while (tmp != null)
            {
                if (ind == count)
                {
                    tmp.data = value;
                    break;
                }
                count++;
                tmp = tmp.next;
            }
        }
        public void ReplaceAll(Company oldValue,Company value)
        {
            var tmp = head;
            while (tmp != null)
            {
                if (tmp.data == oldValue)
                    tmp.data = value;
                
                tmp = tmp.next;
            }
        }

        public Company FindByName(string name)
        {
            var tmp = head;
            while (tmp != null)
            {
                if (tmp.data.Name == name)
                    return tmp.data;
            }

            return null;
        }
        public Company FindByBudget(int budget)
        {
            var tmp = head;
            while (tmp != null)
            {
                if (tmp.data.Budget == budget)
                    return tmp.data;
            }

            return null;
        }
        public Company FindByEmployees(int employees)
        {
            var tmp = head;
            while (tmp != null)
            {
                if (tmp.data.Employees == employees)
                    return tmp.data;
            }

            return null;
        }

        public void WriteToFile()
        {
            var writer = new StreamWriter("..\\..\\task1.txt", false, Encoding.UTF8);
            var tmp = head;
            while (tmp != null)
            {
                writer.WriteLine(tmp.data.ToString());
            }

            writer.Close();
        }

        public static Company Read()
        {
            var reader = new StreamReader("..\\..\\task1.txt");
            var arr = reader.ReadToEnd().Split('\n');
        }
        

    }
    
}