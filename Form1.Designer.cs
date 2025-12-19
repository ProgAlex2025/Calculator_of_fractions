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
            label1 = new Label();
            Input = new TextBox();
            Output = new Label();
            Solution = new Button();
            Help = new Button();
            SuspendLayout();
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
            // Output
            // 
            resources.ApplyResources(Output, "Output");
            Output.Name = "Output";
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
            // Menu
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            Controls.Add(Help);
            Controls.Add(Solution);
            Controls.Add(Output);
            Controls.Add(Input);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Menu";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox Input;
        private Label Output;
        private Button Solution;
        private Button Help;
    }
}
