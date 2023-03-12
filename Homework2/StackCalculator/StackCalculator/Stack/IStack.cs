namespace StackCalculator;

/// <summary>
/// Last-in-first-out (LIFO) data structure. 
/// </summary>
public interface IStack
{
    /// <summary>
    /// Pushes element on top of the stack.
    /// </summary>
    /// <param name="value">Double number</param>
    public void Push(double value);

    /// <summary>
    /// Pops (deletes and returns) element from top of the stack.
    /// </summary>
    /// <returns>Popped element - the element at the top of the stack.</returns>
    /// <exception cref="InvalidOperationException">Thrown if try to pop from empty stack.</exception>
    public double Pop();

    /// <summary>
    /// Checks stack for being empty.
    /// </summary>
    /// <returns>true - if stack is empty, false - if stack isn't empty.</returns>
    public bool IsEmpty();
}