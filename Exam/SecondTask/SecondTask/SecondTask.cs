namespace secondtask;

public class LinkedListStack
{
    private LinkedList<char> list;

    public LinkedListStack()
    {
        list = new LinkedList<char>();
    }

    public void Push(char value)
    {
        list.AddLast(value);
    }

    public char Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Can't pop from empty stack!");
        }
        var poppedElement = list.Last();
        list.RemoveLast();
        return poppedElement;
    }

    public bool IsEmpty
        => list.First == null;
}

public static class BracketBalance
{
    public static bool IsBalanced(string expression)
    {
        var stack = new LinkedListStack();

        foreach (var symbol in expression)
        {
            if (symbol == '(' || symbol == '[' || symbol == '{')
            {
                stack.Push(symbol);
            }
            else if (symbol == ')' || symbol == ']' || symbol == '}')
            {
                var openingBracket = stack.Pop();
                var closingBracket = symbol;
                if (stack.IsEmpty ||
                    !((openingBracket == '(' && closingBracket == ')') ||
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
