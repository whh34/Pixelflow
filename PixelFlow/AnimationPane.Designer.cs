namespace PixelFlow
{
    partial class AnimationPane
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimationPane));
            this.playPause = new System.Windows.Forms.Button();
            this.stepBackward = new System.Windows.Forms.Button();
            this.stepForward = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.frameRateText = new System.Windows.Forms.TextBox();
            this.animationToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.animationPreview1 = new PixelFlow.AnimationPreview();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // playPause
            // 
            this.playPause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playPause.BackgroundImage")));
            this.playPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playPause.Location = new System.Drawing.Point(243, 350);
            this.playPause.Name = "playPause";
            this.playPause.Size = new System.Drawing.Size(40, 40);
            this.playPause.TabIndex = 1;
            this.animationToolTips.SetToolTip(this.playPause, "Play or Pause the animation");
            this.playPause.UseVisualStyleBackColor = true;
            // 
            // stepBackward
            // 
            this.stepBackward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stepBackward.BackgroundImage")));
            this.stepBackward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stepBackward.Location = new System.Drawing.Point(113, 350);
            this.stepBackward.Name = "stepBackward";
            this.stepBackward.Size = new System.Drawing.Size(40, 40);
            this.stepBackward.TabIndex = 2;
            this.animationToolTips.SetToolTip(this.stepBackward, "Step backward one frame");
            this.stepBackward.UseVisualStyleBackColor = true;
            // 
            // stepForward
            // 
            this.stepForward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stepForward.BackgroundImage")));
            this.stepForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stepForward.Location = new System.Drawing.Point(373, 350);
            this.stepForward.Name = "stepForward";
            this.stepForward.Size = new System.Drawing.Size(40, 40);
            this.stepForward.TabIndex = 3;
            this.animationToolTips.SetToolTip(this.stepForward, "Step forward one frame");
            this.stepForward.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(357, 18);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown1.TabIndex = 4;
            // 
            // frameRateText
            // 
            this.frameRateText.Location = new System.Drawing.Point(286, 18);
            this.frameRateText.Name = "frameRateText";
            this.frameRateText.Size = new System.Drawing.Size(65, 20);
            this.frameRateText.TabIndex = 5;
            this.frameRateText.Text = "Frame Rate";
            // 
            // animationPreview1
            // 
            this.animationPreview1.BackColor = System.Drawing.SystemColors.Window;
            this.animationPreview1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.animationPreview1.Location = new System.Drawing.Point(113, 44);
            this.animationPreview1.Name = "animationPreview1";
            this.animationPreview1.Size = new System.Drawing.Size(300, 300);
            this.animationPreview1.TabIndex = 0;
            // 
            // AnimationPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.frameRateText);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.stepForward);
            this.Controls.Add(this.stepBackward);
            this.Controls.Add(this.playPause);
            this.Controls.Add(this.animationPreview1);
            this.Name = "AnimationPane";
            this.Size = new System.Drawing.Size(433, 600);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AnimationPreview animationPreview1;
        private System.Windows.Forms.Button playPause;
        private System.Windows.Forms.Button stepBackward;
        private System.Windows.Forms.Button stepForward;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox frameRateText;
        private System.Windows.Forms.ToolTip animationToolTips;
    }
}
