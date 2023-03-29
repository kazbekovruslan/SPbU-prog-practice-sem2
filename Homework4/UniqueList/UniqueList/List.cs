namespace Lists;

class List
{
    protected Node? head;

    public List()
    {
        this.head = null;
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
        head = new Node(value, head);
    }

    public void Remove(int value)
    {
        if (head == null)
        {
            throw new ArgumentNullException("List is empty!");
        }

        Node currentNode = head;
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
            head = currentNode.Next;
        }
        else
        {
            previousNode.Next = currentNode.Next;
        }
    }

    public virtual void ReplaceElementByIndex(int value, int index)
    {
        if (head == null)
        {
            throw new ArgumentNullException("List is empty!");
        }

        Node? currentNode = head;
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
        if (head == null)
        {
            throw new ArgumentNullException("List is empty!");
        }

        System.Console.Write("List: ");

        Node? currentNode = head;
        while (currentNode != null)
        {
            System.Console.Write($"{currentNode.Value} ");
            currentNode = currentNode.Next;
        }
        System.Console.WriteLine();
    }
}