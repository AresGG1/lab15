using System;
using System.Collections;
using System.Collections.Generic;

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
    }
}