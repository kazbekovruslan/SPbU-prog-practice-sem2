namespace Lists;

public class UniqueList : List
{
    private bool Contains(int value)
    {
        if (head == null)
        {
            return false;
        }

        Node? currentNode = head;
        while (currentNode != null)
        {
            if (currentNode.Value == value)
            {
                return true;
            }
            currentNode = currentNode.Next;
        }

        return false;
    }

    public override void Add(int value)
    {
        if (Contains(value))
        {
            throw new ElementAlreadyExistsException("This element already exists!");
        }

        head = new Node(value, head);
    }

    public override void ReplaceElementByIndex(int value, int index)
    {
        if (head == null)
        {
            throw new ArgumentNullException("List is empty!");
        }

        if (Contains(value))
        {
            throw new ElementAlreadyExistsException("This element already exists!");
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
}