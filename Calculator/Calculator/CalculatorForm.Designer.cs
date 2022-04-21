namespace Calculator
{
    partial class CalculatorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonNegation = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.buttonDecimalPoint = new System.Windows.Forms.Button();
            this.buttonEquals = new System.Windows.Forms.Button();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonMultiplication = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonBackspace = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSqrt = new System.Windows.Forms.Button();
            this.buttonDivision = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox1, 4);
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(320, 50);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#EBEBEB");
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00061F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
            this.tableLayoutPanel1.Controls.Add(this.buttonNegation, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button0, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonDecimalPoint, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonEquals, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonPlus, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.button9, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.button7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button8, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button5, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button6, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonMinus, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonMultiplication, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonBackspace, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonClear, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSqrt, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonDivision, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Bradley Hand ITC", 32.07273F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(326, 471);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // buttonNegation
            // 
            this.buttonNegation.BackColor = System.Drawing.Color.White;
            this.buttonNegation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNegation.FlatAppearance.BorderSize = 0;
            this.buttonNegation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNegation.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonNegation.Location = new System.Drawing.Point(2, 392);
            this.buttonNegation.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNegation.Name = "buttonNegation";
            this.buttonNegation.Size = new System.Drawing.Size(77, 77);
            this.buttonNegation.TabIndex = 16;
            this.buttonNegation.Text = "+/-";
            this.buttonNegation.UseCompatibleTextRendering = true;
            this.buttonNegation.UseVisualStyleBackColor = false;
            // 
            // button0
            // 
            this.button0.BackColor = System.Drawing.Color.White;
            this.button0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button0.FlatAppearance.BorderSize = 0;
            this.button0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button0.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button0.Location = new System.Drawing.Point(83, 392);
            this.button0.Margin = new System.Windows.Forms.Padding(2);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(77, 77);
            this.button0.TabIndex = 10;
            this.button0.Text = "0";
            this.button0.UseCompatibleTextRendering = true;
            this.button0.UseVisualStyleBackColor = false;
            // 
            // buttonDecimalPoint
            // 
            this.buttonDecimalPoint.BackColor = System.Drawing.Color.White;
            this.buttonDecimalPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDecimalPoint.FlatAppearance.BorderSize = 0;
            this.buttonDecimalPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDecimalPoint.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDecimalPoint.Location = new System.Drawing.Point(164, 392);
            this.buttonDecimalPoint.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDecimalPoint.Name = "buttonDecimalPoint";
            this.buttonDecimalPoint.Size = new System.Drawing.Size(77, 77);
            this.buttonDecimalPoint.TabIndex = 11;
            this.buttonDecimalPoint.Text = ",";
            this.buttonDecimalPoint.UseCompatibleTextRendering = true;
            this.buttonDecimalPoint.UseVisualStyleBackColor = false;
            // 
            // buttonEquals
            // 
            this.buttonEquals.BackColor = System.Drawing.Color.White;
            this.buttonEquals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEquals.FlatAppearance.BorderSize = 0;
            this.buttonEquals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEquals.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEquals.Location = new System.Drawing.Point(245, 392);
            this.buttonEquals.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEquals.Name = "buttonEquals";
            this.buttonEquals.Size = new System.Drawing.Size(79, 77);
            this.buttonEquals.TabIndex = 15;
            this.buttonEquals.Text = "=";
            this.buttonEquals.UseCompatibleTextRendering = true;
            this.buttonEquals.UseVisualStyleBackColor = false;
            // 
            // buttonPlus
            // 
            this.buttonPlus.BackColor = System.Drawing.Color.White;
            this.buttonPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPlus.FlatAppearance.BorderSize = 0;
            this.buttonPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlus.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPlus.Location = new System.Drawing.Point(245, 314);
            this.buttonPlus.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(79, 74);
            this.buttonPlus.TabIndex = 14;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseCompatibleTextRendering = true;
            this.buttonPlus.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.White;
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button9.Location = new System.Drawing.Point(164, 314);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(77, 74);
            this.button9.TabIndex = 9;
            this.button9.Text = "9";
            this.button9.UseCompatibleTextRendering = true;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button7.Location = new System.Drawing.Point(2, 314);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(77, 74);
            this.button7.TabIndex = 7;
            this.button7.Text = "7";
            this.button7.UseCompatibleTextRendering = true;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button8.Location = new System.Drawing.Point(83, 314);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(77, 74);
            this.button8.TabIndex = 8;
            this.button8.Text = "8";
            this.button8.UseCompatibleTextRendering = true;
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(2, 236);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(77, 74);
            this.button4.TabIndex = 4;
            this.button4.Text = "4";
            this.button4.UseCompatibleTextRendering = true;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button5.Location = new System.Drawing.Point(83, 236);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(77, 74);
            this.button5.TabIndex = 5;
            this.button5.Text = "5";
            this.button5.UseCompatibleTextRendering = true;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button6.Location = new System.Drawing.Point(164, 236);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(77, 74);
            this.button6.TabIndex = 6;
            this.button6.Text = "6";
            this.button6.UseCompatibleTextRendering = true;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // buttonMinus
            // 
            this.buttonMinus.BackColor = System.Drawing.Color.White;
            this.buttonMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMinus.FlatAppearance.BorderSize = 0;
            this.buttonMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinus.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonMinus.Location = new System.Drawing.Point(245, 236);
            this.buttonMinus.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(79, 74);
            this.buttonMinus.TabIndex = 13;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseCompatibleTextRendering = true;
            this.buttonMinus.UseVisualStyleBackColor = false;
            // 
            // buttonMultiplication
            // 
            this.buttonMultiplication.BackColor = System.Drawing.Color.White;
            this.buttonMultiplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMultiplication.FlatAppearance.BorderSize = 0;
            this.buttonMultiplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMultiplication.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonMultiplication.Location = new System.Drawing.Point(245, 158);
            this.buttonMultiplication.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMultiplication.Name = "buttonMultiplication";
            this.buttonMultiplication.Size = new System.Drawing.Size(79, 74);
            this.buttonMultiplication.TabIndex = 12;
            this.buttonMultiplication.Text = "✕";
            this.buttonMultiplication.UseCompatibleTextRendering = true;
            this.buttonMultiplication.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(164, 158);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 74);
            this.button3.TabIndex = 3;
            this.button3.Text = "3";
            this.button3.UseCompatibleTextRendering = true;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(83, 158);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 74);
            this.button2.TabIndex = 2;
            this.button2.Text = "2";
            this.button2.UseCompatibleTextRendering = true;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(2, 158);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 74);
            this.button1.TabIndex = 1;
            this.button1.Text = "1";
            this.button1.UseCompatibleTextRendering = true;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // buttonBackspace
            // 
            this.buttonBackspace.BackColor = System.Drawing.Color.White;
            this.buttonBackspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBackspace.FlatAppearance.BorderSize = 0;
            this.buttonBackspace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackspace.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonBackspace.Location = new System.Drawing.Point(2, 80);
            this.buttonBackspace.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBackspace.Name = "buttonBackspace";
            this.buttonBackspace.Size = new System.Drawing.Size(77, 74);
            this.buttonBackspace.TabIndex = 20;
            this.buttonBackspace.Text = "⌫";
            this.buttonBackspace.UseCompatibleTextRendering = true;
            this.buttonBackspace.UseVisualStyleBackColor = false;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.White;
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClear.FlatAppearance.BorderSize = 0;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonClear.Location = new System.Drawing.Point(83, 80);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(77, 74);
            this.buttonClear.TabIndex = 19;
            this.buttonClear.Text = "C";
            this.buttonClear.UseCompatibleTextRendering = true;
            this.buttonClear.UseVisualStyleBackColor = false;
            // 
            // buttonSqrt
            // 
            this.buttonSqrt.BackColor = System.Drawing.Color.White;
            this.buttonSqrt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSqrt.FlatAppearance.BorderSize = 0;
            this.buttonSqrt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSqrt.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSqrt.Location = new System.Drawing.Point(164, 80);
            this.buttonSqrt.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSqrt.Name = "buttonSqrt";
            this.buttonSqrt.Size = new System.Drawing.Size(77, 74);
            this.buttonSqrt.TabIndex = 18;
            this.buttonSqrt.Text = "√";
            this.buttonSqrt.UseCompatibleTextRendering = true;
            this.buttonSqrt.UseVisualStyleBackColor = false;
            // 
            // buttonDivision
            // 
            this.buttonDivision.BackColor = System.Drawing.Color.White;
            this.buttonDivision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDivision.FlatAppearance.BorderSize = 0;
            this.buttonDivision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDivision.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDivision.Location = new System.Drawing.Point(245, 80);
            this.buttonDivision.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDivision.Name = "buttonDivision";
            this.buttonDivision.Size = new System.Drawing.Size(79, 74);
            this.buttonDivision.TabIndex = 17;
            this.buttonDivision.Text = "÷";
            this.buttonDivision.UseCompatibleTextRendering = true;
            this.buttonDivision.UseVisualStyleBackColor = false;
            //
            // binding buttons
            //
            this.button1.Click += new System.EventHandler(this.OperandClick);
            this.button2.Click += new System.EventHandler(this.OperandClick);
            this.button3.Click += new System.EventHandler(this.OperandClick);
            this.button4.Click += new System.EventHandler(this.OperandClick);
            this.button5.Click += new System.EventHandler(this.OperandClick);
            this.button6.Click += new System.EventHandler(this.OperandClick);
            this.button7.Click += new System.EventHandler(this.OperandClick);
            this.button8.Click += new System.EventHandler(this.OperandClick);
            this.button9.Click += new System.EventHandler(this.OperandClick);
            this.button0.Click += new System.EventHandler(this.OperandClick);
            this.buttonPlus.Click += new System.EventHandler(this.OperatorClick);
            this.buttonMinus.Click += new System.EventHandler(this.OperatorClick);
            this.buttonDivision.Click += new System.EventHandler(this.OperatorClick);
            this.buttonMultiplication.Click += new System.EventHandler(this.OperatorClick);
            this.buttonEquals.Click += new System.EventHandler(this.OperatorClick);
            this.buttonSqrt.Click += new System.EventHandler(this.OperatorClick);
            this.buttonNegation.Click += new System.EventHandler(this.ButtonNegationClick);
            this.buttonDecimalPoint.Click += new System.EventHandler(this.ButtonDecimalPointClick);

            this.button1.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.button2.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.button3.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.button4.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.button5.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.button6.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.button7.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.button8.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.button9.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.button0.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.buttonPlus.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.buttonMinus.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.buttonDivision.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.buttonMultiplication.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.buttonEquals.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.buttonSqrt.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.buttonNegation.Click += new System.EventHandler(this.PrintSomethingOnClick);
            this.buttonDecimalPoint.Click += new System.EventHandler(this.PrintSomethingOnClick);

            this.buttonBackspace.Click += new System.EventHandler(this.OnBackspaceButtonClick);
            this.buttonBackspace.Click += new System.EventHandler(this.ButtonBackspaceClick);
            this.buttonClear.Click += new System.EventHandler(this.OnClearButtonClick);
            this.buttonClear.Click += new System.EventHandler(this.ButtonClearClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(326, 471);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(330, 490);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void PrintSomethingOnClick(object sender, EventArgs e)
        {
            textBox1.Text = this.firstOperand + (this.currentOperator == '\0' ? "" : currentOperator) + secondOperand;
        }

        private void OnClearButtonClick(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void OnBackspaceButtonClick(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        #endregion

        private TextBox textBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private Button button4;
        private Button button3;
        private Button button6;
        private Button button2;
        private Button button5;
        private Button button8;
        private Button button7;
        private Button button9;
        private Button button0;
        private Button buttonMultiplication;
        private Button buttonDecimalPoint;
        private Button buttonNegation;
        private Button buttonEquals;
        private Button buttonPlus;
        private Button buttonMinus;
        private Button buttonDivision;
        private Button buttonSqrt;
        private Button buttonClear;
        private Button buttonBackspace;
    }
}