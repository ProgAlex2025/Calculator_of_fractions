namespace Calculator_of_simple_fraction
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            Denumerator = new TextBox();
            label1 = new Label();
            Input = new TextBox();
            Numerator = new Label();
            Solution = new Button();
            Help = new Button();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            OutDenumerator = new Label();
            Output = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // Denumerator
            // 
            resources.ApplyResources(Denumerator, "Denumerator");
            Denumerator.Name = "Denumerator";
            Denumerator.TextChanged += textBox1_TextChanged_1;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // Input
            // 
            resources.ApplyResources(Input, "Input");
            Input.Name = "Input";
            Input.TextChanged += textBox1_TextChanged;
            // 
            // Numerator
            // 
            resources.ApplyResources(Numerator, "Numerator");
            Numerator.Name = "Numerator";
            // 
            // Solution
            // 
            Solution.BackColor = Color.SpringGreen;
            resources.ApplyResources(Solution, "Solution");
            Solution.Name = "Solution";
            Solution.UseVisualStyleBackColor = false;
            Solution.Click += Solution_Click;
            // 
            // Help
            // 
            Help.BackColor = Color.FromArgb(255, 128, 128);
            resources.ApplyResources(Help, "Help");
            Help.Name = "Help";
            Help.UseVisualStyleBackColor = false;
            Help.Click += Help_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // radioButton2
            // 
            resources.ApplyResources(radioButton2, "radioButton2");
            radioButton2.Name = "radioButton2";
            radioButton2.TabStop = true;
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            resources.ApplyResources(radioButton1, "radioButton1");
            radioButton1.Name = "radioButton1";
            radioButton1.TabStop = true;
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // OutDenumerator
            // 
            resources.ApplyResources(OutDenumerator, "OutDenumerator");
            OutDenumerator.Name = "OutDenumerator";
            // 
            // Output
            // 
            resources.ApplyResources(Output, "Output");
            Output.Name = "Output";
            Output.Click += label2_Click;
            // 
            // Menu
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            Controls.Add(Output);
            Controls.Add(OutDenumerator);
            Controls.Add(groupBox1);
            Controls.Add(Denumerator);
            Controls.Add(Help);
            Controls.Add(Solution);
            Controls.Add(Numerator);
            Controls.Add(Input);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Menu";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox Input;
        private Label Numerator;
        private Button Solution;
        private Button Help;
        private TextBox Denumerator;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label OutDenumerator;
        private Label Output;
    }
}
