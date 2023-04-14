namespace TicTacToe;

partial class GameForm
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
        this.tableLayoutPanel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.ColumnCount = 3;
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
        this.tableLayoutPanel1.Controls.Add(this.display, 0, 0);
        this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
        this.tableLayoutPanel1.Controls.Add(this.button2, 1, 1);
        this.tableLayoutPanel1.Controls.Add(this.button3, 2, 1);
        this.tableLayoutPanel1.Controls.Add(this.button4, 0, 2);
        this.tableLayoutPanel1.Controls.Add(this.button5, 1, 2);
        this.tableLayoutPanel1.Controls.Add(this.button6, 2, 2);
        this.tableLayoutPanel1.Controls.Add(this.button7, 0, 3);
        this.tableLayoutPanel1.Controls.Add(this.button8, 1, 3);
        this.tableLayoutPanel1.Controls.Add(this.button9, 2, 3);
        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 4;
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.76471F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.41176F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.41176F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.41176F));
        this.tableLayoutPanel1.Size = new System.Drawing.Size(382, 353);
        this.tableLayoutPanel1.TabIndex = 0;
        // 
        // display
        // 
        this.display.Anchor = System.Windows.Forms.AnchorStyles.Top;
        this.display.AutoSize = true;
        this.tableLayoutPanel1.SetColumnSpan(this.display, 3);
        // this.display.Dock = System.Windows.Forms.DockStyle.Fill;
        this.display.Location = new System.Drawing.Point(3, 0);
        this.display.Name = "display";
        this.display.Size = new System.Drawing.Size(376, 41);
        this.display.TabIndex = 0;
        // 
        // button1
        // 
        this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.button1.Location = new System.Drawing.Point(3, 44);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(121, 97);
        this.button1.TabIndex = 1;
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.OnButtonClick);
        // 
        // button2
        // 
        this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.button2.Location = new System.Drawing.Point(130, 44);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(121, 97);
        this.button2.TabIndex = 2;
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.OnButtonClick);
        // 
        // button3
        // 
        this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.button3.Location = new System.Drawing.Point(257, 44);
        this.button3.Name = "button3";
        this.button3.Size = new System.Drawing.Size(122, 97);
        this.button3.TabIndex = 3;
        this.button3.UseVisualStyleBackColor = true;
        this.button3.Click += new System.EventHandler(this.OnButtonClick);
        // 
        // button4
        // 
        this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
        this.button4.Location = new System.Drawing.Point(3, 147);
        this.button4.Name = "button4";
        this.button4.Size = new System.Drawing.Size(121, 97);
        this.button4.TabIndex = 4;
        this.button4.UseVisualStyleBackColor = true;
        this.button4.Click += new System.EventHandler(this.OnButtonClick);
        // 
        // button5
        // 
        this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
        this.button5.Location = new System.Drawing.Point(130, 147);
        this.button5.Name = "button5";
        this.button5.Size = new System.Drawing.Size(121, 97);
        this.button5.TabIndex = 5;
        this.button5.UseVisualStyleBackColor = true;
        this.button5.Click += new System.EventHandler(this.OnButtonClick);
        // 
        // button6
        // 
        this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
        this.button6.Location = new System.Drawing.Point(257, 147);
        this.button6.Name = "button6";
        this.button6.Size = new System.Drawing.Size(122, 97);
        this.button6.TabIndex = 6;
        this.button6.UseVisualStyleBackColor = true;
        this.button6.Click += new System.EventHandler(this.OnButtonClick);
        // 
        // button7
        // 
        this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
        this.button7.Location = new System.Drawing.Point(3, 250);
        this.button7.Name = "button7";
        this.button7.Size = new System.Drawing.Size(121, 100);
        this.button7.TabIndex = 7;
        this.button7.UseVisualStyleBackColor = true;
        this.button7.Click += new System.EventHandler(this.OnButtonClick);
        // 
        // button8
        // 
        this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
        this.button8.Location = new System.Drawing.Point(130, 250);
        this.button8.Name = "button8";
        this.button8.Size = new System.Drawing.Size(121, 100);
        this.button8.TabIndex = 8;
        this.button8.UseVisualStyleBackColor = true;
        this.button8.Click += new System.EventHandler(this.OnButtonClick);
        // 
        // button9
        // 
        this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
        this.button9.Location = new System.Drawing.Point(257, 250);
        this.button9.Name = "button9";
        this.button9.Size = new System.Drawing.Size(122, 100);
        this.button9.TabIndex = 9;
        this.button9.UseVisualStyleBackColor = true;
        this.button9.Click += new System.EventHandler(this.OnButtonClick);
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(382, 353);
        this.Controls.Add(this.tableLayoutPanel1);
        this.Name = "TicTacToe";
        this.Text = "TicTacToe";
        this.tableLayoutPanel1.ResumeLayout(false);
        this.tableLayoutPanel1.PerformLayout();
        this.ResumeLayout(false);

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
}

