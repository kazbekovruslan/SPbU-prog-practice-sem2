namespace secondtask;

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

    public bool IsEmpty
        => head == null;
}

public static class BracketBalance
{
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
