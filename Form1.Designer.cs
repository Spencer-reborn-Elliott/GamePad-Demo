namespace GamePad_Demo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.OutputArea = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PollForInputBtn = new System.Windows.Forms.Button();
            this.OutputArea2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // OutputArea
            // 
            this.OutputArea.Location = new System.Drawing.Point(21, 105);
            this.OutputArea.Name = "OutputArea";
            this.OutputArea.Size = new System.Drawing.Size(438, 454);
            this.OutputArea.TabIndex = 0;
            this.OutputArea.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(730, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "This is a sandbox for directInput using SharpDX. It should detect the first conne" +
    "cted controller and detect input. It was designed with a dance mat in mind.";
            // 
            // PollForInputBtn
            // 
            this.PollForInputBtn.Location = new System.Drawing.Point(21, 52);
            this.PollForInputBtn.Name = "PollForInputBtn";
            this.PollForInputBtn.Size = new System.Drawing.Size(187, 47);
            this.PollForInputBtn.TabIndex = 3;
            this.PollForInputBtn.Text = "Detect Controller and Poll for Input";
            this.PollForInputBtn.UseVisualStyleBackColor = true;
            this.PollForInputBtn.Click += new System.EventHandler(this.PollForInputBtn_Click);
            // 
            // OutputArea2
            // 
            this.OutputArea2.Location = new System.Drawing.Point(484, 105);
            this.OutputArea2.Name = "OutputArea2";
            this.OutputArea2.Size = new System.Drawing.Size(616, 454);
            this.OutputArea2.TabIndex = 4;
            this.OutputArea2.Text = "";
            this.OutputArea2.TextChanged += new System.EventHandler(this.OutputArea2_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 582);
            this.Controls.Add(this.OutputArea2);
            this.Controls.Add(this.PollForInputBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputArea);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Spencer\'s Dancemat/Joystick Detection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox OutputArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PollForInputBtn;
        private System.Windows.Forms.RichTextBox OutputArea2;
    }
}

