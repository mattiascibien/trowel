namespace Sledge.Shell.Forms
{
    partial class ExceptionWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FrameworkVersion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OperatingSystem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SledgeVersion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.FullError = new System.Windows.Forms.TextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oops! Something went horribly wrong.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = ".NET Version";
            // 
            // FrameworkVersion
            // 
            this.FrameworkVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FrameworkVersion.Location = new System.Drawing.Point(217, 38);
            this.FrameworkVersion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FrameworkVersion.Name = "FrameworkVersion";
            this.FrameworkVersion.ReadOnly = true;
            this.FrameworkVersion.Size = new System.Drawing.Size(335, 23);
            this.FrameworkVersion.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Operating System";
            // 
            // OperatingSystem
            // 
            this.OperatingSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OperatingSystem.Location = new System.Drawing.Point(217, 68);
            this.OperatingSystem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OperatingSystem.Name = "OperatingSystem";
            this.OperatingSystem.ReadOnly = true;
            this.OperatingSystem.Size = new System.Drawing.Size(335, 23);
            this.OperatingSystem.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 102);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Sledge Version";
            // 
            // SledgeVersion
            // 
            this.SledgeVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SledgeVersion.Location = new System.Drawing.Point(217, 98);
            this.SledgeVersion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SledgeVersion.Name = "SledgeVersion";
            this.SledgeVersion.ReadOnly = true;
            this.SledgeVersion.Size = new System.Drawing.Size(335, 23);
            this.SledgeVersion.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 132);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Full Error Message";
            // 
            // FullError
            // 
            this.FullError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FullError.Location = new System.Drawing.Point(217, 132);
            this.FullError.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FullError.Multiline = true;
            this.FullError.Name = "FullError";
            this.FullError.ReadOnly = true;
            this.FullError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FullError.Size = new System.Drawing.Size(335, 201);
            this.FullError.TabIndex = 3;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CloseButton.Location = new System.Drawing.Point(370, 339);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(182, 48);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButtonClicked);
            // 
            // ExceptionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 399);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.FullError);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SledgeVersion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.OperatingSystem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FrameworkVersion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "This isn\'t good!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FrameworkVersion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox OperatingSystem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SledgeVersion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox FullError;
        private System.Windows.Forms.Button CloseButton;
    }
}