namespace Lists;

public class List
{
    protected Node? Head;

    public List()
    {
        this.Head = null;
    }

    protected class Node
    {
        public int Value;

        public Node? Next;

        public Node(int value, Node? next)
        {
            this.Value = value;
            this.Next = next;
        }
    }

    public virtual void Add(int value)
    {
        Head = new Node(value, Head);
    }

    public void Remove(int value)
    {
        if (Head == null)
        {
            throw new ArgumentNullException("List is empty!");
        }

        Node currentNode = Head;
        Node? previousNode = null;
        while (currentNode.Value != value && currentNode.Next != null)
        {
            previousNode = currentNode;
            currentNode = currentNode.Next;
        }

        if (currentNode.Value != value)
        {
            throw new ElementDoesntExistException("There is no such element in the list!");
        }

        if (previousNode == null)
        {
            Head = currentNode.Next;
        }
        else
        {
            previousNode.Next = currentNode.Next;
        }
    }

    public virtual void ReplaceElementByIndex(int value, int index)
    {
        if (Head == null)
        {
            throw new ArgumentNullException("List is empty!");
        }

        Node? currentNode = Head;
        var currentIndex = 0;

        while (currentIndex != index && currentNode != null)
        {
            currentNode = currentNode.Next;
            ++currentIndex;
        }
        if (currentNode == null)
        {
            throw new System.IndexOutOfRangeException("There is no element with such index in the list!");
        }
        currentNode.Value = value;
    }

    public void Print()
    {
        if (Head == null)
        {
            throw new ArgumentNullException("List is empty!");
        }

        System.Console.Write("List: ");

        Node? currentNode = Head;
        while (currentNode != null)
        {
            System.Console.Write($"{currentNode.Value} ");
            currentNode = currentNode.Next;
        }
        System.Console.WriteLine();
    }

    public bool IsEmpty()
    {
        return Head == null;
    }
}