using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class list
    {
        public element head;
        public element tail;
        public int count;
        public list()
        {
            count = 0;
            head = tail = null;            
        }
        public void prepend(element e)
        {
            e.Next = head;
            head = e;
            count++;
            if (tail == null) tail = head;
        }
        public void append(element e)
        {
            e.Next = null;
            if (head == null)
            {
                head = e;
                tail = e;
            }
            else
            {
                tail.Next = e;
                tail = e;
            }
            count++;
        }

        public element FindAtIndex(int index)
        {
            if (index < 0 || index >= count)
                return null;
            element e = head;
            for (int i = 1; i <= index; i++)
                e = e.Next;
            return e;
        }

        public int FindAtElement(element e)
        {
            element x = head;
            int z = -1;
            for (int i = 0; i < count; i++)
            {
                if (e.num == x.num)
                {
                    z = i;
                    break;
                }
                x = x.Next;
            }
            return z;
        }
        public bool DeleteAtIndex(int index)
        {
            if (index < 0 || index >= count)
                return false;
            if (index == 0)
                head = head.Next;
            else
                FindAtIndex(index - 1).Next = FindAtIndex(index + 1);
            count--;
            if (count == 0) head = tail = null;
            if (count == 1) tail = head;
            return true;
        }
        public bool DeleteElement(element e)
        {
            if (e.num == head.num)
            {
                head = head.Next;
                count--;
                return true;
            }
            element prev = null, current = head;
            while (current != null && e.num != current.num)
            {
                prev = current;
                current = current.Next;
            }
            if (current == null)
                return false;
            if (current.num == tail.num)
            {
                prev.Next = null;
                tail = prev;
                count--;
                return true;
            }
            count--;
            prev.Next = current.Next;
            return true;
        }
        public void InsertOrder(element e)
        {
            e.Next = null;
            if (count == 0)
            {
                head = tail = e;
                count++;
                return;
            }
            if (count == 1)
            {
                if (e.num > head.num)
                {
                    head.Next = e;
                    tail = e;
                }
                else
                {
                    e.Next = tail;
                    head = e;
                }
                count++;
                return;
            }
            element prev = null, current = head;
            while (current != null && e.num > current.num)
            {
                prev = current;
                current = current.Next;
            }
            if (current == null)
            {
                tail.Next = e;
                tail = e;
                count++;
                return;
            }
            prev.Next = e;
            if(e.Next!=null)
            e.Next = current;
            count++;
            return;
        }

        public void Reverse()
        {
            if (count == 0 || count == 1)
                return;
            int c = count;
            element tmp = head, t = head;
            bool move = true;
            while (move)
            {
                for (int i = 1; i < c; i++)
                    tmp = tmp.Next;
                t = head;
                head = head.Next;
                t.Next = null;
                t.Next = tmp.Next;
                if (tmp.Next == null)
                    tail = t;
                tmp.Next = t;
                tmp = head;
                c--;
                if (c == 1)
                    move = false;
            }
            return;
        }
        public bool DeleteAll(int k)
        {
            element prev = null, current = head;
            bool ret = false;
            while (current != null)
            {

                if (head.num == k)
                {
                    head = head.Next;
                    count--;
                    if (count == 0)
                        head = tail = null;
                    if (count == 1)
                        tail = head;
                    ret = true;
                }
                else
                {
                    if (current.num == k)
                    {
                        prev.Next = current.Next;
                        if (k == tail.num)
                            tail = prev;
                        count--;
                        ret = true;
                    }
                }
                prev = current;
                current = current.Next;
            }
            return ret;
        }
    }
}
