namespace MatrixMemory;

using System.Collections.Generic;

public partial class MatrixForm : Form
{
    public MatrixForm()
    {
        InitializeComponent();

        game.MakeStart();
        foreach (var button in buttons)
        {
            if (game.MarkedSquares.Contains(button.TabIndex))
            {
                button.Text = "X";
            }
        }

        var timer = new System.Windows.Forms.Timer();
        timer.Interval = 5000;
        timer.Start();
        DisableAllButtons();
        timer.Tick += OnTimerTick!;
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
        var timer = (System.Windows.Forms.Timer)sender;
        timer.Stop();

        foreach (var button in buttons)
        {
            if (button.Text == "X")
            {
                button.Text = "";
            }
        }
        EnableAllButtons();
        label1.Text = "Mark all previously marked squares!";
    }

    private MatrixMemoryGame game = new();

    private HashSet<int> NumbersOfAlreadyPressedMarkedButtons = new HashSet<int>();

    private void OnButtonClick(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var numberOfButton = button.TabIndex;

        if (game.MarkedSquares.Contains(button.TabIndex))
        {
            button.Text = "X";
            NumbersOfAlreadyPressedMarkedButtons.Add(numberOfButton);
            if (NumbersOfAlreadyPressedMarkedButtons.SetEquals(game.MarkedSquares))
            {
                DisableAllButtons();
                label1.Text = "You have won!";
            }
        }
        else
        {
            DisableAllButtons();
            label1.Text = "You have lost!";
        }
    }

    private void EnableAllButtons()
    {
        foreach (var button in buttons)
        {
            button.Enabled = true;
        }
    }

    private void DisableAllButtons()
    {
        foreach (var button in buttons)
        {
            button.Enabled = false;
        }
    }
}