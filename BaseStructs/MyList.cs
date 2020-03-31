using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseStructs
{
    public class MyList<T> : IEnumerable<T>
    {
        // Must have
        public Node<T> Head { get; private set; }

        // Additional
        public Node<T> Tail { get; private set; }
        public int Count { get; private set; }

        public MyList()
        {
            Count = 0;
        }

        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (Head == null)
            {
                Head = node;
                Tail = node;
                Head.Next = Tail;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
            Count++;
        }

        public void Remove(T data)
        {
            Node<T> current = Head;
            Node<T> previous = null;

            if (Head.Data.Equals(data))
            {
                if (Count == 1)
                {
                    Head = null;
                    Count = 0;
                    return;
                }

                if (Count > 1)
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }
            }

            while(current != null)
            {
                if (current.Data.Equals(data))
                {
                    previous.Next = current.Next;

                    if (current.Next == null)
                    {
                        Tail = previous;
                    }
                    Count--;
                    return;
                }
                previous = current;
                current = previous.Next;
            }
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T data)
        {
            return false;
        }

        public void AppendFirst(T data)
        {

        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;

            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
