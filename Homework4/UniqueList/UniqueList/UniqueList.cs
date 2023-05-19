namespace Lists;

/// <summary>
/// Class that represents Unique List data structure.
/// </summary>
public class UniqueList : List
{
    private bool Contains(int value)
    {
        Node? currentNode = Head;
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

    /// <inheritdoc/>
    /// <exception cref="ElementAlreadyExistsException"></exception>
    public override void Add(int value)
    {
        if (Contains(value))
        {
            throw new ElementAlreadyExistsException("This element already exists!");
        }

        Head = new Node(value, Head);
    }

    /// <inheritdoc/>
    public override void ReplaceElementByIndex(int value, int index)
    {
        if (Head == null)
        {
            throw new ArgumentNullException("List is empty!");
        }

        if (Contains(value))
        {
            throw new ElementAlreadyExistsException("This element already exists!");
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
}