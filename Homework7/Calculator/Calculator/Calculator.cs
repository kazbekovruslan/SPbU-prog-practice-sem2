namespace Calculator;

using System.ComponentModel;

internal class Calculator : INotifyPropertyChanged
{
    private string display = "0";

    private const string ErrorMessage = "Error!";

    public string Display
    {
        get => this.display;

        private set
        {
            display = value;

            NotifyPropertyChanged();
        }
    }

    private double resultOfCalculating = 0;
    private double temporaryResult = 0;

    private string currentOperation = " ";
    private string[] operations = new string[] { "+", "-", "×", "÷", "+/-" };

    private enum States
    {
        IsOperand,
        IsOperation
    }

    private States currentState = States.IsOperand;

    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged(string propertyName = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public void AddDigit(char inputDigit)
    {
        if (!char.IsDigit(inputDigit))
        {
            Display = ErrorMessage;
        }

        switch (currentState)
        {
            case (States.IsOperand):
                if (Display.Equals("0") || Display.Equals(ErrorMessage)) // один или несколько errormessag-ей?
                {
                    Display = inputDigit.ToString();
                    resultOfCalculating = double.Parse(Display);
                }
                else
                {
                    Display += inputDigit;
                    resultOfCalculating = double.Parse(Display);
                }

                currentState = States.IsOperand;
                break;
            case (States.IsOperation):
                temporaryResult = resultOfCalculating;
                resultOfCalculating = double.Parse(inputDigit.ToString());
                Display = inputDigit.ToString();
                currentState = States.IsOperand;

                break;
        }
    }

    public void AddOperation(string operation)
    {
        if (!operations.Contains(operation))
        {
            Display = ErrorMessage;
        }

        switch (currentState)
        {
            case States.IsOperand:
                if (operation == "+/-")
                {
                    currentOperation = "+/-";
                    resultOfCalculating = Math.Round(Evaluate(), 3);
                    Display = resultOfCalculating.ToString();
                    currentOperation = " ";
                    return;
                }
                if (currentOperation == " ")
                {
                    currentOperation = operation;
                    currentState = States.IsOperation;
                    temporaryResult = resultOfCalculating;
                }
                else
                {
                    try
                    {
                        resultOfCalculating = Math.Round(Evaluate(), 3);
                        Display = resultOfCalculating.ToString();
                    }
                    catch (Exception ex) when (ex is DivideByZeroException ||
                                               ex is ArgumentException)
                    {
                        Clear();
                        // Display = ex.Message;
                        Display = ErrorMessage;
                        return;
                    }

                    temporaryResult = resultOfCalculating;
                    currentOperation = operation;
                    currentState = States.IsOperand;
                }
                break;

            case States.IsOperation:
                currentOperation = operation;
                break;
        }
    }

    private double Evaluate()
        => currentOperation switch
        {
            "+/-" => resultOfCalculating == 0 ? 0 : -resultOfCalculating,
            "+" => temporaryResult + resultOfCalculating,
            "-" => temporaryResult - resultOfCalculating,
            "×" => temporaryResult * resultOfCalculating,
            "÷" => IsDoubleNumberEqualsToZero(temporaryResult)
                    ? throw new DivideByZeroException("Division by zero is prohibited!")
                    : temporaryResult / resultOfCalculating,
            _ => throw new ArgumentException("Unknown operation!")
        };

    private bool IsDoubleNumberEqualsToZero(double number)
    {
        double delta = 0.001;
        return Math.Abs(number) < delta;
    }

    // public void ChangeSign()
    // {
    //     if (!Display.Equals("0") && !Display.Equals(ErrorMessage))
    //     {
    //         if (Display[0] == '-')
    //         {
    //             Display = Display.Substring(1);
    //         }
    //         else
    //         {
    //             Display = "-" + Display;
    //         }
    //     }
    // }

    public void Calculate()
    {
        switch (currentState)
        {
            case States.IsOperand:
                if (currentOperation != " ")
                {
                    try
                    {
                        resultOfCalculating = Evaluate();
                        Display = resultOfCalculating.ToString();
                    }
                    catch (Exception ex) when (ex is DivideByZeroException ||
                                               ex is ArgumentException)
                    {
                        Clear();
                        // Display = ex.Message;
                        Display = ErrorMessage;
                        return;
                    }

                    currentOperation = " ";
                    currentState = States.IsOperand;
                }
                break;
            case States.IsOperation:
                try
                {
                    resultOfCalculating = Evaluate();
                    Display = resultOfCalculating.ToString();
                }
                catch (Exception ex) when (ex is DivideByZeroException ||
                                               ex is ArgumentException)
                {
                    Clear();
                    // Display = ex.Message;
                    Display = ErrorMessage;
                    return;
                }
                break;
        }
    }

    public void Clear()
    {
        currentState = States.IsOperand;
        Display = "0";
        resultOfCalculating = 0;
        temporaryResult = 0;
    }

}