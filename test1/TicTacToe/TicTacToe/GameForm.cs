using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe;

public partial class GameForm : Form
{
    public GameForm()
    {
        InitializeComponent();
    }

    private void DisableAllButtons()
    {
        button1.Enabled = false;
        button2.Enabled = false;
        button3.Enabled = false;
        button4.Enabled = false;
        button5.Enabled = false;
        button6.Enabled = false;
        button7.Enabled = false;
        button8.Enabled = false;
        button9.Enabled = false;
    }

    private void OnButtonClick(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var numberOfButton = (int)Char.GetNumericValue(button.Name[^1]);

        try
        {
            switch (Game.MakeMove(numberOfButton))
            {
                case 1:
                    button.Text = "X";
                    break;
                case 2:
                    button.Text = "O";
                    break;
                case 3:
                    button.Text = "X";
                    display.Text = "Tie!";
                    DisableAllButtons();
                    break;
                case 4:
                    button.Text = "O";
                    display.Text = "Tie!";
                    DisableAllButtons();
                    break;
                case 5:
                    button.Text = "X";
                    display.Text = "X wins!";
                    DisableAllButtons();
                    break;
                case 6:
                    button.Text = "O";
                    display.Text = "O wins!";
                    DisableAllButtons();
                    break;
            }
        }
        catch (ArgumentException)
        {
        }
    }
}

