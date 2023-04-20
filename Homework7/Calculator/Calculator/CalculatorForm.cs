using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        private Calculator calculator = new();

        public CalculatorForm()
        {
            InitializeComponent();

            var resultBinding = new Binding("Text", calculator, "Display", true, DataSourceUpdateMode.OnPropertyChanged);

            display.DataBindings.Add(resultBinding);
        }

        private void OnButtonNumberClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            calculator.AddDigit(char.Parse(button.Text));
        }

        private void OnButtonEqualClick(object sender, EventArgs e)
            => calculator.Calculate();

        private void OnButtonClearClick(object sender, EventArgs e)
            => calculator.Clear();

        private void OnButtonOperationClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            calculator.AddOperation(button.Text);
        }

        // private void OnButtonSignClick(object sender, EventArgs e)
        // {
        //     calculator.ChangeSign();
        // }
    }
}
