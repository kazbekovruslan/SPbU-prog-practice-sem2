namespace StackCalculator;

/// <summary>
/// Calculator for postfix form expressions based on stack.
/// </summary>
public class StackCalculator
{
    private readonly IStack stack;

    public StackCalculator(IStack stack)
    {
        if (stack == null)
        {
            throw new ArgumentNullException("Stack can't be null!");
        }
        this.stack = stack;
    }

    /// <summary>
    /// Checks if double number
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    private static bool IsZero(double number)
        => Math.Abs(number) < 0.00001;

    /// <summary>
    /// Calculates expression with 2 numbers and 1 operator.
    /// </summary>
    /// <param name="stack"></param>
    /// <param name="firstElement">First element of the action.</param>
    /// <param name="secondElement">Second element of the action.</param>
    /// <param name="operation">One of the four types of operation.</param>
    private void PerformOperation(IStack stack, double firstElement, double secondElement, string operation)
    {
        switch (operation)
        {
            case "+":
                stack.Push(firstElement + secondElement);
                break;
            case "-":
                stack.Push(firstElement - secondElement);
                break;
            case "*":
                stack.Push(firstElement * secondElement);
                break;
            case "/":
                if (!IsZero(secondElement))
                {
                    stack.Push(firstElement / secondElement);
                }
                else
                {
                    throw new ArgumentException("Wrong expression: division by zero!");
                }
                break;
        }
    }

    /// <summary>
    /// Evaluates expression in postfix form.
    /// </summary>
    /// <param name="expression">Expression in postfix form.</param>
    /// <returns>Answer of evaluating of the expression in postfix form.</returns>
    public double EvaluateExpression(string expression)
    {
        if (expression == null)
        {
            throw new InvalidDataException("Expression can't be null!");
        }

        if (expression == string.Empty)
        {
            throw new InvalidDataException("Expression can't be empty!");
        }

        var expressionElementsArray = expression.Split();

        foreach (var expressionElement in expressionElementsArray)
        {
            if (expressionElement == "+" ||
                expressionElement == "-" ||
                expressionElement == "*" ||
                expressionElement == "/")
            {
                double secondElement = 0;
                double firstElement = 0;
                try
                {
                    secondElement = stack.Pop();
                    firstElement = stack.Pop();
                }
                catch
                {
                    throw new ArgumentException("Wrong expression: missing numbers!");
                }

                PerformOperation(stack, firstElement, secondElement, expressionElement);
            }
            else
            {
                if (int.TryParse(expressionElement, out int value))
                {
                    stack.Push(value);
                }
                else
                {
                    throw new ArgumentException("Wrong expression: there are not only numbers and operators!");
                }
            }
        }

        double answer = 0;
        try
        {
            answer = stack.Pop();
        }
        catch
        {
            throw new ArgumentException("Wrong expression: missing numbers!");
        }

        if (!stack.IsEmpty())
        {
            throw new ArgumentException("Wrong expression: too many numbers!");
        }

        return answer;
    }
}