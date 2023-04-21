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

        /// <summary>
        /// Initiziales compnonents in the form and adds bindings to the displays.
        /// </summary>
        public CalculatorForm()
        {
            InitializeComponent();

            display.DataBindings.Add("Text", calculator, "Display", true, DataSourceUpdateMode.OnPropertyChanged);
            historyDisplay.DataBindings.Add("Text", calculator, "HistoryDisplay", true, DataSourceUpdateMode.OnPropertyChanged);
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
    }
}
