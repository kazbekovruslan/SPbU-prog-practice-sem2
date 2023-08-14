namespace secondtask;

/// <summary>
/// Class that represents data structure Stack.
/// </summary>
public class Stack
{
    private class Node
    {
        public char Value { get; }
        public Node? Next { get; }

        public Node(char value, Node? next)
        {
            Value = value;
            Next = next;
        }
    }

    private Node? head;

    /// <summary>
    /// Pushes element on the top of the stack.
    /// </summary>
    /// <param name="value">Value of the element.</param>
    public void Push(char value)
    {
        if (head == null)
        {
            head = new Node(value, null);
        }
        else
        {
            head = new Node(value, head);
        }
    }

    /// <summary>
    /// Pops element from the top of the stack.
    /// </summary>
    /// <returns>Popped element.</returns>
    public char Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Can't pop from empty stack!");
        }
        var poppedElement = head.Value;
        head = head.Next;
        return poppedElement;
    }

    /// <summary>
    /// Checks if stack doesn't have any elements.
    /// </summary>
    public bool IsEmpty
        => head == null;
}

/// <summary>
/// Class for bracket balancing.
/// </summary>
public static class BracketBalance
{
    /// <summary>
    /// Checks if given expression is balanced for brackets.
    /// </summary>
    /// <param name="expression">Input bracket expression.</param>
    /// <returns>true - if balanced, false - if not balanced.</returns>
    public static bool IsBalanced(string expression)
    {
        var stack = new Stack();

        foreach (var symbol in expression)
        {
            if (symbol == '(' || symbol == '[' || symbol == '{')
            {
                stack.Push(symbol);
            }
            else if (symbol == ')' || symbol == ']' || symbol == '}')
            {
                if (stack.IsEmpty)
                {
                    return false;
                }
                var openingBracket = stack.Pop();
                var closingBracket = symbol;
                if (!((openingBracket == '(' && closingBracket == ')') ||
                      (openingBracket == '{' && closingBracket == '}') ||
                      (openingBracket == '[' && closingBracket == ']')))
                {
                    return false;
                }
            }
        }
        return stack.IsEmpty;
    }
}
