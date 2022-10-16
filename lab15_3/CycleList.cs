using System;
using System.CodeDom;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace lab15_3
{
    public class Node<T>
    {
        public T data;
        public Node<T> next;
        public Node<T> perv;
    }
    
    public class CycleList<T>
    {
        public Node<T> head;
        public CycleList()
        {
            this.head = null;
        }

        public void Append(T value)
        {
            if (this.head == null)
            {
                this.head = new Node<T> {data = value};
                return;
            }

            if (this.head.next == null)
            {
                this.head.next = new Node<T> {data = value};
                this.head.perv = this.head.next;
                this.head.next.next = this.head;
                this.head.next.perv = this.head;
                return;
            }

            var tmp = this.head;
            while (tmp.next != this.head)
                tmp = tmp.next;
            tmp.next = new Node<T> {data = value};
            tmp.next.perv = tmp;
            tmp.next.next = this.head;
            this.head.perv = tmp.next;
        }

        public int Count()
        {
            var tmp = this.head;
            int count = 0;
            while (tmp.next != head)
            {
                tmp = tmp.next;
                count++;
            }

            return count + 1;
        }

        public T Pop(int index)
        {
            T res;
            
            if (index == 0)
            {
                res = this.head.data;
                var last = this.head.perv;
                this.head = this.head.next;
                this.head.perv = last;
                return res;
            }

            if (index >= this.Count())
                throw new Exception("Incorect index");
            int count = 0;
            var tmp = this.head;
            while (count != index)
            {
                tmp = tmp.next;
                count++;
            }

            res = tmp.data;
            var newPrev = tmp.perv;
            var newNext = tmp.next;
            newPrev.next = newNext;
            newNext.perv = newPrev;
            return res;
        }
    }
}