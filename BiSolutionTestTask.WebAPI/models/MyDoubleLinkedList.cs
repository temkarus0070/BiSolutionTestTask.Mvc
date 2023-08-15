using BiSolutionTestTask.WebAPI.models;
using System.Collections;
using System.Text;

namespace BiSolutionTestTask.WebAPI.models
{
    public class MyDoubleLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {


        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(this);
        }
        public ListEntry<T>? Head { get; set; }
        public ListEntry<T>? Tail { get; set; }
        public void Add(T element)
        {
            if (Head == null)
            {
                Head = new ListEntry<T>() { Value = element };
                Tail = Head;
            }
            else
            {
                Tail.Next = new ListEntry<T>() { Value = element, Previous = Tail };
                Tail = Tail.Next;
            }
        }


        public void Sort()
        {

            var currentMin = Head.Value;
            var currentMinElement = Head;
            var currentElement = Head;
            while (currentElement.Next != null)
            {
                currentMin = currentElement.Value;
                var nextElement = currentElement.Next;
                while (nextElement != null)
                {

                    if (nextElement != null && nextElement.Value.CompareTo(currentMin) < 0)
                    {
                        currentMin = nextElement.Value;
                        currentMinElement = nextElement;
                    }
                    nextElement = nextElement.Next;
                }
                if (!currentElement.Value.Equals(currentMin))
                {

                    currentMinElement.Value = currentElement.Value;
                    currentElement.Value = currentMin;
                }
                currentElement = currentElement.Next;

            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            var element = Head;
            while (element is not null)
            {
                str.Append(element.Value.ToString() + " ");
                element = element.Next;
            }
            return str.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator<T>(this);
        }
    }
}


class MyEnumerator<T> : IEnumerator<T> where T : IComparable<T>
{
    private MyDoubleLinkedList<T> _list;
    public MyDoubleLinkedList<T> List
    {
        get { return _list; }
        set
        {
            _list = value;
        }
    }

    private ListEntry<T>? current;

    public MyEnumerator(MyDoubleLinkedList<T> list)
    {
        List = list;
    }

    public T Current => current.Value;

    object IEnumerator.Current => current.Value;

    public void Dispose()
    {

    }

    public bool MoveNext()
    {
        if (current == null && List.Head is not null)
        {
            current = List.Head;
            return true;
        }
        else
       if (current != null && current.Next != null)
        {
            current = current.Next;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        current = List.Head;
    }
}
