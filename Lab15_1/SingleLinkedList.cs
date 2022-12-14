using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Lab15_1
{
    public class Node<T>
    {
        public T data;
        public Node<T> next = null;
    }
    public class SingleLinkedList<T>:IEnumerable<T>
    {
        public Node<T> head;
        public Node<T> last;

        public SingleLinkedList()
        {
            
        }
        public SingleLinkedList(IEnumerable<T> arr)
        {
            Node<T> tmp = head;
            int count = 0;
            foreach (var elem in arr)
            {
                if (count == 0)
                {
                    head = new Node<T> {data = elem};
                    count++;
                    tmp = head;
                    continue;
                }

                tmp.next = new Node<T> {data=elem };
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

        public void FromArray(IEnumerable<T> arr)
        {
            Node<T> tmp = head;
            int count = 0;
            foreach (var elem in arr)
            {
                if (count == 0)
                {
                    head = new Node<T> {data = elem};
                    count++;
                    tmp = head;
                    continue;
                }

                tmp.next = new Node<T> {data=elem };
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
        public void Show()
        {
            foreach (var elem in this)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine("-------------");
        }
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

        public void Clear() => head = null;
        public void AppendPos(T value, int position)
        {
            if (position == 0)
            {
                var currentFirst = this.head;
                this.head = new Node<T> {data = value};
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
                    var node = new Node<T> {data = value};
                    node.next = next;
                    tmp.next = node;
                }
                tmp = tmp.next;
                count++;
            }
        }
        public void Append(T value)
        {
            var node = new Node<T>{data = value};
            if (head != null)
            {
                last.next = node;
                last = node;
            }
            else
            {   
                head = new Node<T> { data = value };
                last = head;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
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

        public void ReplaceByInd(int ind, T value)
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
        
        public void DeleteByInd(int id)
        {
            if (id == 0)
            {
                this.head = this.head.next;
                return;
            }
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
                SetLast();
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
        public void DeleteAllByValue(T value)
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
            string path = "..\\..\\task1.txt";
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