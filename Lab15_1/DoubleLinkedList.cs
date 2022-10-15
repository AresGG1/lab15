using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Lab15_1
{
    
    public class DoubleNode<T>
    {
        public T data;
        public DoubleNode<T> next = null;
        public DoubleNode<T> prev = null;
    }
    
    public class DoubleLinkedList<T>:IEnumerable<T>
    {
        public DoubleNode<T> head;
        public DoubleNode<T> last;

        public DoubleLinkedList()
        {
            
        }
        public DoubleLinkedList(IEnumerable<T> arr)
        {
            DoubleNode<T> tmp = head;
            int count = 0;
            foreach (var elem in arr)
            {
                if (count == 0)
                {
                    head = new DoubleNode<T> {data = elem};
                    count++;
                    tmp = head;
                    continue;
                }

                tmp.next = new DoubleNode<T> {data=elem };
                tmp.next.prev = tmp;
                tmp = tmp.next;
                count++;
            }
            SetLast();
        }
        public int Count()
        {
            var tmp = head;
            int count = 0;
            while (tmp != null)
            {
                count++;
                tmp = tmp.next;
            }
            
            return count;
        }
        
        public void Sort()
        {
            var arr = new List<T>(this.ToArray());
            arr.Sort();
            FromArray(arr);
            SetLast();
        }
        
        public void FromArray(IEnumerable<T> arr)
        {
            DoubleNode<T> tmp = head;
            int count = 0;
            foreach (var elem in arr)
            {
                if (count == 0)
                {
                    head = new DoubleNode<T> {data = elem};
                    count++;
                    tmp = head;
                    continue;
                }

                tmp.next = new DoubleNode<T> {data=elem };
                tmp.next.prev = tmp;
                tmp = tmp.next;
                count++;
            }
            SetLast();
        }
        
        private T[] ToArray()
        {
            var arr = new T[this.Count()];
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
        
        public void DeleteByInd(int id)
        {
            if (id == 0)
            {
                this.head = this.head.next;
                this.head.prev = null;
                this.head.next.prev = this.head;
                return;
            }
            int count = 0;
            var tmp = this.head;
            while (tmp != null)
            {
                if (count == id - 1)
                {
                    var prev = tmp;
                    tmp.next = tmp.next.next;
                    if(tmp.next != null)
                        tmp.next.prev = tmp;
                    SetLast();
                    break;
                }
                tmp = tmp.next;
                count++;
            }
            
        }
        public void Append(T value)
        {
            var node = new DoubleNode<T>{data = value};
            if (head != null)
            {
                last.next = node;
                node.prev = last;
                last = node;
            }
            else
            {   
                head = new DoubleNode<T> { data = value };
                last = head;
            }
        }
        public void AppendPos(T value, int position)
        {
            if (position == 0)
            {
                var currentFirst = this.head;
                this.head = new DoubleNode<T> {data = value};
                currentFirst.prev = head;
                this.head.next = currentFirst;
                return;
            }
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
                    var node = new DoubleNode<T> {data = value};
                    node.next = next;
                    node.prev = tmp;
                    tmp.next = node;
                }
                tmp = tmp.next;
                count++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            DoubleNode<T> current = head;
            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public void Show()
        {
            foreach (var elem in this)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine("-------------");
        }
        public T this[int index]
        {
            get
            {
                int count = 0;
                var tmp = head;
                while (tmp != null)
                {
                    if (count == index)
                        return tmp.data;
                    count++;
                    tmp = tmp.next;
                }

                throw new Exception("Index out of bounds !");
            }
            set
            {
                int count = 0;
                var tmp = head;
                while (tmp != null)
                {
                    if (count == index)
                    {
                        tmp.data = value;
                        return;
                    }
                    count++;
                    tmp = tmp.next;
                }
                throw new Exception("Index out of bounds !");
            }
        }
        public void Clear() => head = null;
        public bool IsInList(T elem)
        {
            var tmp = this.head;
            while (tmp != null)
            {
                if (EqualityComparer<T>.Default.Equals(tmp.data, elem))
                    return true;
                tmp = tmp.next;
            }

            return false;
        }
        public void ReplaceAll(T oldValue,T value)
        {
            var tmp = head;
            while (tmp != null)
            {
                if (EqualityComparer<T>.Default.Equals(tmp.data , oldValue))
                    tmp.data = value;
                
                tmp = tmp.next;
            }
        }
        public void DeleteByValue(T value)
        {
            int count = 0;
            var tmp = this.head;
            while (tmp != null)
            {
                if (EqualityComparer<T>.Default.Equals(tmp.data , value))
                {
                    DeleteByInd(count);
                    return;
                }
                count++;
                tmp = tmp.next;
                SetLast();
            }
        }
        public void DeleteByAllValue(T value)
        {
            int count = 0;
            var tmp = this.head;
            while (tmp != null)
            {
                if (EqualityComparer<T>.Default.Equals(tmp.data , value))
                {
                    DeleteByInd(count);
                    count = 0;
                    tmp = head;
                    continue;
                }
                count++;
                tmp = tmp.next;
                SetLast();
            }
        }
        public void Write()
        {
            string path = "..\\..\\task1_2.txt";
            StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8);
            string st = "";
            foreach (var elem in this)
            {
                st += elem.ToString();
                st += "\n";
            }
            writer.Write(st);
            writer.Close();
            Console.WriteLine("Write success");
        }
    }
}