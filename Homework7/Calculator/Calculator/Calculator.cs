namespace Calculator;

using System.ComponentModel;

/// <summary>
/// Class that represents functional of the calculator.
/// </summary>
internal class Calculator : INotifyPropertyChanged
{
    private const string ErrorMessage = "Error!";

    private string display = "0";
    private string historyDisplay = "";

    /// <summary>
    /// Property for displaying data on the display.
    /// </summary>
    /// <value></value>
    public string Display
    {
        get => this.display;

        private set
        {
            display = value;

            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Property for displaying data on the history display.
    /// </summary>
    /// <value></value>
    public string HistoryDisplay
    {
        get => this.historyDisplay;

        private set
        {
            historyDisplay = value;

            OnPropertyChanged();
        }
    }

    private void OnPropertyChanged(string propertyName = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private bool IsNeedToClearHistoryDisplay = false;
    private bool IsOperationFinished = false;


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

    /// <summary>
    /// Event that works for binding controls and properties.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Adds digit to the number in the calculator.
    /// </summary>
    /// <param name="inputDigit">Added digit.</param>
    public void AddDigit(char inputDigit)
    {
        if (!char.IsDigit(inputDigit))
        {
            Display = ErrorMessage;
        }

        ClearHistoryDisplay();

        switch (currentState)
        {
            case States.IsOperand:
                if (IsOperationFinished)
                {
                    Clear();
                }
                if (!Display.Equals(ErrorMessage))
                {
                    resultOfCalculating = Math.Sign(resultOfCalculating) >= 0
                        ? resultOfCalculating * 10 + Char.GetNumericValue(inputDigit)
                        : resultOfCalculating * 10 - Char.GetNumericValue(inputDigit);
                    Display = resultOfCalculating.ToString();
                    currentState = States.IsOperand;
                    IsOperationFinished = false;
                }
                break;
            case States.IsOperation:
                temporaryResult = resultOfCalculating;
                resultOfCalculating = char.GetNumericValue(inputDigit);
                Display = inputDigit.ToString();
                currentState = States.IsOperand;
                break;
        }
    }

    /// <summary>
    /// Add operation to the calculator.
    /// </summary>
    /// <param name="operation"></param>
    public void AddOperation(string operation)
    {
        if (!operations.Contains(operation))
        {
            Display = ErrorMessage;
        }

        ClearHistoryDisplay();

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
                    HistoryDisplay += temporaryResult + " " + operation;
                }
                else
                {
                    try
                    {
                        CalculateAndPrint();
                    }
                    catch (Exception ex) when (ex is DivideByZeroException ||
                                               ex is ArgumentException)
                    {
                        Clear();
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
                HistoryDisplay = temporaryResult + " " + operation;
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
            "÷" => IsDoubleNumberEqualsToZero(resultOfCalculating)
                    ? throw new DivideByZeroException("Division by zero is prohibited!")
                    : temporaryResult / resultOfCalculating,
            _ => throw new ArgumentException("Unknown operation!")
        };

    private bool IsDoubleNumberEqualsToZero(double number)
    {
        double delta = 0.001;
        return Math.Abs(number) < delta;
    }

    /// <summary>
    /// Calculates result number in the calculator.
    /// </summary>
    public void Calculate()
    {
        switch (currentState)
        {
            case States.IsOperand:
                if (currentOperation != " ")
                {
                    try
                    {
                        CalculateAndPrint();
                    }
                    catch (Exception ex) when (ex is DivideByZeroException ||
                                               ex is ArgumentException)
                    {
                        Clear();
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
                    CalculateAndPrint();
                }
                catch (Exception ex) when (ex is DivideByZeroException ||
                                           ex is ArgumentException)
                {
                    Clear();
                    Display = ErrorMessage;
                    return;
                }
                break;
        }
    }

    private void CalculateAndPrint()
    {
        HistoryDisplay += " " + resultOfCalculating + " =";
        IsNeedToClearHistoryDisplay = true;
        resultOfCalculating = Math.Round(Evaluate(), 3);
        if (resultOfCalculating == -0)
        {
            resultOfCalculating = 0;
        }
        Display = resultOfCalculating.ToString();
        IsOperationFinished = true;
    }

    private void ClearHistoryDisplay()
    {
        if (IsNeedToClearHistoryDisplay)
        {
            HistoryDisplay = "";
            IsNeedToClearHistoryDisplay = false;
        }
    }

    /// <summary>
    /// Clears all data in the calculator.
    /// </summary>
    public void Clear()
    {
        currentState = States.IsOperand;
        Display = "0";
        HistoryDisplay = "";
        resultOfCalculating = 0;
        temporaryResult = 0;
    }
}