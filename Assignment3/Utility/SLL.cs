using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    public class SLL<T> : ILinkedListADT<T>
    {
        public Node<User> head;
        public Node<User> tail;
        private int count;

        public class CannotRemoveException : Exception
        {
            public CannotRemoveException() : base("The list is currently empty") { } 
        }

        public void Prepend(User value)
        {
            Node<User> newNode = new Node<User>(value);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
            count++;
        }

        public void Append(User value)
        {
            Node<User> newNode = new Node<User>(value);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new CannotRemoveException();
            }

            if (index == 0)
            {
                RemoveFirst();
            }
            else 
            {
                Node<User> previous = null;
                Node<User> current = head;

                for (int i = 0; i < index; i++)
                {
                    previous = current;
                    current = current.Next;
                }
                previous.Next = current.Next;
                
                if (current == tail)
                {
                    tail = previous;
                }
                
                count--;              
            }
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                throw new CannotRemoveException();
            }

            head = head.Next;
            if (head == null)
            {
                tail = null;
            }
            count--;
        }

        public void RemoveLast()
        {
            if (tail == null)
            {
                throw new CannotRemoveException();
            }

            if (head == tail)
            {
                RemoveFirst();
            }

            else
            {
                Node<User> current = head;

                while (current.Next.Next != null)
                {
                    current = current.Next;                
                }

                current.Next = null;
                tail = current;
            }
            count--;
        }

        public void Add(User value, int index)
        {
            if (index <= 0)
            {
                Prepend(value);
            }

            else if (index >= count) 
            {
                Append(value);
            }
            
            else
            {
                Node<User> newNode = new Node<User>(value);
                Node<User> previous = null;
                Node<User> current = head;

                for (int i = 0; i < index; i++)
                {
                    previous = current;
                    current = current.Next;
                }

                previous.Next = newNode;
                newNode.Next = current;
                count++;
            }
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            if (head == null || tail == null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            Node<User> current = head;
            for (int i = 0;i < index; i++)
            {
                current = current.Next;
            }
            current.Data = value;
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            Node<User> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public int IndexOf(User value)
        {
            if (head == null || tail == null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            Node<User> current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data == value)
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            throw new KeyNotFoundException("Could not find that item. Check spelling and try again.");
        }

        public bool Contains(User value)
        {
            if (head == null || tail == null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            Node<User> current = head;
            while (current != null)
            {
                if (current.Data == value)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
            Console.WriteLine("The list has been cleared");
        }

        public int Count()
        {
            int index = 0;
            Node<User> current = head;

            while (current != null)
            {
                current = current.Next;
                ++index;
            }
            return index;
        }

        public bool IsEmpty()
        {
            if (head == null && tail == null)
            {
                return true; 
            }
            return false;
        }

        public void Reverse()
        {
            Node<User> previous = null;
            Node<User> next = null;
            Node<User> current = head;

            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            tail = head;
            head = previous;
        }
    }
}
