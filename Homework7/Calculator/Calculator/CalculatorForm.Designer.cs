namespace Calculator
{
    partial class CalculatorForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculatorForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.display = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.buttonEqual = new System.Windows.Forms.Button();
            this.buttonAddition = new System.Windows.Forms.Button();
            this.buttonSubtraction = new System.Windows.Forms.Button();
            this.buttonMultiplication = new System.Windows.Forms.Button();
            this.buttonDivision = new System.Windows.Forms.Button();
            this.buttonSign = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.historyDisplay = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.display, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button5, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button6, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.button7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button8, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button0, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonEqual, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddition, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonSubtraction, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonMultiplication, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonDivision, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSign, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonClear, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.historyDisplay, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(382, 453);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // display
            // 
            this.display.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.display, 4);
            this.display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.display.Location = new System.Drawing.Point(3, 0);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(376, 75);
            this.display.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.display.TabIndex = 0;
            this.display.TextAlign = ContentAlignment.BottomRight;
            // this.display.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // historyDisplay
            // 
            this.historyDisplay.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.historyDisplay, 4);
            this.historyDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyDisplay.Location = new System.Drawing.Point(3, 0);
            this.historyDisplay.Name = "historyDisplay";
            this.historyDisplay.Size = new System.Drawing.Size(376, 44);
            this.historyDisplay.TabIndex = 18;
            this.historyDisplay.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.historyDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyDisplay.TextAlign = ContentAlignment.BottomRight;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 69);
            this.button1.TabIndex = 1;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnButtonNumberClick);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(98, 303);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 69);
            this.button2.TabIndex = 2;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnButtonNumberClick);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(193, 303);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 69);
            this.button3.TabIndex = 3;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnButtonNumberClick);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(3, 228);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 69);
            this.button4.TabIndex = 4;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.OnButtonNumberClick);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(98, 228);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 69);
            this.button5.TabIndex = 5;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OnButtonNumberClick);
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Location = new System.Drawing.Point(193, 228);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(89, 69);
            this.button6.TabIndex = 6;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.OnButtonNumberClick);
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Location = new System.Drawing.Point(3, 153);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(89, 69);
            this.button7.TabIndex = 7;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.OnButtonNumberClick);
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Location = new System.Drawing.Point(98, 153);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(89, 69);
            this.button8.TabIndex = 8;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.OnButtonNumberClick);
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.Location = new System.Drawing.Point(193, 153);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(89, 69);
            this.button9.TabIndex = 9;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.OnButtonNumberClick);
            // 
            // button0
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button0, 3);
            this.button0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button0.Location = new System.Drawing.Point(3, 378);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(279, 72);
            this.button0.TabIndex = 10;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.OnButtonNumberClick);
            // 
            // buttonEqual
            // 
            this.buttonEqual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEqual.Location = new System.Drawing.Point(288, 378);
            this.buttonEqual.Name = "buttonEqual";
            this.buttonEqual.Size = new System.Drawing.Size(91, 72);
            this.buttonEqual.TabIndex = 11;
            this.buttonEqual.Text = "=";
            this.buttonEqual.UseVisualStyleBackColor = true;
            this.buttonEqual.Click += new System.EventHandler(this.OnButtonEqualClick);
            // 
            // buttonAddition
            // 
            this.buttonAddition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddition.Location = new System.Drawing.Point(288, 303);
            this.buttonAddition.Name = "buttonAddition";
            this.buttonAddition.Size = new System.Drawing.Size(91, 69);
            this.buttonAddition.TabIndex = 12;
            this.buttonAddition.Text = "+";
            this.buttonAddition.UseVisualStyleBackColor = true;
            this.buttonAddition.Click += new System.EventHandler(this.OnButtonOperationClick);
            // 
            // buttonSubtraction
            // 
            this.buttonSubtraction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSubtraction.Location = new System.Drawing.Point(288, 228);
            this.buttonSubtraction.Name = "buttonSubtraction";
            this.buttonSubtraction.Size = new System.Drawing.Size(91, 69);
            this.buttonSubtraction.TabIndex = 13;
            this.buttonSubtraction.Text = "-";
            this.buttonSubtraction.UseVisualStyleBackColor = true;
            this.buttonSubtraction.Click += new System.EventHandler(this.OnButtonOperationClick);
            // 
            // buttonMultiplication
            // 
            this.buttonMultiplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMultiplication.Location = new System.Drawing.Point(288, 153);
            this.buttonMultiplication.Name = "buttonMultiplication";
            this.buttonMultiplication.Size = new System.Drawing.Size(91, 69);
            this.buttonMultiplication.TabIndex = 14;
            this.buttonMultiplication.Text = "×";
            this.buttonMultiplication.UseVisualStyleBackColor = true;
            this.buttonMultiplication.Click += new System.EventHandler(this.OnButtonOperationClick);
            // 
            // buttonDivision
            // 
            this.buttonDivision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDivision.Location = new System.Drawing.Point(288, 78);
            this.buttonDivision.Name = "buttonDivision";
            this.buttonDivision.Size = new System.Drawing.Size(91, 69);
            this.buttonDivision.TabIndex = 15;
            this.buttonDivision.Text = "÷";
            this.buttonDivision.UseVisualStyleBackColor = true;
            this.buttonDivision.Click += new System.EventHandler(this.OnButtonOperationClick);
            // 
            // buttonSign
            // 
            this.buttonSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSign.Location = new System.Drawing.Point(193, 78);
            this.buttonSign.Name = "buttonSign";
            this.buttonSign.Size = new System.Drawing.Size(89, 69);
            this.buttonSign.TabIndex = 16;
            this.buttonSign.Text = "+/-";
            this.buttonSign.UseVisualStyleBackColor = true;
            this.buttonSign.Click += new System.EventHandler(this.OnButtonOperationClick);
            // 
            // buttonClear
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonClear, 2);
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClear.Location = new System.Drawing.Point(3, 78);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(184, 69);
            this.buttonClear.TabIndex = 17;
            this.buttonClear.Text = "C";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.OnButtonClearClick);
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 453);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CalculatorForm";
            this.Text = "Calculator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            MinimumSize = new Size(400, 450);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label display;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button buttonEqual;
        private System.Windows.Forms.Button buttonAddition;
        private System.Windows.Forms.Button buttonSubtraction;
        private System.Windows.Forms.Button buttonMultiplication;
        private System.Windows.Forms.Button buttonDivision;
        private System.Windows.Forms.Button buttonSign;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label historyDisplay;
    }
}

