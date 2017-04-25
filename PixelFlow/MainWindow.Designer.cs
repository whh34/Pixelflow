namespace PixelFlow
{
    partial class MainWindow
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
            this.animationPane1 = new PixelFlow.AnimationPane();
            this.toolbarPane1 = new PixelFlow.ToolbarPane();
            this.drawPane1 = new PixelFlow.DrawPane();
            this.optionsBar1 = new PixelFlow.OptionsBar();
            this.SuspendLayout();
            // 
            // animationPane1
            // 
            this.animationPane1.BackColor = System.Drawing.SystemColors.GrayText;
            this.animationPane1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.animationPane1.Dock = System.Windows.Forms.DockStyle.Right;
            this.animationPane1.Location = new System.Drawing.Point(1128, 100);
            this.animationPane1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.animationPane1.Name = "animationPane1";
            this.animationPane1.Size = new System.Drawing.Size(648, 948);
            this.animationPane1.TabIndex = 6;
            // 
            // toolbarPane1
            // 
            this.toolbarPane1.BackColor = System.Drawing.SystemColors.GrayText;
            this.toolbarPane1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolbarPane1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolbarPane1.Location = new System.Drawing.Point(0, 100);
            this.toolbarPane1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.toolbarPane1.Name = "toolbarPane1";
            this.toolbarPane1.Size = new System.Drawing.Size(167, 948);
            this.toolbarPane1.TabIndex = 4;
            // 
            // drawPane1
            // 
            this.drawPane1.BackColor = System.Drawing.SystemColors.Window;
            this.drawPane1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawPane1.Location = new System.Drawing.Point(198, 114);
            this.drawPane1.Margin = new System.Windows.Forms.Padding(0);
            this.drawPane1.Name = "drawPane1";
            this.drawPane1.Size = new System.Drawing.Size(479, 491);
            this.drawPane1.TabIndex = 3;
            // 
            // optionsBar1
            // 
            this.optionsBar1.BackColor = System.Drawing.SystemColors.GrayText;
            this.optionsBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.optionsBar1.Location = new System.Drawing.Point(0, 0);
            this.optionsBar1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.optionsBar1.Name = "optionsBar1";
            this.optionsBar1.Size = new System.Drawing.Size(1776, 100);
            this.optionsBar1.TabIndex = 5;
            this.optionsBar1.Load += new System.EventHandler(this.optionsBar1_Load);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1776, 1048);
            this.Controls.Add(this.animationPane1);
            this.Controls.Add(this.toolbarPane1);
            this.Controls.Add(this.drawPane1);
            this.Controls.Add(this.optionsBar1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1789, 1078);
            this.Name = "MainWindow";
            this.Text = "PixelFlow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private DrawPane drawPane1;
        private ToolbarPane toolbarPane1;
        private OptionsBar optionsBar1;
        private AnimationPane animationPane1;
    }
}

